using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleDotNetFiveApp.Data.Domain.Managers.ApplicantManagers;

namespace SampleDotNetFiveApp.Data.Web.StartupExtensions
{
    public static partial class StartupExtension
    {
        public static IServiceCollection ManagerCollection(this IServiceCollection collection, IConfiguration configuration)
        {
            collection.AddScoped<IApplicantManager, ApplicantManager>();
            return collection;
        }
    }
}
