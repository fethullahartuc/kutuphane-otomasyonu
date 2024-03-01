using FluentValidation;
using Kutuphane_Otomasyonu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Otomasyonu.Validation
{
    public class YazarlarValidator: AbstractValidator<Yazarlar>
    {
        public YazarlarValidator()
        {
            RuleFor(x => x.YazarAdi).NotEmpty().WithMessage("Yazar Adı alanı boş geçilemez.");
            RuleFor(x => x.YazarAdi).MaximumLength(100).WithMessage("Kitap Türü alanı en fazla 100 karakter olabilir");
        }
    }
}
