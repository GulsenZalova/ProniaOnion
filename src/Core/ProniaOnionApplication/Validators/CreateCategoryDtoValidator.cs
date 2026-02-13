using System.Security.Cryptography.X509Certificates;
using FluentValidation;
using ProniaOnion.src.Application;

namespace ProniaOnion.Application
{
    public class CreateCategoryDtoValidator:AbstractValidator<CreateCategoryDTO>
    {
        public CreateCategoryDtoValidator()
        {
            
            RuleFor(c=>c.Name)
            .NotEmpty().WithMessage("Not Empty")
            .MinimumLength(3).WithMessage("Qisaqdir")
            .MaximumLength(20).WithMessage("Uzundur")
            .Matches(@"^[A-Za-z\s0-9]*$").WithMessage("Formata uy]un data daxil edin");
            

            // boyuk hefler
            // kicik herfler
            // bosluqlar
            // reqemler

        }
    }
}