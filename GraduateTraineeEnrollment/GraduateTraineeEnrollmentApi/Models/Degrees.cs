﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace GraduateTraineeEnrollmentApi.Models
{
    public partial class Degrees
    {
        public Degrees()
        {
            GraduateTrainees = new HashSet<GraduateTrainees>();
            Streams = new HashSet<Streams>();
        }

        public int DegreeId { get; set; }
        public string DegreeName { get; set; }
        public string DegreeDescription { get; set; }

        public virtual ICollection<GraduateTrainees> GraduateTrainees { get; set; }
        public virtual ICollection<Streams> Streams { get; set; }
    }
}