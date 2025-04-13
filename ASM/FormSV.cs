using BUS_QL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASM
{
    public partial class FormSV : Form
    {
        BUS_GUI Qlgiaodien = new BUS_GUI();
        private int xPosition;
        private string[] images;
        private int index = 0;
        string username;
        string IDACC;
        public FormSV(string User, string IDrole, string idacc)
        {
            InitializeComponent();
            IDACC = idacc;
            username = User;
            //ThongTinTaiKhoan.Text = "Chào " + User;
            //UserNameThongTinTaiKhoan.Text = "Username: " + User;
            //RoleThongTinTaiKhoan.Text = "Role: " + Qlgiaodien.GetRole(IDrole);
            //LoadInfoSv();

            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string resourcePath = Path.Combine(basePath, "GVPIC");

            images = Directory.GetFiles(resourcePath, "*.*")
                              .Where(file => file.EndsWith(".png") || file.EndsWith(".jpg"))
                              .ToArray();
            if (images.Length > 0)
            {
                pictureBox1.Image = Image.FromFile(images[index]);
            }

            timer1.Interval = 2000;
            timer1.Tick += timer1_Tick;
            timer1.Start();

            xPosition = this.Width;
            lblMarquee.Text = "Chào mừng sinh viên đến với hệ thống! | Xem lịch học, lịch thi và điểm tại đây. | Cập nhật thông tin nhanh chóng!";
            lblMarquee.AutoSize = true;
            timer2.Interval = 100;
            timer2.Tick += timer2_Tick;
            timer2.Start();
        }
        //public void LoadInfoSv()
        //{
        //    DataTable dt = Qlgiaodien.LayThongTinCoBanSv(IDACC);
        //    if (dt.Rows.Count > 0)
        //    {
        //        DataRow row = dt.Rows[0];
        //        lblMaSV.Text = $"Mã SV: {row["IDSV"]}";
        //        lblHoTen.Text = $"Họ tên: {row["TenSV"]}";
        //        lblLop.Text = $"Lớp: {row["IDLop"]}";
        //        lblEmail.Text = $"Email: {row["Email"]}";
        //        lblSoDT.Text = $"Số ĐT: {row["SoDT"]}";
        //        lblDiaChi.Text = $"Địa chỉ: {row["Diachi"]}";
        //        lblGioiTinh.Text = $"Giới tính: {(row["GioiTinh"].ToString() == "1" ? "Nam" : "Nữ")}";
        //    }
        //    else
        //    {
        //        MessageBox.Show("Không tìm thấy thông tin sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            index = (index + 1) % images.Length;
            pictureBox1.Image = Image.FromFile(images[index]);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            xPosition -= 5;
            if (xPosition < -lblMarquee.Width)
            {
                xPosition = this.Width;
            }
            lblMarquee.Left = xPosition;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMenuXemLichHoc_Click(object sender, EventArgs e)
        {
            PnMain.Controls.Clear();
            FormSvXemLichHoc SV = new FormSvXemLichHoc(IDACC);
            SV.TopLevel = false;
            SV.FormBorderStyle = FormBorderStyle.None;
            SV.Dock = DockStyle.Fill;
            PnMain.Controls.Add(SV);
            SV.Show();
        }

        private void btnXemLichTHi_Click(object sender, EventArgs e)
        {
            PnMain.Controls.Clear();
            FormSvXemLichThi SV = new FormSvXemLichThi(IDACC);
            SV.TopLevel = false;
            SV.FormBorderStyle = FormBorderStyle.None;
            SV.Dock = DockStyle.Fill;
            PnMain.Controls.Add(SV);
            SV.Show();
        }

        private void btnXemDiem_Click(object sender, EventArgs e)
        {
            PnMain.Controls.Clear();
            FormSvXemDiem SV = new FormSvXemDiem(IDACC);
            SV.TopLevel = false;
            SV.FormBorderStyle = FormBorderStyle.None;
            SV.Dock = DockStyle.Fill;
            PnMain.Controls.Add(SV);
            SV.Show();
        }
    }
}
