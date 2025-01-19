using AjandaProje.Data;
using AjandaProje.Models.Entities;
using AjandaProje.Models;
using Microsoft.AspNetCore.Mvc;

namespace AjandaProje.Controllers
{
    public class TakvimDetayController : Controller
    {
        SQLContext _context = new SQLContext();
        public IActionResult TakvimDetay(DateTime tarih, int kullaniciId)
        {
            var notGoruntuleModel = new NotGoruntuleModel();
           
            bool veriVar = true;
            
            var veriGetir = _context.Notlar.FirstOrDefault(x => x.Tarih == tarih &&x.KullaniciId==kullaniciId);
            
            notGoruntuleModel.Tarih = tarih;
            
            if (veriGetir == null)
            {
                veriVar = false;
                notGoruntuleModel.Not = "";
            }
            else
            {
                veriVar = true;
                notGoruntuleModel.Not = veriGetir.Notlar;
            }
   
            ViewBag.veriVar = veriVar;
            TempData.Keep("KullaniciId");
            TempData.Keep("TamIsim");

            return View(notGoruntuleModel);
        }

        public IActionResult TakvimDetayEkle(NotEkleModel notEkleModel)
        {
            var not = new Not();
            
            not.Tarih = notEkleModel.Tarih;
            not.KullaniciId = notEkleModel.KullaniciId;
            not.Notlar = notEkleModel.Not;

            _context.Notlar.Add(not);
            _context.SaveChanges();

            TempData.Keep("KullaniciId");
           
            return RedirectToAction("TakvimGoruntule", "Takvim",new {yil = not.Tarih.Year,ay=not.Tarih.Month});
        }
        public IActionResult TakvimDetayGuncelle(NotGuncelleModel notGuncelleModel)
        {
            var notGetir = _context.Notlar.FirstOrDefault(x => x.Tarih  == notGuncelleModel.Tarih && x.KullaniciId==notGuncelleModel.KullaniciId);
            if (notGetir == null)
                return BadRequest("İlgili Not Bulunamadı");

            notGetir.Tarih = notGuncelleModel.Tarih;
            notGetir.KullaniciId = notGuncelleModel.KullaniciId;

            if (string.IsNullOrEmpty(notGuncelleModel.Not))
            {
                TakvimDetaySil(notGuncelleModel.Tarih, notGuncelleModel.KullaniciId);
                return RedirectToAction("TakvimGoruntule", "Takvim", new { yil = notGetir.Tarih.Year, ay = notGetir.Tarih.Month });
            }
            notGetir.Notlar = notGuncelleModel.Not;

            _context.Notlar.Update(notGetir);
            _context.SaveChanges();
            
            TempData.Keep("KullaniciId");
            TempData.Keep("TamIsim");

            return RedirectToAction("TakvimGoruntule", "Takvim", new { yil = notGetir.Tarih.Year, ay = notGetir.Tarih.Month });
        }

        public IActionResult TakvimDetaySil(DateTime tarih, int kullaniciId)
        {
            var notBul = _context.Notlar.FirstOrDefault(x => x.Tarih == tarih && x.KullaniciId == kullaniciId);
            if (notBul == null)
                return BadRequest("İlgili Not Bulunamadı");

            _context.Notlar.Remove(notBul);
            _context.SaveChanges();
            
            TempData.Keep("KullaniciId");
            TempData.Keep("TamIsim");

            return RedirectToAction("TakvimGoruntule", "Takvim", new { yil = notBul.Tarih.Year, ay = notBul.Tarih.Month });
        }
    }
}
