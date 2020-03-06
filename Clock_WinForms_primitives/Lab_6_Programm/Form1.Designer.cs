namespace Lab_6_Programm
{
    partial class FormClock
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
            this.components = new System.ComponentModel.Container();
            this._timer = new System.Windows.Forms.Timer(this.components);
            this._pictureBox = new System.Windows.Forms.PictureBox();
            this._linkLabel = new System.Windows.Forms.LinkLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ClockBackroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BorderColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NumbersColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HourArrowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MinuteArrowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SecArrowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BorderNoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DigitalTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.RiseSizeClockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DecreseClockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.OpenConfigFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WriteInFileConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AbAuthorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _timer
            // 
            this._timer.Tick += new System.EventHandler(this._timer_Tick);
            // 
            // _pictureBox
            // 
            this._pictureBox.Location = new System.Drawing.Point(0, 0);
            this._pictureBox.Name = "_pictureBox";
            this._pictureBox.Size = new System.Drawing.Size(160, 160);
            this._pictureBox.TabIndex = 0;
            this._pictureBox.TabStop = false;
            this._pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this._pictureBox_Paint);
            this._pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this._pictureBox_MouseDown);
            this._pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this._pictureBox_MouseMove);
            // 
            // _linkLabel
            // 
            this._linkLabel.AutoSize = true;
            this._linkLabel.Enabled = false;
            this._linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._linkLabel.Location = new System.Drawing.Point(40, 107);
            this._linkLabel.Name = "_linkLabel";
            this._linkLabel.Size = new System.Drawing.Size(90, 20);
            this._linkLabel.TabIndex = 1;
            this._linkLabel.TabStop = true;
            this._linkLabel.Text = "linkLabel1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.BorderNoneToolStripMenuItem,
            this.DigitalTimeToolStripMenuItem,
            this.toolStripSeparator3,
            this.RiseSizeClockToolStripMenuItem,
            this.DecreseClockToolStripMenuItem,
            this.toolStripSeparator4,
            this.OpenConfigFromFileToolStripMenuItem,
            this.WriteInFileConfigToolStripMenuItem,
            this.toolStripSeparator1,
            this.AbAuthorToolStripMenuItem,
            this.toolStripSeparator2,
            this.ExitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(309, 226);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClockBackroundToolStripMenuItem,
            this.BorderColorToolStripMenuItem,
            this.NumbersColorToolStripMenuItem,
            this.HourArrowToolStripMenuItem,
            this.MinuteArrowToolStripMenuItem,
            this.SecArrowToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(308, 22);
            this.toolStripMenuItem1.Text = "Изменить цвета";
            // 
            // ClockBackroundToolStripMenuItem
            // 
            this.ClockBackroundToolStripMenuItem.Name = "ClockBackroundToolStripMenuItem";
            this.ClockBackroundToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.ClockBackroundToolStripMenuItem.Text = "Циферблата";
            this.ClockBackroundToolStripMenuItem.Click += new System.EventHandler(this.ClockBackroundToolStripMenuItem_Click);
            // 
            // BorderColorToolStripMenuItem
            // 
            this.BorderColorToolStripMenuItem.Name = "BorderColorToolStripMenuItem";
            this.BorderColorToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.BorderColorToolStripMenuItem.Text = "Рамки";
            this.BorderColorToolStripMenuItem.Click += new System.EventHandler(this.BorderColorToolStripMenuItem_Click);
            // 
            // NumbersColorToolStripMenuItem
            // 
            this.NumbersColorToolStripMenuItem.Name = "NumbersColorToolStripMenuItem";
            this.NumbersColorToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.NumbersColorToolStripMenuItem.Text = "Цифр";
            this.NumbersColorToolStripMenuItem.Click += new System.EventHandler(this.NumbersColorToolStripMenuItem_Click);
            // 
            // HourArrowToolStripMenuItem
            // 
            this.HourArrowToolStripMenuItem.Name = "HourArrowToolStripMenuItem";
            this.HourArrowToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.HourArrowToolStripMenuItem.Text = "Часовой стрелки";
            this.HourArrowToolStripMenuItem.Click += new System.EventHandler(this.HourArrowToolStripMenuItem_Click);
            // 
            // MinuteArrowToolStripMenuItem
            // 
            this.MinuteArrowToolStripMenuItem.Name = "MinuteArrowToolStripMenuItem";
            this.MinuteArrowToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.MinuteArrowToolStripMenuItem.Text = "Минутной стрелки";
            this.MinuteArrowToolStripMenuItem.Click += new System.EventHandler(this.MinuteArrowToolStripMenuItem_Click);
            // 
            // SecArrowToolStripMenuItem
            // 
            this.SecArrowToolStripMenuItem.Name = "SecArrowToolStripMenuItem";
            this.SecArrowToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.SecArrowToolStripMenuItem.Text = "Секундной стрелки";
            this.SecArrowToolStripMenuItem.Click += new System.EventHandler(this.SecArrowToolStripMenuItem_Click);
            // 
            // BorderNoneToolStripMenuItem
            // 
            this.BorderNoneToolStripMenuItem.Checked = true;
            this.BorderNoneToolStripMenuItem.CheckOnClick = true;
            this.BorderNoneToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BorderNoneToolStripMenuItem.Name = "BorderNoneToolStripMenuItem";
            this.BorderNoneToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.BorderNoneToolStripMenuItem.Text = "Безрамочный вид";
            this.BorderNoneToolStripMenuItem.Click += new System.EventHandler(this.BorderNoneToolStripMenuItem_Click);
            // 
            // DigitalTimeToolStripMenuItem
            // 
            this.DigitalTimeToolStripMenuItem.CheckOnClick = true;
            this.DigitalTimeToolStripMenuItem.Name = "DigitalTimeToolStripMenuItem";
            this.DigitalTimeToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.DigitalTimeToolStripMenuItem.Text = "Цифровое время";
            this.DigitalTimeToolStripMenuItem.Click += new System.EventHandler(this.DigitalTimeToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(305, 6);
            // 
            // RiseSizeClockToolStripMenuItem
            // 
            this.RiseSizeClockToolStripMenuItem.Name = "RiseSizeClockToolStripMenuItem";
            this.RiseSizeClockToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.RiseSizeClockToolStripMenuItem.Text = "Увеличить часы";
            this.RiseSizeClockToolStripMenuItem.Click += new System.EventHandler(this.RiseSizeClockToolStripMenuItem_Click);
            // 
            // DecreseClockToolStripMenuItem
            // 
            this.DecreseClockToolStripMenuItem.Name = "DecreseClockToolStripMenuItem";
            this.DecreseClockToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.DecreseClockToolStripMenuItem.Text = "Уменьшить часы";
            this.DecreseClockToolStripMenuItem.Click += new System.EventHandler(this.DecreseClockToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(305, 6);
            // 
            // OpenConfigFromFileToolStripMenuItem
            // 
            this.OpenConfigFromFileToolStripMenuItem.Name = "OpenConfigFromFileToolStripMenuItem";
            this.OpenConfigFromFileToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.OpenConfigFromFileToolStripMenuItem.Text = "Открыть конфигурацию из файла";
            this.OpenConfigFromFileToolStripMenuItem.Click += new System.EventHandler(this.OpenConfigFromFileToolStripMenuItem_Click);
            // 
            // WriteInFileConfigToolStripMenuItem
            // 
            this.WriteInFileConfigToolStripMenuItem.Name = "WriteInFileConfigToolStripMenuItem";
            this.WriteInFileConfigToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.WriteInFileConfigToolStripMenuItem.Text = "Записать текущую конфигурацию  в файл";
            this.WriteInFileConfigToolStripMenuItem.Click += new System.EventHandler(this.WriteInFileConfigToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(305, 6);
            // 
            // AbAuthorToolStripMenuItem
            // 
            this.AbAuthorToolStripMenuItem.Name = "AbAuthorToolStripMenuItem";
            this.AbAuthorToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.AbAuthorToolStripMenuItem.Text = "Об авторе";
            this.AbAuthorToolStripMenuItem.Click += new System.EventHandler(this.AbAuthorToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(305, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(308, 22);
            this.ExitToolStripMenuItem.Text = "Выход";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // FormClock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(161, 161);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this._linkLabel);
            this.Controls.Add(this._pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormClock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clock";
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.PictureBox _pictureBox;
        private System.Windows.Forms.LinkLabel _linkLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ClockBackroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BorderColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HourArrowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MinuteArrowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SecArrowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NumbersColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AbAuthorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem BorderNoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DigitalTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RiseSizeClockToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem DecreseClockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WriteInFileConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem OpenConfigFromFileToolStripMenuItem;
    }
}

