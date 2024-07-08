using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhieuNhapDAL
    {
        public List<PhieuNhapDTO> GetLists()
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var lst = db.tbl_PHIEUNHAP.Select(s => new PhieuNhapDTO
                    {
                        MaPN = s.MaPN,
                        MaDuocSi = s.MaDuocSi,
                        MaKho = s.MaKho,    
                        MaNCC = s.MaNCC,
                        NgayNhapHang = s.NgayNhapHang,
                        TenDuocSi = s.tbl_DUOCSI!= null ? s.tbl_DUOCSI.TenDuocSi : null,
                        TenKho = s.tbl_KHO!= null ? s.tbl_KHO.TenKho : null,  
                        TenNhaCungCap = s.tbl_NHACUNGCAP!= null ? s.tbl_NHACUNGCAP.TenNCC : null,

                        TongTien = s.TongTien,
                        TrangThai = s.TrangThai,
                    }).ToList();
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting PhieuNhap list: " + ex.Message);
            }
        }

        public PhieuNhapDTO GetItem(string maPN)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var item = db.tbl_PHIEUNHAP
                        .Where(s => s.MaPN == maPN)
                        .Select(s => new PhieuNhapDTO
                    {
                        MaPN = s.MaPN,
                        MaDuocSi = s.MaDuocSi,
                        MaKho = s.MaKho,
                        MaNCC = s.MaNCC,
                        NgayNhapHang = s.NgayNhapHang,
                        TenDuocSi = s.tbl_DUOCSI != null ? s.tbl_DUOCSI.TenDuocSi : null,
                        TenKho = s.tbl_KHO != null ? s.tbl_KHO.TenKho : null,
                        TenNhaCungCap = s.tbl_NHACUNGCAP != null ? s.tbl_NHACUNGCAP.TenNCC : null,
                        TongTien = s.TongTien,
                        TrangThai = s.TrangThai,
                    }).FirstOrDefault();
                    return item;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting PhieuNhap item: " + ex.Message);
            }
        }

        public void AddItem(tbl_PHIEUNHAP newItem)
        {

            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    db.tbl_PHIEUNHAP.Add(newItem);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error A Add: " + ex.Message);
            }
        }


        public void UpdateItem(tbl_PHIEUNHAP updatedItem)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var existingItem = db.tbl_PHIEUNHAP.Find(updatedItem.MaPN);
                    if (existingItem != null)
                    {
                        // Update properties of existingItem with the values from updatedItem
                        existingItem.MaDuocSi = updatedItem.MaDuocSi;
                        existingItem.TongTien = updatedItem.TongTien;
                        existingItem.NgayNhapHang = updatedItem.NgayNhapHang;
                        existingItem.TrangThai = updatedItem.TrangThai;
                        existingItem.MaNCC = updatedItem.MaNCC;
                        existingItem.MaKho = updatedItem.MaKho;

                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating PhieuNhap item: " + ex.Message);
            }
        }

        public void DeleteItem(string maPN)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var itemToDelete = db.tbl_PHIEUNHAP.Find(maPN);
                    if (itemToDelete != null)
                    {
                        db.tbl_PHIEUNHAP.Remove(itemToDelete);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting PhieuNhap item: " + ex.Message);
            }
        }
        public string MaxPhieuNhap()
        {
            using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
            {
                var _hd = db.tbl_PHIEUNHAP.OrderByDescending(x => x.MaPN).FirstOrDefault();
                if (_hd != null)
                    return _hd.MaPN;
                else
                    return "0000";
            };
        }
    }
}
