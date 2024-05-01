using GraduateTraineeEnrollmentApi.Dtos;

namespace GraduateTraineeEnrollmentApi.Services.Contract
{
    public interface IAuthService
    {
        ServiceResponse<string> RegisterUserService(RegisterDto register);

        ServiceResponse<string> LoginUserService(LoginDto login);
    }
}
