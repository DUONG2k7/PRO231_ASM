using DAL_QL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QL;

namespace BUS_QL
{
    public class BUS_IT
    {
        DAL_IT TruyVanTaiKhoan = new DAL_IT();

        public DataTable LoadDsTk(string IDRole)
        {
            return TruyVanTaiKhoan.GetListAccount(IDRole);
        }
        public DataTable LoadDsRoleLocDuLieu()
        {
            return TruyVanTaiKhoan.GetListRoleLocDuLieu();
        }
        public DataTable LoadDsRole()
        {
            return TruyVanTaiKhoan.GetListRole();
        }
        public DataTable LoadDsChuaCoTaiKhoan(string ROLE)
        {
            return TruyVanTaiKhoan.GetListChuaCoTaiKhoan(ROLE);
        }
        public DataTable LoadLichSu(string idAcc)
        {
            return TruyVanTaiKhoan.GetListHistory(idAcc);
        }
        public string LayRoleCuaTk(string mataikhoan)
        {
            return TruyVanTaiKhoan.GetRole(mataikhoan);
        }
        public bool AddNewAccount(DTO_IT_IT taikhoan, out string message)
        {
            return TruyVanTaiKhoan.InsertAccount(taikhoan, out message);
        }
        public bool UpdateAccount(DTO_IT_IT taikhoan, out string message)
        {
            return TruyVanTaiKhoan.UpdateAccount(taikhoan, out message);
        }
        public bool LockOrUnlockAccount(string idAcc)
        {
            return TruyVanTaiKhoan.LockOrUnlockAccount(idAcc);
        }
        public bool KtSoLuongTkIT(string idAcc)
        {
            return TruyVanTaiKhoan.KtSlRoleAdmin(idAcc);
        }
        public string CreateID(string prefix)
        {
            return TruyVanTaiKhoan.CreateNewId(prefix);
        }
        public bool KtTkDaTonTai(string maTk)
        {
            return TruyVanTaiKhoan.KtTkDaTonTai(maTk);
        }

        //Form quản lý tin tức
        public DataTable LoadDsTinTuc()
        {
            return TruyVanTaiKhoan.GetListNews();
        }
        public bool ThemTinTuc(DTO_IT_TINTUC tinTuc, out string message)
        {
            return TruyVanTaiKhoan.InsertNews(tinTuc, out message);
        }
        public bool CapNhatTinTuc(DTO_IT_TINTUC tinTuc, out string message)
        {
            return TruyVanTaiKhoan.UpdateNews(tinTuc, out message);
        }
        public bool LockOrUnlockNews(int IDTin)
        {
            return TruyVanTaiKhoan.LockOrUnlockNews(IDTin);
        }
        public string CreateIDTinTuc(string prefix)
        {
            return TruyVanTaiKhoan.CreateNewIdTinTuc(prefix);
        }

        //Form hiện tin tức
        public int GetTotalNews()
        {
            return TruyVanTaiKhoan.GetTotalNews();
        }
        public DataTable LayDsTinTuc(int id)
        {
            return TruyVanTaiKhoan.GetAllNews(id);
        }
    }
}
