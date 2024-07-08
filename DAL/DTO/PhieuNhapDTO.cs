using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class PhieuNhapDTO
    {
        public string MaPN { get; set; }
        public int MaDuocSi { get; set; }
        public Nullable<double> TongTien { get; set; }
        public Nullable<System.DateTime> NgayNhapHang { get; set; }
        public Nullable<bool> TrangThai { get; set; }
        public Nullable<int> MaNCC { get; set; }
        public string MaKho { get; set; }
        public string TenKho { get; set; }
        public string TenDuocSi { get; set; }
        public string TenNhaCungCap { get; set; }
    }
}
