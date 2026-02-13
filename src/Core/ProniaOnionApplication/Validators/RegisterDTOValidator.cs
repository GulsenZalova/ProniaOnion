using System.Security.Cryptography.X509Certificates;
using FluentValidation;
using ProniaOnion.src.Application;

namespace ProniaOnion.Application
{
    public class RegisterDTOValidator:AbstractValidator<RegisterDTO>
    {
        public RegisterDTOValidator()
        {
            
            RuleFor(u=>u.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50)
            .Matches(@"^[A-Za-z]*$");

             RuleFor(u=>u.Surname)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50)
            .Matches(@"^[A-Za-z]*$");
            
             RuleFor(u=>u.UserName)
            .NotEmpty()
            .MinimumLength(4)
            .MaximumLength(250)
            .Matches(@"^[A-Za-z0-9-._@]*$");

             RuleFor(u=>u.Email)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(256)
            .Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");

             RuleFor(u=>u.Password)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(100);
   
        }
    }
}