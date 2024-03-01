using Kutuphane_Otomasyonu.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Otomasyonu.Model.Context
{
    public class KutuphaneContext:DbContext
    {
        public KutuphaneContext():base("Kutuphane")
        {
            
        }

        public DbSet<EmanetKitaplar> EmanetKitaplar { get; set; }
        public DbSet<Kitaplar> Kitaplar { get; set; }
        public DbSet<KitapTurleri> KitapTurleri { get; set; }
        public DbSet<Uyeler> Uyeler { get; set; }

        public DbSet<Yazarlar> Yazarlar {  get; set; }

        // sql tabloların deisgn kısmını güncellemek için
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmanetKitaplarMap());

            modelBuilder.Configurations.Add(new KitaplarMap());

            modelBuilder.Configurations.Add(new KitapTurleriMap());

            modelBuilder.Configurations.Add(new UyelerMap());
            modelBuilder.Configurations.Add(new YazarlarMap());

        }



    }
}
