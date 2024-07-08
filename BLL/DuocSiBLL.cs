using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DuocSiBLL
    {
        private readonly DuocSiDAL _duocSiDAL;
        public DuocSiBLL()
        {
            _duocSiDAL = new DuocSiDAL();
        }

        public List<tbl_DUOCSI> GetLists()
        {
            try
            {
                return _duocSiDAL.GetLists();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting DuocSi list: " + ex.Message);
            }
        }
        

             public tbl_DUOCSI GetItemDS(string userName)
        {
            try
            {
                return _duocSiDAL.GetItemWithTK(userName);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting DuocSi item: " + ex.Message);
            }
        }
        public tbl_DUOCSI GetItem(int maDuocSi)
        {
            try
            {
                return _duocSiDAL.GetItem(maDuocSi);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting DuocSi item: " + ex.Message);
            }
        }

        public void AddItem(tbl_DUOCSI newItem)
        {
            try
            {
                _duocSiDAL.AddItem(newItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding DuocSi item: " + ex.Message);
            }
        }

        public void UpdateItem(tbl_DUOCSI updatedItem)
        {
            try
            {
                _duocSiDAL.UpdateItem(updatedItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating DuocSi item: " + ex.Message);
            }
        }

        public void DeleteItem(int maDuocSi)
        {
            try
            {
                _duocSiDAL.DeleteItem(maDuocSi);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting DuocSi item: " + ex.Message);
            }
        }
    }
}
