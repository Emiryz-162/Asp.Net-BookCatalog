using FluentValidation;
using Kitaplik3.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik3.Business.Validators
{
    public class PublisherValidator: AbstractValidator<Publisher>
    {
        public PublisherValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Yayıncı adı boş olamaz.")
                .Length(3, 100).WithMessage("Yayıncı adı 3 ile 100 karakter arasında olmalıdır.");
        }
    }
}
