using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using PatientViewer.Data.Models;
using PatientViewer.Service.Interfaces;

namespace PatientViewer.Web.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // GET: api/Patient
        /// <summary>
        /// Gets all patients
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _patientService.GetAllAsync();
        }

        // GET: api/Patient/1
        /// <summary>
        /// Gets a single patient by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<Patient> GetByIdAsync(int id)
        {
            return await _patientService.GetByIdAsync(id);
        }
    }
}
