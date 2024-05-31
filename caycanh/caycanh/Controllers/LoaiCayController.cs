using caycanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace caycanh.Controllers
{
    public class LoaiCayController : Controller
    {
        // GET: LoaiCay
        public ActionResult Index()
        {
            QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
            List<LoaiCay> loaiCays = db.LoaiCay.ToList();
            return View(loaiCays);
        }

        // GET: LoaiCay/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiCay/Create
        [HttpPost]
        public ActionResult Create(LoaiCay loaiCay)
        {
            if (ModelState.IsValid)
            {
                QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
                db.LoaiCay.Add(loaiCay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiCay);
        }
        // GET: LoaiCay/Details/{id}
        public ActionResult Details(String id)
        {
            QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
            LoaiCay loaiCay = db.LoaiCay.FirstOrDefault(l => l.MaLoaiCay == id);

            if (loaiCay == null)
            {
                return HttpNotFound();
            }

            return View(loaiCay);
        }
        // GET: LoaiCay/Edit/{id}
        public ActionResult Edit(String id)
        {
            QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
            LoaiCay loaiCay = db.LoaiCay.FirstOrDefault(l => l.MaLoaiCay == id);

            if (loaiCay == null)
            {
                return HttpNotFound();
            }

            return View(loaiCay);
        }

        // POST: LoaiCay/Edit/{id}
        [HttpPost]
        public ActionResult Edit(String id, LoaiCay editedLoaiCay)
        {
            if (ModelState.IsValid)
            {
                QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
                LoaiCay loaiCay = db.LoaiCay.FirstOrDefault(l => l.MaLoaiCay == id);

                if (loaiCay == null)
                {
                    return HttpNotFound();
                }
                loaiCay.MaLoaiCay = editedLoaiCay.MaLoaiCay;
                loaiCay.TenLoaiCay = editedLoaiCay.TenLoaiCay;

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(editedLoaiCay);
        }
        // GET: LoaiCay/Delete/{id}
        public ActionResult Delete(String id)
        {
            QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
            LoaiCay loaiCay = db.LoaiCay.FirstOrDefault(l => l.MaLoaiCay == id);

            if (loaiCay == null)
            {
                return HttpNotFound();
            }

            return View(loaiCay);
        }

        // POST: LoaiCay/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(String id)
        {
            QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
            LoaiCay loaiCay = db.LoaiCay.FirstOrDefault(l => l.MaLoaiCay == id);

            if (loaiCay == null)
            {
                return HttpNotFound();
            }

            db.LoaiCay.Remove(loaiCay);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}