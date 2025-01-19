using System.ComponentModel.DataAnnotations;

namespace AjandaProje.Models
{
    public class GirisYapModel
    {
        [Required]
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

        [Required]
        [Display(Name = "Şifre")]
        public string Sifre { get; set; }
    }
}
