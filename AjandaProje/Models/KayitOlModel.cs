using System.ComponentModel.DataAnnotations;

namespace AjandaProje.Models
{
    public class KayitOlModel
    {

        [Required]
        [Display(Name = "E-Posta Giriniz")]
        public string Mail { get; set; }

        [Required]
        [Display(Name = "Kullanıcı Adı Giriniz")]
        public string KullaniciAdi { get; set; }

        [Required]
        [Display(Name = "Şifre Giriniz")]
        public string Sifre { get; set; }

        [Required]
        [Display(Name = "İsim Giriniz")]
        public string Isim { get; set; }

        [Required]
        [Display(Name = "Soyisim Giriniz")]
        public string Soyisim { get; set; }

        [Required]
        [Display(Name = "Telefon Numarası Giriniz")]
        public string TelefonNo { get; set; }

    }

}
