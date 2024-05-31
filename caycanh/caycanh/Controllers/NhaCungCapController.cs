using caycanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace caycanh.Controllers
{
    public class NhaCungCapController : Controller
    {
        // GET: NhaCungCap
        public ActionResult Index()
        {
            QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
            List<NhaCungCap> nhaCungCaps = db.NhaCungCap.ToList();
            return View(nhaCungCaps);
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiCay/Create
        [HttpPost]
        public ActionResult Create(NhaCungCap nhaCungCap)
        {
            if (ModelState.IsValid)
            {
                QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
                db.NhaCungCap.Add(nhaCungCap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhaCungCap);
        }
        public ActionResult Details(String id)
        {
            QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
            NhaCungCap nhaCungCap = db.NhaCungCap.FirstOrDefault(l => l.MaNhaCungCap == id);

            if (nhaCungCap == null)
            {
                return HttpNotFound();
            }

            return View(nhaCungCap);
        }
        public ActionResult Edit(String id)
        {
            QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
            NhaCungCap nhaCungCap = db.NhaCungCap.FirstOrDefault(l => l.MaNhaCungCap == id);

            if (nhaCungCap == null)
            {
                return HttpNotFound();
            }

            return View(nhaCungCap);
        }

        // POST: LoaiCay/Edit/{id}
        [HttpPost]
        public ActionResult Edit(String id,NhaCungCap editeNhaCungCap)
        {
            if (ModelState.IsValid)
            {
                QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
                NhaCungCap nhaCungCap = db.NhaCungCap.FirstOrDefault(l => l.MaNhaCungCap == id);

                if (nhaCungCap == null)
                {
                    return HttpNotFound();
                }
                nhaCungCap.MaNhaCungCap = editeNhaCungCap.MaNhaCungCap;
                nhaCungCap.TenNhaCungCap = editeNhaCungCap.TenNhaCungCap;
                nhaCungCap.DiaChi = editeNhaCungCap.DiaChi;

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(editeNhaCungCap);
        }
        // GET: LoaiCay/Delete/{id}
        public ActionResult Delete(String id)
        {
            QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
            NhaCungCap nhaCungCap = db.NhaCungCap.FirstOrDefault(l => l.MaNhaCungCap == id);

            if (nhaCungCap == null)
            {
                return HttpNotFound();
            }

            return View(nhaCungCap);
        }
        // POST: LoaiCay/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(String id)
        {
            QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
            NhaCungCap nhaCungCap = db.NhaCungCap.FirstOrDefault(l => l.MaNhaCungCap == id);

            if (nhaCungCap == null)
            {
                return HttpNotFound();
            }

            db.NhaCungCap.Remove(nhaCungCap);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}