namespace AjandaProje.Models
{
    public class NotGuncelleModel
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public DateTime Tarih { get; set; }
        public string Not { get; set; }
    }

}
