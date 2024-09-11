using OneNote.Elements;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
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
        public  Form1 form;
        public float Zoom; //масштаб приближения
        public FPoint OffsetCenter; //где будет находится центр экрана (с точки зрения координат элементов)
        public Element element = null;
        public List<Element> allElements=new List<Element>();
        public Element selectedElement = null;
        public bool flagStartMoveing = false;

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

            foreach (Element el in allElements.Take(2))
            {
                el.Draw(this, selectedElement == el, true);
            }
            foreach (Element el in allElements.Skip(2))
            {
                el.Draw(this,selectedElement==el, false);
            }
        }
        private void Init() 
        {
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
        private float Distance(float _x0, float _y0,float _x1,float _y1,float _x2,float _y2)
        {
            float a = Math.Abs((_y2 - _y1) * _x0 - (_x2 - _x1) * _y0 + _x2 * _y1 - _y2 * _x1);
            float b = (float)Math.Sqrt((_y2 - _y1) * (_y2 - _y1) + (_x2 - _x1) * (_x2 - _x1));

            float d1 = (float)Math.Sqrt((_x1 - _x0) * (_x1 - _x0) + (_y1 - _y0) * (_y1 - _y0));
            float d2 = (float)Math.Sqrt((_x2 - _x0) * (_x2 - _x0) + (_y2 - _y0) * (_y2 - _y0));
            float d = (float)Math.Sqrt((_x2 - _x1) * (_x2 - _x1) + (_y2 - _y1) * (_y2 - _y1));

            if ((d > d1) && (d > d2)) // is perp on segment?
            {
                return a / b;
            }
            else
            {
                return (d1 < d2) ? d1 : d2;
            }
        }
        public bool TrySelectElement(int _x, int _y)
        {
            float a, b,d;
            a = PixelX2ElementCoord(_x);
            b = PixelY2ElementCoord(_y);
            
            foreach (Element el in allElements.Skip(2)) //пропустить оси
            {
                if (el.elementType == ELEMENT_TYPES.ELEMENT_TYPE_LINE)
                {
                    d = Distance(a, b, el.x1, el.y1, (el as ElLine).x2, (el as ElLine).y2);
                    if (d < 0.01f / Zoom)
                    {
                        ElementWasSelected(el);
                        return true;
                    }
                }
            }
            ElementWasDeselected();
            return false;
        }
        public void ElementWasSelected(Element _el)
        {
            if (selectedElement == _el) { return; } //already selected
            ElementWasDeselected();

            selectedElement = _el;
            form.DeleteElementMenuItem.Enabled = true;
            if ((_el.elementType == ELEMENT_TYPES.ELEMENT_TYPE_TEXT) ||
                (_el.elementType == ELEMENT_TYPES.ELEMENT_TYPE_PICTURE)) 
            {
                form.MoveElementStripMenuItem.Enabled = true;
            }
        }
        public void ElementWasDeselected()
        {
            selectedElement = null;
            form.DeleteElementMenuItem.Enabled = false;
            form.MoveElementStripMenuItem.Enabled = false;
            form.ShowStatus(form.fsm.GetName());
        }
        public void Load(String _fileName)
        {
            byte[] fileData = null;
            int type;
            Element el = null;
            allElements.Clear();
            AddDecartNet();

            using (FileStream fs = File.OpenRead(_fileName))
            {
                using (BinaryReader binaryReader = new BinaryReader(fs))
                {
                    while (fs.Position != fs.Length) {
                        fileData = binaryReader.ReadBytes(IntPtr.Size);
                        type= BitConverter.ToInt32(fileData, 0);
                        switch ((ELEMENT_TYPES)type) 
                        {
                            case ELEMENT_TYPES.ELEMENT_TYPE_LINE:
                                el = new ElLine(ELEMENT_TYPES.ELEMENT_TYPE_LINE, form);
                            break;
                            case ELEMENT_TYPES.ELEMENT_TYPE_TEXT:
                                el = new ElText(ELEMENT_TYPES.ELEMENT_TYPE_TEXT, form, this);
                                break;
                            case ELEMENT_TYPES.ELEMENT_TYPE_PICTURE:
                                el = new ElImage(ELEMENT_TYPES.ELEMENT_TYPE_PICTURE, form, this);
                                break;
                            default:
                                
                                break;
                        }
                        el.Load(fs);
                        allElements.Add(el);
                        Draw();
                    }
                }
            } 
        }
        public void Save(String _fileName)
        {
            try
            {
                using (FileStream fs = File.OpenWrite(_fileName))
                {
                    using (BinaryWriter binaryWriter = new BinaryWriter(fs))
                    {
                        foreach (Element el in allElements.Skip(2))
                        {
                            fs.Write(BitConverter.GetBytes((int)el.elementType), 0, 4); // Type
                            el.Save(fs);
                        }
                    }
                    fs.Close();
                }
            }
            catch (Exception e) {
                form.ShowStatus("Не смог сохранить в файл");
            }
        }
        public void NewProject()
        {
            foreach (Element el in allElements.Skip(2))
            {
                if (el.elementType == ELEMENT_TYPES.ELEMENT_TYPE_TEXT)
                {
                    (el as ElText).TextBox.Dispose();
                }
                if (el.elementType == ELEMENT_TYPES.ELEMENT_TYPE_PICTURE)
                {
                    (el as ElImage).pictureBox.Dispose();
                }

            }
            allElements.Clear();
            AddDecartNet();
            Draw();
            Zoom = 1;
            OffsetCenter.X = OffsetCenter.Y = 0;
        }
    }
}
