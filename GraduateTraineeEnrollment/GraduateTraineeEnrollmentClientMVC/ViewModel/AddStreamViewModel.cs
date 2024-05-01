using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GraduateTraineeEnrollmentClientMVC.ViewModel
{
    public class AddStreamViewModel
    {
        [Required(ErrorMessage = "Stream name is required")]
        [DisplayName("Stream name")]
        public string StreamName { get; set; }

        [Required(ErrorMessage = "Stream description is required")]
        [DisplayName("Stream description")]
        public string StreamDescription { get; set; }

        [Required(ErrorMessage = "Degree is required")]
        [DisplayName("Degree")]
        public int DegreeId { get; set; }

        public StreamDegreeViewModel? Degree { get; set; }

        public List<DegreeViewModel>? Degrees { get; set; }
    }
}
