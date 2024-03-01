using FluentValidation;
using Kutuphane_Otomasyonu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Otomasyonu.Validation
{
    public class UyelerValidator:AbstractValidator<Uyeler>
    {
        public UyelerValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş geçilemez.");
            RuleFor(x => x.Email).MaximumLength(150).WithMessage("Email alanı en fazla 150 karakter olabilir.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen bir Email formatı giriniz.");
            //////////////////

            RuleFor(x => x.AdiSoyadi).NotEmpty().WithMessage("Adı Soyadı alanı boş geçilemez.");
            RuleFor(x => x.AdiSoyadi).MaximumLength(100).WithMessage("Adı soyadı alanı en fazla 100 karakter olabilir.");

            RuleFor(x => x.Telefon).NotEmpty().WithMessage("Telefon alanı boş geçilemez.");
            RuleFor(x => x.Telefon).MaximumLength(20).WithMessage("Telefon alanı en fazla 20 karakter olabilir.");

            RuleFor(x => x.Adres).NotEmpty().WithMessage("Adres alanı boş geçilemez.");
            RuleFor(x => x.Adres).MaximumLength(500).WithMessage("Adres alanı en fazla 500 karakter olabilir.");
        }
    }
}
