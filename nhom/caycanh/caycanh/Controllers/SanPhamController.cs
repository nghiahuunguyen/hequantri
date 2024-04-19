using caycanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace caycanh.Controllers
{
    public class SanPhamController : Controller
    {
        private QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
        // GET: SanPham
        public ActionResult Index()
        {
            List<SanPham> sanPhams = db.SanPhams.ToList();
            return View(sanPhams);
        }
        public ActionResult sanpham()
        {
            List<SanPham> sanPhams = db.SanPhams.ToList();
            return View(sanPhams);
        }
        public ActionResult Create()
        {
            List<NhaCungCap> nhaCungCapList = db.NhaCungCaps.ToList();
            ViewBag.NhaCungCapList = nhaCungCapList;

            return View();
        }

        // POST: CayCanh/Create
        [HttpPost]
        public ActionResult Create(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<NhaCungCap> nhaCungCapList = db.NhaCungCaps.ToList();
            ViewBag.NhaCungCapList = nhaCungCapList;

            return View(sanPham);
        }
        public ActionResult Details(string id)
        {
            SanPham sanPham = db.SanPhams.FirstOrDefault(l => l.MaSanPham == id);

            if (sanPham == null)
            {
                return HttpNotFound();
            }

            return View(sanPham);

        }
        public ActionResult chitiet(string id)
        {
            SanPham sanPham = db.SanPhams.FirstOrDefault(l => l.MaSanPham == id);

            if (sanPham == null)
            {
                return HttpNotFound();
            }

            return View(sanPham);

        }
        public ActionResult Edit(string id)
        {
            SanPham sanPham = db.SanPhams.FirstOrDefault(l => l.MaSanPham == id);

            if (sanPham == null)
            {
                return HttpNotFound();
            }

            List<NhaCungCap> nhaCungCapList = db.NhaCungCaps.ToList();
            ViewBag.NhaCungCapList = nhaCungCapList;

            return View(sanPham);
        }

        // POST: CayCanh/Edit/{id}
        [HttpPost]
        public ActionResult Edit(string id, SanPham editedSanPham)
        {
            if (ModelState.IsValid)
            {
                SanPham sanPham = db.SanPhams.FirstOrDefault(l => l.MaSanPham == id);

                if (sanPham == null)
                {
                    return HttpNotFound();
                }

                sanPham.MaSanPham = editedSanPham.MaSanPham;
                sanPham.TenSanPham = editedSanPham.TenSanPham;
                sanPham.GiaTien = editedSanPham.GiaTien;
                sanPham.MaNhaCungCap = editedSanPham.MaNhaCungCap;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(editedSanPham);
        }
        public ActionResult Delete(String id)
        {
            QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
            SanPham sanPham = db.SanPhams.FirstOrDefault(l => l.MaSanPham == id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }

            return View(sanPham);
        }

        // POST: LoaiCay/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(String id)
        {
            QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
            SanPham sanPham = db.SanPhams.FirstOrDefault(l => l.MaSanPham == id);

            if (sanPham == null)
            {
                return HttpNotFound();
            }

            db.SanPhams.Remove(sanPham);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}