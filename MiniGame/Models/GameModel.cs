using System;
using System.Collections.Generic;
using System.Drawing;

namespace WinFormsGame.Models
{
    public class GameModel
    {
        public PlayerEntity Player { get; set; }
        public List<CollectibleItem> Items { get; set; }
        public Rectangle MapBounds { get; set; }
        public int Score { get; set; }

        public event EventHandler PlayerMoved;
        public event EventHandler ItemsChanged;
        public event EventHandler ScoreChanged;

        private Random random = new Random();

        private GameSettings settings;

        public GameModel(Rectangle mapBounds, GameSettings settings = null)
        {
            MapBounds = mapBounds;
            this.settings = settings ?? new GameSettings();
            Player = new PlayerEntity();
            Items = new List<CollectibleItem>();
            InitializeGame();
        }

        private void InitializeGame()
        {
            Player.Position = new PointF(MapBounds.Width / 2, MapBounds.Height / 2);
            Player.TargetPosition = Player.Position;
            Player.Speed = settings.BaseSpeed;

            for (int i = 0; i < settings.InitialItemCount; i++)
            {
                SpawnRandomItem();
            }
        }

        public void SpawnRandomItem()
        {
            PointF position = new PointF(
                random.Next(20, MapBounds.Width - 20),
                random.Next(20, MapBounds.Height - 20)
            );

            var item = CollectibleFactory.CreateRandom(position, settings.CoinSpawnChance);
            Items.Add(item);
            OnItemsChanged();
        }

        public void Update(bool isBoosting)
        {
            var oldPosition = Player.Position;
            Player.UpdatePosition(isBoosting, settings.BaseSpeed);

            if (oldPosition != Player.Position)
            {
                CheckItemCollisions();
                OnPlayerMoved();
            }
        }

        private void CheckItemCollisions()
        {
            var playerBounds = new RectangleF(
                Player.Position.X - PlayerEntity.PlayerSize / 2,
                Player.Position.Y - PlayerEntity.PlayerSize / 2,
                PlayerEntity.PlayerSize,
                PlayerEntity.PlayerSize
            );

            for (int i = Items.Count - 1; i >= 0; i--)
            {
                if (!Items[i].IsCollected &&
                    playerBounds.IntersectsWith(Items[i].Bounds))
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

        public void ApplySettings(GameSettings newSettings)
        {
            settings = newSettings;
            Player.Speed = settings.BaseSpeed;
        }



        public void SetPlayerTarget(PointF target)
        {
            // Ограничиваем цель границами карты с учетом размера персонажа
            float halfSize = PlayerEntity.PlayerSize / 2;
            target.X = Math.Max(halfSize, Math.Min(MapBounds.Width - halfSize, target.X));
            target.Y = Math.Max(halfSize, Math.Min(MapBounds.Height - halfSize, target.Y));
            Player.TargetPosition = target;
        }

        public void MovePlayerByVector(PointF vector)
        {
            PointF newTarget = new PointF(
                Player.TargetPosition.X + vector.X,
                Player.TargetPosition.Y + vector.Y
            );
            SetPlayerTarget(newTarget);
        }

        protected virtual void OnPlayerMoved() => PlayerMoved?.Invoke(this, EventArgs.Empty);
        protected virtual void OnItemsChanged() => ItemsChanged?.Invoke(this, EventArgs.Empty);
        protected virtual void OnScoreChanged() => ScoreChanged?.Invoke(this, EventArgs.Empty);
    }
}