using GraduateTraineeEnrollmentApi.Dtos;
using GraduateTraineeEnrollmentApi.Models;

namespace GraduateTraineeEnrollmentApi.Services.Contract
{
    public interface IDegreeService
    {
        ServiceResponse<IEnumerable<DegreeDto>> GetAllDegrees();

        ServiceResponse<DegreeDto> GetDegreeById(int degreeId);

        ServiceResponse<string> AddDegree(Degrees degrees);

        ServiceResponse<string> ModifyDegree(Degrees degrees);

        ServiceResponse<string> RemoveDegree(int id);


    }
}
