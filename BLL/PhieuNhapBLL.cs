using DAL;
using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhieuNhapBLL
    {
        private readonly PhieuNhapDAL _phieuNhapDAL;

        public PhieuNhapBLL()
        {
            _phieuNhapDAL = new PhieuNhapDAL();
        }

        public List<PhieuNhapDTO> GetLists()
        {
            try
            {
                return _phieuNhapDAL.GetLists();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting PhieuNhap list: " + ex.Message);
            }
        }

        public PhieuNhapDTO GetItem(string maPN)
        {
            try
            {
                return _phieuNhapDAL.GetItem(maPN);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting PhieuNhap item: " + ex.Message);
            }
        }

        public void AddItem(tbl_PHIEUNHAP newItem)
        {

            try
            {
                _phieuNhapDAL.AddItem(newItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Error B adding PhieuNhap item: " + ex.Message);
            }
        }

        public void UpdateItem(tbl_PHIEUNHAP updatedItem)
        {
            try
            {
                _phieuNhapDAL.UpdateItem(updatedItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating PhieuNhap item: " + ex.Message);
            }
        }

        public void DeleteItem(string maPN)
        {
            try
            {
                _phieuNhapDAL.DeleteItem(maPN);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting PhieuNhap item: " + ex.Message);
            }
        }

        public void TongTienNhap(string maPN)
        {
            try
            {
                using(tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities ())
                {
                    var item = db.tbl_PHIEUNHAP.FirstOrDefault(x => x.MaPN ==  maPN);
                    var tongTien = item.tbl_CTPHIEUNHAP.Sum(x => x.TongTien) ?? 0;
                    if (item.tbl_CTPHIEUNHAP.Count != 0)
                    {
                        item.TrangThai = true;
                    }
                    item.TongTien = tongTien;
                    db.SaveChanges();
                }    
            }
            catch (Exception ex)
            {
                throw new Exception("Error updateting soluong PhieuNhap item: " + ex.Message);
            }
        }    
        public string MaPhieuNhap()
        {
            var maxSoHD = _phieuNhapDAL.MaxPhieuNhap();
            int so = int.Parse(maxSoHD.Substring(Math.Max(0, maxSoHD.Length - 4))) + 1;

            string yearPart = DateTime.Now.Year.ToString("0000");
            string monthPart = DateTime.Now.Month.ToString("00");
            string soPart = so.ToString("0000");

            string maPhieuNhap = yearPart + monthPart + soPart;

            return maPhieuNhap;
        }
    }
}
