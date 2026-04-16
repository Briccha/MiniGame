using System;
using System.Collections.Generic;
using System.Drawing;
using WinFormsGame.Utilities;

namespace WinFormsGame.Models
{
    public class GameModel
    {
        private const double AttackCooldownSeconds = 1.0;
        private const double HitFlashDurationSeconds = 0.20;
        private readonly Random random = new Random();

        public PlayerEntity Player { get; set; }
        public List<CollectibleItem> Items { get; set; }
        public List<MonsterEntity> Monsters { get; set; }
        public Rectangle MapBounds { get; set; }

        public event EventHandler PlayerMoved;
        public event EventHandler ItemsChanged;
        public event EventHandler ScoreChanged;
        public event EventHandler MonstersChanged;
        public event EventHandler PlayerStateChanged;

        private GameSettings settings;

        public GameModel(Rectangle mapBounds, GameSettings settings = null)
        {
            MapBounds = mapBounds;
            this.settings = settings ?? new GameSettings();
            Player = new PlayerEntity();
            Items = new List<CollectibleItem>();
            Monsters = new List<MonsterEntity>();
            InitializeGame();
        }

        private void InitializeGame()
        {
            Player.Position = new PointF(MapBounds.Width / 2f, MapBounds.Height / 2f);
            Player.TargetPosition = Player.Position;
            Player.Speed = settings.BaseSpeed;
            Player.Health = Player.MaxHealth;

            Items.Clear();
            for (int i = 0; i < settings.MinItemsOnMap; i++)
            {
                SpawnRandomItem();
            }

            Monsters.Clear();
            MaintainMonsterPopulation();
        }

        public void SpawnRandomItem(PointF? fixedPosition = null)
        {
            PointF position = fixedPosition ?? new PointF(
                random.Next(20, Math.Max(21, MapBounds.Width - 20)),
                random.Next(20, Math.Max(21, MapBounds.Height - 20)));

            var item = CollectibleFactory.CreateRandom(position, settings.CrystalDropChance);
            Items.Add(item);
            OnItemsChanged();
        }

        public void Update(bool isBoosting)
        {
            var oldPosition = Player.Position;
            Player.UpdatePosition(isBoosting, settings.BaseSpeed);

            UpdateMonsters();
            ResolveEntityCollisions();
            ResolveCombat();

            if (oldPosition != Player.Position)
            {
                CheckItemCollisions();
                OnPlayerMoved();
            }

            MaintainMonsterPopulation();

            if (settings.CurrentDifficultyConfig.PeacefulMode && Items.Count < settings.MinItemsOnMap)
            {
                SpawnRandomItem();
            }
        }

        private void UpdateMonsters()
        {
            foreach (var monster in Monsters)
            {
                var dx = Player.Position.X - monster.Position.X;
                var dy = Player.Position.Y - monster.Position.Y;
                var distance = (float)Math.Sqrt(dx * dx + dy * dy);

                if (distance <= monster.VisionRadius)
                {
                    monster.TargetPosition = Player.Position;
                }
                else if (Distance(monster.Position, monster.TargetPosition) <= 6f)
                {
                    monster.PickRandomTarget(MapBounds);
                }

                monster.MoveTowardTarget(MapBounds);
            }

            OnMonstersChanged();
        }

