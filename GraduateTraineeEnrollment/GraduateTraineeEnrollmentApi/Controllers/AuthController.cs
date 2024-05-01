using GraduateTraineeEnrollmentApi.Dtos;
using GraduateTraineeEnrollmentApi.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduateTraineeEnrollmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterDto register)
        {
            var response = _authService.RegisterUserService(register);
            return !response.Success ? BadRequest(response) : Ok(response);
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDto login)
        {
            var response = _authService.LoginUserService(login);
            return !response.Success ? BadRequest(response) : Ok(response);
        }
    }
}
