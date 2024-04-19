using caycanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace caycanh.Controllers
{
    public class ChiTietDonHangController : Controller
    {
        private QUANLYCAYCANHEntities db = new QUANLYCAYCANHEntities();
        // GET: ChiTietDonHang
        public ActionResult Index()
        {
            List<ChiTietDonDatHang> chiTiets = db.ChiTietDonDatHangs.ToList();
            return View(chiTiets);
        }
        public ActionResult Create()
        {
            List<SanPham> sanPhamList = db.SanPhams.ToList();
            ViewBag.SanPhamList = sanPhamList;
            List<CayCanh> cayCanhList = db.CayCanhs.ToList();
            ViewBag.CayCanhList = cayCanhList;
            List<DonDatHang> donHangList = db.DonDatHangs.ToList();
            ViewBag.DonHangList = donHangList;
            return View();
        }

        // POST: CayCanh/Create
        [HttpPost]
        public ActionResult Create(ChiTietDonDatHang chitiet)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietDonDatHangs.Add(chitiet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<SanPham> sanPhamList = db.SanPhams.ToList();
            ViewBag.SanPhamList = sanPhamList;
            List<CayCanh> cayCanhList = db.CayCanhs.ToList();
            ViewBag.CayCanhList = cayCanhList;
            List<DonDatHang> donHangList = db.DonDatHangs.ToList();
            ViewBag.DonHangList = donHangList;

            return View(chitiet);
        }

        public ActionResult Edit(string id)
        {

            ChiTietDonDatHang chitiet = db.ChiTietDonDatHangs.FirstOrDefault(l => l.MaDonDatHang == id);
            if (chitiet == null)
            {
                return HttpNotFound();
            }

            List<SanPham> sanPhamList = db.SanPhams.ToList();
            ViewBag.SanPhamList = sanPhamList;
            List<CayCanh> cayCanhList = db.CayCanhs.ToList();
            ViewBag.CayCanhList = cayCanhList;
            List<DonDatHang> donHangList = db.DonDatHangs.ToList();
            ViewBag.DonHangList = donHangList;

            return View(chitiet);
        }

        // POST: DonHang/Edit/{id}
        [HttpPost]
        public ActionResult Edit(string id, ChiTietDonDatHang editchiTiet)
        {
            if (ModelState.IsValid)
            {
                DonDatHang donHang = db.DonDatHangs.FirstOrDefault(d => d.MaDonDatHang == editchiTiet.MaDonDatHang);
                if (donHang == null)
                {
                    return HttpNotFound();
                }

                ChiTietDonDatHang chitiet = db.ChiTietDonDatHangs.FirstOrDefault(l => l.MaDonDatHang == id);
                if (chitiet == null)
                {
                    return HttpNotFound();
                }

                // Update the properties of the ChiTietDonDatHang object
                chitiet.MaDonDatHang = editchiTiet.MaDonDatHang;
                chitiet.MaCay = editchiTiet.MaCay;
                chitiet.MaSanPham = editchiTiet.MaSanPham;
                chitiet.SoLuong = editchiTiet.SoLuong;
                chitiet.GiamGia = editchiTiet.GiamGia;
                chitiet.ChietKhau = editchiTiet.ChietKhau;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            List<SanPham> sanPhamList = db.SanPhams.ToList();
            ViewBag.SanPhamList = sanPhamList;
            List<CayCanh> cayCanhList = db.CayCanhs.ToList();
            ViewBag.CayCanhList = cayCanhList;
            List<DonDatHang> donHangList = db.DonDatHangs.ToList();
            ViewBag.DonHangList = donHangList;

            return View(editchiTiet);
        }

        public ActionResult Delete(string id)
        {
            ChiTietDonDatHang chitiet = db.ChiTietDonDatHangs.FirstOrDefault(l => l.MaDonDatHang == id);
            if (chitiet == null)
            {
                return HttpNotFound();
            }

            return View(chitiet);
        }

        // POST: DonHang/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            ChiTietDonDatHang chitiet = db.ChiTietDonDatHangs.FirstOrDefault(l => l.MaDonDatHang == id);
            if (chitiet == null)
            {
                return HttpNotFound();
            }

            db.ChiTietDonDatHangs.Remove(chitiet);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}