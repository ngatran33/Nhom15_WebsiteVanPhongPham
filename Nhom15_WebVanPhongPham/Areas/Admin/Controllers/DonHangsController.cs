using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nhom15_WebVanPhongPham.Models;

namespace Nhom15_WebVanPhongPham.Areas.Admin.Controllers
{
    public class DonHangsController : Controller
    {
        private DBNhom15 db = new DBNhom15();

        // GET: Admin/DonHangs
        public ActionResult Index()
        {
            var donHangs = db.DonHangs.Include(d => d.TaiKhoan);
            return View(donHangs.ToList());
        }

        // GET: Admin/DonHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // GET: Admin/DonHangs/Create
        public ActionResult Create()
        {
            ViewBag.MaTk = new SelectList(db.TaiKhoans, "MaTk", "HoTen");
            return View();
        }

        // POST: Admin/DonHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDH,MaTk,NgayDat,DiaChi,HoTen")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                db.DonHangs.Add(donHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaTk = new SelectList(db.TaiKhoans, "MaTk", "HoTen", donHang.MaTk);
            return View(donHang);
        }

        // GET: Admin/DonHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaTk = new SelectList(db.TaiKhoans, "MaTk", "HoTen", donHang.MaTk);
            return View(donHang);
        }

        // POST: Admin/DonHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDH,MaTk,NgayDat,DiaChi,HoTen")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaTk = new SelectList(db.TaiKhoans, "MaTk", "HoTen", donHang.MaTk);
            return View(donHang);
        }

        // GET: Admin/DonHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // POST: Admin/DonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonHang donHang = db.DonHangs.Find(id);
            db.DonHangs.Remove(donHang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
