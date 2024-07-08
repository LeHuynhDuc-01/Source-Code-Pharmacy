using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class BaoCaoCTHoaDonDTO
    {
        public string MaHD { get; set; }
        public string MaCTSP { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<double> GiaBan { get; set; }
        public Nullable<double> DonGia { get; set; }
        public string MaCTHD { get; set; }
        public string TenSP { get; set; }
        public Nullable<DateTime> NgayLap { get; set; }
        public string DuocSi { get; set; }
    }
}
