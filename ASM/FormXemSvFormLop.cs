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
    public partial class FormXemSvFormLop : Form
    {
        BUS_CBDT QlLop = new BUS_CBDT();
        string IDLOP;
        public FormXemSvFormLop(string idlop)
        {
            InitializeComponent();
            IDLOP = idlop;
            Loaddata();
            if (dgvBaoCao.Columns.Contains("Hình"))
            {
                dgvBaoCao.Columns["Hình"].Visible = false;
            }
            dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void Loaddata()
        {
            dgvBaoCao.DataSource = QlLop.LoadDsSinhVien(IDLOP);
            dgvBaoCao.Columns[0].Visible = false;
            DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)dgvBaoCao.Columns["Hình"];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
    }
}
