using DAL;
using DAL.DTO;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CTHoaDonBLL
    {
        private CTHoaDonDAL _ctHoaDonDAL;
        private ChiTietHangHoaDAL _ctHangHoaDAL;
        private HoaDonDAL _hoaDonDAL;

        public CTHoaDonBLL()
        {
            _ctHoaDonDAL = new CTHoaDonDAL();
            _ctHangHoaDAL = new ChiTietHangHoaDAL();
            _hoaDonDAL = new HoaDonDAL();
        }

        public List<tbl_CTHOADON> GetLists()
        {
            try
            {
                return _ctHoaDonDAL.GetLists();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<BaoCaoCTHoaDonDTO> GetListDTOsWithDay(DateTime dateStart, DateTime dateEnd)
        {
            try
            {
                return _ctHoaDonDAL.GetListDTOsWithDay(dateStart, dateEnd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<BaoCaoCTHoaDonDTO> GetListDTOsWithDay(DateTime dateStart, DateTime dateEnd, int maDuocSi)
        {
            try
            {
                return _ctHoaDonDAL.GetListDTOsWithDay(dateStart, dateEnd, maDuocSi);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int GetSoLuongDon(DateTime dateStart, DateTime dateEnd)
        {
            try
            {
                return _ctHoaDonDAL.GetListDTOsWithDay(dateStart, dateEnd).Count;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int GetSoLuongDon(DateTime dateStart, DateTime dateEnd, int maDuocSi)
        {
            try
            {
                return _ctHoaDonDAL.GetListDTOsWithDay(dateStart, dateEnd, maDuocSi).Count;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public double GetTongTien(DateTime dateStart, DateTime dateEnd)
        {
            try
            {
                return (double)_ctHoaDonDAL.GetListDTOsWithDay(dateStart, dateEnd).Sum(s =>s.DonGia);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public double GetTongTien(DateTime dateStart, DateTime dateEnd, int maDuocSi)
        {
            try
            {
                return (double)_ctHoaDonDAL.GetListDTOsWithDay(dateStart, dateEnd, maDuocSi).Sum(s => s.DonGia);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<BaoCaoCTHoaDonDTO> GetAllListDTOs()
        {
            try
            {
                return _ctHoaDonDAL.GetAllListDTOs();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<ChiTietHoaDonDTO> GetListDTOs(string maHd)
        {
            try
            {
                return _ctHoaDonDAL.GetListDTOs(maHd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public tbl_CTHOADON GetItem(string id)
        {
            try
            {
                return _ctHoaDonDAL.GetItem(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddItem(tbl_CTHOADON newItem)
        {
            try
            {
                _ctHoaDonDAL.AddItem(newItem);
                newItem = _SaveData(newItem);
                _ctHoaDonDAL.UpdateItem(newItem);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        tbl_CTHOADON _SaveData(tbl_CTHOADON updatedItem)
        {
            var itemHangHoa = _ctHangHoaDAL.GetItem(updatedItem.MaCTSP);
            if (itemHangHoa != null)
            {
                var sl = itemHangHoa.SoLuong - updatedItem.SoLuong;
                itemHangHoa.SoLuong = sl;
                _ctHangHoaDAL.UpdateItem(itemHangHoa);
                updatedItem.DonGia = updatedItem.SoLuong * itemHangHoa.GiaBan;
                var item = _hoaDonDAL.GetItem(updatedItem.MaHD);
                item.TongTien = GetTotalPriceByMaHD(updatedItem.MaHD);
                _hoaDonDAL.UpdateItem(item);
            }
            return updatedItem;
        }
    
        public void UpdateItem(tbl_CTHOADON updatedItem)
        {
            try
            {
                _ctHoaDonDAL.UpdateItem(updatedItem);
                updatedItem = _SaveData(updatedItem);
                _ctHoaDonDAL.UpdateItem(updatedItem);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteItem(int id)
        {
            try
            {
                _ctHoaDonDAL.DeleteItem(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public double GetTotalPriceByMaHD(string maHD)
        {
            try
            {
                return _ctHoaDonDAL.GetTotalPriceByMaHD(maHD);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteItemWithMaCTSP(string MaCTSP)
        {
            try
            {
                var itemHangHoa = _ctHangHoaDAL.GetItem(MaCTSP);
                var itemCTHoaDon = _ctHoaDonDAL.GetItemWithMaCTSP(MaCTSP);
                if (itemHangHoa != null && itemCTHoaDon != null)
                {
                    var sl = itemHangHoa.SoLuong + itemCTHoaDon.SoLuong;
                    itemHangHoa.SoLuong = sl;
                    _ctHangHoaDAL.UpdateItem(itemHangHoa);
                    var item = _hoaDonDAL.GetItem(itemCTHoaDon.MaHD);
                    item.TongTien = GetTotalPriceByMaHD(itemCTHoaDon.MaHD);
                    _hoaDonDAL.UpdateItem(item);
                    _ctHoaDonDAL.DeleteItemWithMaCTSP(MaCTSP);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}