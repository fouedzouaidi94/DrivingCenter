using System;
using System.Collections.Generic;

namespace drivingCenter.Models
{
    public partial class Vehicle
    {
        public int VehicleId { get; set; }
        public string? Mat { get; set; }
        public string? Model { get; set; }
        public int? Mileage { get; set; }
        public DateTime? DateEcheance { get; set; }
        public DateTime? DateVisite { get; set; }
        public int? Userid { get; set; }

        public virtual User? User { get; set; }
    }
}
