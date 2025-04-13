namespace ASM
{
    partial class FormSV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblMarquee = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.PnMain = new Guna.UI2.WinForms.Guna2Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PnMenu = new Guna.UI2.WinForms.Guna2Panel();
            this.btnMenuXemLichHoc = new Guna.UI2.WinForms.Guna2Button();
            this.PnInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.ElipseFormSV = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl2 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.dragFromSV = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.btnXemLichTHi = new Guna.UI2.WinForms.Guna2Button();
            this.btnXemDiem = new Guna.UI2.WinForms.Guna2Button();
            this.PnMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PnMenu.SuspendLayout();
            this.PnInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMarquee
            // 
            this.lblMarquee.AutoSize = true;
            this.lblMarquee.Location = new System.Drawing.Point(949, 12);
            this.lblMarquee.Name = "lblMarquee";
            this.lblMarquee.Size = new System.Drawing.Size(35, 13);
            this.lblMarquee.TabIndex = 10;
            this.lblMarquee.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // PnMain
            // 
            this.PnMain.BackColor = System.Drawing.Color.Transparent;
            this.PnMain.Controls.Add(this.pictureBox1);
            this.PnMain.Controls.Add(this.lblMarquee);
            this.PnMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.PnMain.Location = new System.Drawing.Point(293, 0);
            this.PnMain.Name = "PnMain";
            this.PnMain.Size = new System.Drawing.Size(1087, 822);
            this.PnMain.TabIndex = 16;
            this.PnMain.UseTransparentBackground = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(87, 102);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(838, 569);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // PnMenu
            // 
            this.PnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.PnMenu.Controls.Add(this.btnXemDiem);
            this.PnMenu.Controls.Add(this.btnXemLichTHi);
            this.PnMenu.Controls.Add(this.btnMenuXemLichHoc);
            this.PnMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnMenu.Location = new System.Drawing.Point(94, 0);
            this.PnMenu.Name = "PnMenu";
            this.PnMenu.Size = new System.Drawing.Size(201, 822);
            this.PnMenu.TabIndex = 19;
            // 
            // btnMenuXemLichHoc
            // 
            this.btnMenuXemLichHoc.Animated = true;
            this.btnMenuXemLichHoc.BackColor = System.Drawing.Color.Transparent;
            this.btnMenuXemLichHoc.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnMenuXemLichHoc.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuXemLichHoc.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuXemLichHoc.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuXemLichHoc.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuXemLichHoc.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuXemLichHoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenuXemLichHoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenuXemLichHoc.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnMenuXemLichHoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMenuXemLichHoc.ForeColor = System.Drawing.Color.White;
            this.btnMenuXemLichHoc.Location = new System.Drawing.Point(0, 28);
            this.btnMenuXemLichHoc.Name = "btnMenuXemLichHoc";
            this.btnMenuXemLichHoc.Size = new System.Drawing.Size(201, 45);
            this.btnMenuXemLichHoc.TabIndex = 0;
            this.btnMenuXemLichHoc.Text = "Xem lịch học";
            this.btnMenuXemLichHoc.UseTransparentBackground = true;
            this.btnMenuXemLichHoc.Click += new System.EventHandler(this.btnMenuXemLichHoc_Click);
            // 
            // PnInfo
            // 
            this.PnInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.PnInfo.Controls.Add(this.guna2Button2);
            this.PnInfo.Controls.Add(this.guna2Button1);
            this.PnInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnInfo.Location = new System.Drawing.Point(0, 0);
            this.PnInfo.Name = "PnInfo";
            this.PnInfo.Size = new System.Drawing.Size(94, 822);
            this.PnInfo.TabIndex = 18;
            // 
            // guna2Button2
            // 
            this.guna2Button2.Animated = true;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Image = global::ASM.Properties.Resources.undo;
            this.guna2Button2.ImageSize = new System.Drawing.Size(40, 40);
            this.guna2Button2.Location = new System.Drawing.Point(0, 760);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(94, 62);
            this.guna2Button2.TabIndex = 2;
            this.guna2Button2.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.Animated = true;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Image = global::ASM.Properties.Resources._2022_PTCD_White_01;
            this.guna2Button1.ImageSize = new System.Drawing.Size(40, 40);
            this.guna2Button1.Location = new System.Drawing.Point(12, 12);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(67, 42);
            this.guna2Button1.TabIndex = 1;
            // 
            // ElipseFormSV
            // 
            this.ElipseFormSV.BorderRadius = 30;
            this.ElipseFormSV.TargetControl = this;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.PnInfo;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // guna2DragControl2
            // 
            this.guna2DragControl2.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl2.TargetControl = this.PnMenu;
            this.guna2DragControl2.UseTransparentDrag = true;
            // 
            // dragFromSV
            // 
            this.dragFromSV.DockIndicatorTransparencyValue = 0.6D;
            this.dragFromSV.TargetControl = this.PnMain;
            this.dragFromSV.UseTransparentDrag = true;
            // 
            // btnXemLichTHi
            // 
            this.btnXemLichTHi.Animated = true;
            this.btnXemLichTHi.BackColor = System.Drawing.Color.Transparent;
            this.btnXemLichTHi.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnXemLichTHi.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnXemLichTHi.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnXemLichTHi.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnXemLichTHi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXemLichTHi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXemLichTHi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXemLichTHi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXemLichTHi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnXemLichTHi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXemLichTHi.ForeColor = System.Drawing.Color.White;
            this.btnXemLichTHi.Location = new System.Drawing.Point(0, 102);
            this.btnXemLichTHi.Name = "btnXemLichTHi";
            this.btnXemLichTHi.Size = new System.Drawing.Size(201, 45);
            this.btnXemLichTHi.TabIndex = 0;
            this.btnXemLichTHi.Text = "Xem lịch thi";
            this.btnXemLichTHi.UseTransparentBackground = true;
            this.btnXemLichTHi.Click += new System.EventHandler(this.btnXemLichTHi_Click);
            // 
            // btnXemDiem
            // 
            this.btnXemDiem.Animated = true;
            this.btnXemDiem.BackColor = System.Drawing.Color.Transparent;
            this.btnXemDiem.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnXemDiem.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnXemDiem.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnXemDiem.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnXemDiem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXemDiem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXemDiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXemDiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXemDiem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnXemDiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXemDiem.ForeColor = System.Drawing.Color.White;
            this.btnXemDiem.Location = new System.Drawing.Point(0, 182);
            this.btnXemDiem.Name = "btnXemDiem";
            this.btnXemDiem.Size = new System.Drawing.Size(201, 45);
            this.btnXemDiem.TabIndex = 0;
            this.btnXemDiem.Text = "Xem điểm";
            this.btnXemDiem.UseTransparentBackground = true;
            this.btnXemDiem.Click += new System.EventHandler(this.btnXemDiem_Click);
            // 
            // FormSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1380, 822);
            this.Controls.Add(this.PnMenu);
            this.Controls.Add(this.PnInfo);
            this.Controls.Add(this.PnMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSV";
            this.PnMain.ResumeLayout(false);
            this.PnMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PnMenu.ResumeLayout(false);
            this.PnInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblMarquee;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private Guna.UI2.WinForms.Guna2Panel PnMain;
        private Guna.UI2.WinForms.Guna2Panel PnMenu;
        private Guna.UI2.WinForms.Guna2Button btnMenuXemLichHoc;
        private Guna.UI2.WinForms.Guna2Panel PnInfo;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Elipse ElipseFormSV;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl2;
        private Guna.UI2.WinForms.Guna2DragControl dragFromSV;
        private Guna.UI2.WinForms.Guna2Button btnXemDiem;
        private Guna.UI2.WinForms.Guna2Button btnXemLichTHi;
    }
}