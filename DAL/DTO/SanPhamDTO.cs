using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class SanPhamDTO
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string ThanhPhan { get; set; }
        public Nullable<int> MaNSX { get; set; }
        public Nullable<int> MaLoai { get; set; }
        public byte[] HinhAnh { get; set; }
        public Nullable<double> Gia { get; set; }
        public String TenNSX { get; set; }
        public string TenLoai { get; set; }
    }
}
