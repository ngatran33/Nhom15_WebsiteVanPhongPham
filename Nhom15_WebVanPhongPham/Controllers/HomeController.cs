using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nhom15_WebVanPhongPham.Models;
using PagedList;

namespace Nhom15_WebVanPhongPham.Controllers
{
    public class HomeController : Controller
    {
        DBNhom15 db = new DBNhom15();
        

      
        public ActionResult Account()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }public ActionResult Card()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Blog()
        {
            return View(db.Blogs.ToList());
        }
        public ActionResult ChiTietBlogs(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }
        public ActionResult Index(string id, string sortOder, string searchString, string currentFilter, int? page)
        {
            List<SanPham> sanPhams = new List<SanPham>();
            ViewBag.CurrentSort = sortOder;//lấy yêu cầu sắp
            ViewBag.SapTheoTen = String.IsNullOrEmpty(sortOder) ? "name_desc" : "";
            ViewBag.SapTheoGia = sortOder == "Gia" ? "gia_desc" : "Gia";
           
            if (id == null)
            {
                sanPhams = db.SanPhams.Select(s => s).ToList();
            }
            else
            {
                sanPhams = db.SanPhams.Where(s => s.DanhMuc.TenDM.Contains(id)).Select(s => s).ToList();
            }
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                sanPhams = db.SanPhams.Where(s => s.TenSP.Contains(searchString) || s.ThuongHieu.Contains(searchString)).Select(s => s).ToList();
            }
            //sắp xếp
            switch (sortOder)
            {
                case "name_desc":
                    sanPhams = sanPhams.OrderByDescending(s => s.TenSP).ToList();
                    break;
                case "Gia":
                    sanPhams = sanPhams.OrderBy(s => s.Gia).ToList();
                    break;
                case "gia_desc":
                    sanPhams = sanPhams.OrderByDescending(s => s.Gia).ToList();
                    break;            
                default:
                    sanPhams = sanPhams.OrderBy(s => s.TenSP).ToList();
                    break;
            }
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(sanPhams.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult ChiTietSP(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }
<<<<<<< HEAD
=======
<<<<<<< HEAD
        public ActionResult UserTT(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserTT([Bind(Include = "MaTk,HoTen,Email,DiaChi,Sdt,TenDN,MatKhau,Quyen")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taiKhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taiKhoan);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string TenDN, string MatKhau)
        {
            if (ModelState.IsValid)
            {
                var user = db.TaiKhoans.Where(u => u.TenDN.Equals(TenDN) && u.MatKhau.Equals(MatKhau)).ToList();
                if (user.Count() > 0)
                {
                    //add session
                    Session["HoTen"] = user.FirstOrDefault().HoTen;
                    Session["Email"] = user.FirstOrDefault().Email;
                    Session["idUser"] = user.FirstOrDefault().MaTk;
                    Session["SDT"] = user.FirstOrDefault().Sdt;
                    Session["DiaChi"] = user.FirstOrDefault().DiaChi;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Tài khoản hoặc mật khẩu sai! Vui lòng đăng nhập lại!!!!";
                }

            }
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            List<string> Cities = new List<string>
            {
                "Hà Nội","Thanh Hoá","Thái Bình","Nam Định"
            };
            ViewBag.Cities = Cities;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "MaTk,HoTen,Email,DiaChi,Sdt,TenDN,MatKhau,Quyen")] TaiKhoan taiKhoan)
        {
            var tkcheck = db.TaiKhoans.Where(tk => tk.Email == taiKhoan.Email || tk.TenDN == taiKhoan.TenDN);
            if (tkcheck.Count() == 0)
            {
                if (ModelState.IsValid)
                {
                    db.TaiKhoans.Add(taiKhoan);
                    db.SaveChanges();

                }
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.error = "Tài khoản đã tồn tại";
                return View(taiKhoan);
            }

=======
>>>>>>> 502c65d0405fba83a7f5ef1951f421f085884739
        public ActionResult ProductList(int id, int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            var sanphams = db.SanPhams.Where(h => h.MaDM.Equals(id)).Select(h => h).OrderBy(s => s.MaSp);
            return View(sanphams.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Header()
        {
            var danhmucs = db.DanhMucs.Select(h => h);
            return PartialView(danhmucs);
<<<<<<< HEAD
=======
>>>>>>> Lanh
>>>>>>> 502c65d0405fba83a7f5ef1951f421f085884739
        }
    }
}