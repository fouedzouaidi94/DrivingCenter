using System;
using System.Collections.Generic;

namespace drivingCenter.Models
{
    public partial class User
    {
        public User()
        {
            Courses = new HashSet<Course>();
            Factures = new HashSet<Facture>();
            TimetableCandidates = new HashSet<Timetable>();
            TimetableMonitors = new HashSet<Timetable>();
            Vehicles = new HashSet<Vehicle>();
        }

        public int Userid { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Files { get; set; }
        public string? Dob { get; set; }
        public string? Role { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Facture> Factures { get; set; }
        public virtual ICollection<Timetable> TimetableCandidates { get; set; }
        public virtual ICollection<Timetable> TimetableMonitors { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
