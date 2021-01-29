using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleDotNetFiveApp.Data.Entities;
using SampleDotNetFiveApp.Data.Web.Validators;

namespace SampleDotNetFiveApp.Data.Web.StartupExtensions
{
    public static partial class StartupExtension
    {
        public static IServiceCollection ValidatorCollection(this IServiceCollection collection, IConfiguration configuration)
        {
            collection.AddScoped<IValidator<Applicant>, ApplicantValidator>();
            return collection;
        }
    }
}
