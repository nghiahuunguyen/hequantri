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
            List<DonDatHang> donDatHangs = db.DonDatHang.ToList();
            return View(donDatHangs);
        }

        public ActionResult Create()
        {
            List<KhachHang> khachHangList = db.KhachHang.ToList();
            ViewBag.KhachHangList = khachHangList;
            List<NhanVien> nhanVienList = db.NhanVien.ToList();
            ViewBag.NhanVienList = nhanVienList;
            return View();
        }

        // POST: DonHang/Create
        [HttpPost]
        public ActionResult Create(DonDatHang donDatHang)
        {
            if (ModelState.IsValid)
            {
                db.DonDatHang.Add(donDatHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<KhachHang> khachHangList = db.KhachHang.ToList();
            ViewBag.KhachHangList = khachHangList;
            List<NhanVien> nhanVienList = db.NhanVien.ToList();
            ViewBag.NhanVienList = nhanVienList;

            return View(donDatHang);
        }

        // GET: DonHang/Details/{id}
        public ActionResult Details(string id)
        {
            DonDatHang donDatHang = db.DonDatHang.Find(id);
            if (donDatHang == null)
            {
                return HttpNotFound();
            }

            List<ChiTietDonDatHang> chiTietDonDatHangs = db.ChiTietDonDatHang.Where(c => c.MaDonDatHang == id).ToList();
            donDatHang.ChiTietDonDatHang = chiTietDonDatHangs;

            ViewBag.CayCanhList = db.CayCanh.ToList(); 
            ViewBag.SanPhamList=db.SanPham.ToList();

            return View(donDatHang);
        }

        public ActionResult Edit(string id)
        {
            DonDatHang donDatHang = db.DonDatHang.FirstOrDefault(l => l.MaDonDatHang == id);
            if (donDatHang == null)
            {
                return HttpNotFound();
            }

            List<KhachHang> khachHangList = db.KhachHang.ToList();
            ViewBag.KhachHangList = khachHangList;
            List<NhanVien> nhanVienList = db.NhanVien.ToList();
            ViewBag.NhanVienList = nhanVienList;

            return View(donDatHang);
        }

        // POST: DonHang/Edit/{id}
        [HttpPost]
        public ActionResult Edit(string id, DonDatHang editedDonDatHang)
        {
            if (ModelState.IsValid)
            {
                DonDatHang donDatHang = db.DonDatHang.Find(id);
                if (donDatHang == null)
                {
                    return HttpNotFound();
                }

                // Update the properties of the DonDatHang object
                donDatHang.MaKhachHang = editedDonDatHang.MaKhachHang;
                donDatHang.MaNhanVien = editedDonDatHang.MaNhanVien;
                donDatHang.NgayDatHang = editedDonDatHang.NgayDatHang;
                donDatHang.GiaTien=editedDonDatHang.GiaTien;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            List<KhachHang> khachHangList = db.KhachHang.ToList();
            ViewBag.KhachHangList = khachHangList;
            List<NhanVien> nhanVienList = db.NhanVien.ToList();
            ViewBag.NhanVienList = nhanVienList;

            return View(editedDonDatHang);
        }

        public ActionResult Delete(string id)
        {
            DonDatHang donDatHang = db.DonDatHang.Find(id);
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
            DonDatHang donDatHang = db.DonDatHang.Find(id);
            if (donDatHang == null)
            {
                return HttpNotFound();
            }

            db.DonDatHang.Remove(donDatHang);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        
    }
}