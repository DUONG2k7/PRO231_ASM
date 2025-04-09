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
    public partial class FormSvXemLichThi : Form
    {
        BUS_SV QlLichThiSv = new BUS_SV();
        public FormSvXemLichThi(string IDacc)
        {
            InitializeComponent();
            LoadDsLichThiGV(IDacc);

            dgvLichThi.Columns["Ngày"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dgvLichThi.Columns.Contains("Mã Kỳ"))
            {
                dgvLichThi.Columns["Mã Kỳ"].Visible = false;
            }
            if (dgvLichThi.Columns.Contains("Loại Ngày"))
            {
                dgvLichThi.Columns["Loại Ngày"].Visible = false;
            }
            if (dgvLichThi.Columns.Contains("Mã Lớp"))
            {
                dgvLichThi.Columns["Mã Lớp"].Visible = false;
            }
            if (dgvLichThi.Columns.Contains("Mã Giảng Viên"))
            {
                dgvLichThi.Columns["Mã Giảng Viên"].Visible = false;
            }
        }
        public void LoadDsLichThiGV(string IDacc)
        {
            dgvLichThi.DataSource = QlLichThiSv.LoadDsLichThiSv(IDacc);
        }
    }
}
