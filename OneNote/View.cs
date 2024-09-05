using OneNote.Elements;
using System;
using System.Collections;
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
        public Element element = null;
        public List<Element> allElements=new List<Element>();

        public View (Form1 _f)
        {
            form = _f;
            Init();
            AddDecartNet();
        }
        private int MouseCoord2PixelX(int _x)   //x- mouse coord position, return coord on Form
        { 
            return _x - 5 - 3 - form.Left;
        }
        private int MouseCoord2PixelY(int _y)   //y- mouse coord position, return coord on Form
        {
            return _y - 20 - 10 - form.Top;
        }

        public int ElementCoord2PixelX(float _x) //перевод кооддинат элементов в координаты на форме.
        {
            int sizeX = form.Width / 2;
            return (int)(sizeX + 1.0f * sizeX * Zoom * (_x - OffsetCenter.X));
        }
        public int ElementCoord2PixelY(float _y) //перевод кооддинат элементов в координаты на форме.
        {
            int sizeY = form.Height / 2;
            return (int)(sizeY - (1.0f * sizeY * Zoom * (_y - OffsetCenter.Y)));
        }
        public float PixelX2ElementCoord(int _x) //перевод координаты на форме в кооддинаты элементов.
        {
            int sizeX = form.Width / 2;
            return 1.0f * (_x - sizeX) / sizeX / Zoom + OffsetCenter.X;
        }
        public float PixelY2ElementCoord(int _y) //перевод координаты на форме в кооддинаты элементов.
        {
            int sizeY = form.Height / 2;
            return -1.0f * (_y - sizeY) / sizeY / Zoom + OffsetCenter.Y;
        }
        public void Draw()
        {
            form.Refresh();
            UpdateDecartNet();
            foreach (Element el in allElements)
            {
                el.Draw(this);
            }
        }
        private void Init() 
        {
            CoordZero = new Point(form.Width / 2, form.Height / 2);
            Zoom = 1.0f;
        }
        public void ScaleZoom() { Zoom *= 1.05f; Draw(); }
        public void ScaleDistance() { Zoom /= 1.05f; Draw(); }
        public void AddDecartNet()
        {
            ElLine AxeX, AxeY;
            AxeX = new ElLine(ELEMENT_TYPES.ELEMENT_TYPE_LINE, form);
            AxeY = new ElLine(ELEMENT_TYPES.ELEMENT_TYPE_LINE, form);
            allElements.Add(AxeX);
            allElements.Add(AxeY);
        }
        public void UpdateDecartNet()
        {
            allElements[0].x1 = -1.0f/Zoom+OffsetCenter.X;
            (allElements[0] as ElLine).x2 = 1.0f / Zoom + OffsetCenter.X;
            allElements[1].y1 = -1.0f / Zoom + OffsetCenter.Y; ;
            (allElements[1]as ElLine).y2 = 1.0f / Zoom+OffsetCenter.Y;
        }
        public void MoveCanvas(int _dx,int _dy) 
        {
            OffsetCenter.X -= 4.0f*(1.0f/Zoom) * 0.5f * _dx / form.Width;
            OffsetCenter.Y += 4.0f*(1.0f/Zoom) * 0.5f * _dy / form.Height;
            Draw();
        }
    }
}
