using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DuocSiDAL
    {
        public List<tbl_DUOCSI> GetLists()
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    return db.tbl_DUOCSI.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting DuocSi list: " + ex.Message);
            }
        }
        public tbl_DUOCSI GetItemWithTK(string user)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var item = db.tbl_DUOCSI.FirstOrDefault(i => i.TenDangNhap == user);
                    return item;
                }
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
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var item = db.tbl_DUOCSI.FirstOrDefault(i => i.MaDuocSi == maDuocSi);
                    return item;
                }
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
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    db.tbl_DUOCSI.Add(newItem);
                    db.SaveChanges();
                }
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
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var existingItem = db.tbl_DUOCSI.Find(updatedItem.MaDuocSi);
                    if (existingItem != null)
                    {
                        existingItem.TenDuocSi = updatedItem.TenDuocSi;
                        existingItem.SDT = updatedItem.SDT;
                        existingItem.Email = updatedItem.Email;
                        existingItem.DiaChi = updatedItem.DiaChi;
                        existingItem.TenDangNhap = updatedItem.TenDangNhap;

                        db.SaveChanges();
                    }
                }
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
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var itemToDelete = db.tbl_DUOCSI.Find(maDuocSi);
                    if (itemToDelete != null)
                    {
                        db.tbl_DUOCSI.Remove(itemToDelete);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting DuocSi item: " + ex.Message);
            }
        }
    }
}
