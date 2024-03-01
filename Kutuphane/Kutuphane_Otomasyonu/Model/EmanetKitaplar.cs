using FluentValidation.Attributes;
using Kutuphane_Otomasyonu.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Kutuphane_Otomasyonu.Model
{
    [Validator(typeof(EmanetKitaplarValidator))]
    public class EmanetKitaplar
    {
        public int Id { get; set; }
        public int UyeId { get; set; }
        public int KitapId { get; set; }
        public DateTime KitapAldigiTarihi { get; set; }
        public DateTime? KitapIadeTarihi { get; set; }

        public Kitaplar Kitaplar { get; set; }

        public Uyeler Uyeler { get; set; }
    }
}
