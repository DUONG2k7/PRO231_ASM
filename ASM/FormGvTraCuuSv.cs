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
    public partial class FormGvTraCuuSv : Form
    {
        BUS_GV QlGvtracuugv = new BUS_GV();
        int IDKyhoc;
        public FormGvTraCuuSv(int idkyhoc)
        {
            InitializeComponent();
            IDKyhoc = idkyhoc;
        }
        public bool LoadInfoSv(string IDSV)
        {
            DataTable dt = QlGvtracuugv.LoadDsThongTinSinhVien(IDSV);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtHoTen.Text = row["Tên Sinh Viên"].ToString();
                txtIDLop.Text = row["Mã Lớp"].ToString();
                txtEmail.Text = row["Email"].ToString();
                txtSDT.Text = row["Số Điện Thoại"].ToString();
                txtDiaChi.Text = row["Địa Chỉ"].ToString();
                txtGioiTinh.Text = row["Giới Tính"].ToString() == "1" ? "Nam" : "Nữ";
                byte[] image = row["Hình"] as byte[];
                if (image != null && image.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(image))
                    {
                        pbAnhSv.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pbAnhSv.Image = null;
                    pbAnhSv.Visible = false;
                }
                return true;
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maSinhVien = txtTimkiem.Text.Trim();
            if (LoadInfoSv(maSinhVien))
            {
                dgvDiem.DataSource = QlGvtracuugv.GetListDiem(maSinhVien);
            }
            else
            {
                dgvDiem.DataSource = null;
                pbAnhSv.Image = null;
                txtHoTen.Text = "";
                txtIDLop.Text = "";
                txtEmail.Text = "";
                txtSDT.Text = "";
                txtDiaChi.Text = "";
                txtGioiTinh.Text = "";
            }
        }
    }
}
