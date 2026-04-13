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
            Color backColor, foreColor, accentColor;

            bool useDark = theme == AppTheme.Dark ||
                          (theme == AppTheme.System && IsSystemDarkTheme());

            if (useDark)
            {
                backColor = Color.FromArgb(32, 32, 32);
                foreColor = Color.White;
                accentColor = Color.FromArgb(64, 64, 64);
            }
            else
            {
                backColor = Color.WhiteSmoke;
                foreColor = Color.Black;
                accentColor = Color.LightGray;
            }

            ApplyThemeToControl(control, backColor, foreColor, accentColor);
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