using FluentValidation;
using Kutuphane_Otomasyonu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Otomasyonu.Validation
{
    public class KitapTurleriValidator:AbstractValidator<KitapTurleri>
    {
        public KitapTurleriValidator()
        {
            RuleFor(x => x.KitapTuru).NotEmpty().WithMessage("Kitap Türü alanı boş geçilemez.");
            RuleFor(x => x.KitapTuru).MaximumLength(150).WithMessage("Kitap Türü alanı en fazla 150 karakter olabilir");

        }
    }
}
