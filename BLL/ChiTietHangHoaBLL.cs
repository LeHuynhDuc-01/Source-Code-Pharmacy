using DAL;
using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChiTietHangHoaBLL
    {
        private readonly ChiTietHangHoaDAL _chiTietHangHoaDAL;

        public ChiTietHangHoaBLL()
        {
            _chiTietHangHoaDAL = new ChiTietHangHoaDAL();
        }

        public List<tbl_CHITIETHANGHOA> GetLists()
        {
            try
            {
                return _chiTietHangHoaDAL.GetLists();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting ChiTietHangHoa list: " + ex.Message);
            }
        }
        public List<ChiTietHangHoaDTO> GetListDTOs()
        {
            try
            {
                return _chiTietHangHoaDAL.GetListDTOs();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting ChiTietHangHoa list: " + ex.Message);
            }
        }

        public tbl_CHITIETHANGHOA GetItem(string maCTSP)
        {
            try
            {
                return _chiTietHangHoaDAL.GetItem(maCTSP);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting ChiTietHangHoa item: " + ex.Message);
            }
        }

        public void AddItem(tbl_CHITIETHANGHOA newItem)
        {
            try
            {
                _chiTietHangHoaDAL.AddItem(newItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding ChiTietHangHoa item: " + ex.Message);
            }
        }

        public void UpdateItem(tbl_CHITIETHANGHOA updatedItem)
        {
            try
            {
                _chiTietHangHoaDAL.UpdateItem(updatedItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating ChiTietHangHoa item: " + ex.Message);
            }
        }

        public void DeleteItem(string maCTSP)
        {
            try
            {
                _chiTietHangHoaDAL.DeleteItem(maCTSP);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting ChiTietHangHoa item: " + ex.Message);
            }
        }

        public string MaCTHangHoa(int masp)
        {
            var maxSoHD = _chiTietHangHoaDAL.MaxChiTietHangHoas();
            int twoDigitYear = DateTime.Now.Year % 100;
            string twoDigitYearString = twoDigitYear.ToString("00");
            int so = int.Parse(maxSoHD.Substring(Math.Max(0, maxSoHD.Length - 3))) + 1;
            string monthPart = DateTime.Now.Month.ToString("00");
            string soPart = so.ToString("000");
            string maPhieuNhap = twoDigitYearString + monthPart +masp.ToString("000")+ soPart;
            return maPhieuNhap;
        }
    }
}
