using DTO;
using FluentValidation;

public class UserDtoValidator : AbstractValidator<userDto>
{
    public UserDtoValidator()
    {
        RuleFor(dto => dto.Username)
            .NotEmpty().WithMessage("UsernName Alanı Boş.")
            .MaximumLength(50).WithMessage("UsernName Alanı %0 karakteri geçemez.");

        RuleFor(dto => dto.Email)
            .NotEmpty().WithMessage("Email Alanı Boş.")
            .EmailAddress().WithMessage("Invalid email address.");

        RuleFor(dto => dto.Password)
            .NotEmpty().WithMessage("Şifre gerekli")
            .MinimumLength(6).WithMessage("Şifre minimum 6 karakterli olabilir.");

        RuleFor(dto => dto.Yas)
            .NotNull().WithMessage("Yaş bilgisi gerekli")
            .InclusiveBetween(18, 99).WithMessage("Yaş alanı 18 ile 99 arasında olmalıdır.");

        RuleFor(dto => dto.Roles)
            .NotEmpty().WithMessage("Roles gerekli bilgisi gerekli")
            .MaximumLength(18).WithMessage("roles alanı 18 ile 99 arasında olmalıdır.");
    }
}
