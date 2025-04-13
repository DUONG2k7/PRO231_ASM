using BUS_QL;
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
    public partial class FormXemNvFormPhongBan : Form
    {
        BUS_CBQL QlPB = new BUS_CBQL();
        int IDP;
        public FormXemNvFormPhongBan(int idp)
        {
            InitializeComponent();
            IDP = idp;
            Loaddata();
            if (dgvBaoCao.Columns.Contains("Hình"))
            {
                dgvBaoCao.Columns["Hình"].Visible = false;
            }
            dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void Loaddata()
        {
            if (IDP == 0)
            {
                dgvBaoCao.DataSource = QlPB.GetListStaffWithNOPhongBan();
                return;
            }

            DataTable dtRole = QlPB.GetRoleFromIDPhong(IDP);
            if (dtRole.Rows.Count == 0)
            {
                dgvBaoCao.DataSource = null;
                MessageBox.Show("Không tìm thấy role tương ứng với phòng ban.");
                return;
            }

            string idRole = dtRole.Rows[0]["IDRole"].ToString().Trim();
            switch (idRole)
            {
                case "R01":
                    dgvBaoCao.DataSource = QlPB.LoadDsIT(IDP);
                    break;
                case "R02":
                    dgvBaoCao.DataSource = QlPB.LoadDsCBDT(IDP);
                    break;
                case "R03":
                    dgvBaoCao.DataSource = QlPB.LoadDsCBQL(IDP);
                    break;
            }

            DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)dgvBaoCao.Columns["Hình"];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
    }
}
