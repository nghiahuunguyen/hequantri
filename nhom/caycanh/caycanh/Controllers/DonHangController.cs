using caycanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace caycanh.Controllers
{
    public class DonHangController : Controller
    {
        private QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();

        // GET: DonHang
        public ActionResult Index()
        {
            List<DonDatHang> donDatHangs = db.DonDatHangs.ToList();
            return View(donDatHangs);
        }

        public ActionResult Create()
        {
            List<KhachHang> khachHangList = db.KhachHangs.ToList();
            ViewBag.KhachHangList = khachHangList;
            List<NhanVien> nhanVienList = db.NhanViens.ToList();
            ViewBag.NhanVienList = nhanVienList;
            return View();
        }

        // POST: DonHang/Create
        [HttpPost]
        public ActionResult Create(DonDatHang donDatHang)
        {
            if (ModelState.IsValid)
            {
                db.DonDatHangs.Add(donDatHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<KhachHang> khachHangList = db.KhachHangs.ToList();
            ViewBag.KhachHangList = khachHangList;
            List<NhanVien> nhanVienList = db.NhanViens.ToList();
            ViewBag.NhanVienList = nhanVienList;

            return View(donDatHang);
        }

        // GET: DonHang/Details/{id}
        public ActionResult Details(string id)
        {
            DonDatHang donDatHang = db.DonDatHangs.Find(id);
            if (donDatHang == null)
            {
                return HttpNotFound();
            }

            List<ChiTietDonDatHang> chiTietDonDatHangs = db.ChiTietDonDatHangs.Where(c => c.MaDonDatHang == id).ToList();
            donDatHang.ChiTietDonDatHangs = chiTietDonDatHangs;

            ViewBag.CayCanhList = db.CayCanhs.ToList(); 
            ViewBag.SanPhamList=db.SanPhams.ToList();

            return View(donDatHang);
        }

        public ActionResult Edit(string id)
        {
            DonDatHang donDatHang = db.DonDatHangs.FirstOrDefault(l => l.MaDonDatHang == id);
            if (donDatHang == null)
            {
                return HttpNotFound();
            }

            List<KhachHang> khachHangList = db.KhachHangs.ToList();
            ViewBag.KhachHangList = khachHangList;
            List<NhanVien> nhanVienList = db.NhanViens.ToList();
            ViewBag.NhanVienList = nhanVienList;

            return View(donDatHang);
        }

        // POST: DonHang/Edit/{id}
        [HttpPost]
        public ActionResult Edit(string id, DonDatHang editedDonDatHang)
        {
            if (ModelState.IsValid)
            {
                DonDatHang donDatHang = db.DonDatHangs.Find(id);
                if (donDatHang == null)
                {
                    return HttpNotFound();
                }

                // Update the properties of the DonDatHang object
                donDatHang.MaKhachHang = editedDonDatHang.MaKhachHang;
                donDatHang.MaNhanVien = editedDonDatHang.MaNhanVien;
                donDatHang.NgayDatHang = editedDonDatHang.NgayDatHang;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            List<KhachHang> khachHangList = db.KhachHangs.ToList();
            ViewBag.KhachHangList = khachHangList;
            List<NhanVien> nhanVienList = db.NhanViens.ToList();
            ViewBag.NhanVienList = nhanVienList;

            return View(editedDonDatHang);
        }

        public ActionResult Delete(string id)
        {
            DonDatHang donDatHang = db.DonDatHangs.Find(id);
            if (donDatHang == null)
            {
                return HttpNotFound();
            }

            return View(donDatHang);
        }

        // POST: DonHang/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            DonDatHang donDatHang = db.DonDatHangs.Find(id);
            if (donDatHang == null)
            {
                return HttpNotFound();
            }

            db.DonDatHangs.Remove(donDatHang);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        
    }
}