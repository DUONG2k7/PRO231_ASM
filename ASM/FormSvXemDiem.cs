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
    public partial class FormSvXemDiem : Form
    {
        BUS_SV QlSvXemDIem = new BUS_SV();
        string idACC;
        public FormSvXemDiem(string idacc)
        {
            InitializeComponent();
            idACC = idacc;
            LoadDsKyHoc();
            cbHocKy.SelectedValueChanged += cbHocKy_SelectedIndexChanged;
            LoadDSDIEM(idACC, Convert.ToInt32(cbHocKy.SelectedValue));
        }
        public void LoadDsKyHoc()
        {
            cbHocKy.DataSource = QlSvXemDIem.LoadDsKyhoc();
            cbHocKy.DisplayMember = "TenKy";
            cbHocKy.ValueMember = "IDKyHoc";
        }
        public void LoadDSDIEM(string IDACC, int IDKYHOC)
        {
            dgvDiem.DataSource = QlSvXemDIem.LayDiem(IDACC, IDKYHOC);
        }

        private void cbHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbHocKy.SelectedValue is DataRowView rowView)
            {
                int selectedKyHoc = Convert.ToInt32(rowView["IDKyHoc"]);
                LoadDSDIEM(idACC, selectedKyHoc);
            }
            else
            {
                int selectedKyHoc = Convert.ToInt32(cbHocKy.SelectedValue);
                LoadDSDIEM(idACC, selectedKyHoc);
            }
        }
    }
}
