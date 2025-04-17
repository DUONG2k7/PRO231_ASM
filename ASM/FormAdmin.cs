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
        public Control FindControlRecursive(Control parent, string name)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Name == name)
                    return c;

                Control found = FindControlRecursive(c, name);
                if (found != null)
                    return found;
            }
            return null;
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            tpIT.Controls.Clear();
            FormIT QlIT = new FormIT("IT1", "R01");
            QlIT.TopLevel = false;
            QlIT.FormBorderStyle = FormBorderStyle.None;
            QlIT.Dock = DockStyle.Fill;

            Control btnIT = FindControlRecursive(QlIT, "btnthoat");
            if (btnIT != null)
            {
                btnIT.Visible = false;
            }

            tpIT.Controls.Add(QlIT);
            QlIT.Show();

            tpCBDT.Controls.Clear();
            FormCBDT QlDT = new FormCBDT("DT1", "R02");
            QlDT.TopLevel = false;
            QlDT.FormBorderStyle = FormBorderStyle.None;
            QlDT.Dock = DockStyle.Fill;

            Control btnDT = FindControlRecursive(QlDT, "btnthoat");
            if (btnDT != null)
            {
                btnDT.Visible = false;
            }

            tpCBDT.Controls.Add(QlDT);
            QlDT.Show();

            tpCBQL.Controls.Clear();
            FormCBQL QlQL = new FormCBQL("QL1", "R03");
            QlQL.TopLevel = false;
            QlQL.FormBorderStyle = FormBorderStyle.None;
            QlQL.Dock = DockStyle.Fill;
            
            Control btnQL = FindControlRecursive(QlQL, "btnthoat");
            if (btnQL != null)
            {
                btnQL.Visible = false;
            }

            tpCBQL.Controls.Add(QlQL);
            QlQL.Show();

            tpGV.Controls.Clear();
            FormGV QlGV = new FormGV("GV1", "R04", "A20");
            QlGV.TopLevel = false;
            QlGV.FormBorderStyle = FormBorderStyle.None;
            QlGV.Dock = DockStyle.Fill;
            
            Control btnGV = FindControlRecursive(QlGV, "btnthoat");
            if (btnGV != null)
            {
                btnGV.Visible = false;
            }

            tpGV.Controls.Add(QlGV);
            QlGV.Show();

            tpSV.Controls.Clear();
            FormSV QlSV = new FormSV("SV1", "R05", "A25");
            QlSV.TopLevel = false;
            QlSV.FormBorderStyle = FormBorderStyle.None;
            QlSV.Dock = DockStyle.Fill;
            
            Control btnSV = FindControlRecursive(QlSV, "btnthoat");
            if (btnSV != null)
            {
                btnSV.Visible = false;
            }

            tpSV.Controls.Add(QlSV);
            QlSV.Show();
        }
    }
}
