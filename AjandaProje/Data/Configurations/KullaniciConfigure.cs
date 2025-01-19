using AjandaProje.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AjandaProje.Data.Configurations
{
    //Veri tabanı konfigürasyon dosyası.
    public class KullaniciConfigure : IEntityTypeConfiguration<Kullanici>
    {
        public void Configure(EntityTypeBuilder<Kullanici> builder)
        {
            //Hangi Tablo ile eşleşeceği
            builder.ToTable("Kullancilar");

            //Primary Key Alanı
            builder.HasKey(x => x.Id);

            //Tablonun Kolonlarının Tanımları
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Mail).HasColumnName("Mail");
            builder.Property(x => x.KullaniciAdi).HasMaxLength(250).HasColumnName("KullaniciAdi");
            builder.Property(x => x.Sifre).HasMaxLength(500).HasColumnName("Sifre");
            builder.Property(x => x.Isim).HasMaxLength(64).HasColumnName("Isim");
            builder.Property(x => x.Soyisim).HasMaxLength(64).HasColumnName("Soyisim");
            builder.Property(x => x.TelefonNo).HasMaxLength(11).HasColumnName("TelefonNo");

        }
    }
}
