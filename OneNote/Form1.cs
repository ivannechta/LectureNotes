using OneNote.Elements;
using System;
using System.Drawing;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;

namespace OneNote
{
    public partial class Form1 : Form
    {
        private static View view;

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
            switch (fsm.GetState())
            {
                case FSM_STATES.FSM_STATE_IDLE:
                    coordMouseDown.X = e.X; coordMouseDown.Y = e.Y;
                    fsm.SetState(FSM_STATES.FSM_STATE_CANVAS_MOVE);
                    if (view.TrySelectElement(e.X, e.Y))
                    {
                        fsm.SetState(FSM_STATES.FSM_STATE_IDLE);
                    }
                    break;
                case FSM_STATES.FSM_STATE_ELEMENT_READY_DRAW:
                    ShowStatus("" + e.X + "- " + e.Y);
                    view.element.StartDraw(view, e.X, e.Y);
                    fsm.SetState(FSM_STATES.FSM_STATE_ELEMENT_DRAW);
                    break;

                default: break;
            };
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (fsm.GetState())
            {
                case FSM_STATES.FSM_STATE_IDLE:
                    //throw new Exception("Imposible State chain");
                case FSM_STATES.FSM_STATE_CANVAS_MOVE:
                    fsm.SetState(FSM_STATES.FSM_STATE_IDLE);
                    ShowStatus(fsm.GetName());
                    break;
                case FSM_STATES.FSM_STATE_ELEMENT_DRAW:
                    view.element.StopDraw(this,view);
                    view.allElements.Add(view.element);
                    fsm.SetState(FSM_STATES.FSM_STATE_IDLE);
                    ShowStatus(fsm.GetName());
                    break;
                default: break;
            };
            view.Draw();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            switch (fsm.GetState())
            {
                case FSM_STATES.FSM_STATE_CANVAS_MOVE:
                    view.MoveCanvas(e.X - coordMouseDown.X, e.Y - coordMouseDown.Y);
                    coordMouseDown.X = e.X;
                    coordMouseDown.Y = e.Y;
                    break;
                case FSM_STATES.FSM_STATE_ELEMENT_DRAW:
                    view.element.Move(view,e.X, e.Y);
                    break;

                default:
                    break;
            };

        }
        private void ShowStatus(String _message)
        {
            this.Status.Text = _message;
        }
        private void Form1_Activated(object sender, EventArgs e)
        {
            view.Draw();
        }
        private void линияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fsm.SetState(FSM_STATES.FSM_STATE_IDLE);
            fsm.SetState(FSM_STATES.FSM_STATE_ELEMENT_READY_DRAW);
            ShowStatus(fsm.GetName());            
            view.element = new ElLine(ELEMENT_TYPES.ELEMENT_TYPE_LINE,this);
        }       

        private void текстовоеПолеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fsm.SetState(FSM_STATES.FSM_STATE_IDLE);
            fsm.SetState(FSM_STATES.FSM_STATE_ELEMENT_READY_DRAW);
            ShowStatus(fsm.GetName());
            view.element = new ElText(ELEMENT_TYPES.ELEMENT_TYPE_TEXT, this,view);
        }
    }
}
