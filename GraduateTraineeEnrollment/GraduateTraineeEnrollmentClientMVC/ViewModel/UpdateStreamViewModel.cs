using System.ComponentModel.DataAnnotations;

namespace GraduateTraineeEnrollmentClientMVC.ViewModel
{
    public class UpdateStreamViewModel
    {
        [Required(ErrorMessage = "Stream id is required")]
        public int StreamId { get; set; }

        [Required(ErrorMessage = "Stream name is required")]
        public string StreamName { get; set; }

        [Required(ErrorMessage = "Stream description is required")]
        public string StreamDescription { get; set; }

        [Required(ErrorMessage = "Degree id is required")]
        public int DegreeId { get; set; }

        public StreamDegreeViewModel? Degree { get; set; }

        public List<DegreeViewModel>? Degrees { get; set; }
    }
}
