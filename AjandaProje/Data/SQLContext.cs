using AjandaProje.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AjandaProje.Data
{
    public class SQLContext :DbContext
    {
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Not> Notlar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = AjandaKayit; Trusted_Connection = true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
