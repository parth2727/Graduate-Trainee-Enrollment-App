namespace GraduateTraineeEnrollmentClientMVC.ViewModel
{
    public class StreamViewModel
    {
        public int StreamId { get; set; }
        public string StreamName { get; set; }
        public string StreamDescription { get; set; }
        public int DegreeId { get; set; }

        public StreamDegreeViewModel? Degree {  get; set; }

        public List<DegreeViewModel>? Degrees { get; set; }
    }
}
