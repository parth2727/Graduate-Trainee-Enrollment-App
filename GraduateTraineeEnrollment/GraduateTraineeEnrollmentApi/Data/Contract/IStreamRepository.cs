using GraduateTraineeEnrollmentApi.Models;

namespace GraduateTraineeEnrollmentApi.Data.Contract
{
    public interface IStreamRepository
    {
        IEnumerable<Streams> GetAllStreams();
        IEnumerable<Streams> GetStreamByDegreeId(int id);

        IEnumerable<Streams> GetAllStreamByPagination(int page, int pageSize);

        int TotalNoOfStreams();

        Streams GetStreamById(int id);
        bool InsertStream(Streams stream);

        bool UpdateStream(Streams stream);

        bool DeleteStream(int id);

        Streams GetStreamsByDegreeIdStreamName(int degreeId, string streamName);

        Streams GetStreamsByDegreeIdStreamName(int streamId, int degreeId, string streamName);
    }
}
