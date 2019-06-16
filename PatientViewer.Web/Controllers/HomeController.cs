using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using PatientViewer.Web.Models;
using PatientViewer.Service.Interfaces;

namespace PatientViewer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPatientService _patientService;

        public HomeController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        /// <summary>
        /// Gets all patients
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var patients = await _patientService.GetAllAsync();

            return View(patients.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}