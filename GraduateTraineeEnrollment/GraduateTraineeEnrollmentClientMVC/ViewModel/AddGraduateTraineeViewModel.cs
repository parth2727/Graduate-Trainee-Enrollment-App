using System.ComponentModel.DataAnnotations;

namespace GraduateTraineeEnrollmentClientMVC.ViewModel
{
    public class AddGraduateTraineeViewModel
    {
        public int GraduateTraineeId { get; set; }

        [Required(ErrorMessage = "Degree is required.")]
        public int DegreeId { get; set; }

        [Required(ErrorMessage = "Stream is required.")]
        public int? StreamId { get; set; }

        [Required(ErrorMessage = "Trainee name is required.")]
        public string TraineeName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Trainee email is required.")]
        public string TraineeEmail { get; set; }

        [Required(ErrorMessage = "University name is required.")]
        public string UniversityName { get; set; }

        [Required(ErrorMessage = "Last semester status is required.")]
        public bool IsLastSemesterPending { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Date of Application is required.")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfApplication { get; set; }

        [Required(ErrorMessage = "Image is required.")]
        public string Image { get; set; }
        public decimal? Ai { get; set; }
        public decimal? Phyton { get; set; }
        public decimal? BusinessAnalysis { get; set; }
        public decimal? MachineLearning { get; set; }
        public decimal? Practical { get; set; }
        public decimal? TotalMarks { get; set; }
        public decimal? Percentages { get; set; }
        public bool? IsAdmisisonConfirmed { get; set; }
        public List<DegreeViewModel>? degrees { get; set; }
        public List<StreamViewModel>? streams { get; set; }
    }
}
