using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleDotNetFiveApp.Data.Repositories.ApplicantRepositories;

namespace SampleDotNetFiveApp.Data.Web.StartupExtensions
{
    public static partial class StartupExtension
    {
        public static IServiceCollection RepositoryCollection(this IServiceCollection collection, IConfiguration configuration)
        {
           // collection.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            collection.AddScoped<IApplicantRepository, ApplicantRepository>();
            return collection;
        }
    }
}
