using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicalAppointmentApp.Models
{
    public class VisitTime
    {
        [Key, Required]
        public int VisitTimeId { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan From { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan To { get; set; }
        public virtual Visits Visits { get; set; }
    }
}
