using System;
using System.Drawing;

namespace WinFormsGame.Models
{
    public abstract class CollectibleItem
    {
        public PointF Position { get; set; }
        public bool IsCollected { get; set; }
        public abstract int Value { get; }
        public abstract Color Color { get; }
        public abstract string Type { get; }
        public const int Size = 20;

        public RectangleF Bounds => new RectangleF(
            Position.X - Size / 2,
            Position.Y - Size / 2,
            Size,
            Size
        );
    }

    public class Coin : CollectibleItem
    {
        public override int Value => 1;
        public override Color Color => Color.Gold;
        public override string Type => "Coin";
    }

    public class Crystal : CollectibleItem
    {
        public override int Value => 5;
        public override Color Color => Color.Cyan;
        public override string Type => "Crystal";
    }

    public static class CollectibleFactory
    {
        private static Random random = new Random();

        public static CollectibleItem CreateRandom(PointF position, float crystalChance = 0.18f)
        {
            if (random.NextDouble() < crystalChance)
                return new Crystal { Position = position };

            return new Coin { Position = position };
        }
    }
}