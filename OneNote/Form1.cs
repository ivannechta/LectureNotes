using System;
using System.Drawing;
using System.Windows.Forms;

namespace OneNote
{
    public partial class Form1 : Form
    {
        private View view;
        private FSM fsm=new FSM();
        Point coordMouseDown=new Point();
        public Form1()
        {
            InitializeComponent();
            view = new View(this);
            ShowStatus(fsm.GetName());
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

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            coordMouseDown.X = e.X; coordMouseDown.Y = e.Y;
            switch (fsm.GetState())
            {
                case FSM_STATES.FSM_STATE_IDLE:
                    fsm.SetState(FSM_STATES.FSM_STATE_CANVAS_MOVE);
                    ShowStatus(fsm.GetName());
                    break;

                default: break;
            };
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (fsm.GetState())
            {
                case FSM_STATES.FSM_STATE_IDLE:
                    throw new Exception("Imposible State chain");
                case FSM_STATES.FSM_STATE_CANVAS_MOVE:
                    fsm.SetState(FSM_STATES.FSM_STATE_IDLE);
                    ShowStatus(fsm.GetName());
                    break;
                default: break;
            };
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            switch (fsm.GetState())
            {
                case FSM_STATES.FSM_STATE_CANVAS_MOVE:
                    view.MoveCanvas(e.X - coordMouseDown.X, e.Y - coordMouseDown.Y);
                    break;
                default: break;
            };
            coordMouseDown.X = e.X;
            coordMouseDown.Y = e.Y;
        }
        private void ShowStatus(String _message)
        {
            this.Status.Text = _message;
        } 
    }
}
