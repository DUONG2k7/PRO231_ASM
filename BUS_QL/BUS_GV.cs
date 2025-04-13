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
    public class BUS_GV
    {
        DAL_GV QlGiaoVien = new DAL_GV();

        //Tất cả Form đều dùng
        public string GetMaLop(string taikhoan)
        {
            return QlGiaoVien.GetMaLop(taikhoan);
        }

        //Form Hiện Thị
        public DataTable GetData(string query, string Malop)
        {
            return QlGiaoVien.GetData(query, Malop);
        }

        //Form Quản Lý Điểm
        public DataTable LoadDsSinhVien(string IdGv, string IDLop, int IDMonHoc)
        {
            return QlGiaoVien.GetListStudent(IdGv, IDLop, IDMonHoc);
        }
        public DataTable LoadDsLop(string IdGv)
        {
            return QlGiaoVien.GetMaLopFormQuanLyDiem(IdGv);
        }
        public DataTable LoadDsMonHoc(string IdGv)
        {
            return QlGiaoVien.GetMaMonHocFormQuanLyDiem(IdGv);
        }
        public DataTable GetStudentsByPage(string Malop, string IdGv, int pageIndex, int pageSize)
        {
            return QlGiaoVien.GetStudentsByPage(Malop, IdGv, pageIndex, pageSize);
        }
        public string GetIdGvFromIdAcc(string Idacc)
        {
            return QlGiaoVien.GetIdGvFromIdAcc(Idacc);
        }
        public int GetIdMonhocFromIdGv_IDlop(string IdGv, string IDLop)
        {
            return QlGiaoVien.GetIdMonhocFromIdGv_IDlop(IdGv, IDLop);
        }
        public int GetTotalStudent(string maLop, string idGV)
        {
            return QlGiaoVien.GetTotalStudent(maLop, idGV);
        }
        public bool KtSvDaCoDiemChua(string maHs)
        {
            return QlGiaoVien.KtSvDaCoDiemChua(maHs);
        }
        public DataTable TimKiemSinhVien(string maLop, string maGV, string maSV)
        {
            return QlGiaoVien.SearchByID(maLop, maGV, maSV);
        }
        public bool ThemDiem(DTO_GV_DIEM DiemSV, out string message)
        {
            return QlGiaoVien.InsertGrade(DiemSV, out message);
        }
        public bool CapNhattDiem(DTO_GV_DIEM DiemSV, out string message)
        {
            return QlGiaoVien.UpdateGrade(DiemSV, out message);
        }

        //Form lịch dạy
        public DataTable LayDsLichDay(string IDGV)
        {
            return QlGiaoVien.GetListLichDay(IDGV);
        }
        public DataTable LoadDsLopGvDangDay(string IDGV)
        {
            return QlGiaoVien.GetListClassOfTeacher(IDGV);
        }
        public DataTable LoadDsMonHocGvDangDay(string IDGV, string IDLOP)
        {
            return QlGiaoVien.GetListSubjectOfTeacher(IDGV, IDLOP);
        }
        //Form Điểm danh
        public DataTable LoadDsSinhVienDiemDanh(string IDLop, int lichhoc, DateTime ngaydiemdanh)
        {
            return QlGiaoVien.GetListSinhVienDiemDanh(IDLop, lichhoc, ngaydiemdanh);
        }
        public int LayIDLichHOC(string IDLop, int IDmonhoc, string IDGV, int idkyhoc)
        {
            return QlGiaoVien.GetIDLichHoc(IDLop, IDmonhoc, IDGV, idkyhoc);
        }
        public DateTime? LayNgayDiemdanh(int IDLichhoc)
        {
            return QlGiaoVien.GetNgayDiemdanh(IDLichhoc);
        }
        public string GetTenLop(int IDLop)
        {
            return QlGiaoVien.GetTenLop(IDLop);
        }
        public string GetTenMon(int IDMonHoc)
        {
            return QlGiaoVien.GetTenMon(IDMonHoc);
        }
        public bool XoaDiemDanhCu(DTO_GV_DIEMDANH d, out string errorMessage)
        {
            return QlGiaoVien.XoaDiemDanhCu(d, out errorMessage);
        }
        public bool ThemDiemDanh(DTO_GV_DIEMDANH d, out string errorMessage)
        {
            return QlGiaoVien.ThemDiemDanh(d, out errorMessage);
        }
        public DataTable LoadDsBaoCaoDiemDanh(int idLichHoc, DateTime Ngay)
        {
            return QlGiaoVien.GetListBaoCaoDiemDanh(idLichHoc, Ngay);
        }

        //Form Tra cứu sv
        public DataTable LoadDsThongTinSinhVien(string IDSV)
        {
            return QlGiaoVien.GetInfoSv(IDSV);
        }
        public DataTable GetListDiem(string IDSV)
        {
            return QlGiaoVien.GetListDiem(IDSV);
        }
    }
}
