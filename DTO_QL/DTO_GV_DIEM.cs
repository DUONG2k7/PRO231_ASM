using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QL
{
    public class DTO_GV_DIEM
    {
        public int IDKyHoc { get; set; }
        public string IDSV { get; set; }
        public int IDMonHoc { get; set; }
        public string DiemLab { get; set; }
        public string DiemASM { get; set; }
        public string DiemThi { get; set; }
         
        public DTO_GV_DIEM(int idKyHoc, string idSV, int idMonHoc, string diemLab, string diemASM, string diemThi)
        {
            IDKyHoc = idKyHoc;
            IDSV = idSV;
            IDMonHoc = idMonHoc;
            DiemLab = diemLab;
            DiemASM = diemASM;
            DiemThi = diemThi;
        }
    }
}
