﻿namespace OneNote
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripScale = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйПроектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьПроектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьПроектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сбросМасштабаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.центрироватьЭкранToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.элементыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьЭлементToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.линияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стрелкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.текстовоеПолеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.эллипсToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьЭлементToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.линияToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.шрифтToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.цветToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.цветФонаШрифтаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteElementMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveElementStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileImage = new System.Windows.Forms.OpenFileDialog();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolCoordCenter = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.Status,
            this.toolStripStatusLabel2,
            this.toolStripScale,
            this.toolStripStatusLabel3,
            this.toolCoordCenter});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(46, 17);
            this.toolStripStatusLabel1.Text = "Статус:";
            // 
            // Status
            // 
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(80, 17);
            this.toolStripStatusLabel2.Text = "Масштаб:";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripScale
            // 
            this.toolStripScale.Name = "toolStripScale";
            this.toolStripScale.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.видToolStripMenuItem,
            this.элементыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйПроектToolStripMenuItem,
            this.открытьПроектToolStripMenuItem,
            this.сохранитьПроектToolStripMenuItem,
            this.toolStripMenuItem1,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // новыйПроектToolStripMenuItem
            // 
            this.новыйПроектToolStripMenuItem.Name = "новыйПроектToolStripMenuItem";
            this.новыйПроектToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.новыйПроектToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.новыйПроектToolStripMenuItem.Text = "Новый проект";
            this.новыйПроектToolStripMenuItem.Click += new System.EventHandler(this.новыйПроектToolStripMenuItem_Click);
            // 
            // открытьПроектToolStripMenuItem
            // 
            this.открытьПроектToolStripMenuItem.Name = "открытьПроектToolStripMenuItem";
            this.открытьПроектToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.открытьПроектToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.открытьПроектToolStripMenuItem.Text = "Открыть проект";
            this.открытьПроектToolStripMenuItem.Click += new System.EventHandler(this.открытьПроектToolStripMenuItem_Click);
            // 
            // сохранитьПроектToolStripMenuItem
            // 
            this.сохранитьПроектToolStripMenuItem.Name = "сохранитьПроектToolStripMenuItem";
            this.сохранитьПроектToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.сохранитьПроектToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.сохранитьПроектToolStripMenuItem.Text = "Сохранить проект";
            this.сохранитьПроектToolStripMenuItem.Click += new System.EventHandler(this.сохранитьПроектToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(211, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сбросМасштабаToolStripMenuItem,
            this.центрироватьЭкранToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // сбросМасштабаToolStripMenuItem
            // 
            this.сбросМасштабаToolStripMenuItem.Name = "сбросМасштабаToolStripMenuItem";
            this.сбросМасштабаToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.сбросМасштабаToolStripMenuItem.Text = "Сброс масштаба";
            this.сбросМасштабаToolStripMenuItem.Click += new System.EventHandler(this.сбросМасштабаToolStripMenuItem_Click);
            // 
            // центрироватьЭкранToolStripMenuItem
            // 
            this.центрироватьЭкранToolStripMenuItem.Name = "центрироватьЭкранToolStripMenuItem";
            this.центрироватьЭкранToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.центрироватьЭкранToolStripMenuItem.Text = "Центрировать экран";
            this.центрироватьЭкранToolStripMenuItem.Click += new System.EventHandler(this.центрироватьЭкранToolStripMenuItem_Click);
            // 
            // элементыToolStripMenuItem
            // 
            this.элементыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьЭлементToolStripMenuItem,
            this.изменитьЭлементToolStripMenuItem,
            this.DeleteElementMenuItem,
            this.MoveElementStripMenuItem});
            this.элементыToolStripMenuItem.Name = "элементыToolStripMenuItem";
            this.элементыToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.элементыToolStripMenuItem.Text = "Элементы";
            // 
            // добавитьЭлементToolStripMenuItem
            // 
            this.добавитьЭлементToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.линияToolStripMenuItem,
            this.стрелкаToolStripMenuItem,
            this.текстовоеПолеToolStripMenuItem,
            this.изображениеToolStripMenuItem,
            this.эллипсToolStripMenuItem});
            this.добавитьЭлементToolStripMenuItem.Name = "добавитьЭлементToolStripMenuItem";
            this.добавитьЭлементToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.добавитьЭлементToolStripMenuItem.Text = "Добавить элемент";
            // 
            // линияToolStripMenuItem
            // 
            this.линияToolStripMenuItem.Name = "линияToolStripMenuItem";
            this.линияToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.линияToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.линияToolStripMenuItem.Text = "Линия";
            this.линияToolStripMenuItem.Click += new System.EventHandler(this.линияToolStripMenuItem_Click);
            // 
            // стрелкаToolStripMenuItem
            // 
            this.стрелкаToolStripMenuItem.Name = "стрелкаToolStripMenuItem";
            this.стрелкаToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.стрелкаToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.стрелкаToolStripMenuItem.Text = "Стрелка";
            this.стрелкаToolStripMenuItem.Click += new System.EventHandler(this.стрелкаToolStripMenuItem_Click);
            // 
            // текстовоеПолеToolStripMenuItem
            // 
            this.текстовоеПолеToolStripMenuItem.Name = "текстовоеПолеToolStripMenuItem";
            this.текстовоеПолеToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.текстовоеПолеToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.текстовоеПолеToolStripMenuItem.Text = "Текстовое поле";
            this.текстовоеПолеToolStripMenuItem.Click += new System.EventHandler(this.текстовоеПолеToolStripMenuItem_Click);
            // 
            // изображениеToolStripMenuItem
            // 
            this.изображениеToolStripMenuItem.Name = "изображениеToolStripMenuItem";
            this.изображениеToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.изображениеToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.изображениеToolStripMenuItem.Text = "Изображение";
            this.изображениеToolStripMenuItem.Click += new System.EventHandler(this.изображениеToolStripMenuItem_Click);
            // 
            // эллипсToolStripMenuItem
            // 
            this.эллипсToolStripMenuItem.Name = "эллипсToolStripMenuItem";
            this.эллипсToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.эллипсToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.эллипсToolStripMenuItem.Text = "Эллипс";
            this.эллипсToolStripMenuItem.Click += new System.EventHandler(this.эллипсToolStripMenuItem_Click);
            // 
            // изменитьЭлементToolStripMenuItem
            // 
            this.изменитьЭлементToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.линияToolStripMenuItem1});
            this.изменитьЭлементToolStripMenuItem.Name = "изменитьЭлементToolStripMenuItem";
            this.изменитьЭлементToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.изменитьЭлементToolStripMenuItem.Text = "Изменить элемент";
            // 
            // линияToolStripMenuItem1
            // 
            this.линияToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.шрифтToolStripMenuItem,
            this.цветToolStripMenuItem,
            this.цветФонаШрифтаToolStripMenuItem});
            this.линияToolStripMenuItem1.Name = "линияToolStripMenuItem1";
            this.линияToolStripMenuItem1.Size = new System.Drawing.Size(159, 22);
            this.линияToolStripMenuItem1.Text = "Текстовое поле";
            // 
            // шрифтToolStripMenuItem
            // 
            this.шрифтToolStripMenuItem.Name = "шрифтToolStripMenuItem";
            this.шрифтToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.шрифтToolStripMenuItem.Text = "Шрифт";
            this.шрифтToolStripMenuItem.Click += new System.EventHandler(this.шрифтToolStripMenuItem_Click);
            // 
            // цветToolStripMenuItem
            // 
            this.цветToolStripMenuItem.Name = "цветToolStripMenuItem";
            this.цветToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.цветToolStripMenuItem.Text = "Цвет шрифта";
            this.цветToolStripMenuItem.Click += new System.EventHandler(this.цветToolStripMenuItem_Click);
            // 
            // цветФонаШрифтаToolStripMenuItem
            // 
            this.цветФонаШрифтаToolStripMenuItem.Name = "цветФонаШрифтаToolStripMenuItem";
            this.цветФонаШрифтаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.цветФонаШрифтаToolStripMenuItem.Text = "Цвет фона шрифта";
            this.цветФонаШрифтаToolStripMenuItem.Click += new System.EventHandler(this.цветФонаШрифтаToolStripMenuItem_Click);
            // 
            // DeleteElementMenuItem
            // 
            this.DeleteElementMenuItem.Enabled = false;
            this.DeleteElementMenuItem.Name = "DeleteElementMenuItem";
            this.DeleteElementMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.DeleteElementMenuItem.Size = new System.Drawing.Size(240, 22);
            this.DeleteElementMenuItem.Text = "Удалить элемент";
            this.DeleteElementMenuItem.Click += new System.EventHandler(this.DeleteElementMenuItem_Click);
            // 
            // MoveElementStripMenuItem
            // 
            this.MoveElementStripMenuItem.Enabled = false;
            this.MoveElementStripMenuItem.Name = "MoveElementStripMenuItem";
            this.MoveElementStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.MoveElementStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.MoveElementStripMenuItem.Text = "Переместить элемент";
            this.MoveElementStripMenuItem.Click += new System.EventHandler(this.переместитьЭлементToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.lnt";
            this.saveFileDialog1.Filter = "Lecture Notes|*.lnt";
            this.saveFileDialog1.RestoreDirectory = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.lnt";
            this.openFileDialog1.Filter = "Lecture Notes|*.lnt";
            // 
            // openFileImage
            // 
            this.openFileImage.DefaultExt = "*.lnt";
            this.openFileImage.Filter = "Jpeg image|*.jpg";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(119, 17);
            this.toolStripStatusLabel3.Text = "Координаты центра:";
            // 
            // toolCoordCenter
            // 
            this.toolCoordCenter.Name = "toolCoordCenter";
            this.toolCoordCenter.Size = new System.Drawing.Size(22, 17);
            this.toolCoordCenter.Text = "0;0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Lecture Notes";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel Status;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem элементыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьЭлементToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem линияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem текстовоеПолеToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem DeleteElementMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сбросМасштабаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новыйПроектToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьПроектToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьПроектToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripScale;
        public System.Windows.Forms.ToolStripMenuItem MoveElementStripMenuItem;
        public System.Windows.Forms.OpenFileDialog openFileImage;
        private System.Windows.Forms.ToolStripMenuItem изображениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem центрироватьЭкранToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem стрелкаToolStripMenuItem;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.ToolStripMenuItem изменитьЭлементToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem линияToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem шрифтToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem цветToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ToolStripMenuItem цветФонаШрифтаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem эллипсToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolCoordCenter;
    }
}

