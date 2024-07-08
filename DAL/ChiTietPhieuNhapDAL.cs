using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChiTietPhieuNhapDAL
    {
        public List<tbl_CTPHIEUNHAP> GetLists()
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    return db.tbl_CTPHIEUNHAP.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting CTPhieuNhap list: " + ex.Message);
            }
        }
        public List<ChiTietPhieuNhapDTO> GetListDTOs()
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var lst = db.tbl_CTPHIEUNHAP
                        .Select(s => new ChiTietPhieuNhapDTO 
                    {
                        GiaBan = s.tbl_CHITIETHANGHOA != null ? s.tbl_CHITIETHANGHOA.GiaBan : null,
                        GiaNhap = s.tbl_CHITIETHANGHOA.GiaNhap ,
                        HSD = s.tbl_CHITIETHANGHOA.HSD ,
                            MaCTPN = s.MaCTPN,
                            MACTSP =s.MACTSP,
                            SoLuong = s.tbl_CHITIETHANGHOA.SoLuong,
                            TenSP= s.tbl_CHITIETHANGHOA.tbl_SANPHAM!= null ? s.tbl_CHITIETHANGHOA.tbl_SANPHAM.TenSP : null,
                            MaPN = s.MaPN,
                            TenKho = s.tbl_CHITIETHANGHOA.tbl_KHO != null ? s.tbl_CHITIETHANGHOA.tbl_KHO.TenKho : null,
                            NgayNhap = s.NgayNhap,
                            NSX = s.tbl_CHITIETHANGHOA.NSX,
                            TongTien = s.TongTien
                        }).ToList();
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting CTPhieuNhap list: " + ex.Message);
            }
        }
        public List<ChiTietPhieuNhapDTO> GetListDTONhap(int soLuong)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var lst = db.tbl_CTPHIEUNHAP
                        .Where(s=> s.tbl_CHITIETHANGHOA.SoLuong <= soLuong)
                        .Select(s => new ChiTietPhieuNhapDTO
                        {
                            GiaBan = s.tbl_CHITIETHANGHOA != null ? s.tbl_CHITIETHANGHOA.GiaBan : null,
                            GiaNhap = s.tbl_CHITIETHANGHOA.GiaNhap,
                            HSD = s.tbl_CHITIETHANGHOA.HSD,
                            MaCTPN = s.MaCTPN,
                            MACTSP = s.MACTSP,
                            SoLuong = s.tbl_CHITIETHANGHOA.SoLuong,
                            TenSP = s.tbl_CHITIETHANGHOA.tbl_SANPHAM != null ? s.tbl_CHITIETHANGHOA.tbl_SANPHAM.TenSP : null,
                            MaPN = s.MaPN,
                            NgayNhap = s.NgayNhap,
                            TenKho = s.tbl_CHITIETHANGHOA.tbl_KHO != null ? s.tbl_CHITIETHANGHOA.tbl_KHO.TenKho : null,
                            NSX = s.tbl_CHITIETHANGHOA.NSX,
                            TongTien = s.TongTien
                        }).ToList();
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting CTPhieuNhap list: " + ex.Message);
            }
        }
        public List<ChiTietPhieuNhapDTO> GetListDTONhap(int soLuong, string maKho)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var lst = db.tbl_CTPHIEUNHAP
                        .Where(s => s.tbl_CHITIETHANGHOA.SoLuong <= soLuong && s.tbl_CHITIETHANGHOA.MaKho == maKho)
                        .Select(s => new ChiTietPhieuNhapDTO
                        {
                            GiaBan = s.tbl_CHITIETHANGHOA != null ? s.tbl_CHITIETHANGHOA.GiaBan : null,
                            GiaNhap = s.tbl_CHITIETHANGHOA.GiaNhap,
                            HSD = s.tbl_CHITIETHANGHOA.HSD,
                            MaCTPN = s.MaCTPN,
                            MACTSP = s.MACTSP,
                            SoLuong = s.tbl_CHITIETHANGHOA.SoLuong,
                            TenSP = s.tbl_CHITIETHANGHOA.tbl_SANPHAM != null ? s.tbl_CHITIETHANGHOA.tbl_SANPHAM.TenSP : null,
                            MaPN = s.MaPN,
                            TenKho = s.tbl_CHITIETHANGHOA.tbl_KHO != null ? s.tbl_CHITIETHANGHOA.tbl_KHO.TenKho : null,
                            NgayNhap = s.NgayNhap,
                            NSX = s.tbl_CHITIETHANGHOA.NSX,
                            TongTien = s.TongTien
                        }).ToList();
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting CTPhieuNhap list: " + ex.Message);
            }
        }
        public List<ChiTietPhieuNhapDTO> GetListDTOByKho(string maKho)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var lst = db.tbl_CTPHIEUNHAP
                        .Where(s => s.tbl_CHITIETHANGHOA.MaKho == maKho)
                        .Select(s => new ChiTietPhieuNhapDTO
                        {
                            GiaBan = s.tbl_CHITIETHANGHOA != null ? s.tbl_CHITIETHANGHOA.GiaBan : null,
                            GiaNhap = s.tbl_CHITIETHANGHOA.GiaNhap,
                            HSD = s.tbl_CHITIETHANGHOA.HSD,
                            MaCTPN = s.MaCTPN,
                            MACTSP = s.MACTSP,
                            SoLuong = s.tbl_CHITIETHANGHOA.SoLuong,
                            TenSP = s.tbl_CHITIETHANGHOA.tbl_SANPHAM != null ? s.tbl_CHITIETHANGHOA.tbl_SANPHAM.TenSP : null,
                            MaPN = s.MaPN,
                            TenKho = s.tbl_CHITIETHANGHOA.tbl_KHO != null ? s.tbl_CHITIETHANGHOA.tbl_KHO.TenKho : null,
                            NgayNhap = s.NgayNhap,
                            NSX = s.tbl_CHITIETHANGHOA.NSX,
                            TongTien = s.TongTien
                        }).ToList();
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting CTPhieuNhap list: " + ex.Message);
            }
        }
        public List<ChiTietPhieuNhapDTO> GetListDTObyMaHD(string maPn)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var lst = db.tbl_CTPHIEUNHAP
                        .Where(s => s.MaPN == maPn)
                        .Select(s => new ChiTietPhieuNhapDTO
                        {
                            GiaBan = s.tbl_CHITIETHANGHOA != null ? s.tbl_CHITIETHANGHOA.GiaBan : null,
                            GiaNhap = s.tbl_CHITIETHANGHOA.GiaNhap,
                            HSD = s.tbl_CHITIETHANGHOA.HSD,
                            MaCTPN = s.MaCTPN,
                            MACTSP = s.MACTSP,
                            SoLuong = s.tbl_CHITIETHANGHOA.SoLuong,
                            TenSP = s.tbl_CHITIETHANGHOA.tbl_SANPHAM != null ? s.tbl_CHITIETHANGHOA.tbl_SANPHAM.TenSP : null,
                            MaPN = s.MaPN,
                            NgayNhap = s.NgayNhap,
                            TenKho = s.tbl_CHITIETHANGHOA.tbl_KHO != null ? s.tbl_CHITIETHANGHOA.tbl_KHO.TenKho : null,
                            NSX = s.tbl_CHITIETHANGHOA.NSX,
                            TongTien = s.TongTien
                        }).ToList();
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting CTPhieuNhap list: " + ex.Message);
            }
        }
        public ChiTietPhieuNhapDTO GetItemDTOs(string MaCTPN)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var item = db.tbl_CTPHIEUNHAP
                        .Where(s => s.MaCTPN == MaCTPN)
                        .Select(s => new ChiTietPhieuNhapDTO
                        {
                            GiaBan = s.tbl_CHITIETHANGHOA != null ? s.tbl_CHITIETHANGHOA.GiaBan : null,
                            GiaNhap = s.tbl_CHITIETHANGHOA.GiaNhap,
                            HSD = s.tbl_CHITIETHANGHOA.HSD,
                            MaCTPN = s.MaCTPN,
                            MACTSP = s.MACTSP,
                            SoLuong = s.tbl_CHITIETHANGHOA.SoLuong,
                            TenSP = s.tbl_CHITIETHANGHOA.tbl_SANPHAM != null ? s.tbl_CHITIETHANGHOA.tbl_SANPHAM.TenSP : null,
                            MaPN = s.MaPN,
                            NgayNhap = s.NgayNhap,
                            NSX = s.tbl_CHITIETHANGHOA.NSX,
                            MaSP = s.tbl_CHITIETHANGHOA.MASP,
                            TenLoai = s.tbl_CHITIETHANGHOA.tbl_SANPHAM.tbl_LOAI != null ? s.tbl_CHITIETHANGHOA.tbl_SANPHAM.tbl_LOAI.TenLoai : null,
                            TongTien = s.TongTien,
                            TenKho = s.tbl_CHITIETHANGHOA.tbl_KHO != null ? s.tbl_CHITIETHANGHOA.tbl_KHO.TenKho : null,
                            
                        }).FirstOrDefault();
                    return item;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting CTPhieuNhap list: " + ex.Message);
            }
        }
        public tbl_CTPHIEUNHAP GetItem(string maCTPN)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    return db.tbl_CTPHIEUNHAP.FirstOrDefault(ctpn => ctpn.MaCTPN == maCTPN);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting CTPhieuNhap item: " + ex.Message);
            }
        }

        public void AddItem(tbl_CTPHIEUNHAP newItem)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    db.tbl_CTPHIEUNHAP.Add(newItem);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding CTPhieuNhap item: " + ex.Message);
            }
        }

        public void UpdateItem(tbl_CTPHIEUNHAP updatedItem)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var existingItem = db.tbl_CTPHIEUNHAP.FirstOrDefault(s => s.MaCTPN == updatedItem.MaCTPN);
                    if (existingItem != null)
                    {
                        // Update properties of existingItem with the values from updatedItem
                        existingItem.MaPN = updatedItem.MaPN;
                        existingItem.MACTSP = updatedItem.MACTSP;
                        existingItem.NgayNhap = updatedItem.NgayNhap;
                        existingItem.TongTien = updatedItem.TongTien;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating CTPhieuNhap item: " + ex.Message);
            }
        }

        public void DeleteItem(string maCTPN)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var itemToDelete = db.tbl_CTPHIEUNHAP.Find(maCTPN);
                    if (itemToDelete != null)
                    {
                        db.tbl_CTPHIEUNHAP.Remove(itemToDelete);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting CTPhieuNhap item: " + ex.Message);
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
