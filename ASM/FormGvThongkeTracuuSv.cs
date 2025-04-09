using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASM
{
    public partial class FormGvThongkeTracuuSv : Form
    {
        string TK;
        int KyHoc;
        public FormGvThongkeTracuuSv(string tk, int kyhoc)
        {
            InitializeComponent();
            TK = tk;
            KyHoc = kyhoc;
        }

        private void FormGvThongkeTracuuSv_Load(object sender, EventArgs e)
        {
            tpThongke.Controls.Clear();
            FormDanhSachHienThi QlGV1 = new FormDanhSachHienThi(TK);
            QlGV1.TopLevel = false;
            QlGV1.FormBorderStyle = FormBorderStyle.None;
            QlGV1.Dock = DockStyle.Fill;
            tpThongke.Controls.Add(QlGV1);
            QlGV1.Show();

            tpTraCuu.Controls.Clear();
            FormGvTraCuuSv QlGV2 = new FormGvTraCuuSv(KyHoc);
            QlGV2.TopLevel = false;
            QlGV2.FormBorderStyle = FormBorderStyle.None;
            QlGV2.Dock = DockStyle.Fill;
            tpTraCuu.Controls.Add(QlGV2);
            QlGV2.Show();
        }

        private void guna2TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tpThongke_Click(object sender, EventArgs e)
        {

        }

        private void tpTraCuu_Click(object sender, EventArgs e)
        {

        }
    }
}
