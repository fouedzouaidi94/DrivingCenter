using System;
using System.Collections.Generic;

namespace drivingCenter.Models
{
    public partial class Course
    {
        public int CourseId { get; set; }
        public string? Label { get; set; }
        public string? Type { get; set; }
        public string? CourseUrl { get; set; }
        public int? Userid { get; set; }

        public virtual User? User { get; set; }
    }
}
