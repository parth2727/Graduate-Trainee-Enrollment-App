using GraduateTraineeEnrollmentApi.Models;

namespace GraduateTraineeEnrollmentApi.Dtos
{
    public class StreamDto
    {
        public int StreamId { get; set; }
        public string StreamName { get; set; }
        public string StreamDescription { get; set; }
        public int DegreeId { get; set; }

        public virtual Degrees Degree { get; set; }
        public virtual ICollection<GraduateTrainees> GraduateTrainees { get; set; }
    }
}
