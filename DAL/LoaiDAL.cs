using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoaiDAL
    {
        public List<tbl_LOAI> GetLists()
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    return db.tbl_LOAI.ToList();
                }
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
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var item = db.tbl_LOAI.FirstOrDefault(i => i.MaLoai == id);
                    return item;
                }
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
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    db.tbl_LOAI.Add(newItem);
                    db.SaveChanges();
                }
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
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var existingItem = db.tbl_LOAI.Find(updatedItem.MaLoai);
                    if (existingItem != null)
                    {
                        existingItem.TenLoai = updatedItem.TenLoai;

                        db.SaveChanges();
                    }
                }
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
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var itemToDelete = db.tbl_LOAI.Find(id);
                    if (itemToDelete != null)
                    {
                        db.tbl_LOAI.Remove(itemToDelete);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting Loai item: " + ex.Message);
            }
        }
    }
}
