using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneNote
{
    struct FPoint 
    {
        public float X;
        public float Y;
    };
    internal class View
    {
        private Form1 form;
        float Zoom; //масштаб приближения
        Point CoordZero; //где будет на форме координатная сетка
        FPoint OffsetCenter; //где будет находится центр экрана (с точки зрения координат элементов)        
        public View (Form1 _f)
        {
            form = _f;
            Init();
        }
        private int MouseCoord2PixelX(int _x) //x- mouse coord position, return coord on Form
        { 
            return _x - 5 - 3 - form.Left;
        }
        private int MouseCoord2PixelY(int _y)//y- mouse coord position, return coord on Form
        {
            return _y - 20 - 10 - form.Top;
        }

        private int ElementCoord2PixelX(float _x) //перевод кооддинат элементов в координаты на форме.
        {
            int sizeX = form.Width / 2;
            return (int)(sizeX + 1.0f * sizeX * Zoom * (_x - OffsetCenter.X));
        }
        private int ElementCoord2PixelY(float _y) //перевод кооддинат элементов в координаты на форме.
        {
            int sizeY = form.Height / 2;
            return (int)(sizeY - (1.0f * sizeY * Zoom * (_y - OffsetCenter.Y)));
        }
        public void Draw()
        {
            form.Refresh();            
            OffsetCenter.X = +0.25f;
            OffsetCenter.Y = +0.3f;

            DrawDecartNet();

            float x1, y1;
            int a, b,c,d;
            x1 = 0.2f;
            y1 = 0.2f;
            a = ElementCoord2PixelX(x1);
            b = ElementCoord2PixelY(y1);
            c = ElementCoord2PixelX(x1 + 0.1f);
            d = ElementCoord2PixelY(y1 + 0.1f);
            

            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            Graphics g = form.CreateGraphics();

            g.DrawLine(pen, a, b, c, d);
        }


        private void Init() 
        {
            CoordZero = new Point(form.Width / 2,form.Height/2);
            Zoom = 1.0f;
        }

        public void ScaleZoom() { Zoom *= 1.05f; Draw(); }
        public void ScaleDistance() { Zoom /= 1.05f; Draw(); }
        public void DrawDecartNet() 
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            Graphics g = form.CreateGraphics();
            //abscissa
            g.DrawLine(pen, 0, CoordZero.Y, form.Width, CoordZero.Y);
            //ordinate
            g.DrawLine(pen, CoordZero.X, 0, CoordZero.X, form.Height);            
        }
    }
}
