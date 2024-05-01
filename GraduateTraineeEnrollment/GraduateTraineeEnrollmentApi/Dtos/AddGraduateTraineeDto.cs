using GraduateTraineeEnrollmentApi.Models;
using System.ComponentModel.DataAnnotations;

namespace GraduateTraineeEnrollmentApi.Dtos
{
    public class AddGraduateTraineeDto
    {
        [Required(ErrorMessage = "Degree id is required")]
        public int DegreeId { get; set; }


        [Required(ErrorMessage = "Stream id is required")]
        public int StreamId { get; set; }
        
        [Required(ErrorMessage = "Trainee name  is required")]
        public string TraineeName { get; set; }

        [Required(ErrorMessage = "Trainee email  is required")]
        public string TraineeEmail { get; set; }

        [Required(ErrorMessage = "University name  is required")]
        public string UniversityName { get; set; }


        [Required]
        public bool IsLastSemesterPending { get; set; }

        [Required(ErrorMessage = "Gender  is required")]
        public string Gender { get; set; }

        [Required]
        public DateTime DateOfApplication { get; set; }

        public string? Image { get; set; }
        public decimal? Ai { get; set; }
        public decimal? Phyton { get; set; }
        public decimal? BusinessAnalysis { get; set; }
        public decimal? MachineLearning { get; set; }
        public decimal? Practical { get; set; }
        public decimal? TotalMarks { get; set; }
        public decimal? Percentages { get; set; }
        public bool? IsAdmisisonConfirmed { get; set; }

        //public virtual Degrees Degree { get; set; }
        //public virtual Streams Stream { get; set; }
    }
}
