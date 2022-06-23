using System;
using System.Collections.Generic;

namespace drivingCenter.Models
{
    public partial class Timetable
    {
        public int TimetableId { get; set; }
        public DateTime? Date { get; set; }
        public string? Hour { get; set; }
        public int? Monitorid { get; set; }
        public int? Candidateid { get; set; }

        public virtual User? Candidate { get; set; }
        public virtual User? Monitor { get; set; }
    }
}
