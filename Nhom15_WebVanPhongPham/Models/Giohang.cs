using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom15_WebVanPhongPham.Models
{
    public class Giohang
    {
        DBNhom15 db = new DBNhom15();
        public int sMaSp { set; get; }
        public string sTenSP { get; set; }
        public double sKhoiLuong { get; set; }

        public int sSoLuong { get; set; }

  
        public string sThuongHieu { get; set; }

        public string sAnh { get; set; }

        public double sGia { get; set; }

        public double sThanhTien { get { return sSoLuong * sGia; } }
        public Giohang(int maSP)
        {
            sMaSp = maSP;
            SanPham sanPham = db.SanPhams.Single(n => n.MaSp == sMaSp);
            sTenSP = sanPham.TenSP;
            sSoLuong = 1;
            sThuongHieu = sanPham.ThuongHieu;
            sAnh = sanPham.Anh;
            sGia = sanPham.Gia;
        }
    }
}