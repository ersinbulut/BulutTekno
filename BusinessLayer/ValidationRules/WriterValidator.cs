﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<WriterUser>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz!");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadını Boş Geçemezsiniz!");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında kısmını Boş Geçemezsiniz!");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın!");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla veri girişi yapmayın!");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Ünvan kısmını Boş Geçemezsiniz!");
        }
    }
}
