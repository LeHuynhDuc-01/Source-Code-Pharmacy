using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class HoaDonDAL
    {
        public List<tbl_HOADON> GetLists()
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    return db.tbl_HOADON.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public tbl_HOADON GetItem(string id)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    return db.tbl_HOADON.FirstOrDefault(i => i.MaHD == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddItem(tbl_HOADON newItem)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    db.tbl_HOADON.Add(newItem);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding HoaDon item: " + ex.Message);
            }
        }

        public void UpdateItem(tbl_HOADON updatedItem)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var existingItem = db.tbl_HOADON.Find(updatedItem.MaHD);
                    if (existingItem != null)
                    {
                        // Update properties of existingItem with the values from updatedItem
                        existingItem.MaDuocSi = updatedItem.MaDuocSi;
                        existingItem.NgayLap = updatedItem.NgayLap;
                        existingItem.TongTien = updatedItem.TongTien;
                        existingItem.MaKH = updatedItem.MaKH;
                        existingItem.Thang = updatedItem.Thang;
                        existingItem.Nam = updatedItem.Nam;

                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating HoaDon item: " + ex.Message);
            }
        }

        public void DeleteItem(string id)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var itemToDelete = db.tbl_HOADON.Find(id);
                    if (itemToDelete != null)
                    {
                        db.tbl_HOADON.Remove(itemToDelete);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting HoaDon item: " + ex.Message);
            }
        }

        public string MaxHoaDon()
        {
            using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
            {
                var _hd = db.tbl_HOADON.OrderByDescending(x => x.MaHD).FirstOrDefault();
                if (_hd != null)
                    return _hd.MaHD;
                else
                    return "000000";
            };
        }

        public void DeleteHoaDonAndCTHD(string maHD)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    // Xóa tất cả chi tiết hóa đơn liên quan
                    var cthdList = db.tbl_CTHOADON.Where(ct => ct.MaHD == maHD).ToList();
                    foreach (var cthd in cthdList)
                    {
                        var item = db.tbl_CHITIETHANGHOA.FirstOrDefault(s=>s.MACTSP== cthd.MaCTSP);
                        if (item != null)
                        {
                            item.SoLuong += cthd.SoLuong;
                        }    
                        db.tbl_CTHOADON.Remove(cthd);
                    }

                    // Xóa hóa đơn
                    var hoaDon = db.tbl_HOADON.Find(maHD);
                    if (hoaDon != null)
                    {
                        db.tbl_HOADON.Remove(hoaDon);
                    }

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
