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
    public partial class FormMain : Form
    {
        BUS_IT qltintuc = new BUS_IT();
        int max;
        int IdTinTuc;
        FormLogin formLogin;
        public FormMain()
        {
            InitializeComponent();
            max = qltintuc.GetTotalNews();
            if (max > 0)
            {
                IdTinTuc = GetNextID();
                LoadInfoTinTuc(IdTinTuc);

                timerND.Interval = 5000;
                timerND.Tick += timerND_Tick;
                timerND.Start();
            }
        }
        public int GetNextID()
        {
            IdTinTuc++;

            if (IdTinTuc > max)
                IdTinTuc = 1; // Quay lại từ đầu

            return IdTinTuc;
        }
        public void LoadInfoTinTuc(int id)
        {
            DataTable dt = qltintuc.LayDsTinTuc(id);
            if (dt.Rows.Count > 0)
            {
                pnTinTuc.Controls.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    UcTinTuc tin = new UcTinTuc();
                    tin.TieuDe = row["Title"].ToString();
                    tin.NoiDung = row["Content"].ToString();

                    byte[] imgBytes = row["Hinh"] as byte[];
                    if (imgBytes != null && imgBytes.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(imgBytes))
                        {
                            tin.HinhAnh = Image.FromStream(ms);
                        }
                    }

                    pnTinTuc.Controls.Add(tin);
                }
            }
        }
        private void timerND_Tick(object sender, EventArgs e)
        {
            IdTinTuc = GetNextID();
            LoadInfoTinTuc(IdTinTuc);
        }
        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            formLogin = new FormLogin();
            formLogin.FormClosed += (s, args) => this.Hide();
            formLogin.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Xác nhận thoát !", "Message", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (kq == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
