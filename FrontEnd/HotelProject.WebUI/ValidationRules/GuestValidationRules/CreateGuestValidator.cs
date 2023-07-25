using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class CreateGuestValidator:AbstractValidator<CreateGuestDto>
    {
        public CreateGuestValidator()
        {
                RuleFor(x=>x.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez");  
                RuleFor(x=>x.Surname).NotEmpty().WithMessage("Soyisim Alanı Boş Geçilemez");  
                RuleFor(x=>x.City).NotEmpty().WithMessage("Şehir Alanı Boş Geçilemez");

            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Girişi Yapınız");
            RuleFor(x => x.Surname).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter Girişi Yapınız");

        }
    }
}
