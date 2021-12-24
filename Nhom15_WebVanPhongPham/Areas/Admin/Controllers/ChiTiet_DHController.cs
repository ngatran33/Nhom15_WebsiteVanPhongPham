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
    public class ChiTiet_DHController : Controller
    {
        private DBNhom15 db = new DBNhom15();

        // GET: Admin/ChiTiet_DH
        public ActionResult Index()
        {
            var chiTiet_DH = db.ChiTiet_DH.Include(c => c.DonHang).Include(c => c.SanPham);
            return View(chiTiet_DH.ToList());
        }

        // GET: Admin/ChiTiet_DH/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTiet_DH chiTiet_DH = db.ChiTiet_DH.Find(id);
            if (chiTiet_DH == null)
            {
                return HttpNotFound();
            }
            return View(chiTiet_DH);
        }

        // GET: Admin/ChiTiet_DH/Create
        public ActionResult Create()
        {
            ViewBag.MaDH = new SelectList(db.DonHangs, "MaDH", "DiaChi");
            ViewBag.MaDH = new SelectList(db.SanPhams, "MaSp", "TenSP");
            return View();
        }

        // POST: Admin/ChiTiet_DH/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSp,MaDH,SLBan")] ChiTiet_DH chiTiet_DH)
        {
            if (ModelState.IsValid)
            {
                db.ChiTiet_DH.Add(chiTiet_DH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDH = new SelectList(db.DonHangs, "MaDH", "DiaChi", chiTiet_DH.MaDH);
            ViewBag.MaDH = new SelectList(db.SanPhams, "MaSp", "TenSP", chiTiet_DH.MaDH);
            return View(chiTiet_DH);
        }

        // GET: Admin/ChiTiet_DH/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTiet_DH chiTiet_DH = db.ChiTiet_DH.Find(id);
            if (chiTiet_DH == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDH = new SelectList(db.DonHangs, "MaDH", "DiaChi", chiTiet_DH.MaDH);
            ViewBag.MaDH = new SelectList(db.SanPhams, "MaSp", "TenSP", chiTiet_DH.MaDH);
            return View(chiTiet_DH);
        }

        // POST: Admin/ChiTiet_DH/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSp,MaDH,SLBan")] ChiTiet_DH chiTiet_DH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTiet_DH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDH = new SelectList(db.DonHangs, "MaDH", "DiaChi", chiTiet_DH.MaDH);
            ViewBag.MaDH = new SelectList(db.SanPhams, "MaSp", "TenSP", chiTiet_DH.MaDH);
            return View(chiTiet_DH);
        }

        // GET: Admin/ChiTiet_DH/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTiet_DH chiTiet_DH = db.ChiTiet_DH.Find(id);
            if (chiTiet_DH == null)
            {
                return HttpNotFound();
            }
            return View(chiTiet_DH);
        }

        // POST: Admin/ChiTiet_DH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTiet_DH chiTiet_DH = db.ChiTiet_DH.Find(id);
            db.ChiTiet_DH.Remove(chiTiet_DH);
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
