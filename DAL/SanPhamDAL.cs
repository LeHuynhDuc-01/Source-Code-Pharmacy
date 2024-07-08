using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SanPhamDAL
    {
        public List<SanPhamDTO> GetLists()
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var lst = db.tbl_SANPHAM.Select(s => new SanPhamDTO
                    {
                        MaSP = s.MaSP,
                        TenSP = s.TenSP,
                        Gia = s.Gia,
                        ThanhPhan = s.ThanhPhan,
                        HinhAnh = s.HinhAnh,
                        MaLoai = s.MaLoai,
                        MaNSX = s.MaNSX,
                        TenLoai = s.tbl_LOAI != null ? s.tbl_LOAI.TenLoai : null,
                        TenNSX = s.tbl_NHASANXUAT != null ? s.tbl_NHASANXUAT.TenNSX : null,
                    }).ToList();
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting SanPham list: " + ex.Message);
            }
        }

        public SanPhamDTO GetItem(int maSP)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var item = db.tbl_SANPHAM
                        .Where(s => s.MaSP == maSP)
                        .Select(s => new SanPhamDTO
                    {
                        MaSP = s.MaSP,
                        TenSP = s.TenSP,
                        Gia = s.Gia,
                        ThanhPhan = s.ThanhPhan,
                        HinhAnh = s.HinhAnh,
                        MaLoai = s.MaLoai,
                        MaNSX = s.MaNSX,
                        TenLoai = s.tbl_LOAI != null ? s.tbl_LOAI.TenLoai : null,
                        TenNSX = s.tbl_NHASANXUAT != null ? s.tbl_NHASANXUAT.TenNSX : null,
                    }).FirstOrDefault();
                    return item;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting SanPham item: " + ex.Message);
            }
        }

        public void AddItem(tbl_SANPHAM newItem)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    db.tbl_SANPHAM.Add(newItem);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding SanPham item: " + ex.Message);
            }
        }

        public void UpdateItem(tbl_SANPHAM updatedItem)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var existingItem = db.tbl_SANPHAM.Find(updatedItem.MaSP);
                    if (existingItem != null)
                    {
                        existingItem.TenSP = updatedItem.TenSP;
                        existingItem.ThanhPhan = updatedItem.ThanhPhan;
                        existingItem.Gia = updatedItem.Gia;
                        existingItem.MaNSX = updatedItem.MaNSX;
                        existingItem.MaLoai = updatedItem.MaLoai;
                        existingItem.HinhAnh = updatedItem.HinhAnh;


                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating SanPham item: " + ex.Message);
            }
        }

        public void DeleteItem(int maSP)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var itemToDelete = db.tbl_SANPHAM.Find(maSP);
                    if (itemToDelete != null)
                    {
                        db.tbl_SANPHAM.Remove(itemToDelete);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting SanPham item: " + ex.Message);
            }
        }
    }
}
