using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class KhachHangBLL
    {
        private readonly KhachHangDAL _khachHangDAL;

        public KhachHangBLL()
        {
            _khachHangDAL = new KhachHangDAL();
        }

        public List<tbl_KHACHHANG> GetLists()
        {
            try
            {
                return _khachHangDAL.GetLists();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting KhachHang list: " + ex.Message);
            }
        }

        public tbl_KHACHHANG GetItem(int maKH)
        {
            try
            {
                return _khachHangDAL.GetItem(maKH);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting KhachHang item: " + ex.Message);
            }
        }

        public void AddItem(tbl_KHACHHANG newItem)
        {
            try
            {
                _khachHangDAL.AddItem(newItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding KhachHang item: " + ex.Message);
            }
        }

        public void UpdateItem(tbl_KHACHHANG updatedItem)
        {
            try
            {
                _khachHangDAL.UpdateItem(updatedItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating KhachHang item: " + ex.Message);
            }
        }

        public void DeleteItem(int maKH)
        {
            try
            {
                _khachHangDAL.DeleteItem(maKH);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting KhachHang item: " + ex.Message);
            }
        }
    }
}
