using GraduateTraineeEnrollmentClientMVC.Infrastructure;
using GraduateTraineeEnrollmentClientMVC.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduateTraineeEnrollmentClientMVC.Controllers
{
    [Authorize]
    public class EnrollmentReportController : Controller
    {
        private readonly IHttpClientService _httpClientService;

        private readonly IConfiguration _configuration;

        private string endPoint;

        public EnrollmentReportController(IHttpClientService httpClientService, IConfiguration configuration)
        {
            _httpClientService = httpClientService;
            _configuration = configuration;
            endPoint = _configuration["EndPoint:CivicaApi"];
        }


        public IActionResult Index()
        {
            ServiceResponse<IEnumerable<EnrollmentReportViewModel>> response = new ServiceResponse<IEnumerable<EnrollmentReportViewModel>>();
            string endPoint = _configuration["EndPoint:CivicaApi"];
            response = _httpClientService.ExecuteApiRequest<ServiceResponse<IEnumerable<EnrollmentReportViewModel>>>
                ($"{endPoint}GraduateTrainee/GetTraineeEnrollmentReport", HttpMethod.Get, HttpContext.Request);

            if (response.Success)
            {
                return View(response.Data);
            }
            return View(new List<EnrollmentReportViewModel>());
        }
    }
}
