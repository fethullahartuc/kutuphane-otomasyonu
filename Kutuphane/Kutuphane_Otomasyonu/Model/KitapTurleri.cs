using FluentValidation.Attributes;
using Kutuphane_Otomasyonu.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Otomasyonu.Model
{
    [Validator(typeof(KitapTurleriValidator))]
    public class KitapTurleri
    {
        public int Id { get; set; }
        public string KitapTuru { get; set; }

        public List<Kitaplar> Kitaplar { get; set; } // bir kitap türünün birden fazla kitabı olabilir o yüzden list
    }
}
