using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class ChiTietPhieuNhapDTO
    {
 
        public string MaCTPN { get; set; }
        public string MaPN { get; set; }
        public string MACTSP { get; set; }
        public System.DateTime NgayNhap { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> HSD { get; set; }
        public Nullable<System.DateTime> NSX { get; set; }
        public Nullable<double> GiaNhap { get; set; }
        public Nullable<double> GiaBan { get; set; }
        public Nullable<double> TongTien { get; set; }
        public string TenSP { get; set; }
        public Nullable<int> MaSP { get; set; }
        public Nullable<int> MaLoai { get; set; }
        public string TenLoai { get; set; }
        public string TenKho { get; set; }



    }
}