        private void ResolveCombat()
        {
            var now = DateTime.UtcNow;
            var playerRadius = PlayerEntity.PlayerSize / 2f;
            var monsterRadius = MonsterEntity.MonsterSize / 2f;

            for (int i = Monsters.Count - 1; i >= 0; i--)
            {
                var monster = Monsters[i];
                var dist = Distance(Player.Position, monster.Position);
                if (dist > playerRadius + monsterRadius)
                {
                    continue;
                }

                if ((now - Player.LastAttackTimeUtc).TotalSeconds >= AttackCooldownSeconds)
                {
                    monster.Health -= Player.AttackPower;
                    Player.LastAttackTimeUtc = now;
                    RegisterHitFx(Player, Color.DodgerBlue);
                    RegisterHitFx(monster, Color.IndianRed);
                    SoundEffectPlayer.PlayHitSound();
                }

                if (monster.Health > 0 && (now - monster.LastAttackTimeUtc).TotalSeconds >= AttackCooldownSeconds)
                {
                    Player.Health -= monster.AttackPower;
                    monster.LastAttackTimeUtc = now;
                    RegisterHitFx(Player, Color.DodgerBlue);
                    RegisterHitFx(monster, Color.IndianRed);
                    SoundEffectPlayer.PlayHitSound();
                    OnPlayerStateChanged();
                }

                if (monster.Health <= 0)
                {
                    Player.Health = Math.Min(Player.MaxHealth, Player.Health + monster.MaxHealth);
                    SpawnRandomItem(monster.Position);
                    Monsters.RemoveAt(i);
                    OnMonstersChanged();
                    OnPlayerStateChanged();
                }
            }

            if (Player.Health <= 0)
            {
                Player.Health = Player.MaxHealth;
                Player.Position = new PointF(MapBounds.Width / 2f, MapBounds.Height / 2f);
                Player.TargetPosition = Player.Position;
                OnPlayerStateChanged();
                OnPlayerMoved();
            }
        }

        private void CheckItemCollisions()
        {
            var playerBounds = new RectangleF(
                Player.Position.X - PlayerEntity.PlayerSize / 2,
                Player.Position.Y - PlayerEntity.PlayerSize / 2,
                PlayerEntity.PlayerSize,
                PlayerEntity.PlayerSize);

            for (int i = Items.Count - 1; i >= 0; i--)
            {
                if (!Items[i].IsCollected && playerBounds.IntersectsWith(Items[i].Bounds))
                {
                    Items[i].IsCollected = true;
                    Player.Balance += Items[i].Value;
                    Items.RemoveAt(i);
                    OnScoreChanged();
                    OnItemsChanged();
                }
            }

            while (Items.Count < settings.MinItemsOnMap)
            {
                SpawnRandomItem();
            }
        }

        private void MaintainMonsterPopulation()
        {
            var profile = settings.CurrentDifficultyConfig;

            if (profile.PeacefulMode)
            {
                if (Monsters.Count > 0)
                {
                    Monsters.Clear();
                    OnMonstersChanged();
                }
                return;
            }

            while (Monsters.Count < profile.MaxMonsters)
            {
                var monster = new MonsterEntity
                {
                    Position = RandomMapPoint(),
                    TargetPosition = RandomMapPoint(),
                    MaxHealth = profile.MonsterHealth,
                    Health = profile.MonsterHealth,
                    AttackPower = profile.MonsterDamage,
                    Speed = profile.MonsterSpeed,
                    VisionRadius = profile.MonsterVisionRadius
                };
                Monsters.Add(monster);
                OnMonstersChanged();
            }

            if (Monsters.Count > profile.MaxMonsters)
            {
                Monsters.RemoveRange(profile.MaxMonsters, Monsters.Count - profile.MaxMonsters);
                OnMonstersChanged();
            }
        }

        public void ApplySettings(GameSettings newSettings)
        {
            settings = newSettings;
            Player.Speed = settings.BaseSpeed;
            MaintainMonsterPopulation();
        }

        public void ApplyPlayerSettings(string name, int health, int damage, float speed)
        {
            Player.Name = name;
            Player.MaxHealth = Math.Max(1, health);
            Player.Health = Math.Min(Player.Health, Player.MaxHealth);
            Player.AttackPower = Math.Max(1, damage);
            Player.Speed = Math.Max(0.5f, speed);
            settings.BaseSpeed = Player.Speed;
            OnPlayerStateChanged();
        }

        public void SetPlayerTarget(PointF target)
        {
            float halfSize = PlayerEntity.PlayerSize / 2;
            target.X = Math.Max(halfSize, Math.Min(MapBounds.Width - halfSize, target.X));
            target.Y = Math.Max(halfSize, Math.Min(MapBounds.Height - halfSize, target.Y));
            Player.TargetPosition = target;
        }

        public void MovePlayerByVector(PointF vector)
        {
            PointF newTarget = new PointF(
                Player.TargetPosition.X + vector.X,
                Player.TargetPosition.Y + vector.Y);
            SetPlayerTarget(newTarget);
        }

        private PointF RandomMapPoint()
        {
            return new PointF(
                random.Next(20, Math.Max(21, MapBounds.Width - 20)),
                random.Next(20, Math.Max(21, MapBounds.Height - 20)));
        }

