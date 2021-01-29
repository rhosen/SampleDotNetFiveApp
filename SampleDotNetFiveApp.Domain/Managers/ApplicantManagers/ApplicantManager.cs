using System;
using System.Collections.Generic;
using SampleDotNetFiveApp.Data.Entities;
using SampleDotNetFiveApp.Data.Repositories.ApplicantRepositories;

namespace SampleDotNetFiveApp.Data.Domain.Managers.ApplicantManagers
{
    public class ApplicantManager : ManagerCommon, IApplicantManager
    {
        private readonly IApplicantRepository _applicantRepository;

        public ApplicantManager(IApplicantRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }

        public List<Applicant> GetAll()
        {

            try
            {
                return _applicantRepository.GetAll().Result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Applicant Get(int id)
        {
            try
            {
                return _applicantRepository.Get(id).Result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Applicant Add(Applicant entity)
        {
            try
            {
                return _applicantRepository.Add(entity).Result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Applicant Update(Applicant entity)
        {
            try
            {
                return _applicantRepository.Update(entity).Result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Applicant Delete(int id)
        {
            try
            {
                return _applicantRepository.Delete(id).Result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
