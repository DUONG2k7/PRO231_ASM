﻿namespace ASM
{
    partial class FormQuanLyNhanSu
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
            this.guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabPageIT = new System.Windows.Forms.TabPage();
            this.tabPageCBDT = new System.Windows.Forms.TabPage();
            this.tabPageCBQL = new System.Windows.Forms.TabPage();
            this.guna2TabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2TabControl1
            // 
            this.guna2TabControl1.Controls.Add(this.tabPageIT);
            this.guna2TabControl1.Controls.Add(this.tabPageCBDT);
            this.guna2TabControl1.Controls.Add(this.tabPageCBQL);
            this.guna2TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2TabControl1.ItemSize = new System.Drawing.Size(180, 40);
            this.guna2TabControl1.Location = new System.Drawing.Point(0, 0);
            this.guna2TabControl1.Name = "guna2TabControl1";
            this.guna2TabControl1.SelectedIndex = 0;
            this.guna2TabControl1.Size = new System.Drawing.Size(997, 887);
            this.guna2TabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.guna2TabControl1.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.guna2TabControl1.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.guna2TabControl1.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.guna2TabControl1.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.guna2TabControl1.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.guna2TabControl1.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.guna2TabControl1.TabButtonSize = new System.Drawing.Size(180, 40);
            this.guna2TabControl1.TabIndex = 1;
            this.guna2TabControl1.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.guna2TabControl1.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // tabPageIT
            // 
            this.tabPageIT.Location = new System.Drawing.Point(4, 44);
            this.tabPageIT.Name = "tabPageIT";
            this.tabPageIT.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIT.Size = new System.Drawing.Size(989, 839);
            this.tabPageIT.TabIndex = 0;
            this.tabPageIT.Text = "Quản lý IT";
            this.tabPageIT.UseVisualStyleBackColor = true;
            // 
            // tabPageCBDT
            // 
            this.tabPageCBDT.Location = new System.Drawing.Point(4, 44);
            this.tabPageCBDT.Name = "tabPageCBDT";
            this.tabPageCBDT.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCBDT.Size = new System.Drawing.Size(682, 250);
            this.tabPageCBDT.TabIndex = 1;
            this.tabPageCBDT.Text = "Quản lý CBDT";
            this.tabPageCBDT.UseVisualStyleBackColor = true;
            // 
            // tabPageCBQL
            // 
            this.tabPageCBQL.Location = new System.Drawing.Point(4, 44);
            this.tabPageCBQL.Name = "tabPageCBQL";
            this.tabPageCBQL.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCBQL.Size = new System.Drawing.Size(682, 250);
            this.tabPageCBQL.TabIndex = 2;
            this.tabPageCBQL.Text = "Quản lý CBQL";
            this.tabPageCBQL.UseVisualStyleBackColor = true;
            // 
            // FormQuanLyNhanSu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 887);
            this.Controls.Add(this.guna2TabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormQuanLyNhanSu";
            this.Text = "FormQuanLyNhanSu";
            this.Load += new System.EventHandler(this.FormQuanLyNhanSu_Load);
            this.guna2TabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TabControl guna2TabControl1;
        private System.Windows.Forms.TabPage tabPageIT;
        private System.Windows.Forms.TabPage tabPageCBDT;
        private System.Windows.Forms.TabPage tabPageCBQL;
    }
}