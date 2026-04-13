using System.Drawing;
using System.Windows.Forms;

namespace WinFormsGame.Utilities
{
    public static class ScalingHelper
    {
        public static Rectangle CalculateCanvasBounds(Control parent, Control canvas)
        {
            int margin = 10;
            return new Rectangle(
                margin,
                margin,
                parent.ClientSize.Width - margin * 2,
                parent.ClientSize.Height - margin * 2 - 100 // место для панели управления
            );
        }
    }
}