using GraduateTraineeEnrollmentClientMVC.Infrastructure;
using GraduateTraineeEnrollmentClientMVC.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GraduateTraineeEnrollmentClientMVC.Controllers
{
    [Authorize]
    public class GraduateTraineeController : Controller
    {
        private readonly IHttpClientService _httpClientService;

        private readonly IConfiguration _configuration;

        private string endPoint;

        public GraduateTraineeController(IHttpClientService httpClientService, IConfiguration configuration)
        {
            _httpClientService = httpClientService;
            _configuration = configuration;
            endPoint = _configuration["EndPoint:CivicaApi"];
        }




        public IActionResult Index()
        {

            ServiceResponse<IEnumerable<GraduateTraineeViewModel>> response = new ServiceResponse<IEnumerable<GraduateTraineeViewModel>>();

            response = _httpClientService.ExecuteApiRequest<ServiceResponse<IEnumerable<GraduateTraineeViewModel>>>
                ($"{endPoint}GraduateTrainee/GetAll", HttpMethod.Get, HttpContext.Request);
            if (response.Success)
            {
                return View(response.Data);
            }

            return View(new List<GraduateTraineeViewModel>());
        }

        private List<DegreeViewModel> GetAllDegrees()
        {
            ServiceResponse<IEnumerable<DegreeViewModel>> response = new ServiceResponse<IEnumerable<DegreeViewModel>>();
            string endPoint = _configuration["EndPoint:CivicaApi"];
            response = _httpClientService.ExecuteApiRequest<ServiceResponse<IEnumerable<DegreeViewModel>>>
                ($"{endPoint}Degree/GetAllDegrees", HttpMethod.Get, HttpContext.Request);

            if (response.Success)
            {
                return response.Data.ToList();
            }
            return new List<DegreeViewModel>();
        }


        private List<StreamViewModel> GetAllStreams()
        {
            ServiceResponse<IEnumerable<StreamViewModel>> response = new ServiceResponse<IEnumerable<StreamViewModel>>();
            string endPoint = _configuration["EndPoint:CivicaApi"];
            response = _httpClientService.ExecuteApiRequest<ServiceResponse<IEnumerable<StreamViewModel>>>
                ($"{endPoint}Stream/GetAllStream", HttpMethod.Get, HttpContext.Request);

            if (response.Success)
            {
                return response.Data.ToList();
            }
            return new List<StreamViewModel>();
        }

        


        public IActionResult Create()
        {
            AddGraduateTraineeViewModel viewModel = new AddGraduateTraineeViewModel();
            viewModel.degrees = GetAllDegrees();
            viewModel.streams = GetAllStreams();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(AddGraduateTraineeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                string apiUrl = $"{endPoint}GraduateTrainee/AddTrainee";
                var response = _httpClientService.PostHttpResponseMessage(apiUrl, viewModel, HttpContext.Request);
                if (response.IsSuccessStatusCode)
                {
                    string successResponse = response.Content.ReadAsStringAsync().Result;
                    var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<string>>(successResponse);
                    TempData["successMessage"] = serviceResponse.Message;
                    return RedirectToAction("Index");
                }
                else
                {
                    string errorData = response.Content.ReadAsStringAsync().Result;
                    var errorResponse = JsonConvert.DeserializeObject<ServiceResponse<string>>(errorData);
                    if (errorResponse != null)
                    {
                        TempData["errorMessage"] = errorResponse.Message;
                    }
                    else
                    {
                        TempData["errorMesssage"] = "Something went wrong try after some time";
                        return RedirectToAction("Index");
                    }
                }
                return RedirectToAction();
            }
            viewModel.degrees = GetAllDegrees();
            return View(viewModel);
        }

        private List<StreamViewModel> GetStreams(int id)
        {
            ServiceResponse<IEnumerable<StreamViewModel>> response = new ServiceResponse<IEnumerable<StreamViewModel>>();
            string endPoint = _configuration["EndPoint:CivicaApi"];
            response = _httpClientService.ExecuteApiRequest<ServiceResponse<IEnumerable<StreamViewModel>>>
                ($"{endPoint}Stream/GetStreamByDegreeId/" + id, HttpMethod.Get, HttpContext.Request);

            if (response.Success)
            {
                return response.Data.ToList();
            }
            return new List<StreamViewModel>();
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {

            var apiUrl = $"{endPoint}GraduateTrainee/GetById/" + id;
            var response = _httpClientService.GetHttpResponseMessage<UpdateTraineeViewModel>(apiUrl, HttpContext.Request);


            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<UpdateTraineeViewModel>>(data);
                if (serviceResponse != null && serviceResponse.Success && serviceResponse.Data != null)
                {
                    UpdateTraineeViewModel ViewModel = serviceResponse.Data;
                    ViewModel.degrees = GetAllDegrees();
                    ViewModel.streams = GetStreams(ViewModel.DegreeId);
                    return View(ViewModel);
                }
                else
                {
                    TempData["ErrorMessage"] = serviceResponse.Message;
                    return RedirectToAction("Index");
                }
            }
            else
            {
                string errorData = response.Content.ReadAsStringAsync().Result;
                var errorResponse = JsonConvert.DeserializeObject<ServiceResponse<UpdateTraineeViewModel>>(errorData);
                if (errorResponse != null)
                {
                    TempData["ErrorMessage"] = errorResponse.Message;
                }
                else
                {
                    TempData["ErrorMessage"] = "Something went wrong.Please try after sometime.";
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(UpdateTraineeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var apiUrl = $"{endPoint}GraduateTrainee/UpdateTrainee";
                HttpResponseMessage response = _httpClientService.PutHttpResponseMessage(apiUrl, viewModel, HttpContext.Request);
                if (response.IsSuccessStatusCode)
                {
                    string successResponse = response.Content.ReadAsStringAsync().Result;
                    var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<string>>(successResponse);
                    TempData["successMessage"] = serviceResponse.Message;
                    return RedirectToAction("Index");
                }
                else
                {
                    string errorData = response.Content.ReadAsStringAsync().Result;
                    var errorResponse = JsonConvert.DeserializeObject<ServiceResponse<string>>(errorData);
                    if (errorResponse != null)
                    {
                        TempData["errorMessage"] = errorResponse.Message;
                    }
                    else
                    {
                        TempData["errorMesssage"] = "Something went wrong try after some time";
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {

            var apiUrl = $"{endPoint}GraduateTrainee/GetById/" + id;
            var response = _httpClientService.GetHttpResponseMessage<UpdateTraineeViewModel>(apiUrl, HttpContext.Request);

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<UpdateTraineeViewModel>>(data);

                if (serviceResponse != null && serviceResponse.Success && serviceResponse.Data != null)
                {
                    return View(serviceResponse.Data);
                }
                else
                {
                    TempData["ErrorMessage"] = serviceResponse.Message;
                    return RedirectToAction("Index");
                }
            }
            else
            {
                string errorData = response.Content.ReadAsStringAsync().Result;
                var errorResponse = JsonConvert.DeserializeObject<ServiceResponse<UpdateTraineeViewModel>>(errorData);

                if (errorResponse != null)
                {
                    TempData["ErrorMessage"] = errorResponse.Message;
                }
                else
                {
                    TempData["ErrorMessage"] = "Something went wrong please try after some time.";
                }

                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            var apiUrl = $"{endPoint}GraduateTrainee/GetById/" + id;
            var response = _httpClientService.GetHttpResponseMessage<UpdateTraineeViewModel>(apiUrl, HttpContext.Request);

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<UpdateTraineeViewModel>>(data);

                if (serviceResponse != null && serviceResponse.Success && serviceResponse.Data != null)
                {
                    return View(serviceResponse.Data);
                }
                else
                {
                    TempData["ErrorMessage"] = serviceResponse.Message;
                    return RedirectToAction("Index");
                }
            }
            else
            {
                string errorData = response.Content.ReadAsStringAsync().Result;
                var errorResponse = JsonConvert.DeserializeObject<ServiceResponse<UpdateTraineeViewModel>>(errorData);

                if (errorResponse != null)
                {
                    TempData["ErrorMessage"] = errorResponse.Message;
                }
                else
                {
                    TempData["ErrorMessage"] = "Something went wrong please try after some time.";
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int graduateTraineeId)
        {
            var apiUrl = $"{endPoint}GraduateTrainee/RemoveTrainee/" + graduateTraineeId;
            //var response = _httpClientService.GetHttpResponseMessage<string>(apiUrl, HttpContext.Request);

            var response = _httpClientService.ExecuteApiRequest<ServiceResponse<string>>
                ($"{apiUrl}", HttpMethod.Delete, HttpContext.Request);

            if (response.Success)
            {
                TempData["SuccessMessage"] = response.Message;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = response.Message;
                return RedirectToAction("Index");
            }


        }

    }
}
