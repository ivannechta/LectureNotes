using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneNote.Elements
{
    internal class ElLine: Element
    {
        public float x2, y2;
        public ElLine(ELEMENT_TYPES _t,Form1 _context):base(_t,_context)
        {}

        public override void Draw(View v)
        {
            Graphics canvas = context.CreateGraphics();
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            canvas.DrawLine(pen, v.ElementCoord2PixelX(x1), v.ElementCoord2PixelY(y1), 
                                 v.ElementCoord2PixelX(x2), v.ElementCoord2PixelY(y2));
        }

        public override void Move(View v, int _x,int _y)
        {
            float tmpX = v.PixelX2ElementCoord(_x);
            float tmpY = v.PixelY2ElementCoord(_y);
            Graphics canvas = context.CreateGraphics();
            Pen pen = new Pen(SystemColors.Control);
            canvas.DrawLine(pen, v.ElementCoord2PixelX(x1), v.ElementCoord2PixelY(y1), 
                                v.ElementCoord2PixelX(x2), v.ElementCoord2PixelY(y2));

            pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            canvas.DrawLine(pen, v.ElementCoord2PixelX(x1), v.ElementCoord2PixelY(y1),
                                    v.ElementCoord2PixelX(tmpX), v.ElementCoord2PixelY(tmpY));
            x2 = tmpX;
            y2 = tmpY;
        }

        public override void StartDraw(View v, int _x,int _y)
        {
            x1 = x2 = v.PixelX2ElementCoord(_x);
            y1 = y2 = v.PixelY2ElementCoord(_y);
        }
    }
}
