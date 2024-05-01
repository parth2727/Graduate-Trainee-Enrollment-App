using GraduateTraineeEnrollmentApi.Models;

namespace GraduateTraineeEnrollmentApi.Data.Contract
{
    public interface IDegreeRepository
    {
        IEnumerable<Degrees> GetAllDegrees();

        Degrees GetDegreeById(int id);

        bool InsertDegree(Degrees degree);

        bool UpdateDegree(Degrees degree);

        bool DeleteDegree(int id);

        bool DegreeAlreadyExists(string name);

        bool DegreeAlreadyExists(int degreeId, string name);
    }
}
