using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneNote
{
    public partial class Form1 : Form
    {
        private View view;
        public Form1()
        {
            InitializeComponent();
            view = new View(this);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Zoom);
        }

        private void Zoom(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0) //прокрутили вниз
            {
                view.ScaleDistance(); 
            }
            else //прокрутили вверх
            {
                view.ScaleZoom();
            }            
        }
    }
}
