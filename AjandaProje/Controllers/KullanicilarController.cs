using AjandaProje.Data;
using AjandaProje.Models;
using AjandaProje.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AjandaProje.Controllers
{
    public class KullanicilarController : Controller
    {
        SQLContext _context = new SQLContext();

        [HttpPost]
        public IActionResult KayitOl(KayitOlModel kayitOlModel)
        {
            if (ModelState.IsValid)
            {
                //Kullanıcının Kayıt olurken eğer ilgili kullanıcının Mail bilgisi veya KullanıcıAdı varsa hata dönsün
                var kullaniciVar = _context.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == kayitOlModel.KullaniciAdi || x.Mail == kayitOlModel.Mail);
                if (kullaniciVar != null)
                    return BadRequest("İlgili Kullanıcı Sistemde Mevcut");

                var kayitOl = new Kullanici();
                kayitOl.KullaniciAdi = kayitOlModel.KullaniciAdi;
                kayitOl.Isim = kayitOlModel.Isim;
                kayitOl.Soyisim = kayitOlModel.Soyisim;
                kayitOl.Mail = kayitOlModel.Mail;
                kayitOl.Sifre = kayitOlModel.Sifre;
                kayitOl.TelefonNo = kayitOlModel.TelefonNo;

                _context.Kullanicilar.Add(kayitOl);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");

        }
      
        [HttpPost]
        public IActionResult GirisYap(GirisYapModel girisYapModel)
        {
            //İlgili Kullanıcı var ise Giriş yapsın.
            var kullaniciVar = _context.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == girisYapModel.KullaniciAdi && x.Sifre == girisYapModel.Sifre);
            if (kullaniciVar == null)
                return RedirectToAction("Index", "Home");

            //Kullanıcının bilgilerini Tempdata'da tutma
            TempData["TamIsim"] = kullaniciVar.Isim + " " + kullaniciVar.Soyisim;
            TempData["KullaniciId"] = kullaniciVar.Id;
            return RedirectToAction("TakvimGoruntule", "Takvim");
        }
    }


}
