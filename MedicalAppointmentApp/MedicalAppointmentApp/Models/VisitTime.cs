using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointmentApp.Models
{
    /// <summary>
    /// VisitTime Table Model
    /// </summary>
    public class VisitTime
    {
        /// <summary>
        /// Unique Id of Visit Period
        /// </summary>
        [Key, Required]
        public int VisitTimeId { get; set; }
        /// <summary>
        /// Start of Visit
        /// </summary>
        [Column(TypeName = "time")]
        public TimeSpan From { get; set; }
        /// <summary>
        /// End of Visit
        /// </summary>
        [Column(TypeName = "time")]
        public TimeSpan To { get; set; }
        /// <summary>
        /// Visit this period is related to
        /// </summary>
        public virtual Visits Visits { get; set; }
    }
}
