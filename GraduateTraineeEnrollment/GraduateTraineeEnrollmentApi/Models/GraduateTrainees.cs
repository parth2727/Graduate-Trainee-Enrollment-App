﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace GraduateTraineeEnrollmentApi.Models
{
    public partial class GraduateTrainees
    {
        public int GraduateTraineeId { get; set; }
        public int? DegreeId { get; set; }
        public int? StreamId { get; set; }
        public string TraineeName { get; set; }
        public string TraineeEmail { get; set; }
        public string UniversityName { get; set; }
        public bool IsLastSemesterPending { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfApplication { get; set; }
        public string Image { get; set; }
        public decimal? Ai { get; set; }
        public decimal? Phyton { get; set; }
        public decimal? BusinessAnalysis { get; set; }
        public decimal? MachineLearning { get; set; }
        public decimal? Practical { get; set; }
        public decimal? TotalMarks { get; set; }
        public decimal? Percentages { get; set; }
        public bool? IsAdmisisonConfirmed { get; set; }

        public virtual Degrees Degree { get; set; }
        public virtual Streams Stream { get; set; }
    }
}