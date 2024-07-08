using DAL;
using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChiTietPhieuNhapBLL
    {
        private readonly ChiTietPhieuNhapDAL _ctPhieuNhapDAL;

        public ChiTietPhieuNhapBLL()
        {
            _ctPhieuNhapDAL = new ChiTietPhieuNhapDAL();
        }

        public List<tbl_CTPHIEUNHAP> GetLists()
        {
            try
            {
                return _ctPhieuNhapDAL.GetLists();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting CTPhieuNhap list: " + ex.Message);
            }
        }
        public List<ChiTietPhieuNhapDTO> GetListDTONhap(int soLuong)
        {
            try
            {
                return _ctPhieuNhapDAL.GetListDTONhap(soLuong);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting CTPhieuNhap list: " + ex.Message);
            }
        }
        public List<ChiTietPhieuNhapDTO> GetListDTONhap(int soLuong, string maKho)
        {
            try
            {
                return _ctPhieuNhapDAL.GetListDTONhap(soLuong, maKho);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting CTPhieuNhap list: " + ex.Message);
            }
        }

        public List<ChiTietPhieuNhapDTO> GetListDTOs()
        {
            try
            {
                return _ctPhieuNhapDAL.GetListDTOs();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting CTPhieuNhap list: " + ex.Message);
            }
        }
        public List<ChiTietPhieuNhapDTO> GetListDTObyKho(string makho)
        {
            try
            {
                return _ctPhieuNhapDAL.GetListDTOByKho(makho);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting CTPhieuNhap list: " + ex.Message);
            }
        }
        public List<ChiTietPhieuNhapDTO> GetListDTObyPhieuNhap(string maPN)
        {
            try
            {
                return _ctPhieuNhapDAL.GetListDTObyMaHD(maPN);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting CTPhieuNhap list: " + ex.Message);
            }
        }

        public tbl_CTPHIEUNHAP GetItem(string maCTPN)
        {
            try
            {
                return _ctPhieuNhapDAL.GetItem(maCTPN);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting CTPhieuNhap item: " + ex.Message);
            }
        }

        public ChiTietPhieuNhapDTO GetItemDTO(string maCTPN)
        {
            try
            {
                return _ctPhieuNhapDAL.GetItemDTOs(maCTPN);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting CTPhieuNhap item: " + ex.Message);
            }
        }

        public void AddItem(tbl_CTPHIEUNHAP newItem)
        {
            try
            {
                _ctPhieuNhapDAL.AddItem(newItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding CTPhieuNhap item: " + ex.Message);
            }
        }

        public void UpdateItem(tbl_CTPHIEUNHAP updatedItem)
        {
            try
            {
                _ctPhieuNhapDAL.UpdateItem(updatedItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating CTPhieuNhap item: " + ex.Message);
            }
        }

        public void DeleteItem(string maCTPN)
        {
            try
            {
                _ctPhieuNhapDAL.DeleteItem(maCTPN);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting CTPhieuNhap item: " + ex.Message);
            }
        }


    }
}
