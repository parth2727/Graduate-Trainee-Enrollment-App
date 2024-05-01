using System.ComponentModel.DataAnnotations;

namespace GraduateTraineeEnrollmentApi.Dtos
{
    public class AddStreamDto
    {
        [Required(ErrorMessage = "Stream name is required")]
        public string StreamName { get; set; }

        [Required(ErrorMessage = "Stream description is required")]
        public string StreamDescription { get; set; }

        [Required(ErrorMessage = "Degree id is required")]
        public int DegreeId { get; set; }
    }
}
