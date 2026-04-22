using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WinFormsGame.Utilities
{
    public enum AppTheme
    {
        Light,
        Dark,
        System
    }

    public class ThemeManager
    {
        public struct ThemePalette
        {
            public Color BackColor;
            public Color ForeColor;
            public Color AccentColor;
            public Color SurfaceColor;
            public Color CanvasGridColor;
            public Color ContrastColor;
            public Color DamageFlashColor;
        }

        public static bool IsSystemDarkTheme()
        {
            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(
                    @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize"))
                {
                    var value = key?.GetValue("AppsUseLightTheme");
                    return value != null && (int)value == 0;
                }
            }
            catch
            {
                return false;
            }
        }

        public static void ApplyTheme(Control control, AppTheme theme)
        {
            var palette = GetPalette(theme);
            ApplyThemeToControl(control, palette.BackColor, palette.ForeColor, palette.AccentColor);
        }

        public static ThemePalette GetPalette(AppTheme theme)
        {
            bool useDark = theme == AppTheme.Dark ||
                           (theme == AppTheme.System && IsSystemDarkTheme());

            if (useDark)
            {
                return new ThemePalette
                {
                    BackColor = Color.FromArgb(24, 28, 34),
                    ForeColor = Color.FromArgb(239, 242, 246),
                    AccentColor = Color.FromArgb(56, 68, 82),
                    SurfaceColor = Color.FromArgb(31, 37, 45),
                    CanvasGridColor = Color.FromArgb(72, 82, 94),
                    ContrastColor = Color.FromArgb(255, 214, 102),
                    DamageFlashColor = Color.FromArgb(255, 164, 120)
                };
            }

            return new ThemePalette
            {
                BackColor = Color.FromArgb(242, 245, 250),
                ForeColor = Color.FromArgb(28, 31, 36),
                AccentColor = Color.FromArgb(214, 224, 238),
                SurfaceColor = Color.White,
                CanvasGridColor = Color.FromArgb(188, 202, 221),
                ContrastColor = Color.FromArgb(28, 90, 210),
                DamageFlashColor = Color.FromArgb(210, 74, 74)
            };
        }

        private static void ApplyThemeToControl(Control control, Color backColor,
            Color foreColor, Color accentColor)
        {
            control.BackColor = backColor;
            control.ForeColor = foreColor;

            foreach (Control child in control.Controls)
            {
                if (child is Button button)
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 1;
                    button.FlatAppearance.BorderColor = accentColor;
                    button.BackColor = accentColor;
                }
                else if (child is Panel || child is GroupBox)
                {
                    ApplyThemeToControl(child, backColor, foreColor, accentColor);
                }
                else
                {
                    child.BackColor = backColor;
                    child.ForeColor = foreColor;
                }
            }
        }
    }
}
