using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LoaiBLL
    {
        private readonly LoaiDAL _loaiDAL;

        public LoaiBLL()
        {
            _loaiDAL = new LoaiDAL();
        }

        public List<tbl_LOAI> GetLists()
        {
            try
            {
                return _loaiDAL.GetLists();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting Loai list: " + ex.Message);
            }
        }

        public tbl_LOAI GetItem(int id)
        {
            try
            {
                return _loaiDAL.GetItem(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting Loai item: " + ex.Message);
            }
        }

        public void AddItem(tbl_LOAI newItem)
        {
            try
            {
                _loaiDAL.AddItem(newItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding Loai item: " + ex.Message);
            }
        }

        public void UpdateItem(tbl_LOAI updatedItem)
        {
            try
            {
                _loaiDAL.UpdateItem(updatedItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating Loai item: " + ex.Message);
            }
        }

        public void DeleteItem(int id)
        {
            try
            {
                _loaiDAL.DeleteItem(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting Loai item: " + ex.Message);
            }
        }
    }
}
