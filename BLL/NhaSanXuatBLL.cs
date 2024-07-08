using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class NhaSanXuatBLL
    {
        private readonly NhaSanXuatDAL _nhaSanXuatDAL;

        public NhaSanXuatBLL()
        {
            _nhaSanXuatDAL = new NhaSanXuatDAL();
        }

        public List<tbl_NHASANXUAT> GetLists()
        {
            try
            {
                return _nhaSanXuatDAL.GetLists();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting NhaSanXuat list: " + ex.Message);
            }
        }

        public tbl_NHASANXUAT GetItem(int id)
        {
            try
            {
                return _nhaSanXuatDAL.GetItem(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting NhaSanXuat item: " + ex.Message);
            }
        }

        public void AddItem(tbl_NHASANXUAT newItem)
        {
            try
            {
                _nhaSanXuatDAL.AddItem(newItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding NhaSanXuat item: " + ex.Message);
            }
        }

        public void UpdateItem(tbl_NHASANXUAT updatedItem)
        {
            try
            {
                _nhaSanXuatDAL.UpdateItem(updatedItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating NhaSanXuat item: " + ex.Message);
            }
        }

        public void DeleteItem(int id)
        {
            try
            {
                _nhaSanXuatDAL.DeleteItem(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting NhaSanXuat item: " + ex.Message);
            }
        }


    }
}
