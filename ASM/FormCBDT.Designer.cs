namespace ASM
{
    partial class FormCBDT
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblMarquee = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.PnInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.PnMenu = new Guna.UI2.WinForms.Guna2Panel();
            this.btnMenuQlyPhanChiaViec = new Guna.UI2.WinForms.Guna2Button();
            this.btnMenyQlyKyHoc = new Guna.UI2.WinForms.Guna2Button();
            this.btnMenuQlyLichhoc = new Guna.UI2.WinForms.Guna2Button();
            this.btnMenuQlyGiangVien = new Guna.UI2.WinForms.Guna2Button();
            this.btnMenuQlyLop = new Guna.UI2.WinForms.Guna2Button();
            this.btnMenuQlySV = new Guna.UI2.WinForms.Guna2Button();
            this.PnMain = new Guna.UI2.WinForms.Guna2Panel();
            this.ElipseFormCBDT = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.dragFromCBDT = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl2 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PnInfo.SuspendLayout();
            this.PnMenu.SuspendLayout();
            this.PnMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(106, 102);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(880, 569);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // lblMarquee
            // 
            this.lblMarquee.AutoSize = true;
            this.lblMarquee.Location = new System.Drawing.Point(951, 28);
            this.lblMarquee.Name = "lblMarquee";
            this.lblMarquee.Size = new System.Drawing.Size(35, 13);
            this.lblMarquee.TabIndex = 12;
            this.lblMarquee.Text = "label1";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // PnInfo
            // 
            this.PnInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PnInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.PnInfo.Controls.Add(this.guna2Button2);
            this.PnInfo.Controls.Add(this.guna2Button1);
            this.PnInfo.Location = new System.Drawing.Point(0, 0);
            this.PnInfo.Name = "PnInfo";
            this.PnInfo.Size = new System.Drawing.Size(94, 822);
            this.PnInfo.TabIndex = 14;
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
            this.guna2Button2.Location = new System.Drawing.Point(0, 754);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(94, 68);
            this.guna2Button2.TabIndex = 2;
            this.guna2Button2.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
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
            // PnMenu
            // 
            this.PnMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.PnMenu.Controls.Add(this.btnMenuQlyPhanChiaViec);
            this.PnMenu.Controls.Add(this.btnMenyQlyKyHoc);
            this.PnMenu.Controls.Add(this.btnMenuQlyLichhoc);
            this.PnMenu.Controls.Add(this.btnMenuQlyGiangVien);
            this.PnMenu.Controls.Add(this.btnMenuQlyLop);
            this.PnMenu.Controls.Add(this.btnMenuQlySV);
            this.PnMenu.Location = new System.Drawing.Point(94, 0);
            this.PnMenu.Name = "PnMenu";
            this.PnMenu.Size = new System.Drawing.Size(201, 822);
            this.PnMenu.TabIndex = 15;
            // 
            // btnMenuQlyPhanChiaViec
            // 
            this.btnMenuQlyPhanChiaViec.Animated = true;
            this.btnMenuQlyPhanChiaViec.BackColor = System.Drawing.Color.Transparent;
            this.btnMenuQlyPhanChiaViec.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnMenuQlyPhanChiaViec.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuQlyPhanChiaViec.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuQlyPhanChiaViec.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuQlyPhanChiaViec.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuQlyPhanChiaViec.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenuQlyPhanChiaViec.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenuQlyPhanChiaViec.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnMenuQlyPhanChiaViec.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMenuQlyPhanChiaViec.ForeColor = System.Drawing.Color.White;
            this.btnMenuQlyPhanChiaViec.Location = new System.Drawing.Point(0, 406);
            this.btnMenuQlyPhanChiaViec.Name = "btnMenuQlyPhanChiaViec";
            this.btnMenuQlyPhanChiaViec.Size = new System.Drawing.Size(201, 45);
            this.btnMenuQlyPhanChiaViec.TabIndex = 0;
            this.btnMenuQlyPhanChiaViec.Text = "Quản lý công việc";
            this.btnMenuQlyPhanChiaViec.UseTransparentBackground = true;
            this.btnMenuQlyPhanChiaViec.Click += new System.EventHandler(this.btnMenuQlyPhanChiaViec_Click);
            // 
            // btnMenyQlyKyHoc
            // 
            this.btnMenyQlyKyHoc.Animated = true;
            this.btnMenyQlyKyHoc.BackColor = System.Drawing.Color.Transparent;
            this.btnMenyQlyKyHoc.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnMenyQlyKyHoc.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenyQlyKyHoc.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenyQlyKyHoc.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenyQlyKyHoc.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenyQlyKyHoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenyQlyKyHoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenyQlyKyHoc.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnMenyQlyKyHoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMenyQlyKyHoc.ForeColor = System.Drawing.Color.White;
            this.btnMenyQlyKyHoc.Location = new System.Drawing.Point(0, 253);
            this.btnMenyQlyKyHoc.Name = "btnMenyQlyKyHoc";
            this.btnMenyQlyKyHoc.Size = new System.Drawing.Size(201, 45);
            this.btnMenyQlyKyHoc.TabIndex = 0;
            this.btnMenyQlyKyHoc.Text = "Quản lý kỳ học / môn học";
            this.btnMenyQlyKyHoc.UseTransparentBackground = true;
            this.btnMenyQlyKyHoc.Click += new System.EventHandler(this.btnMenyQlyKyHoc_Click);
            // 
            // btnMenuQlyLichhoc
            // 
            this.btnMenuQlyLichhoc.Animated = true;
            this.btnMenuQlyLichhoc.BackColor = System.Drawing.Color.Transparent;
            this.btnMenuQlyLichhoc.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnMenuQlyLichhoc.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuQlyLichhoc.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuQlyLichhoc.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuQlyLichhoc.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuQlyLichhoc.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuQlyLichhoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenuQlyLichhoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenuQlyLichhoc.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnMenuQlyLichhoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMenuQlyLichhoc.ForeColor = System.Drawing.Color.White;
            this.btnMenuQlyLichhoc.Location = new System.Drawing.Point(0, 332);
            this.btnMenuQlyLichhoc.Name = "btnMenuQlyLichhoc";
            this.btnMenuQlyLichhoc.Size = new System.Drawing.Size(201, 45);
            this.btnMenuQlyLichhoc.TabIndex = 0;
            this.btnMenuQlyLichhoc.Text = "Quản lý lịch học";
            this.btnMenuQlyLichhoc.UseTransparentBackground = true;
            this.btnMenuQlyLichhoc.Click += new System.EventHandler(this.btnMenuQlyLichhoc_Click);
            // 
            // btnMenuQlyGiangVien
            // 
            this.btnMenuQlyGiangVien.Animated = true;
            this.btnMenuQlyGiangVien.BackColor = System.Drawing.Color.Transparent;
            this.btnMenuQlyGiangVien.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnMenuQlyGiangVien.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuQlyGiangVien.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuQlyGiangVien.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuQlyGiangVien.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuQlyGiangVien.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuQlyGiangVien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenuQlyGiangVien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenuQlyGiangVien.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnMenuQlyGiangVien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMenuQlyGiangVien.ForeColor = System.Drawing.Color.White;
            this.btnMenuQlyGiangVien.Location = new System.Drawing.Point(0, 179);
            this.btnMenuQlyGiangVien.Name = "btnMenuQlyGiangVien";
            this.btnMenuQlyGiangVien.Size = new System.Drawing.Size(201, 45);
            this.btnMenuQlyGiangVien.TabIndex = 0;
            this.btnMenuQlyGiangVien.Text = "Quản lý giảng viên";
            this.btnMenuQlyGiangVien.UseTransparentBackground = true;
            this.btnMenuQlyGiangVien.Click += new System.EventHandler(this.btnMenuQlyGiangVien_Click);
            // 
            // btnMenuQlyLop
            // 
            this.btnMenuQlyLop.Animated = true;
            this.btnMenuQlyLop.BackColor = System.Drawing.Color.Transparent;
            this.btnMenuQlyLop.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnMenuQlyLop.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuQlyLop.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuQlyLop.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuQlyLop.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuQlyLop.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenuQlyLop.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenuQlyLop.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnMenuQlyLop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMenuQlyLop.ForeColor = System.Drawing.Color.White;
            this.btnMenuQlyLop.Location = new System.Drawing.Point(0, 102);
            this.btnMenuQlyLop.Name = "btnMenuQlyLop";
            this.btnMenuQlyLop.Size = new System.Drawing.Size(201, 45);
            this.btnMenuQlyLop.TabIndex = 0;
            this.btnMenuQlyLop.Text = "Quản lý lớp";
            this.btnMenuQlyLop.UseTransparentBackground = true;
            this.btnMenuQlyLop.Click += new System.EventHandler(this.btnMenuQlyLop_Click);
            // 
            // btnMenuQlySV
            // 
            this.btnMenuQlySV.Animated = true;
            this.btnMenuQlySV.BackColor = System.Drawing.Color.Transparent;
            this.btnMenuQlySV.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnMenuQlySV.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuQlySV.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuQlySV.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuQlySV.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuQlySV.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuQlySV.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenuQlySV.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenuQlySV.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnMenuQlySV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMenuQlySV.ForeColor = System.Drawing.Color.White;
            this.btnMenuQlySV.Location = new System.Drawing.Point(0, 28);
            this.btnMenuQlySV.Name = "btnMenuQlySV";
            this.btnMenuQlySV.Size = new System.Drawing.Size(201, 45);
            this.btnMenuQlySV.TabIndex = 0;
            this.btnMenuQlySV.Text = "Quản lý sinh viên";
            this.btnMenuQlySV.UseTransparentBackground = true;
            this.btnMenuQlySV.Click += new System.EventHandler(this.btnMenuQlySV_Click);
            // 
            // PnMain
            // 
            this.PnMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnMain.BackColor = System.Drawing.Color.Transparent;
            this.PnMain.Controls.Add(this.lblMarquee);
            this.PnMain.Controls.Add(this.pictureBox1);
            this.PnMain.Location = new System.Drawing.Point(293, 0);
            this.PnMain.Name = "PnMain";
            this.PnMain.Size = new System.Drawing.Size(1087, 822);
            this.PnMain.TabIndex = 16;
            this.PnMain.UseTransparentBackground = true;
            // 
            // ElipseFormCBDT
            // 
            this.ElipseFormCBDT.BorderRadius = 30;
            this.ElipseFormCBDT.TargetControl = this;
            // 
            // dragFromCBDT
            // 
            this.dragFromCBDT.DockIndicatorTransparencyValue = 0.6D;
            this.dragFromCBDT.TargetControl = this.PnMain;
            this.dragFromCBDT.UseTransparentDrag = true;
            // 
            // guna2DragControl2
            // 
            this.guna2DragControl2.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl2.TargetControl = this.PnMenu;
            this.guna2DragControl2.UseTransparentDrag = true;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.PnInfo;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // FormCBDT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1380, 822);
            this.Controls.Add(this.PnMain);
            this.Controls.Add(this.PnMenu);
            this.Controls.Add(this.PnInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormCBDT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCBDT";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PnInfo.ResumeLayout(false);
            this.PnMenu.ResumeLayout(false);
            this.PnMain.ResumeLayout(false);
            this.PnMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblMarquee;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Panel PnInfo;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Panel PnMenu;
        private Guna.UI2.WinForms.Guna2Button btnMenuQlyLop;
        private Guna.UI2.WinForms.Guna2Button btnMenuQlySV;
        private Guna.UI2.WinForms.Guna2Button btnMenyQlyKyHoc;
        private Guna.UI2.WinForms.Guna2Button btnMenuQlyGiangVien;
        private Guna.UI2.WinForms.Guna2Button btnMenuQlyPhanChiaViec;
        private Guna.UI2.WinForms.Guna2Button btnMenuQlyLichhoc;
        private Guna.UI2.WinForms.Guna2Panel PnMain;
        private Guna.UI2.WinForms.Guna2Elipse ElipseFormCBDT;
        private Guna.UI2.WinForms.Guna2DragControl dragFromCBDT;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl2;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}