using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhoDAL
    {
        public List<tbl_KHO> GetLists()
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    return db.tbl_KHO.ToList();
                }
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
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    return db.tbl_KHO.FirstOrDefault(k => k.MaKho == maKho);
                }
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
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    db.tbl_KHO.Add(newItem);
                    db.SaveChanges();
                }
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
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var existingItem = db.tbl_KHO.Find(updatedItem.MaKho);
                    if (existingItem != null)
                    {
                        // Update properties of existingItem with the values from updatedItem
                        existingItem.ViTri = updatedItem.ViTri;
                        existingItem.TenKho = updatedItem.TenKho;

                        db.SaveChanges();
                    }
                }
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
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var itemToDelete = db.tbl_KHO.Find(maKho);
                    if (itemToDelete != null)
                    {
                        db.tbl_KHO.Remove(itemToDelete);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting Kho item: " + ex.Message);
            }
        }
        public string MaxKho()
        {
            using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
            {
                var _hd = db.tbl_KHO.OrderByDescending(x => x.MaKho).FirstOrDefault();
                if (_hd != null)
                    return _hd.MaKho;
                else
                    return "001";
            };
        }
    }
}
