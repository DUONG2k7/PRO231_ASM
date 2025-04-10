namespace ASM
{
    partial class UcTinTuc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbAnh = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timerND = new System.Windows.Forms.Timer(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.lbTieuDE = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbNd = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // pbAnh
            // 
            this.pbAnh.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbAnh.Location = new System.Drawing.Point(0, 0);
            this.pbAnh.Name = "pbAnh";
            this.pbAnh.Size = new System.Drawing.Size(225, 350);
            this.pbAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAnh.TabIndex = 12;
            this.pbAnh.TabStop = false;
            // 
            // lbTieuDE
            // 
            this.lbTieuDE.AutoSize = false;
            this.lbTieuDE.BackColor = System.Drawing.Color.Transparent;
            this.lbTieuDE.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTieuDE.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTieuDE.ForeColor = System.Drawing.Color.Black;
            this.lbTieuDE.Location = new System.Drawing.Point(225, 0);
            this.lbTieuDE.Name = "lbTieuDE";
            this.lbTieuDE.Size = new System.Drawing.Size(238, 55);
            this.lbTieuDE.TabIndex = 17;
            this.lbTieuDE.Text = "Tieu de";
            this.lbTieuDE.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbNd
            // 
            this.lbNd.AutoSize = false;
            this.lbNd.BackColor = System.Drawing.Color.Transparent;
            this.lbNd.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbNd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNd.ForeColor = System.Drawing.Color.Black;
            this.lbNd.Location = new System.Drawing.Point(225, 55);
            this.lbNd.Name = "lbNd";
            this.lbNd.Size = new System.Drawing.Size(238, 295);
            this.lbNd.TabIndex = 17;
            this.lbNd.Text = "noidung";
            // 
            // UcTinTuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbNd);
            this.Controls.Add(this.lbTieuDE);
            this.Controls.Add(this.pbAnh);
            this.Name = "UcTinTuc";
            this.Size = new System.Drawing.Size(463, 350);
            ((System.ComponentModel.ISupportInitialize)(this.pbAnh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbAnh;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer timerND;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbTieuDE;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbNd;
    }
}
