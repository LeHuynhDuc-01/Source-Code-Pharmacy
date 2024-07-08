using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CTHoaDonDAL
    {
        public List<tbl_CTHOADON> GetLists()
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    return db.tbl_CTHOADON.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<ChiTietHoaDonDTO> GetListDTOs(string maHD)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var lst = db.tbl_CTHOADON.Where(s => s.MaHD == maHD)
                        .Select(s => new ChiTietHoaDonDTO
                        {
                            MaCTSP = s.MaCTSP,
                            DonGia = s.DonGia,
                            GiaBan = s.tbl_CHITIETHANGHOA!= null ? s.tbl_CHITIETHANGHOA.GiaBan : null,
                             MaCTHD = s.MaCTHD,
                             MaHD = s.MaHD,
                             SoLuong = s.SoLuong,
                             TenSP = s.tbl_CHITIETHANGHOA!= null ? s.tbl_CHITIETHANGHOA.tbl_SANPHAM != null ? s.tbl_CHITIETHANGHOA.tbl_SANPHAM.TenSP : null : null,
                        }).ToList();
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting CTPhieuNhap list: " + ex.Message);
            }
        }
        public List<BaoCaoCTHoaDonDTO> GetAllListDTOs()
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var lst = db.tbl_CTHOADON
                        .Select(s => new BaoCaoCTHoaDonDTO
                        {
                            MaCTSP = s.MaCTSP,
                            DonGia = s.DonGia,
                            GiaBan = s.tbl_CHITIETHANGHOA != null ? s.tbl_CHITIETHANGHOA.GiaBan : null,
                            MaCTHD = s.MaCTHD,
                            MaHD = s.MaHD,
                            SoLuong = s.SoLuong,
                            TenSP = s.tbl_CHITIETHANGHOA != null ? s.tbl_CHITIETHANGHOA.tbl_SANPHAM != null ? s.tbl_CHITIETHANGHOA.tbl_SANPHAM.TenSP : null : null,
                            NgayLap = s.tbl_HOADON != null ? s.tbl_HOADON.NgayLap : null,
                            DuocSi = s.tbl_HOADON.tbl_DUOCSI != null ? s.tbl_HOADON.tbl_DUOCSI.TenDuocSi : null,
                        }).ToList();
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting CTPhieuNhap list: " + ex.Message);
            }
        }
        public List<BaoCaoCTHoaDonDTO> GetListDTOsWithDay(DateTime dateStart, DateTime dateEnd)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var lst = db.tbl_CTHOADON
                        .Where(s => s.tbl_HOADON.NgayLap >= dateStart && s.tbl_HOADON.NgayLap <= dateEnd)
                        .Select(s => new BaoCaoCTHoaDonDTO
                        {
                            MaCTSP = s.MaCTSP,
                            DonGia = s.DonGia,
                            GiaBan = s.tbl_CHITIETHANGHOA != null ? s.tbl_CHITIETHANGHOA.GiaBan : null,
                            MaCTHD = s.MaCTHD,
                            MaHD = s.MaHD,
                            SoLuong = s.SoLuong,
                            TenSP = s.tbl_CHITIETHANGHOA != null ? s.tbl_CHITIETHANGHOA.tbl_SANPHAM != null ? s.tbl_CHITIETHANGHOA.tbl_SANPHAM.TenSP : null : null,
                            NgayLap = s.tbl_HOADON!= null ? s.tbl_HOADON.NgayLap : null,    
                            DuocSi = s.tbl_HOADON.tbl_DUOCSI !=null ? s.tbl_HOADON.tbl_DUOCSI.TenDuocSi :null,
                        }).ToList();
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting CTPhieuNhap list: " + ex.Message);
            }
        }
        public List<BaoCaoCTHoaDonDTO> GetListDTOsWithDay(DateTime dateStart, DateTime dateEnd, int maDuocSi)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var lst = db.tbl_CTHOADON
                        .Where(s => s.tbl_HOADON.NgayLap >= dateStart && s.tbl_HOADON.NgayLap <= dateEnd && s.tbl_HOADON.MaDuocSi == maDuocSi)
                        .Select(s => new BaoCaoCTHoaDonDTO
                        {
                            MaCTSP = s.MaCTSP,
                            DonGia = s.DonGia,
                            GiaBan = s.tbl_CHITIETHANGHOA != null ? s.tbl_CHITIETHANGHOA.GiaBan : null,
                            MaCTHD = s.MaCTHD,
                            MaHD = s.MaHD,
                            SoLuong = s.SoLuong,
                            TenSP = s.tbl_CHITIETHANGHOA != null ? s.tbl_CHITIETHANGHOA.tbl_SANPHAM != null ? s.tbl_CHITIETHANGHOA.tbl_SANPHAM.TenSP : null : null,
                            NgayLap = s.tbl_HOADON != null ? s.tbl_HOADON.NgayLap : null,
                            DuocSi = s.tbl_HOADON.tbl_DUOCSI != null ? s.tbl_HOADON.tbl_DUOCSI.TenDuocSi : null,
                        }).ToList();
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting CTPhieuNhap list: " + ex.Message);
            }
        }
        public tbl_CTHOADON GetItem(string id)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    return db.tbl_CTHOADON.FirstOrDefault(i => i.MaCTHD == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddItem(tbl_CTHOADON newItem)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    db.tbl_CTHOADON.Add(newItem);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding CTHoaDon item: " + ex.Message);
            }
        }

        public void UpdateItem(tbl_CTHOADON updatedItem)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var existingItem = db.tbl_CTHOADON.Find(updatedItem.MaCTHD);
                    if (existingItem != null)
                    {
                        // Update properties of existingItem with the values from updatedItem
                        existingItem.MaHD = updatedItem.MaHD;
                        existingItem.MaCTSP = updatedItem.MaCTSP;
                        existingItem.SoLuong = updatedItem.SoLuong;
                        existingItem.DonGia = updatedItem.DonGia;

                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating CTHoaDon item: " + ex.Message);
            }
        }

        public void DeleteItem(int id)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var itemToDelete = db.tbl_CTHOADON.Find(id);
                    if (itemToDelete != null)
                    {
                        db.tbl_CTHOADON.Remove(itemToDelete);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting CTHoaDon item: " + ex.Message);
            }
        }

        public void DeleteItemWithMaCTSP(string _mactSp)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var itemToDelete = db.tbl_CTHOADON.FirstOrDefault(s =>s.MaCTSP == _mactSp);
                    if (itemToDelete != null)
                    {
                        db.tbl_CTHOADON.Remove(itemToDelete);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting CTHoaDon item: " + ex.Message);
            }
        }
        public double GetTotalPriceByMaHD(string maHD)
        {
            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    var totalPrice = db.tbl_CTHOADON
                        .Where(ct => ct.MaHD == maHD)
                        .Sum(ct => ct.DonGia) ?? 0;
                    return totalPrice;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public tbl_CTHOADON GetItemWithMaCTSP(string maCTSP)
        {

            try
            {
                using (tbl_QLHieuThuocEntities db = new tbl_QLHieuThuocEntities())
                {
                    return db.tbl_CTHOADON.FirstOrDefault(i => i.MaCTSP == maCTSP);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
