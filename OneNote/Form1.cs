﻿using Microsoft.Win32;
using OneNote.Elements;
using System;
using System.Drawing;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OneNote
{
    public partial class Form1 : Form
    {
        private static View view;

        public FSM fsm=new FSM();
        Point coordMouseDown=new Point();

        public Form1()
        {
            InitializeComponent();
            view = new View(this);
            ShowStatus(fsm.GetName());
            this.MouseWheel += new MouseEventHandler(this.Zoom);
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                if (args[1].Substring(args[1].Length - 4) == ".lnt")
                {
                    view.Load(args[1]);
                }
            }
            RegisterExtension(args[0]);
        }
        void RegisterExtension(string _path) 
        {
            RegistryKey extension = Registry.ClassesRoot.OpenSubKey(".lnt", false);
            if (extension != null)
            {
                return;
            }
            try
            {
                RegistryKey registryKey = Registry.ClassesRoot.CreateSubKey(".lnt");
                registryKey.SetValue("", "LectureNotes");

                registryKey = Registry.ClassesRoot.CreateSubKey("LectureNotes");
                registryKey = Registry.ClassesRoot.CreateSubKey("LectureNotes\\DefaultIcon");
                registryKey.SetValue("", _path + ",0");

                registryKey = Registry.ClassesRoot.CreateSubKey("LectureNotes\\shell");
                registryKey = Registry.ClassesRoot.CreateSubKey("LectureNotes\\shell\\open");
                registryKey = Registry.ClassesRoot.CreateSubKey("LectureNotes\\shell\\open\\command");
                registryKey.SetValue("", _path + " \"%1\"");
            }
            catch(Exception)
            {
                MessageBox.Show("Запустите программу в режиме Администратора для регистрации файлового расширения", "Недостаточно прав", MessageBoxButtons.OK);
            }
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
            ShowStatus(fsm.GetName());
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (fsm.GetState())
            {
                case FSM_STATES.FSM_STATE_IDLE:
                case FSM_STATES.FSM_STATE_ELEMENT_MOVE:
                    coordMouseDown.X = e.X; coordMouseDown.Y = e.Y;
                    fsm.SetState(FSM_STATES.FSM_STATE_CANVAS_MOVE);
                    if (view.TrySelectElement(e.X, e.Y))
                    {
                        fsm.SetState(FSM_STATES.FSM_STATE_IDLE);
                    }
                    else 
                    {
                        ShowStatus(fsm.GetName());
                    }
                    break;
                case FSM_STATES.FSM_STATE_ELEMENT_READY_DRAW:
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
                    ShowCenterCoord();
                    break;
                case FSM_STATES.FSM_STATE_ELEMENT_DRAW:
                    view.element.Move(view,e.X, e.Y);
                    break;

                default:
                    break;
            };
        }
        public void ShowStatus(String _message)
        {
            this.Status.Text = _message;
            this.toolStripScale.Text = "" + view.Zoom;
            ShowCenterCoord();
        }
        public void ShowCenterCoord()
        {
            this.toolCoordCenter.Text = "" + view.OffsetCenter.X.ToString("0.0") + "; " + view.OffsetCenter.Y.ToString("0.0");
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
        private void DeleteElementMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Element el in view.allElements)
            {
                if (el.Equals(view.selectedElement))
                {
                    view.allElements.Remove(el);
                    if (el.elementType == ELEMENT_TYPES.ELEMENT_TYPE_TEXT)
                    {
                        this.Controls.Remove((el as ElText).TextBox);
                        (el as ElText).TextBox.Dispose();
                    }
                    if (el.elementType == ELEMENT_TYPES.ELEMENT_TYPE_PICTURE)
                    {
                        this.Controls.Remove((el as ElImage).pictureBox);
                        (el as ElImage).pictureBox.Dispose();
                    }
                    view.Draw();
                    DeleteElementMenuItem.Enabled = false;
                    return;
                }
            }
        }
        private void сбросМасштабаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view.Zoom = 1.0f;
            view.Draw();
            ShowStatus(fsm.GetName());
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            view.Draw();
        }
        private void открытьПроектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                view.NewProject();
                view.Load(openFileDialog1.FileName);
            }
        }
        private void сохранитьПроектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                view.Save(saveFileDialog1.FileName);
            }
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void новыйПроектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view.NewProject();
            ShowStatus(fsm.GetName());
        }
        private void переместитьЭлементToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fsm.SetState(FSM_STATES.FSM_STATE_IDLE);
            fsm.SetState(FSM_STATES.FSM_STATE_ELEMENT_MOVE);
            ShowStatus(fsm.GetName());
        }
        private void изображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fsm.SetState(FSM_STATES.FSM_STATE_IDLE);
            fsm.SetState(FSM_STATES.FSM_STATE_ELEMENT_READY_DRAW);
            ShowStatus(fsm.GetName());
            view.element = new ElImage(ELEMENT_TYPES.ELEMENT_TYPE_PICTURE, this, view);
        }
        private void центрироватьЭкранToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view.OffsetCenter.X = view.OffsetCenter.Y = 0;
            view.Draw();
            ShowStatus(fsm.GetName());
        }
        private void стрелкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fsm.SetState(FSM_STATES.FSM_STATE_IDLE);
            fsm.SetState(FSM_STATES.FSM_STATE_ELEMENT_READY_DRAW);
            ShowStatus(fsm.GetName());
            view.element = new ElArrow(ELEMENT_TYPES.ELEMENT_TYPE_ARROW, this);
        }
        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Element el in view.allElements)
            {
                if (el.Equals(view.selectedElement))
                {   
                    if (el.elementType == ELEMENT_TYPES.ELEMENT_TYPE_TEXT)
                    {
                        (el as ElText).TextBoxSetFont();
                        return;
                    }
                }
            }
        }
        private void цветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Element el in view.allElements)
            {
                if (el.Equals(view.selectedElement))
                {
                    if (el.elementType == ELEMENT_TYPES.ELEMENT_TYPE_TEXT)
                    {
                        (el as ElText).TextBoxSetColor();
                        return;
                    }
                }
            }
        }
        private void цветФонаШрифтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Element el in view.allElements)
            {
                if (el.Equals(view.selectedElement))
                {
                    if (el.elementType == ELEMENT_TYPES.ELEMENT_TYPE_TEXT)
                    {
                        (el as ElText).TextBoxSetBgColor();
                        return;
                    }
                }
            }
        }
        private void эллипсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fsm.SetState(FSM_STATES.FSM_STATE_IDLE);
            fsm.SetState(FSM_STATES.FSM_STATE_ELEMENT_READY_DRAW);
            ShowStatus(fsm.GetName());
            view.element = new ElEllipse(ELEMENT_TYPES.ELEMENT_TYPE_ELLIPSE, this);
        }
    }
}
