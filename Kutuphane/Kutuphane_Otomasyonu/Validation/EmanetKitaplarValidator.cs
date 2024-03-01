using FluentValidation;
using Kutuphane_Otomasyonu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Otomasyonu.Validation
{
    public class EmanetKitaplarValidator:AbstractValidator<EmanetKitaplar>
    {
        public EmanetKitaplarValidator()
        {

            RuleFor(x => x.UyeId).NotEmpty().WithMessage("Üye Adı alanı boş geçilemez.");
            RuleFor(x => x.KitapId).NotEmpty().WithMessage("Kitap Adı alanı boş geçilemez.");
            RuleFor(x => x.KitapAldigiTarihi).NotEmpty().WithMessage("Tarih alanı boş geçilemez.");


        }
    }
}
