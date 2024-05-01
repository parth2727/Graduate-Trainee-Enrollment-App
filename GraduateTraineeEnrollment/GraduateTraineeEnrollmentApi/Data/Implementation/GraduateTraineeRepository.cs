using GraduateTraineeEnrollmentApi.Data.Contract;
using GraduateTraineeEnrollmentApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraduateTraineeEnrollmentApi.Data.Implementation
{
    public class GraduateTraineeRepository : IGraduateTraineeRepository
    {
        private AppDBContext _appDbContext;

        public GraduateTraineeRepository(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<GraduateTrainees> GetAllTrainee()
        {
            var gt = new List<GraduateTrainees>();
            gt = _appDbContext.GraduateTrainees.Include(t=> t.Stream).Include(t=>t.Degree).ToList();
            return gt;
        }

        public GraduateTrainees GetGraduateTraineeById(int id)
        {
            var trainee = _appDbContext.GraduateTrainees.Include(t => t.Stream).Include(t => t.Degree).FirstOrDefault(c => c.GraduateTraineeId == id);
            return trainee;
        }

        public GraduateTrainees GetGradsByDegreeIdStreamIdGradsName(string traineeEmail)
        {
            var trainee = _appDbContext.GraduateTrainees.FirstOrDefault(t =>t.TraineeEmail == traineeEmail);
            return trainee;
        }

        public GraduateTrainees GetGradsByDegreeIdStreamIdGradsName(int gradsId, string traineeEmail)
        {
            var trainee = _appDbContext.GraduateTrainees.FirstOrDefault(t => t.GraduateTraineeId == gradsId && t.TraineeEmail == traineeEmail);
            return trainee;
        }

        public bool InsertGraduateTrainee(GraduateTrainees graduateTrainee)
        {
            var result = false;
            if (graduateTrainee != null)
            {
                _appDbContext.GraduateTrainees.Add(graduateTrainee);
                _appDbContext.SaveChanges();
                result = true;
            }

            return result;
        }

        public bool UpdateGraduateTrainee(GraduateTrainees graduateTrainee)
        {
            var result = false;
            if (graduateTrainee != null)
            {
                _appDbContext.GraduateTrainees.Update(graduateTrainee);
                _appDbContext.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool DeleteGraduateTrainee(int id)
        {
            var result = false;
            if(id > 0)
            {
                var grads = _appDbContext.GraduateTrainees.Find(id);
                if(grads != null)
                {
                    _appDbContext.GraduateTrainees.Remove(grads);
                    _appDbContext.SaveChanges();
                    result = true;
                }
            }
            return result;
        }

        

        public bool IsDateValid(DateTime dateTime)
        {
            var date = _appDbContext.GraduateTrainees.FirstOrDefault(c => c.DateOfApplication == dateTime);
            if (dateTime > DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<TraineeEnrollmentReportResult> TraineeEnrollmentReport()
        {
            List<TraineeEnrollmentReportResult> report = _appDbContext.TraineeEnrollmentReport().ToList();
            return report;
        }



    }
}
