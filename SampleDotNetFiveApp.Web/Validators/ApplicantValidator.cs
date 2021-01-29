using FluentValidation;
using SampleDotNetFiveApp.Data.Entities;

namespace SampleDotNetFiveApp.Data.Web.Validators
{
    public class ApplicantValidator : AbstractValidator<Applicant>
    {
        public ApplicantValidator()
        {

            RuleFor(x => x.Name)
                .MinimumLength(5);

            RuleFor(x => x.FamilyName)
                .MinimumLength(5);

            RuleFor(x => x.Address)
                .MinimumLength(10);

            RuleFor(x => x.EmailAddress)
                .EmailAddress();

            RuleFor(x => x.Age)
                .InclusiveBetween(20, 60);

            RuleFor(x => x.CountryOfOrigin)
                .NotEmpty().WithMessage("'Country Of Origin' is not a valid country.");
        }
    }
}
