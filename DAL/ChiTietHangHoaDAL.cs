using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChiTietHangHoaDAL
    {

        public List<ChiTietHangHoaDTO> GetListDTOs()
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    return db.tbl_CHITIETHANGHOA.Select(s => new ChiTietHangHoaDTO
                    {
                        MACTSP = s.MACTSP,
                        SoLuong = s.SoLuong,
                        HSD = s.HSD,
                        NSX = s.NSX,
                        MASP = s.MASP,
                        GiaNhap = s.GiaNhap,
                        GiaBan = s.GiaBan,
                        MaKho = s.MaKho,
                        TenKho = s.tbl_KHO != null ? s.tbl_KHO.TenKho : null,
                        TenSP = s.tbl_SANPHAM != null ? s.tbl_SANPHAM.TenSP : null,
                        ThanhPhan = s.tbl_SANPHAM != null ? s.tbl_SANPHAM.ThanhPhan : null,
                        MaNSX = s.tbl_SANPHAM != null ? s.tbl_SANPHAM.MaNSX : null,
                        HinhAnh = s.tbl_SANPHAM != null ? s.tbl_SANPHAM.HinhAnh : null,
                        TenLoai = s.tbl_SANPHAM != null ? s.tbl_SANPHAM.tbl_LOAI != null ? s.tbl_SANPHAM.tbl_LOAI.TenLoai : null : null,
                        TenNSX = s.tbl_SANPHAM != null ? s.tbl_SANPHAM.tbl_NHASANXUAT != null ? s.tbl_SANPHAM.tbl_NHASANXUAT.TenNSX : null : null,
                        MaLoai = s.tbl_SANPHAM != null ? s.tbl_SANPHAM.MaLoai : null,
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting CTPhieuNhap list: " + ex.Message);
            }
           
        }
        public ChiTietHangHoaDTO GetItemDTOs(string MaCTSP)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var item = db.tbl_CHITIETHANGHOA
                        .Where(s => s.MACTSP == MaCTSP)
                        .Select(s => new ChiTietHangHoaDTO
                        {
                            MACTSP = s.MACTSP,
                            SoLuong = s.SoLuong,
                            HSD = s.HSD,
                            NSX = s.NSX,
                            MASP = s.MASP,
                            GiaNhap = s.GiaNhap,
                            GiaBan = s.GiaBan,
                            MaKho = s.MaKho,
                            TenKho = s.tbl_KHO != null ? s.tbl_KHO.TenKho : null,
                            TenSP = s.tbl_SANPHAM != null ? s.tbl_SANPHAM.TenSP : null,
                            ThanhPhan = s.tbl_SANPHAM != null ? s.tbl_SANPHAM.ThanhPhan : null,
                            MaNSX = s.tbl_SANPHAM != null ? s.tbl_SANPHAM.MaNSX : null,
                            HinhAnh = s.tbl_SANPHAM != null ? s.tbl_SANPHAM.HinhAnh : null,
                            TenLoai = s.tbl_SANPHAM != null ? s.tbl_SANPHAM.tbl_LOAI != null ? s.tbl_SANPHAM.tbl_LOAI.TenLoai : null : null,
                            TenNSX = s.tbl_SANPHAM != null ? s.tbl_SANPHAM.tbl_NHASANXUAT != null ? s.tbl_SANPHAM.tbl_NHASANXUAT.TenNSX : null : null,
                            MaLoai = s.tbl_SANPHAM != null ? s.tbl_SANPHAM.MaLoai : null,
                        }).FirstOrDefault();
                    return item;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting CTPhieuNhap list: " + ex.Message);
            }
        }

        public List<tbl_CHITIETHANGHOA> GetLists()
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    return db.tbl_CHITIETHANGHOA.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting ChiTietHangHoa list: " + ex.Message);
            }
        }

        public tbl_CHITIETHANGHOA GetItem(string maCTSP)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    return db.tbl_CHITIETHANGHOA.FirstOrDefault(ctsp => ctsp.MACTSP == maCTSP);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting ChiTietHangHoa item: " + ex.Message);
            }
        }

        public void AddItem(tbl_CHITIETHANGHOA newItem)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    db.tbl_CHITIETHANGHOA.Add(newItem);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding ChiTietHangHoa item: " + ex.Message);
            }
        }

        public void UpdateItem(tbl_CHITIETHANGHOA updatedItem)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var existingItem = db.tbl_CHITIETHANGHOA.Find(updatedItem.MACTSP);
                    if (existingItem != null)
                    {
                        // Update properties of existingItem with the values from updatedItem
                        existingItem.SoLuong = updatedItem.SoLuong;
                        existingItem.HSD = updatedItem.HSD;
                        existingItem.NSX = updatedItem.NSX;
                        existingItem.MASP = updatedItem.MASP;
                        existingItem.GiaNhap = updatedItem.GiaNhap;
                        existingItem.GiaBan = updatedItem.GiaBan;
                        existingItem.MaKho = updatedItem.MaKho;

                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating ChiTietHangHoa item: " + ex.Message);
            }
        }

        public void DeleteItem(string maCTSP)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var itemToDelete = db.tbl_CHITIETHANGHOA.Find(maCTSP);
                    if (itemToDelete != null)
                    {
                        db.tbl_CHITIETHANGHOA.Remove(itemToDelete);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting ChiTietHangHoa item: " + ex.Message);
            }
        }

        public string MaxChiTietHangHoas()
        {
            using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
            {
                var _hd = db.tbl_CHITIETHANGHOA.OrderByDescending(x => x.MACTSP).FirstOrDefault();
                if (_hd != null)
                    return _hd.MACTSP;
                else
                    return "000000";
            };
        }
    }
}