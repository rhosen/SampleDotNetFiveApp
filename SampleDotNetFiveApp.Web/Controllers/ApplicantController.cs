using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SampleDotNetFiveApp.Data.Domain.Managers.ApplicantManagers;
using SampleDotNetFiveApp.Data.Entities;

namespace SampleDotNetFiveApp.Data.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantManager _applicantManager;
        private readonly IValidator<Applicant> _validator;
        private static readonly HttpClient Client = new HttpClient();

        public ApplicantController(
            IApplicantManager applicantManager,
            IValidator<Applicant> validator
            )
        {
            _applicantManager = applicantManager;
            _validator = validator;
        }

        /// <summary>
        /// Get all Applicant
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicantManager.GetAll());
        }

        /// <summary>
        /// Get an applicant by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var res = _applicantManager.Get(id);
            return res == null ? (ActionResult<string>) NotFound() : Ok(res);
        }

        /// <summary>
        /// Add a new applicant
        /// </summary>
        /// <param name="applicant"></param>
        /// <returns></returns>
        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Applicant applicant)
        {
            applicant = ValidateCountry(applicant).Result;
            var result = _validator.Validate(applicant);
            if (result.IsValid)
            {
                var response = _applicantManager.Add(applicant);
                return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
            }
            return BadRequest(result.Errors.FirstOrDefault()?.ErrorMessage);
        }


        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<Applicant> ValidateCountry(Applicant applicant)
        {
            if (string.IsNullOrEmpty(applicant.CountryOfOrigin)) return applicant;

            var url = $"https://restcountries.eu/rest/v2/name/{applicant.CountryOfOrigin}?fullText=true";
            try
            {
                HttpResponseMessage response = await Client.GetAsync(url);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                // set country of origin to empty if not found
                // then call NotEmpty() from validator to validate
                applicant.CountryOfOrigin = "";
            }
            return applicant;
        }

        /// <summary>
        /// Update an existing applicant
        /// </summary>
        /// <param name="id"></param>
        /// <param name="applicant"></param>
        /// <returns></returns>
        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Applicant applicant)
        {
            if (id != applicant.Id) return BadRequest();
            if (_applicantManager.Get(id) == null) return NotFound();
            applicant = ValidateCountry(applicant).Result;
            var result = _validator.Validate(applicant);
            if (result.IsValid)
            {
                var response = _applicantManager.Update(applicant);
                return NoContent();
            }
            return BadRequest(result.Errors.FirstOrDefault()?.ErrorMessage);

        }

        /// <summary>
        /// Delete an applicant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_applicantManager.Get(id) == null) return NotFound();
            _applicantManager.Delete(id);
            return NoContent();
        }
    }
}
