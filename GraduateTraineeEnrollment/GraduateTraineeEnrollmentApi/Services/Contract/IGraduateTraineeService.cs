using GraduateTraineeEnrollmentApi.Dtos;
using GraduateTraineeEnrollmentApi.Models;

namespace GraduateTraineeEnrollmentApi.Services.Contract
{
    public interface IGraduateTraineeService
    {
        ServiceResponse<IEnumerable<GraduateTraineeDto>> GetGraduateTrainees();

        ServiceResponse<GraduateTraineeDto> GetGraduateTraineeById(int id);

        ServiceResponse<string> AddGraduateTrainee(GraduateTrainees graduateTrainees);

        ServiceResponse<string> ModifyTrainee(GraduateTrainees graduateTrainees);

        ServiceResponse<string> DeleteTrainee(int id);

        ServiceResponse<IEnumerable<TraineeEnrollmentReportResult>> TraineeReport();

    }
}
