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
    public class EmanetKitaplarMap:EntityTypeConfiguration<EmanetKitaplar>
    {
        public EmanetKitaplarMap()
        {
            this.ToTable("EmanetKitaplar");
            this.HasKey(x => x.Id); // primary key
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // otoamtik artan sayı

            this.HasRequired(x=>x.Kitaplar).WithMany(x=>x.EmanetKitaplar).HasForeignKey(x=>x.KitapId);
            this.HasRequired(x => x.Uyeler).WithMany(x => x.EmanetKitaplar).HasForeignKey(x => x.UyeId);
            


        }
    }
}
