using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        public override void Draw(View v,bool isSelected, bool isAxes)
        {
            Graphics canvas = context.CreateGraphics();

            Pen pen;
            if (isSelected)
            {
                pen = new Pen(ColorPalette.Selection());
            }
            else
            {
                if (isAxes)
                { 
                    pen = new Pen(ColorPalette.Axes());
                }
                else
                {
                    pen = new Pen(ColorPalette.Line());
                }
            }

            canvas.DrawLine(pen, v.ElementCoord2PixelX(x1), v.ElementCoord2PixelY(y1), 
                                 v.ElementCoord2PixelX(x2), v.ElementCoord2PixelY(y2));
        }
        public override void Move(View v, int _x,int _y)
        {
            float tmpX = v.PixelX2ElementCoord(_x);
            float tmpY = v.PixelY2ElementCoord(_y);
            Graphics canvas = context.CreateGraphics();
            Pen pen = new Pen(ColorPalette.BackGround());
            canvas.DrawLine(pen, v.ElementCoord2PixelX(x1), v.ElementCoord2PixelY(y1), 
                                v.ElementCoord2PixelX(x2), v.ElementCoord2PixelY(y2));

            pen = new Pen(ColorPalette.Line());
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
        public override void StopDraw(Form1 _form, View _v)
        {
            int a, b;
            a = _v.ElementCoord2PixelX(x1);
            b = _v.ElementCoord2PixelY(y1);
        }
        public override void Save(FileStream _fs) 
        {
            _fs.Write(BitConverter.GetBytes(x1), 0, sizeof(float));
            _fs.Write(BitConverter.GetBytes(y1), 0, sizeof(float));
            _fs.Write(BitConverter.GetBytes(x2), 0, sizeof(float));
            _fs.Write(BitConverter.GetBytes(y2), 0, sizeof(float));
        }
        public override void Load(FileStream _fs)
        {
            byte[] fileData = new byte[sizeof(float)];
            _fs.Read(fileData, 0, sizeof(float));
            x1 = BitConverter.ToSingle(fileData, 0);
            _fs.Read(fileData, 0, sizeof(float));
            y1 = BitConverter.ToSingle(fileData, 0);
            _fs.Read(fileData, 0, sizeof(float));
            x2 = BitConverter.ToSingle(fileData, 0);
            _fs.Read(fileData, 0, sizeof(float));
            y2 = BitConverter.ToSingle(fileData, 0);
        }
    }
}
