using caycanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace caycanh.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        public ActionResult Index()
        {
            QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
            List<NhanVien> nhanViens = db.NhanVien.ToList();
            return View(nhanViens);
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiCay/Create
        [HttpPost]
        public ActionResult Create(NhanVien nv)
        {
            if (ModelState.IsValid)
            {
                QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
                db.NhanVien.Add(nv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nv);
        }
        // GET: LoaiCay/Details/{id}
        public ActionResult Details(String id)
        {
            QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
            NhanVien nhanVien = db.NhanVien.FirstOrDefault(l => l.MaNhanVien == id);

            if (nhanVien == null)
            {
                return HttpNotFound();
            }

            return View(nhanVien);
        }
        // GET: LoaiCay/Edit/{id}
        public ActionResult Edit(String id)
        {
            QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
            NhanVien nhanVien = db.NhanVien.FirstOrDefault(l => l.MaNhanVien == id);

            if (nhanVien == null)
            {
                return HttpNotFound();
            }

            return View(nhanVien);
        }

        // POST: LoaiCay/Edit/{id}
        [HttpPost]
        public ActionResult Edit(String id, NhanVien editednv)
        {
            if (ModelState.IsValid)
            {
                QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
                NhanVien nhanVien = db.NhanVien.FirstOrDefault(l => l.MaNhanVien == id);

                if (nhanVien == null)
                {
                    return HttpNotFound();
                }
                nhanVien.MaNhanVien = editednv.MaNhanVien;
                nhanVien.TenNhanVien = editednv.TenNhanVien;
                nhanVien.ChucVu=editednv.ChucVu;
                nhanVien.Luong=editednv.Luong;  

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(editednv);
        }
        // GET: LoaiCay/Delete/{id}
        public ActionResult Delete(String id)
        {
            QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
            NhanVien nhanVien = db.NhanVien.FirstOrDefault(l => l.MaNhanVien == id);

            if (nhanVien == null)
            {
                return HttpNotFound();
            }

            return View(nhanVien);
        }

        // POST: LoaiCay/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(String id)
        {
            QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
            NhanVien nhanVien = db.NhanVien.FirstOrDefault(l => l.MaNhanVien == id);

            if (nhanVien == null)
            {
                return HttpNotFound();
            }

            db.NhanVien.Remove(nhanVien);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}