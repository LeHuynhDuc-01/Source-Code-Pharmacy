using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class KhoBLL
    {
        private readonly KhoDAL _khoDAL;

        public KhoBLL()
        {
            _khoDAL = new KhoDAL();
        }

        public List<tbl_KHO> GetLists()
        {
            try
            {
                return _khoDAL.GetLists();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting Kho list: " + ex.Message);
            }
        }

        public tbl_KHO GetItem(string maKho)
        {
            try
            {
                return _khoDAL.GetItem(maKho);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting Kho item: " + ex.Message);
            }
        }

        public void AddItem(tbl_KHO newItem)
        {
            try
            {
                _khoDAL.AddItem(newItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding Kho item: " + ex.Message);
            }
        }

        public void UpdateItem(tbl_KHO updatedItem)
        {
            try
            {
                _khoDAL.UpdateItem(updatedItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating Kho item: " + ex.Message);
            }
        }

        public void DeleteItem(string maKho)
        {
            try
            {
                _khoDAL.DeleteItem(maKho);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting Kho item: " + ex.Message);
            }
        }

        public string MaKho()
        {
            var maxSoHD = _khoDAL.MaxKho();
            int so = int.Parse(maxSoHD.Substring(maxSoHD.Length - 3)) + 1;
            string shd = "KH" + so.ToString("000");
            return shd;
        }
    }
}
