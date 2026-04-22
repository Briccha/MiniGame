using System.Drawing;

namespace WinFormsGame.Utilities
{
    public static class ColorHelper
    {
        public static Color Blend(Color first, Color second, double amount)
        {
            var clamped = System.Math.Max(0.0, System.Math.Min(1.0, amount));
            var inverse = 1.0 - clamped;
            return Color.FromArgb(
                (int)(first.R * inverse + second.R * clamped),
                (int)(first.G * inverse + second.G * clamped),
                (int)(first.B * inverse + second.B * clamped));
        }

        public static Color GetHitFlashColor(Color baseColor, Color backgroundColor)
        {
            var preferredContrast = GetPreferredContrastColor(baseColor, backgroundColor);
            var softened = Blend(preferredContrast, baseColor, 0.35);

            if (Contrast(softened, backgroundColor) >= 3.0)
            {
                return softened;
            }

            return preferredContrast;
        }

        public static Color GetPreferredContrastColor(Color baseColor, Color backgroundColor)
        {
            var whiteScore = Contrast(Color.White, backgroundColor) + Contrast(Color.White, baseColor);
            var blackScore = Contrast(Color.Black, backgroundColor) + Contrast(Color.Black, baseColor);
            return whiteScore >= blackScore ? Color.White : Color.Black;
        }

        private static double Contrast(Color c1, Color c2)
        {
            double l1 = RelativeLuminance(c1);
            double l2 = RelativeLuminance(c2);
            var lighter = l1 > l2 ? l1 : l2;
            var darker = l1 > l2 ? l2 : l1;
            return (lighter + 0.05) / (darker + 0.05);
        }

        private static double RelativeLuminance(Color color)
        {
            double r = Channel(color.R / 255.0);
            double g = Channel(color.G / 255.0);
            double b = Channel(color.B / 255.0);
            return 0.2126 * r + 0.7152 * g + 0.0722 * b;
        }

        private static double Channel(double value)
        {
            return value <= 0.03928 ? value / 12.92 : System.Math.Pow((value + 0.055) / 1.055, 2.4);
        }
    }
}
