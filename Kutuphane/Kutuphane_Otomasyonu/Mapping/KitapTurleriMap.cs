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
    public class KitapTurleriMap:EntityTypeConfiguration<KitapTurleri>
    {
        public KitapTurleriMap()
        {

            this.ToTable("KitapTurleri");
            this.HasKey(x => x.Id); // primary key
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // otoamtik artan sayı
            this.Property(x => x.KitapTuru).IsRequired().HasMaxLength(150);
        }
    }
}
