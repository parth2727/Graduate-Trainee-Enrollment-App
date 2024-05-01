using GraduateTraineeEnrollmentApi.Data.Contract;
using GraduateTraineeEnrollmentApi.Models;

namespace GraduateTraineeEnrollmentApi.Data.Implementation
{
    public class DegreeRepository : IDegreeRepository
    {
        private AppDBContext _appDbContext;

        public DegreeRepository(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Degrees> GetAllDegrees()
        {
            List<Degrees> degrees = _appDbContext.Degrees.ToList();
            return degrees;
        }

        public Degrees GetDegreeById(int id)
        {
            var d = _appDbContext.Degrees.FirstOrDefault(d => d.DegreeId == id);
            return d;
        }

        public bool InsertDegree(Degrees degree)
        {
            var result = false;
            if (degree != null)
            {
                _appDbContext.Degrees.Add(degree);
                _appDbContext.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool UpdateDegree(Degrees degree)
        {
            var result = false;
            if(degree != null)
            {
                _appDbContext.Degrees.Update(degree);
                _appDbContext.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool DeleteDegree(int id)
        {
            var result = false;
            var degree = _appDbContext.Degrees.Find(id);
            if (degree != null)
            {
                _appDbContext.Degrees.Remove(degree);
                _appDbContext.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool DegreeAlreadyExists(string name)
        {
            var degree = _appDbContext.Degrees.FirstOrDefault(d => d.DegreeName == name);
            if(degree != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DegreeAlreadyExists(int degreeId , string name)
        {
            var degree = _appDbContext.Degrees.FirstOrDefault(d => d.DegreeId != degreeId && d.DegreeName == name);
            if (degree != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
