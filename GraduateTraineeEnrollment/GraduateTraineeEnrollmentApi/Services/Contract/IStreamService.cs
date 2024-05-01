using GraduateTraineeEnrollmentApi.Dtos;
using GraduateTraineeEnrollmentApi.Models;

namespace GraduateTraineeEnrollmentApi.Services.Contract
{
    public interface IStreamService
    {
        ServiceResponse<IEnumerable<StreamDto>> GetAllStreams();
        ServiceResponse<IEnumerable<StreamDto>> GetStreamByDegreeId(int id);

        IEnumerable<Streams> GetPaginatedStreams(int page, int pageSize);

        int TotalNoOfStreams();

        ServiceResponse<string> AddStream(Streams stream);

        ServiceResponse<string> UpdateStream(Streams streams);

        ServiceResponse<string> DeleteStream(int id);

        ServiceResponse<StreamDto> GetStreamById(int id);
    }
}
