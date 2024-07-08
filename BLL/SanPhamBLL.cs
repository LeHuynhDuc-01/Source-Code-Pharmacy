using DAL;
using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SanPhamBLL
    {
        private readonly SanPhamDAL _sanPhamDAL;

        public SanPhamBLL()
        {
            _sanPhamDAL = new SanPhamDAL();
        }

        public List<SanPhamDTO> GetLists()
        {
            try
            {
                return _sanPhamDAL.GetLists();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting SanPham list: " + ex.Message);
            }
        }

        public SanPhamDTO GetItem(int maSP)
        {
            try
            {
                return _sanPhamDAL.GetItem(maSP);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting SanPham item: " + ex.Message);
            }
        }

        public void AddItem(tbl_SANPHAM newItem)
        {
            try
            {
                _sanPhamDAL.AddItem(newItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding SanPham item: " + ex.Message);
            }
        }

        public void UpdateItem(tbl_SANPHAM updatedItem)
        {
            try
            {
                _sanPhamDAL.UpdateItem(updatedItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating SanPham item: " + ex.Message);
            }
        }

        public void DeleteItem(int maSP)
        {
            try
            {
                _sanPhamDAL.DeleteItem(maSP);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting SanPham item: " + ex.Message);
            }
        }
    }
}
