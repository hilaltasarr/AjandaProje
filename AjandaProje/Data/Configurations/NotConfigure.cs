using AjandaProje.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AjandaProje.Data.Configurations
{
    //Veri tabanı konfigürasyon dosyası . 
    public class NotConfigure : IEntityTypeConfiguration<Not>
    {
        public void Configure(EntityTypeBuilder<Not> builder)
        {
            //Hangi Tablo ile eşleşeceği
            builder.ToTable("Notlar");

            //Primary Key Alanı
            builder.HasKey(x => x.Id);
             
            //Tablonun Kolonlarının Tanımları
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.KullaniciId).HasColumnName("KullaniciId");
            builder.Property(x => x.Tarih).HasColumnName("Tarih");
            builder.Property(x => x.Notlar).HasColumnName("Notlar");
        }
    }
}
