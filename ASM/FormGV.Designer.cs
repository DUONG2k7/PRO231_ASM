namespace ASM
{
    partial class FormGV
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
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThongTinTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.UserNameThongTinTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.RoleThongTinTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblMarquee = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PnMain = new Guna.UI2.WinForms.Guna2Panel();
            this.PnInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.btnthoat = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.PnMenu = new Guna.UI2.WinForms.Guna2Panel();
            this.btnMenuGvXemLichDaySV = new Guna.UI2.WinForms.Guna2Button();
            this.btnMenuQlyDanhSach = new Guna.UI2.WinForms.Guna2Button();
            this.btnMenuQlyDiem = new Guna.UI2.WinForms.Guna2Button();
            this.ElipseFormGV = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.dragFromGV = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl2 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PnMain.SuspendLayout();
            this.PnInfo.SuspendLayout();
            this.PnMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngXuấtToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.hệThốngToolStripMenuItem.Text = "Hệ Thống";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng Xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // ThongTinTaiKhoan
            // 
            this.ThongTinTaiKhoan.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ThongTinTaiKhoan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UserNameThongTinTaiKhoan,
            this.RoleThongTinTaiKhoan});
            this.ThongTinTaiKhoan.Name = "ThongTinTaiKhoan";
            this.ThongTinTaiKhoan.Size = new System.Drawing.Size(38, 24);
            this.ThongTinTaiKhoan.Text = "Hi";
            // 
            // UserNameThongTinTaiKhoan
            // 
            this.UserNameThongTinTaiKhoan.Name = "UserNameThongTinTaiKhoan";
            this.UserNameThongTinTaiKhoan.Size = new System.Drawing.Size(129, 22);
            this.UserNameThongTinTaiKhoan.Text = "UserName";
            // 
            // RoleThongTinTaiKhoan
            // 
            this.RoleThongTinTaiKhoan.Name = "RoleThongTinTaiKhoan";
            this.RoleThongTinTaiKhoan.Size = new System.Drawing.Size(129, 22);
            this.RoleThongTinTaiKhoan.Text = "Role";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(83, 209);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(950, 193);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblMarquee
            // 
            this.lblMarquee.AutoSize = true;
            this.lblMarquee.Location = new System.Drawing.Point(939, 12);
            this.lblMarquee.Name = "lblMarquee";
            this.lblMarquee.Size = new System.Drawing.Size(35, 13);
            this.lblMarquee.TabIndex = 0;
            this.lblMarquee.Text = "label1";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // PnMain
            // 
            this.PnMain.BackColor = System.Drawing.Color.Transparent;
            this.PnMain.Controls.Add(this.lblMarquee);
            this.PnMain.Controls.Add(this.pictureBox1);
            this.PnMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.PnMain.Location = new System.Drawing.Point(295, 0);
            this.PnMain.Name = "PnMain";
            this.PnMain.Size = new System.Drawing.Size(1085, 822);
            this.PnMain.TabIndex = 17;
            this.PnMain.UseTransparentBackground = true;
            // 
            // PnInfo
            // 
            this.PnInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.PnInfo.Controls.Add(this.btnthoat);
            this.PnInfo.Controls.Add(this.guna2Button1);
            this.PnInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnInfo.Location = new System.Drawing.Point(0, 0);
            this.PnInfo.Name = "PnInfo";
            this.PnInfo.Size = new System.Drawing.Size(94, 822);
            this.PnInfo.TabIndex = 18;
            // 
            // btnthoat
            // 
            this.btnthoat.Animated = true;
            this.btnthoat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnthoat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnthoat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnthoat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnthoat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnthoat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnthoat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnthoat.ForeColor = System.Drawing.Color.White;
            this.btnthoat.Image = global::ASM.Properties.Resources.undo;
            this.btnthoat.ImageSize = new System.Drawing.Size(40, 40);
            this.btnthoat.Location = new System.Drawing.Point(0, 748);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(94, 74);
            this.btnthoat.TabIndex = 2;
            this.btnthoat.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
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
            this.PnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.PnMenu.Controls.Add(this.btnMenuGvXemLichDaySV);
            this.PnMenu.Controls.Add(this.btnMenuQlyDanhSach);
            this.PnMenu.Controls.Add(this.btnMenuQlyDiem);
            this.PnMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnMenu.Location = new System.Drawing.Point(94, 0);
            this.PnMenu.Name = "PnMenu";
            this.PnMenu.Size = new System.Drawing.Size(201, 822);
            this.PnMenu.TabIndex = 19;
            // 
            // btnMenuGvXemLichDaySV
            // 
            this.btnMenuGvXemLichDaySV.Animated = true;
            this.btnMenuGvXemLichDaySV.BackColor = System.Drawing.Color.Transparent;
            this.btnMenuGvXemLichDaySV.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnMenuGvXemLichDaySV.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuGvXemLichDaySV.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuGvXemLichDaySV.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuGvXemLichDaySV.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuGvXemLichDaySV.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuGvXemLichDaySV.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenuGvXemLichDaySV.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenuGvXemLichDaySV.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnMenuGvXemLichDaySV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMenuGvXemLichDaySV.ForeColor = System.Drawing.Color.White;
            this.btnMenuGvXemLichDaySV.Location = new System.Drawing.Point(0, 179);
            this.btnMenuGvXemLichDaySV.Name = "btnMenuGvXemLichDaySV";
            this.btnMenuGvXemLichDaySV.Size = new System.Drawing.Size(201, 45);
            this.btnMenuGvXemLichDaySV.TabIndex = 0;
            this.btnMenuGvXemLichDaySV.Text = "Xem lịch dạy học";
            this.btnMenuGvXemLichDaySV.UseTransparentBackground = true;
            this.btnMenuGvXemLichDaySV.Click += new System.EventHandler(this.btnMenuGvXemLichDaySV_Click);
            // 
            // btnMenuQlyDanhSach
            // 
            this.btnMenuQlyDanhSach.Animated = true;
            this.btnMenuQlyDanhSach.BackColor = System.Drawing.Color.Transparent;
            this.btnMenuQlyDanhSach.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnMenuQlyDanhSach.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuQlyDanhSach.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuQlyDanhSach.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuQlyDanhSach.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuQlyDanhSach.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenuQlyDanhSach.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenuQlyDanhSach.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnMenuQlyDanhSach.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMenuQlyDanhSach.ForeColor = System.Drawing.Color.White;
            this.btnMenuQlyDanhSach.Location = new System.Drawing.Point(0, 102);
            this.btnMenuQlyDanhSach.Name = "btnMenuQlyDanhSach";
            this.btnMenuQlyDanhSach.Size = new System.Drawing.Size(201, 45);
            this.btnMenuQlyDanhSach.TabIndex = 0;
            this.btnMenuQlyDanhSach.Text = "Thống kê / Tra cứu sinh viên";
            this.btnMenuQlyDanhSach.UseTransparentBackground = true;
            this.btnMenuQlyDanhSach.Click += new System.EventHandler(this.btnMenuQlyDanhSach_Click);
            // 
            // btnMenuQlyDiem
            // 
            this.btnMenuQlyDiem.Animated = true;
            this.btnMenuQlyDiem.BackColor = System.Drawing.Color.Transparent;
            this.btnMenuQlyDiem.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnMenuQlyDiem.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuQlyDiem.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuQlyDiem.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuQlyDiem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuQlyDiem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuQlyDiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenuQlyDiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenuQlyDiem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnMenuQlyDiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMenuQlyDiem.ForeColor = System.Drawing.Color.White;
            this.btnMenuQlyDiem.Location = new System.Drawing.Point(0, 28);
            this.btnMenuQlyDiem.Name = "btnMenuQlyDiem";
            this.btnMenuQlyDiem.Size = new System.Drawing.Size(201, 45);
            this.btnMenuQlyDiem.TabIndex = 0;
            this.btnMenuQlyDiem.Text = "Quản lý sinh viên có điểm";
            this.btnMenuQlyDiem.UseTransparentBackground = true;
            this.btnMenuQlyDiem.Click += new System.EventHandler(this.btnMenuQlyDiem_Click);
            // 
            // ElipseFormGV
            // 
            this.ElipseFormGV.BorderRadius = 30;
            this.ElipseFormGV.TargetControl = this;
            // 
            // dragFromGV
            // 
            this.dragFromGV.DockIndicatorTransparencyValue = 0.6D;
            this.dragFromGV.TargetControl = this.PnMain;
            this.dragFromGV.UseTransparentDrag = true;
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
            // FormGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1380, 822);
            this.Controls.Add(this.PnMenu);
            this.Controls.Add(this.PnInfo);
            this.Controls.Add(this.PnMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormGV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormGV";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PnMain.ResumeLayout(false);
            this.PnMain.PerformLayout();
            this.PnInfo.ResumeLayout(false);
            this.PnMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThongTinTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem UserNameThongTinTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem RoleThongTinTaiKhoan;
        private System.Windows.Forms.Label lblMarquee;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Panel PnMain;
        private Guna.UI2.WinForms.Guna2Panel PnInfo;
        private Guna.UI2.WinForms.Guna2Button btnthoat;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Panel PnMenu;
        private Guna.UI2.WinForms.Guna2Button btnMenuGvXemLichDaySV;
        private Guna.UI2.WinForms.Guna2Button btnMenuQlyDanhSach;
        private Guna.UI2.WinForms.Guna2Button btnMenuQlyDiem;
        private Guna.UI2.WinForms.Guna2Elipse ElipseFormGV;
        private Guna.UI2.WinForms.Guna2DragControl dragFromGV;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl2;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}