using caycanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace caycanh.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        public ActionResult Index()
        {
            QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
            List<KhachHang> khachHangs = db.KhachHangs.ToList();
            return View(khachHangs);
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiCay/Create
        [HttpPost]
        public ActionResult Create(KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khachHang);
        }
        public ActionResult Details(String id)
        {
            QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
            KhachHang khachHang = db.KhachHangs.FirstOrDefault(l => l.MaKhachHang == id);

            if (khachHang == null)
            {
                return HttpNotFound();
            }

            return View(khachHang);
        }
        public ActionResult Edit(String id)
        {
            QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
            KhachHang khachHang = db.KhachHangs.FirstOrDefault(l => l.MaKhachHang == id);

            if (khachHang == null)
            {
                return HttpNotFound();
            }

            return View(khachHang);
        }

        // POST: LoaiCay/Edit/{id}
        [HttpPost]
        public ActionResult Edit(String id, KhachHang editedKhachHang)
        {
            if (ModelState.IsValid)
            {
                QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
                KhachHang khachHang = db.KhachHangs.FirstOrDefault(l => l.MaKhachHang == id);

                if (khachHang == null)
                {
                    return HttpNotFound();
                }
                khachHang.MaKhachHang = editedKhachHang.MaKhachHang;
                khachHang.TenKhachHang = editedKhachHang.TenKhachHang;
                khachHang.DiaChi = editedKhachHang.DiaChi;
                khachHang.SoDienThoai = editedKhachHang.SoDienThoai;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(editedKhachHang);
        }
        public ActionResult Delete(String id)
        {
            QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
            KhachHang khachHang = db.KhachHangs.FirstOrDefault(l => l.MaKhachHang == id);

            if (khachHang == null)
            {
                return HttpNotFound();
            }

            return View(khachHang);
        }

        // POST: LoaiCay/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(String id)
        {
            QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
            KhachHang khachHang = db.KhachHangs.FirstOrDefault(l => l.MaKhachHang == id);

            if (khachHang == null)
            {
                return HttpNotFound();
            }

            db.KhachHangs.Remove(khachHang);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}