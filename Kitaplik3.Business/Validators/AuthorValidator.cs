using FluentValidation;
using Kitaplik3.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik3.Business.Validators
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Yazar adı boş olamaz.")
                .Length(3, 100).WithMessage("Yazar adı 3 ile 100 karakter arasında olmalıdır.");
        }
    }
}
