namespace AjandaProje.Models
{
    public class TakvimGoruntuleModel
    {
        public int Ay { get; set; }
        public int Yil { get; set; }
        public List<int?> Gunler { get; set; } = new List<int?>();
        public List<DateTime?> Tarihler { get; set; } = new List<DateTime?>();
        public List<DateTime> KullaniciEkliVeriler { get; set; } = new List<DateTime>();





    }
    public enum Ay
    {
        Ocak = 1,
        Şubat = 2,
        Mart = 3,
        Nisan = 4,
        Mayıs = 5,
        Haziran = 6,
        Temmuz = 7,
        Ağustos = 8,
        Eylül = 9,
        Ekim = 10,
        Kasım = 11,
        Aralık = 12
    }
}
