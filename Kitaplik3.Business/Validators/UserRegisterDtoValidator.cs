using FluentValidation;
using Kitaplik3.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik3.Business.Validators
{
    public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim boş olamaz.")
                .Matches("^[a-zA-ZğüşöçıİĞÜŞÖÇ ]+$")
                .WithMessage("İsim sadece harf ve boşluk içerebilir.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Soyisim boş olamaz.")
                .Matches("^[a-zA-ZğüşöçıİĞÜŞÖÇ ]+$")
                .WithMessage("Soyisim sadece harf ve boşluk içerebilir.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email adresi boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre boş olamaz.")
                .MinimumLength(8).WithMessage("Şifre minimum 8 karakter olmalıdır.")
                .Must(password => password != null && password.Any(char.IsUpper))
                .WithMessage("Şifre en az 1 büyük harf içermelidir.")
                .Must(password => password != null && password.Any(char.IsLower))
                .WithMessage("Şifre en az 1 küçük harf içermelidir.")
                .Must(password => password != null && password.Any(char.IsDigit))
                .WithMessage("Şifre en az 1 sayı içermelidir.");
        }
    }
}
