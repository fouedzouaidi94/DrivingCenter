using System;
using System.Collections.Generic;

namespace drivingCenter.Models
{
    public partial class Facture
    {
        public int FactureId { get; set; }
        public int? Num { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Mht { get; set; }
        public decimal? Tva { get; set; }
        public decimal? Ttc { get; set; }
        public string? Desc { get; set; }
        public int? Userid { get; set; }

        public virtual User? User { get; set; }
    }
}
