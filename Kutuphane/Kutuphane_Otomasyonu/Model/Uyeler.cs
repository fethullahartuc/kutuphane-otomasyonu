using FluentValidation.Attributes;
using Kutuphane_Otomasyonu.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Otomasyonu.Model
{
    [Validator(typeof(UyelerValidator))]
    public class Uyeler
    {
        public int? Id { get; set; }
        public string AdiSoyadi { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string Email { get; set; }
        public DateTime KayitTarihi { get; set; } = DateTime.Now;

        public List<EmanetKitaplar> EmanetKitaplar { get; set; }
    }
}
