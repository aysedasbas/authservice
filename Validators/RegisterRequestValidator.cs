using FluentValidation;
using AuthService.Controllers;

namespace AuthService.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı boş olamaz.");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalı.");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Şifreler eşleşmiyor.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Geçerli bir email giriniz.");
            RuleFor(x => x.PhoneNumber).NotEmpty().Length(10, 15).WithMessage("Telefon numarası geçersiz.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Ad boş bırakılamaz.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyad boş bırakılamaz.");
        }
    }
}
