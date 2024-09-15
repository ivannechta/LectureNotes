using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneNote
{
    internal static class ColorPalette
    {
        public static Color Axes() 
        {
            return Color.FromArgb(255, 0, 0, 0);
        }
        public static Color Line()
        {
            return Color.FromArgb(255, 0, 0, 255);
        }
        public static Color Arrow()
        {
            return Color.FromArgb(255, 180, 0, 50);
        }
        public static Color Ellipse()
        {
            return Color.FromArgb(255, 50, 50, 150);
        }
        public static Color Text()
        {
            return Color.FromArgb(255, 0, 0, 0);
        }
        public static Color Picture()
        {
            return Color.FromArgb(255, 0, 255, 255);
        }
        public static Color TextBG()
        {
            return SystemColors.Control;
        }
        public static Color Selection()
        {
            return Color.FromArgb(255, 255, 0, 255);
        }
        public static Color BackGround()
        {
            return SystemColors.Control;
        }
    }
}
