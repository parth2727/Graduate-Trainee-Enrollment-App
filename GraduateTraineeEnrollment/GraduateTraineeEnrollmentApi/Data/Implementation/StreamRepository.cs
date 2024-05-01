using GraduateTraineeEnrollmentApi.Data.Contract;
using GraduateTraineeEnrollmentApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraduateTraineeEnrollmentApi.Data.Implementation
{
    public class StreamRepository : IStreamRepository
    {
        private AppDBContext _appDbContext;

        public StreamRepository(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Streams> GetAllStreams()
        {
            var streams = new List<Streams>();
            streams = _appDbContext.Streams.Include(s=>s.Degree).ToList();
            return streams;
        }

        public IEnumerable<Streams> GetStreamByDegreeId(int id)
        {
            
            var streams = _appDbContext.Streams.Where(s=>s.DegreeId == id).ToList();    
            return streams;
        }

        public IEnumerable<Streams> GetAllStreamByPagination(int page, int pageSize)
        {
            int skip = (page - 1) * pageSize;
            return _appDbContext.Streams
                .OrderBy(c => c.StreamId)
                .Skip(skip)
                .Take(pageSize)
                .ToList();
        }

        public int TotalNoOfStreams()
        {
            return _appDbContext.Streams.Count();
        }

        public Streams GetStreamById(int id)
        {
            var stream = _appDbContext.Streams.Include(s=>s.Degree).FirstOrDefault(s=>s.StreamId == id);
            return stream;
        }

        public bool InsertStream(Streams stream)
        {
            var result = false;
            if(stream != null)
            {
                _appDbContext.Streams.Add(stream);
                _appDbContext.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool UpdateStream(Streams stream)
        {
            var result = false;
            if(stream != null)
            {
                _appDbContext.Streams.Update(stream);
                _appDbContext.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool DeleteStream(int id)
        {
            var result = false;
            if (id > 0)
            {
                var stream = _appDbContext.Streams.Find(id);
                if (stream != null)
                {
                    _appDbContext.Streams.Remove(stream);
                    _appDbContext.SaveChanges();
                    result = true;
                }

            }
            return result;
        }


        public Streams GetStreamsByDegreeIdStreamName(int degreeId,string streamName)
        {
            var stream = _appDbContext.Streams.FirstOrDefault(s=>s.DegreeId == degreeId && s.StreamName==streamName);
            return stream;
        }

        public Streams GetStreamsByDegreeIdStreamName(int streamId,int degreeId, string streamName)
        {
            var stream = _appDbContext.Streams.FirstOrDefault(s => s.StreamId==streamId &&  s.DegreeId == degreeId && s.StreamName == streamName);
            return stream;
        }

    }
}
