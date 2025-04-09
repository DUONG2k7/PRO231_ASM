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
    public partial class FormTinTuc : Form
    {
        BUS_IT qltintuc = new BUS_IT();
        int max;
        int IdTinTuc;
        private int xPosition;

        public FormTinTuc()
        {
            InitializeComponent();
            LoadInfoTinTuc();
            //max = qltintuc.GetTotalNews();
            //if (max > 0)
            //{
            //    //đổi tin tức theo kiểu random hoặc tăng dần ( đang tăng dần )
            //    //GetRandomID();
            //    IdTinTuc = GetNextID();
            //    LoadInfoTinTuc();

            //    //Nội dung
            //    timerND.Interval = 100;
            //    timerND.Tick += timerND_Tick;
            //    timerND.Start();
            //}
            //else
            //{
            //    MessageBox.Show("Không có dữ liệu tin tức để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }
        //public int GetRandomID()
        //{
        //    Random random = new Random();
        //    int newId;

        //    do
        //    {
        //        newId = random.Next(1, max + 1);
        //    } while (newId == IdTinTuc); // Lặp lại nếu trùng số trước

        //    return newId;
        //}
        //public int GetNextID()
        //{
        //    IdTinTuc++;

        //    if (IdTinTuc > max)
        //        IdTinTuc = 1; // Quay lại từ đầu

        //    return IdTinTuc;
        //}
        public void LoadInfoTinTuc()
        {
            DataTable dt = qltintuc.LayDsTinTuc();
            if (dt.Rows.Count > 0)
            {
                flpTinTuc.Controls.Clear();

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

                    flpTinTuc.Controls.Add(tin);
                }
            }
            else
            {
                MessageBox.Show("Không có tin tức để hiển thị.");
            }
        }
        //private void timerND_Tick(object sender, EventArgs e)
        //{
        //    xPosition -= 5;

        //    lbNoidung.Left = xPosition;
        //    if (xPosition + lbNoidung.Width < 0)
        //    {
        //        //đổi tin tức theo kiểu random hoặc tăng dần ( đang tăng dần )
        //        //IdTinTuc = GetRandomID();
        //        IdTinTuc = GetNextID();
        //        LoadInfoTinTuc(IdTinTuc);

        //        xPosition = this.Width;
        //    }
        //}
    }
}