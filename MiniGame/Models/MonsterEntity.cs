using System;
using System.Drawing;

namespace WinFormsGame.Models
{
    public class MonsterEntity
    {
        private static readonly Random Random = new Random();

        public const int MonsterSize = 34;

        public PointF Position { get; set; }
        public PointF TargetPosition { get; set; }
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public float Speed { get; set; }
        public float VisionRadius { get; set; }
        public DateTime LastAttackTimeUtc { get; set; } = DateTime.MinValue;
        public DateTime HitFlashUntilUtc { get; set; } = DateTime.MinValue;
        public Color HitFlashColor { get; set; } = Color.Empty;

        public bool IsAlive => Health > 0;
        public bool IsHitFlashActive => DateTime.UtcNow <= HitFlashUntilUtc;

        public RectangleF Bounds => new RectangleF(
            Position.X - MonsterSize / 2f,
            Position.Y - MonsterSize / 2f,
            MonsterSize,
            MonsterSize);

        public void MoveTowardTarget(Rectangle mapBounds)
        {
            var dx = TargetPosition.X - Position.X;
            var dy = TargetPosition.Y - Position.Y;
            var distance = (float)Math.Sqrt(dx * dx + dy * dy);

            if (distance <= 1f)
            {
                return;
            }

            var step = Math.Min(Speed, distance);
            var newPosition = new PointF(
                Position.X + (dx / distance) * step,
                Position.Y + (dy / distance) * step);

            Position = ClampToBounds(newPosition, mapBounds);
        }

        public void PickRandomTarget(Rectangle mapBounds)
        {
            TargetPosition = new PointF(
                Random.Next(MonsterSize, Math.Max(MonsterSize + 1, mapBounds.Width - MonsterSize)),
                Random.Next(MonsterSize, Math.Max(MonsterSize + 1, mapBounds.Height - MonsterSize)));
        }

        private static PointF ClampToBounds(PointF position, Rectangle mapBounds)
        {
            float halfSize = MonsterSize / 2f;
            position.X = Math.Max(halfSize, Math.Min(mapBounds.Width - halfSize, position.X));
            position.Y = Math.Max(halfSize, Math.Min(mapBounds.Height - halfSize, position.Y));
            return position;
        }
    }
}
