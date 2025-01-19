using AjandaProje.Data;
using AjandaProje.Models;
using Microsoft.AspNetCore.Mvc;

namespace AjandaProje.Controllers
{
    public class TakvimController : Controller
    {
        SQLContext _context = new SQLContext();
        public IActionResult TakvimGoruntule(int yil = 0, int ay = 0)
        {
            //Giriş Yapıldıysa hangi tarihte otomatik olarak çeksin
            if (yil == 0)
            {
                yil = DateTime.Now.Year;
                ay = DateTime.Now.Month;
            }
           
            //Önceki Ay Butonuna tıklayıp ilgili tarihin ay zamanı 0'a düşerse ilgili yılı düşür
            if (ay < 1)
            {
                ay = 12;
                yil--;
            }
            //Sonraki Ay Butonuna tıklayıp ilgili tarihin ay zamanı 12'den yüksek olursa ilgili yılı artır
            else if (ay > 12)
            {
                ay = 1;
                yil++;
            }

            //O ay içerisindeki Günleri al
            var ayinIcindekiGunler = DateTime.DaysInMonth(yil, ay);

            //İlgili ayın haftanın ilk gününü al
            var haftaIlkGunAl = new DateTime(yil, ay, 1).DayOfWeek;

            //Bilgisayar sistemleri Otomatik olarak günü pazar günü aldığı için Haftanın ilk gününü Pazartesi olarak al
            int haftaIlkGunAyarla = (int)haftaIlkGunAl - 1;
            if (haftaIlkGunAyarla < 0)
                // Eğer Pazar günü ise 6'ya ayarla
                haftaIlkGunAyarla = 6; 

     
            var gunler = new List<int?>();
            var tarihler = new List<DateTime?>();

            
            //Haftanın ilk günü pazartesiye gelmiyorsa
            //Örneğin; 31.12.2024 Salı gününe denk gelip Ocak ayı için Çarşamba gününe geliyorsa tasarıma göre boşluk at
            for (int i = 0; i < (int)haftaIlkGunAyarla; i++)
            {
                gunler.Add(null);
                tarihler.Add(null);
            }

            //Ayın içerisindeki bütün günleri al
            for (int i = 1; i <= ayinIcindekiGunler; i++)
            {
                gunler.Add(i);
                tarihler.Add(new DateTime(yil, ay, i));

            }

            //Kullanıcının verilerinin olduğu kod bloğu
            var veriOlanGunler = _context.Notlar
                .Where(v => v.Tarih.Year == yil && v.Tarih.Month == ay && v.KullaniciId == Convert.ToInt32(TempData["KullaniciId"]))
                .Select(v => v.Tarih.Date)
                .ToList();

            var viewModel = new TakvimGoruntuleModel
            {
                Yil = yil,
                Ay = ay,
                Gunler = gunler,
                Tarihler = tarihler,
                KullaniciEkliVeriler = veriOlanGunler
            };

            //Giriş yaptığımız kullanıcının bilgileri
            ViewBag.TamIsim = TempData["TamIsim"];
            TempData.Keep("TamIsim");
            TempData.Keep("KullaniciId");

            return View(viewModel);
        }




    }


}
