using FluentValidation;
using Kutuphane_Otomasyonu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Otomasyonu.Validation
{
    public class KitaplarValidator:AbstractValidator<Kitaplar>
    {
        public KitaplarValidator()
        {
            RuleFor(x => x.KitapAdi).NotEmpty().WithMessage("Kitap Adı alanı boş geçilemez.");
            RuleFor(x => x.KitapAdi).MaximumLength(100).WithMessage("Kitap Adı alanı en fazla 100 karakter olabilir.");

            RuleFor(x => x.BarkodNo).NotEmpty().WithMessage("Barkod No alanı boş geçilemez.");
            RuleFor(x => x.SayfaSayisi).NotEmpty().WithMessage("Sayfa Sayısı alanı boş geçilemez.");
            RuleFor(x => x.KitapTuruId).NotEmpty().WithMessage("Kitap Türü alanı boş geçilemez.");
            RuleFor(x => x.BarkodNo).MaximumLength(30).WithMessage("Barkod No alanı en fazla 30 karakter olabilir.");

            RuleFor(x => x.YazarId).NotEmpty().WithMessage("Yazar Adı alanı boş geçilemez.");

            RuleFor(x => x.YayinEvi).NotEmpty().WithMessage("Yayın Evi alanı boş geçilemez.");
            RuleFor(x => x.YayinEvi).MaximumLength(150).WithMessage("Yayın Evi alanı en fazla 150 karakter olabilir.");
        }
    }
}
