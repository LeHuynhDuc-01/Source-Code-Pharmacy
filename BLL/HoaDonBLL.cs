using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HoaDonBLL
    {
        private HoaDonDAL _hoaDonDAL;

        public HoaDonBLL()
        {
            _hoaDonDAL = new HoaDonDAL();
        }

        public List<tbl_HOADON> GetLists()
        {
            try
            {
                return _hoaDonDAL.GetLists();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public tbl_HOADON GetItem(string id)
        {
            try
            {
                return _hoaDonDAL.GetItem(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddItem(tbl_HOADON newItem)
        {
            try
            {
                _hoaDonDAL.AddItem(newItem);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateItem(tbl_HOADON updatedItem)
        {
            try
            {
                _hoaDonDAL.UpdateItem(updatedItem);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteItem(string id)
        {
            try
            {
                _hoaDonDAL.DeleteItem(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteHoaDonAndCTHD(string maHD)
        {
            try
            {
                _hoaDonDAL.DeleteHoaDonAndCTHD(maHD);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string MaHD()
        {
            var maxSoHD = _hoaDonDAL.MaxHoaDon();
            int twoDigitYear = DateTime.Now.Year % 100;
            string twoDigitYearString = twoDigitYear.ToString("00");
            int so = int.Parse(maxSoHD.Substring(Math.Max(0, maxSoHD.Length - 6))) + 1;
            string monthPart = DateTime.Now.Month.ToString("00");
            string soPart = so.ToString("000000");
            string maPhieuNhap = twoDigitYearString + monthPart + soPart;
            return maPhieuNhap;
        }
    }
}
