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
    public partial class FormSvXemLichHoc : Form
    {
        BUS_SV QlLichHocSv = new BUS_SV();
        public FormSvXemLichHoc(string IDacc)
        {
            InitializeComponent();
            LoadDsLichHocGV(IDacc);

            dgvLichHoc.Columns["Ngày"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dgvLichHoc.Columns.Contains("Mã Kỳ"))
            {
                dgvLichHoc.Columns["Mã Kỳ"].Visible = false;
            }
            if (dgvLichHoc.Columns.Contains("Loại Ngày"))
            {
                dgvLichHoc.Columns["Loại Ngày"].Visible = false;
            }
            if (dgvLichHoc.Columns.Contains("Mã Lớp"))
            {
                dgvLichHoc.Columns["Mã Lớp"].Visible = false;
            }
            if (dgvLichHoc.Columns.Contains("Mã Giảng Viên"))
            {
                dgvLichHoc.Columns["Mã Giảng Viên"].Visible = false;
            }
        }
        public void LoadDsLichHocGV(string IDacc)
        {
            dgvLichHoc.DataSource = QlLichHocSv.LoadDsLichHocSv(IDacc);
        }
    }
}
