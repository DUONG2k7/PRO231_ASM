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
using System.Web.Security;
using System.Windows.Forms;

namespace ASM
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }
        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormAdmin_Load(object sender, EventArgs e)
        {
            tpIT.Controls.Clear();
            FormIT QlIT = new FormIT("I", "R01");
            QlIT.TopLevel = false;
            QlIT.FormBorderStyle = FormBorderStyle.None;
            QlIT.Dock = DockStyle.Fill;
            tpIT.Controls.Add(QlIT);
            QlIT.Show();

            tpCBDT.Controls.Clear();
            FormCBDT QlDT = new FormCBDT("DT", "R02");
            QlDT.TopLevel = false;
            QlDT.FormBorderStyle = FormBorderStyle.None;
            QlDT.Dock = DockStyle.Fill;
            tpCBDT.Controls.Add(QlDT);
            QlDT.Show();

            tpCBQL.Controls.Clear();
            FormCBQL QlQL = new FormCBQL("QL", "R03");
            QlQL.TopLevel = false;
            QlQL.FormBorderStyle = FormBorderStyle.None;
            QlQL.Dock = DockStyle.Fill;
            tpCBQL.Controls.Add(QlQL);
            QlQL.Show();

            tpGV.Controls.Clear();
            FormGV QlGV = new FormGV("GV", "R04", "A08");
            QlGV.TopLevel = false;
            QlGV.FormBorderStyle = FormBorderStyle.None;
            QlGV.Dock = DockStyle.Fill;
            tpGV.Controls.Add(QlGV);
            QlGV.Show();

            tpSV.Controls.Clear();
            FormSV QlSV = new FormSV("SV", "R05", "A11");
            QlSV.TopLevel = false;
            QlSV.FormBorderStyle = FormBorderStyle.None;
            QlSV.Dock = DockStyle.Fill;
            tpSV.Controls.Add(QlSV);
            QlSV.Show();
        }
    }
}
