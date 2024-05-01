using GraduateTraineeEnrollmentApi.Models;

namespace GraduateTraineeEnrollmentApi.Dtos
{
    public class DegreeDto
    {
        public int DegreeId { get; set; }
        public string DegreeName { get; set; }
        public string DegreeDescription { get; set; }

        public virtual ICollection<GraduateTrainees> GraduateTrainees { get; set; }
        public virtual ICollection<Streams> Streams { get; set; }
    }
}
