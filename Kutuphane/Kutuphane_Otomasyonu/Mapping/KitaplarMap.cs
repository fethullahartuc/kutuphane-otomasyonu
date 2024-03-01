using Kutuphane_Otomasyonu.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Otomasyonu.Mapping
{
    public class KitaplarMap:EntityTypeConfiguration<Kitaplar>
    {
        public KitaplarMap()
        {
            this.ToTable("Kitaplar");
            this.HasKey(x => x.Id); // primary key
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // otoamtik artan sayı
            this.Property(x => x.BarkodNo).IsRequired().HasMaxLength(30);
            this.Property(x => x.KitapAdi).IsRequired().HasMaxLength(100);
            this.Property(x => x.YayinEvi).IsRequired().HasMaxLength(150);

            this.HasRequired(x =>x.KitapTurleri).WithMany(x=>x.Kitaplar).HasForeignKey(x=>x.KitapTuruId);
            this.HasRequired(x => x.Yazarlar).WithMany(x => x.Kitaplar).HasForeignKey(x => x.YazarId);

        }
    }
}
