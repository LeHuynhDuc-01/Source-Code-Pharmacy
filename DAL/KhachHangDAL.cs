using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhachHangDAL
    {
        public List<tbl_KHACHHANG> GetLists()
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    return db.tbl_KHACHHANG.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting KhachHang list: " + ex.Message);
            }
        }

        public tbl_KHACHHANG GetItem(int maKH)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var item = db.tbl_KHACHHANG.FirstOrDefault(i => i.MaKH == maKH);
                    return item;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting KhachHang item: " + ex.Message);
            }
        }

        public void AddItem(tbl_KHACHHANG newItem)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    db.tbl_KHACHHANG.Add(newItem);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding KhachHang item: " + ex.Message);
            }
        }

        public void UpdateItem(tbl_KHACHHANG updatedItem)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var existingItem = db.tbl_KHACHHANG.Find(updatedItem.MaKH);
                    if (existingItem != null)
                    {
                        existingItem.TenKH = updatedItem.TenKH;
                        existingItem.SDT = updatedItem.SDT;
                        existingItem.DiaChi = updatedItem.DiaChi;

                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating KhachHang item: " + ex.Message);
            }
        }

        public void DeleteItem(int maKH)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var itemToDelete = db.tbl_KHACHHANG.Find(maKH);
                    if (itemToDelete != null)
                    {
                        db.tbl_KHACHHANG.Remove(itemToDelete);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting KhachHang item: " + ex.Message);
            }
        }
    }
}
