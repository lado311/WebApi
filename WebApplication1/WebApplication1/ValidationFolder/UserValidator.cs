using FluentValidation;
using System.Data;
using WebApplication1.Models;

namespace WebApplication1.ValidationFolder
{
    public class UserValidator : AbstractValidator<Student>
    {
        public UserValidator()
        {
            RuleFor(s => s.Name).NotNull().NotEmpty().MaximumLength(12);
            RuleFor(s => s.LastName).NotNull().NotEmpty().MaximumLength(22);
            RuleFor(s => s.Age).NotNull().GreaterThan(17).WithMessage("Age must be minimum: 18");
            RuleFor(s => s.Email).EmailAddress();
            RuleFor(s => s.PhoneNumber).NotNull().NotEmpty().MaximumLength(9).MinimumLength(9).WithMessage("Phone Number is required");
            RuleFor(s => s.SubjectId).NotNull().GreaterThan(0).LessThan(6).WithMessage("Subject id is not valid");


        }
    }
}
