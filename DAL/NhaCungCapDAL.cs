using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhaCungCapDAL
    {
        public List<tbl_NHACUNGCAP> GetLists()
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    return db.tbl_NHACUNGCAP.ToList();
                }
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
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var item = db.tbl_NHACUNGCAP.FirstOrDefault(i => i.MaNCC == id);
                    return item;
                }
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
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    db.tbl_NHACUNGCAP.Add(newItem);
                    db.SaveChanges();
                }
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
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var existingItem = db.tbl_NHACUNGCAP.Find(updatedItem.MaNCC);
                    if (existingItem != null)
                    {
                        existingItem.TenNCC = updatedItem.TenNCC;
                        existingItem.SDT = updatedItem.SDT;
                        existingItem.Email = updatedItem.Email;
                        existingItem.DiaChi = updatedItem.DiaChi;

                        db.SaveChanges();
                    }
                }
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
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var itemToDelete = db.tbl_NHACUNGCAP.Find(id);
                    if (itemToDelete != null)
                    {
                        db.tbl_NHACUNGCAP.Remove(itemToDelete);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting Nhacungcap item: " + ex.Message);
            }
        }
    }
}
