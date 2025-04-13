using DAL_QL;
using DTO_QL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QL
{
    public class BUS_CBQL
    {
        DAL_CBQL QlThongTin = new DAL_CBQL();

        public DataTable GetListStaffWithNOPhongBan()
        {
            return QlThongTin.GetListStaffWithNOPhongBan();
        }
        public bool Update(DTO_CBQL_IT IT, out string message)
        {
            return QlThongTin.Update(IT, out message);
        }

        //IT
        public DataTable LoadDsIT(int id)
        {
            return QlThongTin.GetListIT(id);
        }
        public bool ThemIT(DTO_CBQL_IT IT, out string message)
        {
            return QlThongTin.InsertIT(IT, out message);
        }
        public bool CapNhatIT(DTO_CBQL_IT IT, out string message)
        {
            return QlThongTin.UpdateIT(IT, out message);
        }
        public string CreateNewItId(string prefix)
        {
            return QlThongTin.CreateNewItId(prefix);
        }

        //CBDT
        public DataTable LoadDsCBDT(int id)
        {
            return QlThongTin.GetListCBDT(id);
        }
        public bool ThemCBDT(DTO_CBQL_CBDT CBDT, out string message)
        {
            return QlThongTin.InsertCBDT(CBDT, out message);
        }
        public bool CapNhatCBDT(DTO_CBQL_CBDT CBDT, out string message)
        {
            return QlThongTin.UpdateCBDT(CBDT, out message);
        }
        public string CreateNewCBDTId(string prefix)
        {
            return QlThongTin.CreateNewCBDTId(prefix);
        }

        //CBQL
        public DataTable LoadDsCBQL(int id)
        {
            return QlThongTin.GetListCBQL(id);
        }
        public bool ThemCBQL(DTO_CBQL_CBQL CBQL, out string message)
        {
            return QlThongTin.InsertCBQL(CBQL, out message);
        }
        public bool CapNhatCBQL(DTO_CBQL_CBQL CBQL, out string message)
        {
            return QlThongTin.UpdateCBQL(CBQL, out message);
        }
        public string CreateNewCBQLId(string prefix)
        {
            return QlThongTin.CreateNewCBQLId(prefix);
        }

        //Phòng ban
        public DataTable LoadDsPhongBan()
        {
            return QlThongTin.GetListPhongBan();
        }
        public DataTable LoadDsPhong()
        {
            return QlThongTin.GetListPhong();
        }
        public DataTable LoadLoaiPhong()
        {
            return QlThongTin.GetListRole();
        }
        public DataTable GetRoleFromIDPhong(int IDPhong)
        {
            return QlThongTin.GetRoleFromIDPhong(IDPhong);
        }
        public bool ThemPhong(string TenPhong, string IDROle, out string message)
        {
            return QlThongTin.InsertPhong(TenPhong, IDROle, out message);
        }
        public bool CapNhatPhong(int IDPhong, string TenPhong, string newIDRole, out string message)
        {
            return QlThongTin.UpdatePhong(IDPhong, TenPhong, newIDRole, out message);
        }
    }
}
