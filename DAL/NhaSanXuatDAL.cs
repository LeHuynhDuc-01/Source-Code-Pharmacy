using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhaSanXuatDAL
    {
        
        public List<tbl_NHASANXUAT> GetLists()
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    return db.tbl_NHASANXUAT.ToList();
                }    
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public tbl_NHASANXUAT GetItem(int id)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var item = db.tbl_NHASANXUAT.FirstOrDefault(i => i.MaNSX == id);
                    return item;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AddItem(tbl_NHASANXUAT newItem)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    db.tbl_NHASANXUAT.Add(newItem);
                    db.SaveChanges();
                }
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
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var existingItem = db.tbl_NHASANXUAT.Find(updatedItem.MaNSX);
                    if (existingItem != null)
                    {
                        // Update properties of existingItem with the values from updatedItem
                        existingItem.TenNSX = updatedItem.TenNSX;

                        db.SaveChanges();
                    }
                }
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
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var itemToDelete = db.tbl_NHASANXUAT.Find(id);
                    if (itemToDelete != null)
                    {
                        db.tbl_NHASANXUAT.Remove(itemToDelete);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting NhaSanXuat item: " + ex.Message);
            }
        }
    }
}
