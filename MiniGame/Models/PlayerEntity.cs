using System;
using System.Collections.Generic;
using System.Drawing;

namespace WinFormsGame.Models
{
    public class PlayerEntity
    {
        public string Name { get; set; } = "Hero";
        public int Balance { get; set; } = 0;
        public PointF Position { get; set; }
        public PointF TargetPosition { get; set; }
        public float Speed { get; set; } = 5f;
        public int AttackPower { get; set; } = 5;
        public int MaxHealth { get; set; } = 20;
        public int Health { get; set; } = 20;
        public DateTime LastAttackTimeUtc { get; set; } = DateTime.MinValue;
        public DateTime HitFlashUntilUtc { get; set; } = DateTime.MinValue;
        public Color HitFlashColor { get; set; } = Color.Empty;
        public int CurrentSkinId { get; set; } = 0;
        public List<int> UnlockedSkins { get; set; } = new List<int> { 0 };

        public const int PlayerSize = 40;

        public bool IsMoving => CalculateDistance(Position, TargetPosition) > 1f;
        public bool IsHitFlashActive => DateTime.UtcNow <= HitFlashUntilUtc;

        private float CalculateDistance(PointF p1, PointF p2)
        {
            return (float)Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }

        public void UpdatePosition(bool isBoosting, float baseSpeed)
        {
            if (!IsMoving) return;

            float currentSpeed = isBoosting ? baseSpeed * 2.0f : baseSpeed;
            float dx = TargetPosition.X - Position.X;
            float dy = TargetPosition.Y - Position.Y;
            float distance = CalculateDistance(Position, TargetPosition);

            if (distance <= currentSpeed)
            {
                Position = TargetPosition;
            }
            else
            {
                Position = new PointF(
                    Position.X + (dx / distance) * currentSpeed,
                    Position.Y + (dy / distance) * currentSpeed
                );
            }
        }
    }
}
