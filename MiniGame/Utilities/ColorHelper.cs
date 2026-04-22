using System.Drawing;

namespace WinFormsGame.Utilities
{
    public static class ColorHelper
    {
        public static Color GetThemeContrastColor(Color backgroundColor)
        {
            return Contrast(Color.White, backgroundColor) >= Contrast(Color.Black, backgroundColor)
                ? Color.White
                : Color.Black;
        }

        public static Color GetHitFlashColor(Color baseColor, Color backgroundColor)
        {
            var inverted = Color.FromArgb(255 - baseColor.R, 255 - baseColor.G, 255 - baseColor.B);
            var contrastWithBackground = Contrast(inverted, backgroundColor);
            var contrastWithBase = Contrast(inverted, baseColor);

            if (contrastWithBackground >= 3.0 && contrastWithBase >= 2.0)
            {
                return inverted;
            }

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
