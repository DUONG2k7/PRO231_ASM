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
    public partial class FormCBQL : Form
    {
        BUS_GUI Qlgiaodien = new BUS_GUI();
        private int xPosition;
        private string[] images;
        private int index = 0;
        public FormCBQL(string User, string IDrole)
        {
            InitializeComponent();
            //ThongTinTaiKhoan.Text = "Chào " + User;
            //UserNameThongTinTaiKhoan.Text = "Username: " + User;
            //RoleThongTinTaiKhoan.Text = "Role: " + Qlgiaodien.GetRole(IDrole);

            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string resourcePath = Path.Combine(basePath, "CBDTPIC");
            images = Directory.GetFiles(resourcePath, "*.*")
                              .Where(file => file.EndsWith(".png") || file.EndsWith(".jpg"))
                              .ToArray();
            if (images.Length > 0)
            {
                pictureBox1.Image = Image.FromFile(images[index]);
            }
            timer1.Interval = 2000; // Đặt thời gian mặc định là 2 giây
            timer1.Start();
            xPosition = this.Width; // Đặt vị trí ban đầu ngoài màn hình
            lblMarquee.Text = "Cán bộ đào tạo đóng vai trò quan trọng trong việc tổ chức, quản lý và nâng cao chất lượng giáo dục. Họ chịu trách nhiệm xây dựng, cập nhật chương trình giảng dạy, đảm bảo nội dung đào tạo phù hợp với yêu cầu thực tiễn. Bên cạnh đó, họ điều phối lịch học, hỗ trợ giảng viên và sinh viên trong quá trình học tập, đồng thời giám sát, đánh giá hiệu quả giảng dạy để không ngừng cải thiện chất lượng đào tạo. Ngoài ra, cán bộ đào tạo còn tư vấn, hướng dẫn sinh viên trong việc đăng ký học phần, thực tập và định hướng nghề nghiệp. Với vai trò kết nối giữa nhà trường, giảng viên và sinh viên, họ góp phần xây dựng môi trường học tập chuyên nghiệp, hiện đại và hiệu quả."; // Nội dung hiển thị
            lblMarquee.AutoSize = true; // Để chữ không bị cắt mất
            timer2.Interval = 100; // Điều chỉnh tốc độ chạy
            timer2.Tick += timer2_Tick; // Gán sự kiện Timer
            timer2.Start(); // Bắt đầu Timer
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            xPosition -= 5; // Giảm vị trí X để chữ chạy từ phải sang trái

            if (xPosition < -lblMarquee.Width) // Khi chữ ra khỏi màn hình, đặt lại vị trí
            {
                xPosition = this.Width;
            }

            lblMarquee.Left = xPosition; // Cập nhật vị trí Label
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            index = (index + 1) % images.Length; // Lặp lại khi hết ảnh
            pictureBox1.Image = Image.FromFile(images[index]);
        }

        private void btnMenuQlyCBDT_Click(object sender, EventArgs e)
        {
            PnMain.Controls.Clear();
            FormQuanLyCBDT QlGV = new FormQuanLyCBDT();
            QlGV.TopLevel = false;
            QlGV.FormBorderStyle = FormBorderStyle.None;
            QlGV.Dock = DockStyle.Fill;
            PnMain.Controls.Add(QlGV);
            QlGV.Show();
        }

        private void btnMenuQlyCBQL_Click(object sender, EventArgs e)
        {
            PnMain.Controls.Clear();
            FormQuanLyCBQL QlGV = new FormQuanLyCBQL();
            QlGV.TopLevel = false;
            QlGV.FormBorderStyle = FormBorderStyle.None;
            QlGV.Dock = DockStyle.Fill;
            PnMain.Controls.Add(QlGV);
            QlGV.Show();
        }
        private void btnMenuQlyIT_Click(object sender, EventArgs e)
        {
            PnMain.Controls.Clear();
            FormQuanLyIT QlGV = new FormQuanLyIT();
            QlGV.TopLevel = false;
            QlGV.FormBorderStyle = FormBorderStyle.None;
            QlGV.Dock = DockStyle.Fill;
            PnMain.Controls.Add(QlGV);
            QlGV.Show();
        }

        private void btnMenuQlyPhongBan_Click(object sender, EventArgs e)
        {
            PnMain.Controls.Clear();
            FormQuanLyPhongBan QlGV = new FormQuanLyPhongBan();
            QlGV.TopLevel = false;
            QlGV.FormBorderStyle = FormBorderStyle.None;
            QlGV.Dock = DockStyle.Fill;
            PnMain.Controls.Add(QlGV);
            QlGV.Show();
        }
    }
}
