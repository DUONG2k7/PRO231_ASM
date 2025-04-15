namespace ASM
{
    partial class FormIT
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblMarquee = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.PnMain = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.PnInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.btnthoat = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.PnMenu = new Guna.UI2.WinForms.Guna2Panel();
            this.btnMenuQlyTinTuc = new Guna.UI2.WinForms.Guna2Button();
            this.btnMenuQlyTk = new Guna.UI2.WinForms.Guna2Button();
            this.ElipseFormIT = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.dragFromIT = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl2 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.PnMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.PnInfo.SuspendLayout();
            this.PnMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblMarquee
            // 
            this.lblMarquee.AutoSize = true;
            this.lblMarquee.Location = new System.Drawing.Point(1079, 28);
            this.lblMarquee.Name = "lblMarquee";
            this.lblMarquee.Size = new System.Drawing.Size(35, 13);
            this.lblMarquee.TabIndex = 4;
            this.lblMarquee.Text = "label1";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // PnMain
            // 
            this.PnMain.BackColor = System.Drawing.Color.Transparent;
            this.PnMain.Controls.Add(this.guna2PictureBox1);
            this.PnMain.Controls.Add(this.lblMarquee);
            this.PnMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.PnMain.Location = new System.Drawing.Point(294, 0);
            this.PnMain.Name = "PnMain";
            this.PnMain.Size = new System.Drawing.Size(1086, 822);
            this.PnMain.TabIndex = 5;
            this.PnMain.UseTransparentBackground = true;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(107, 140);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(902, 501);
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
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
            this.PnInfo.TabIndex = 6;
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
            this.btnthoat.Location = new System.Drawing.Point(0, 760);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(94, 62);
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
            this.PnMenu.Controls.Add(this.btnMenuQlyTinTuc);
            this.PnMenu.Controls.Add(this.btnMenuQlyTk);
            this.PnMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnMenu.Location = new System.Drawing.Point(94, 0);
            this.PnMenu.Name = "PnMenu";
            this.PnMenu.Size = new System.Drawing.Size(201, 822);
            this.PnMenu.TabIndex = 7;
            // 
            // btnMenuQlyTinTuc
            // 
            this.btnMenuQlyTinTuc.Animated = true;
            this.btnMenuQlyTinTuc.BackColor = System.Drawing.Color.Transparent;
            this.btnMenuQlyTinTuc.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnMenuQlyTinTuc.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuQlyTinTuc.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuQlyTinTuc.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuQlyTinTuc.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuQlyTinTuc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenuQlyTinTuc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenuQlyTinTuc.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnMenuQlyTinTuc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMenuQlyTinTuc.ForeColor = System.Drawing.Color.White;
            this.btnMenuQlyTinTuc.Location = new System.Drawing.Point(0, 102);
            this.btnMenuQlyTinTuc.Name = "btnMenuQlyTinTuc";
            this.btnMenuQlyTinTuc.Size = new System.Drawing.Size(201, 45);
            this.btnMenuQlyTinTuc.TabIndex = 0;
            this.btnMenuQlyTinTuc.Text = "QUẢN LÝ TIN TỨC";
            this.btnMenuQlyTinTuc.UseTransparentBackground = true;
            this.btnMenuQlyTinTuc.Click += new System.EventHandler(this.btnMenuQlyTinTuc_Click);
            // 
            // btnMenuQlyTk
            // 
            this.btnMenuQlyTk.Animated = true;
            this.btnMenuQlyTk.BackColor = System.Drawing.Color.Transparent;
            this.btnMenuQlyTk.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnMenuQlyTk.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuQlyTk.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuQlyTk.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.btnMenuQlyTk.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuQlyTk.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuQlyTk.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenuQlyTk.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenuQlyTk.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnMenuQlyTk.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMenuQlyTk.ForeColor = System.Drawing.Color.White;
            this.btnMenuQlyTk.Location = new System.Drawing.Point(0, 28);
            this.btnMenuQlyTk.Name = "btnMenuQlyTk";
            this.btnMenuQlyTk.Size = new System.Drawing.Size(201, 45);
            this.btnMenuQlyTk.TabIndex = 0;
            this.btnMenuQlyTk.Text = "QUẢN LÝ TÀI KHOẢN";
            this.btnMenuQlyTk.UseTransparentBackground = true;
            this.btnMenuQlyTk.Click += new System.EventHandler(this.btnMenuQlyTk_Click);
            // 
            // ElipseFormIT
            // 
            this.ElipseFormIT.BorderRadius = 30;
            this.ElipseFormIT.TargetControl = this;
            // 
            // dragFromIT
            // 
            this.dragFromIT.DockIndicatorTransparencyValue = 0.6D;
            this.dragFromIT.TargetControl = this.PnMain;
            this.dragFromIT.UseTransparentDrag = true;
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
            // FormIT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1380, 822);
            this.Controls.Add(this.PnMenu);
            this.Controls.Add(this.PnInfo);
            this.Controls.Add(this.PnMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormIT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormADMIN";
            this.PnMain.ResumeLayout(false);
            this.PnMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.PnInfo.ResumeLayout(false);
            this.PnMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblMarquee;
        private System.Windows.Forms.Timer timer2;
        private Guna.UI2.WinForms.Guna2Panel PnMain;
        private Guna.UI2.WinForms.Guna2Panel PnInfo;
        private Guna.UI2.WinForms.Guna2Panel PnMenu;
        private Guna.UI2.WinForms.Guna2Button btnthoat;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button btnMenuQlyTinTuc;
        private Guna.UI2.WinForms.Guna2Button btnMenuQlyTk;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Elipse ElipseFormIT;
        private Guna.UI2.WinForms.Guna2DragControl dragFromIT;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl2;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}