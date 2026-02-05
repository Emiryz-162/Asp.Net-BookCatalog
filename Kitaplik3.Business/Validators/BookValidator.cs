using FluentValidation;
using Kitaplik3.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik3.Business.Validators
{
    public class BookValidator: AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kitap adı boş olamaz.")
            .Length(3, 100).WithMessage("Kitap adı 3 ile 100 karakter arasında olmalıdır.");

            RuleFor(x => x.ISBN)
                .NotEmpty().WithMessage("ISBN boş olamaz.")
                .Length(10, 13).WithMessage("ISBN 10 veya 13 haneli olmalıdır.");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Kategori seçmelisiniz.");

            RuleFor(x => x.AuthorId)
                .GreaterThan(0).WithMessage("Yazar seçmelisiniz.");

            RuleFor(x => x.PublisherId)
                .GreaterThan(0).WithMessage("Yayıncı seçmelisiniz.");
        }
    }
}
