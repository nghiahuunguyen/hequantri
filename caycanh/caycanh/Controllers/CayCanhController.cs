using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using caycanh.Models;

namespace caycanh.Controllers
{
    public class CayCanhController : Controller
    {
        private QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();

        // GET: CayCanh
        public ActionResult Index()
        {
            List<CayCanh> cayCanhs = db.CayCanh.ToList();
            return View(cayCanhs);
        }
        public ActionResult cay()
        {
            List<CayCanh> cayCanhs = db.CayCanh.ToList();
            return View(cayCanhs);
        }

        // GET: CayCanh/Create
        public ActionResult Create()
        {
            List<LoaiCay> loaiCayList = db.LoaiCay.ToList();
            ViewBag.LoaiCayList = loaiCayList;

            return View();
        }

        // POST: CayCanh/Create
        [HttpPost]
        public ActionResult Create(CayCanh cayCanh)
        {
            if (ModelState.IsValid)
            {
                db.CayCanh.Add(cayCanh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<LoaiCay> loaiCayList = db.LoaiCay.ToList();
            ViewBag.LoaiCayList = loaiCayList;

            return View(cayCanh);
        }

        public ActionResult Details(string id)
        {
            CayCanh cayCanh = db.CayCanh.FirstOrDefault(l => l.MaCay == id);

            if (cayCanh == null)
            {
                return HttpNotFound();
            }

            return View(cayCanh);
          
        }
        public ActionResult chitiet(string id)
        {
            CayCanh cayCanh = db.CayCanh.FirstOrDefault(l => l.MaCay == id);

            if (cayCanh == null)
            {
                return HttpNotFound();
            }

            return View(cayCanh);

        }

        public ActionResult Edit(string id)
        {
            CayCanh cayCanh = db.CayCanh.FirstOrDefault(l => l.MaCay == id);

            if (cayCanh == null)
            {
                return HttpNotFound();
            }

            List<LoaiCay> loaiCayList = db.LoaiCay.ToList();
            ViewBag.LoaiCayList = loaiCayList;

            return View(cayCanh);
        }

        // POST: CayCanh/Edit/{id}
        [HttpPost]
        public ActionResult Edit(string id, CayCanh editedCayCanh)
        {
            if (ModelState.IsValid)
            {
                CayCanh cayCanh = db.CayCanh.FirstOrDefault(l => l.MaCay == id);

                if (cayCanh == null)
                {
                    return HttpNotFound();
                }

                cayCanh.MaCay = editedCayCanh.MaCay;
                cayCanh.TenCay = editedCayCanh.TenCay;
                cayCanh.GiaTien = editedCayCanh.GiaTien;
                cayCanh.MaLoaiCay = editedCayCanh.MaLoaiCay;
                cayCanh.NgayTrong = editedCayCanh.NgayTrong;
                cayCanh.SoLuong = editedCayCanh.SoLuong;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(editedCayCanh);
        }
        public ActionResult Delete(String id)
        {
            QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
            CayCanh cayCanh = db.CayCanh.FirstOrDefault(l => l.MaCay == id);
            if (cayCanh == null)
            {
                return HttpNotFound();
            }

            return View(cayCanh);
        }

        // POST: LoaiCay/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(String id)
        {
            QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
            CayCanh cayCanh = db.CayCanh.FirstOrDefault(l => l.MaCay == id);

            if (cayCanh == null)
            {
                return HttpNotFound();
            }

            db.CayCanh.Remove(cayCanh);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}