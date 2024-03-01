using FluentValidation.Attributes;
using Kutuphane_Otomasyonu.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Otomasyonu.Model
{
    [Validator(typeof(KitaplarValidator))]
    public class Kitaplar
    {
        public int Id { get; set; }
        public int KitapTuruId { get; set; }
        public int YazarId { get; set; }
        public string BarkodNo { get; set; }
        public string KitapAdi { get; set; }
        public string YayinEvi { get; set; }
        public int SayfaSayisi { get; set; }
        public DateTime EklenmeTarihi { get; set; } = DateTime.Now;

        public DateTime? GuncellenmeTarihi { get; set; } = DateTime.Now;

        public KitapTurleri KitapTurleri { get; set; } // Bir kitabın bir tane türü olabilir.
        public Yazarlar Yazarlar { get; set; } 

        public List<EmanetKitaplar> EmanetKitaplar { get; set; }
    }
}
