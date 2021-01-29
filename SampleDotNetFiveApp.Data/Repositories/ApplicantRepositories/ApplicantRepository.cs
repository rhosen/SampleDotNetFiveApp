using SampleDotNetFiveApp.Data.Entities;

namespace SampleDotNetFiveApp.Data.Repositories.ApplicantRepositories
{
    public class ApplicantRepository: GenericRepository<Applicant>, IApplicantRepository
    {
        public ApplicantRepository(ApiContext context):base(context)
        {
                
        }
    }
}