        private static float Distance(PointF p1, PointF p2)
        {
            var dx = p1.X - p2.X;
            var dy = p1.Y - p2.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        private void ResolveEntityCollisions()
        {
            ResolvePlayerMonsterOverlaps();
            ResolveMonsterMonsterOverlaps();
            OnMonstersChanged();
            OnPlayerMoved();
        }

        private void ResolvePlayerMonsterOverlaps()
        {
            var playerRadius = PlayerEntity.PlayerSize / 2f;
            var monsterRadius = MonsterEntity.MonsterSize / 2f;
            var minDistance = playerRadius + monsterRadius;

            foreach (var monster in Monsters)
            {
                var playerPosition = Player.Position;
                var monsterPosition = monster.Position;

                PushEntitiesApart(ref playerPosition, playerRadius, ref monsterPosition, monsterRadius, minDistance);

                Player.Position = playerPosition;
                Player.TargetPosition = playerPosition;
                monster.Position = monsterPosition;
            }
        }

        private void ResolveMonsterMonsterOverlaps()
        {
            var monsterRadius = MonsterEntity.MonsterSize / 2f;
            var minDistance = monsterRadius * 2f;

            for (int i = 0; i < Monsters.Count; i++)
            {
                for (int j = i + 1; j < Monsters.Count; j++)
                {
                    var first = Monsters[i];
                    var second = Monsters[j];

                    var firstPos = first.Position;
                    var secondPos = second.Position;
                    PushEntitiesApart(ref firstPos, monsterRadius, ref secondPos, monsterRadius, minDistance);
                    first.Position = firstPos;
                    second.Position = secondPos;
                }
            }
        }

        private void PushEntitiesApart(ref PointF first, float firstRadius, ref PointF second, float secondRadius, float minDistance)
        {
            var dx = second.X - first.X;
            var dy = second.Y - first.Y;
            var distance = (float)Math.Sqrt(dx * dx + dy * dy);

            if (distance <= 0.001f)
            {
                dx = (float)(random.NextDouble() - 0.5);
                dy = (float)(random.NextDouble() - 0.5);
                distance = (float)Math.Sqrt(dx * dx + dy * dy);
            }

            if (distance >= minDistance || distance <= 0.001f)
            {
                return;
            }

            var overlap = minDistance - distance;
            var nx = dx / distance;
            var ny = dy / distance;

            first = ClampByRadius(new PointF(first.X - nx * overlap / 2f, first.Y - ny * overlap / 2f), firstRadius);
            second = ClampByRadius(new PointF(second.X + nx * overlap / 2f, second.Y + ny * overlap / 2f), secondRadius);
        }

        private PointF ClampByRadius(PointF point, float radius)
        {
            point.X = Math.Max(radius, Math.Min(MapBounds.Width - radius, point.X));
            point.Y = Math.Max(radius, Math.Min(MapBounds.Height - radius, point.Y));
            return point;
        }

        private void RegisterHitFx(PlayerEntity player, Color baseColor)
        {
            player.HitFlashColor = ColorHelper.GetHitFlashColor(baseColor, Color.FromArgb(240, 240, 240));
            player.HitFlashUntilUtc = DateTime.UtcNow.AddSeconds(HitFlashDurationSeconds);
        }

        private void RegisterHitFx(MonsterEntity monster, Color baseColor)
        {
            monster.HitFlashColor = ColorHelper.GetHitFlashColor(baseColor, Color.FromArgb(240, 240, 240));
            monster.HitFlashUntilUtc = DateTime.UtcNow.AddSeconds(HitFlashDurationSeconds);
        }

        protected virtual void OnPlayerMoved() => PlayerMoved?.Invoke(this, EventArgs.Empty);
        protected virtual void OnItemsChanged() => ItemsChanged?.Invoke(this, EventArgs.Empty);
        protected virtual void OnScoreChanged() => ScoreChanged?.Invoke(this, EventArgs.Empty);
        protected virtual void OnMonstersChanged() => MonstersChanged?.Invoke(this, EventArgs.Empty);
        protected virtual void OnPlayerStateChanged() => PlayerStateChanged?.Invoke(this, EventArgs.Empty);
    }
}
