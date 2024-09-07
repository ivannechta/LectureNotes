using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OneNote.Elements
{
    internal class ElText:Element
    {
        public float x2, y2; 
        public RichTextBox TextBox;
        private bool FlagTextBoxMoveing = false;
        private Point OldCursorPosition = new Point();
        private readonly View view;

        public ElText(ELEMENT_TYPES _t, Form1 _context,View _v) : base(_t, _context)
        {
            view = _v;
        }
        private void DrawRect(Graphics _c,Pen _p, int _x1,int _y1, int _x2,int _y2)
        {
            _c.DrawLine(_p, _x1, _y1, _x1, _y2);
            _c.DrawLine(_p, _x2, _y1, _x2, _y2);
            _c.DrawLine(_p, _x1, _y1, _x2, _y1);
            _c.DrawLine(_p, _x1, _y2, _x2, _y2);
        }
        public override void Draw(View v, bool isSelected, bool isAxes)
        {
            float tmp;
            int a, b, c, d;
            a = v.ElementCoord2PixelX(x1);
            b = v.ElementCoord2PixelY(y1);
            c = v.ElementCoord2PixelX(x2);
            d = v.ElementCoord2PixelY(y2);

            if (a > c) { tmp = x1; x1 = x2; x2 = tmp; }
            if (b > d) { tmp = y1; y1 = y2; y2 = tmp; }

            if (isSelected) 
            {
                Graphics canvas = context.CreateGraphics();
                Pen pen = new Pen(ColorPalette.Selection());
                DrawRect(canvas, pen, a - 20, b - 20, c + 20, d + 20);
            }           

            TextBox.Location = new System.Drawing.Point(a, b);
            TextBox.Size = new System.Drawing.Size(c - a, d - b);
        }
        public override void Move(View v, int _x, int _y)
        {
            float tmpX = v.PixelX2ElementCoord(_x);
            float tmpY = v.PixelY2ElementCoord(_y);
            Graphics canvas = context.CreateGraphics();
            Pen pen = new Pen(ColorPalette.BackGround());
            DrawRect(canvas, pen, v.ElementCoord2PixelX(x1), v.ElementCoord2PixelY(y1),
                                v.ElementCoord2PixelX(x2), v.ElementCoord2PixelY(y2));

            pen = new Pen(ColorPalette.Text());
            DrawRect(canvas, pen, v.ElementCoord2PixelX(x1), v.ElementCoord2PixelY(y1),
                                    v.ElementCoord2PixelX(tmpX), v.ElementCoord2PixelY(tmpY));
            x2 = tmpX;
            y2 = tmpY;
        }
        public override void StartDraw(View v, int _x, int _y)
        {
            x1 = x2 = v.PixelX2ElementCoord(_x);
            y1 = y2 = v.PixelY2ElementCoord(_y);
        }
        public override void StopDraw(Form1 _form, View _v)
        {            
            float tmp;
            int a, b, c, d;
            a = _v.ElementCoord2PixelX(x1);
            b = _v.ElementCoord2PixelY(y1);
            c = _v.ElementCoord2PixelX(x2);
            d = _v.ElementCoord2PixelY(y2);

            if (a > c) { tmp = x1; x1 = x2; x2 = tmp; }
            if (b > d) { tmp = y1; y1 = y2; y2 = tmp; }

            TextBox = new RichTextBox
            {
                Location = new System.Drawing.Point(_v.ElementCoord2PixelX(x1), _v.ElementCoord2PixelY(y1)),
                Size = new System.Drawing.Size(c - a, d - b),
                BackColor = ColorPalette.TextBG(),
                BorderStyle = BorderStyle.FixedSingle,
            };
            TextBox.MouseDown += TextBox_MouseDown;
            TextBox.MouseUp += TextBox_MouseUp;
            TextBox.MouseMove += TextBox_MouseMove;
            _form.Controls.Add(TextBox);
        }
        private void TextBox_MouseDown(object sender, MouseEventArgs e)
        {
            FlagTextBoxMoveing = true;
            OldCursorPosition.X = e.X;
            OldCursorPosition.Y = e.Y;     
        }
        private void TextBox_MouseUp(object sender, MouseEventArgs e)
        {
            FlagTextBoxMoveing = false;
            view.selectedElement = this;
            context.DeleteElementMenuItem.Enabled = true;
            view.Draw();
        }
        private void TextBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (FlagTextBoxMoveing)
            {
                TextBox.Left += e.X - OldCursorPosition.X;
                TextBox.Top += e.Y - OldCursorPosition.Y;
                foreach (Element el in view.allElements.Skip(2))
                {
                    if (this == el)
                    {
                        float dx = (el as ElText).x2 - el.x1;
                        float dy = (el as ElText).y2 - el.y1;
                        
                        el.x1 = view.PixelX2ElementCoord(TextBox.Left);
                        el.y1 = view.PixelY2ElementCoord(TextBox.Top);
                        (el as ElText).x2 = dx + el.x1;
                        (el as ElText).y2 = dy + el.y1;
                    }
                }
            }
        }
        public override void Save(FileStream _fs)
        {
            _fs.Write(BitConverter.GetBytes(x1), 0, sizeof(float));
            _fs.Write(BitConverter.GetBytes(y1), 0, sizeof(float));
            _fs.Write(BitConverter.GetBytes(x2), 0, sizeof(float));
            _fs.Write(BitConverter.GetBytes(y2), 0, sizeof(float));
            _fs.Write(BitConverter.GetBytes(TextBox.Rtf.Length), 0, IntPtr.Size);
            _fs.Write(Encoding.ASCII.GetBytes(TextBox.Rtf), 0, TextBox.Rtf.Length);
        }
        public override void Load(FileStream _fs)
        {
            byte[] fileData = new byte[sizeof(float)];
            int size = 0;
            _fs.Read(fileData, 0, sizeof(float));
            x1 = BitConverter.ToSingle(fileData, 0);
            _fs.Read(fileData, 0, sizeof(float));
            y1 = BitConverter.ToSingle(fileData, 0);
            _fs.Read(fileData, 0, sizeof(float));
            x2 = BitConverter.ToSingle(fileData, 0);
            _fs.Read(fileData, 0, sizeof(float));
            y2 = BitConverter.ToSingle(fileData, 0);

            fileData = new byte[IntPtr.Size];
            _fs.Read(fileData, 0, IntPtr.Size);
            size = BitConverter.ToInt32(fileData, 0);

            fileData = new byte[size];
            _fs.Read(fileData, 0, size);
            StopDraw(context,view);
            TextBox.Rtf = Encoding.Default.GetString(fileData);
        }
    }
}
