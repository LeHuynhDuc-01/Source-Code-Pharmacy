using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NguoiDungBLL
    {
        private readonly NguoiDungDAL _nguoiDungDAL;

        public NguoiDungBLL()
        {
            _nguoiDungDAL = new NguoiDungDAL();
        }

        public List<tbl_NGUOIDUNG> GetLists()
        {
            try
            {
                return _nguoiDungDAL.GetLists();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting NguoiDung list: " + ex.Message);
            }
        }

        public tbl_NGUOIDUNG GetItem(string tenDangNhap)
        {
            try
            {
                return _nguoiDungDAL.GetItem(tenDangNhap);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting NguoiDung item: " + ex.Message);
            }
        }

        public void AddItem(tbl_NGUOIDUNG newItem)
        {
            try
            {
                _nguoiDungDAL.AddItem(newItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding NguoiDung item: " + ex.Message);
            }
        }

        public void UpdateItem(tbl_NGUOIDUNG updatedItem)
        {
            try
            {
                _nguoiDungDAL.UpdateItem(updatedItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating NguoiDung item: " + ex.Message);
            }
        }

        public void DeleteItem(string tenDangNhap)
        {
            try
            {
                _nguoiDungDAL.DeleteItem(tenDangNhap);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting NguoiDung item: " + ex.Message);
            }
        }
    }
}
