using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class ChiTietHangHoaDTO
    {
        public string MACTSP { get; set; }
        public int? SoLuong { get; set; }
        public int? MaLoai { get; set; }
        public double? HSD { get; set; }
        public DateTime? NSX { get; set; }
        public int? MASP { get; set; }
        public double? GiaNhap { get; set; }
        public double? GiaBan { get; set; }
        public string MaKho { get; set; }
        public string TenKho { get; set; }
        public string TenSP { get; set; }
        public string ThanhPhan { get; set; }
        public int? MaNSX { get; set; }
        public byte[] HinhAnh { get; set; }
        public string TenLoai { get; set; }
        public string TenNSX { get; set; }
    }
}
