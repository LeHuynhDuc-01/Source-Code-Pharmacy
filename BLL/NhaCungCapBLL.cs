using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhaCungCapBLL
    {
        private readonly NhaCungCapDAL _nhacungcapDAL;

        public NhaCungCapBLL()
        {
            _nhacungcapDAL = new NhaCungCapDAL();
        }

        public List<tbl_NHACUNGCAP> GetLists()
        {
            try
            {
                return _nhacungcapDAL.GetLists();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting Nhacungcap list: " + ex.Message);
            }
        }

        public tbl_NHACUNGCAP GetItem(int id)
        {
            try
            {
                return _nhacungcapDAL.GetItem(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting Nhacungcap item: " + ex.Message);
            }
        }

        public void AddItem(tbl_NHACUNGCAP newItem)
        {
            try
            {
                _nhacungcapDAL.AddItem(newItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding Nhacungcap item: " + ex.Message);
            }
        }

        public void UpdateItem(tbl_NHACUNGCAP updatedItem)
        {
            try
            {
                _nhacungcapDAL.UpdateItem(updatedItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating Nhacungcap item: " + ex.Message);
            }
        }

        public void DeleteItem(int id)
        {
            try
            {
                _nhacungcapDAL.DeleteItem(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting Nhacungcap item: " + ex.Message);
            }
        }
    }
}
