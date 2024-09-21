using OneNote;
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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Image = System.Drawing.Image;

namespace OneNote.Elements
{
    internal class ElImage:Element
    {            
        public float x2, y2;
        public PictureBox pictureBox;
        private Point OldCursorPosition = new Point();
        private readonly View view;

        public ElImage(ELEMENT_TYPES _t, Form1 _context, View _v) : base(_t, _context)
        {
            view = _v;
        }
        private void DrawRect(Graphics _c, Pen _p, int _x1, int _y1, int _x2, int _y2)
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

            pictureBox.Location = new System.Drawing.Point(a, b);
            pictureBox.Size = new System.Drawing.Size(c - a, d - b);

            if (pictureBox.Image==null)
            {
                Graphics canvas = context.CreateGraphics();
                Pen pen = new Pen(ColorPalette.Picture());
                DrawRect(canvas, pen, a - 5, b - 5, c + 5, d + 5);
            }
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

            pictureBox = new PictureBox
            {
                Location = new System.Drawing.Point(_v.ElementCoord2PixelX(x1), _v.ElementCoord2PixelY(y1)),
                Size = new System.Drawing.Size(c - a, d - b),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            
            pictureBox.MouseDown += pictureBox_MouseDown;
            pictureBox.MouseDoubleClick += pictureBox_DoubleClick;
            pictureBox.MouseUp += pictureBox_MouseUp;
            pictureBox.MouseMove += pictureBox_MouseMove;

            _form.Controls.Add(pictureBox);
        }        
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            OldCursorPosition.X = e.X;
            OldCursorPosition.Y = e.Y;
            view.flagStartMoveing = true;
        }
        private void pictureBox_DoubleClick(object sender, MouseEventArgs e)
        {
            if (context.openFileImage.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Load(context.openFileImage.FileName);
            }
            else 
            {
                pictureBox = null;
            }
        }
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            view.flagStartMoveing = false;
            view.ElementWasSelected(this);
            view.Draw();
        }
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (
                (context.fsm.State == FSM_STATES.FSM_STATE_ELEMENT_MOVE) &&
                (this == view.selectedElement) &&
                (view.flagStartMoveing))
            {
                pictureBox.Left += e.X - OldCursorPosition.X;
                pictureBox.Top += e.Y - OldCursorPosition.Y;
                foreach (Element el in view.allElements.Skip(2))
                {
                    if (this == el)
                    {
                        float dx = (el as ElImage).x2 - el.x1;
                        float dy = (el as ElImage).y2 - el.y1;

                        el.x1 = view.PixelX2ElementCoord(pictureBox.Left);
                        el.y1 = view.PixelY2ElementCoord(pictureBox.Top);
                        (el as ElImage).x2 = dx + el.x1;
                        (el as ElImage).y2 = dy + el.y1;
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

            System.Drawing.Image img = pictureBox.Image;
            byte[] buff;
            ImageConverter imgCon = new ImageConverter();
            if (img == null)
            {
                buff = new byte[4];
                buff[0] = buff[1] = buff[2] = buff[3] = 0;
                _fs.Write(buff, 0, sizeof(int));
            }
            else
            {
                buff = (byte[])imgCon.ConvertTo(img, typeof(byte[]));
                Int32 tmp = buff.Length;
                _fs.Write(BitConverter.GetBytes(tmp), 0, sizeof(int));
                _fs.Write(buff, 0, tmp);
            }
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
            MemoryStream ms = new MemoryStream(fileData, 0, size);
            StopDraw(context, view);
            if (size != 0)
            { 
                pictureBox.Image = Image.FromStream(ms, true);
            }
        }
    }
}

