using GraduateTraineeEnrollmentApi.Models;

namespace GraduateTraineeEnrollmentApi.Data.Contract
{
    public interface IGraduateTraineeRepository
    {
        IEnumerable<GraduateTrainees> GetAllTrainee();

        GraduateTrainees GetGraduateTraineeById(int id);

        bool InsertGraduateTrainee(GraduateTrainees graduateTrainee);

        bool UpdateGraduateTrainee(GraduateTrainees graduateTrainee);

        bool DeleteGraduateTrainee(int id);

        //bool GraduateTraineeExists(string name);

        //bool GraduateTraineeExists(int id, string name);

        GraduateTrainees GetGradsByDegreeIdStreamIdGradsName(string traineeEmail);

        GraduateTrainees GetGradsByDegreeIdStreamIdGradsName(int gradsId,string traineeEmail);
        

        bool IsDateValid(DateTime dateTime);

        IEnumerable<TraineeEnrollmentReportResult> TraineeEnrollmentReport();


    }
}
