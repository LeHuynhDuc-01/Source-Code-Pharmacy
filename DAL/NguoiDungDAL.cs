using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NguoiDungDAL
    {
        public List<tbl_NGUOIDUNG> GetLists()
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    return db.tbl_NGUOIDUNG.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting NguoiDung list: " + ex.Message);
            }
        }

        public tbl_NGUOIDUNG GetItem(string tenDangNhap)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var item = db.tbl_NGUOIDUNG.FirstOrDefault(i => i.TenDangNhap == tenDangNhap);
                    return item;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting NguoiDung item: " + ex.Message);
            }
        }

        public void AddItem(tbl_NGUOIDUNG newItem)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    db.tbl_NGUOIDUNG.Add(newItem);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding NguoiDung item: " + ex.Message);
            }
        }

        public void UpdateItem(tbl_NGUOIDUNG updatedItem)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var existingItem = db.tbl_NGUOIDUNG.Find(updatedItem.TenDangNhap);
                    if (existingItem != null)
                    {
                        existingItem.MatKhau = updatedItem.MatKhau;
                        existingItem.QuanTri = updatedItem.QuanTri;

                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating NguoiDung item: " + ex.Message);
            }
        }

        public void DeleteItem(string tenDangNhap)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var itemToDelete = db.tbl_NGUOIDUNG.Find(tenDangNhap);
                    if (itemToDelete != null)
                    {
                        db.tbl_NGUOIDUNG.Remove(itemToDelete);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting NguoiDung item: " + ex.Message);
            }
        }
    }
}
