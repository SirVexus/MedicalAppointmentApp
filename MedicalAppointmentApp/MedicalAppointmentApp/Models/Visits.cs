using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentApp.Models
{
    /// <summary>
    /// Visits Table Model
    /// </summary>
    public class Visits
    {
        /// <summary>
        /// Unique Id of Visit
        /// </summary>
        [Key, Required]
        public int VisitId { get; set; }
        /// <summary>
        /// Visit client Id
        /// </summary>
        [Required]
        public int ClientId { get; set; }
        /// <summary>
        /// Visit Doctor Id
        /// </summary>
        [Required]
        public int DoctorId { get; set; }
        /// <summary>
        /// Visit Location Id
        /// </summary>
        [Required]
        public int LocationId { get; set; }
        /// <summary>
        /// Visit Time Id
        /// </summary>
        [Required]
        public int VisitTimeId { get; set; }
        /// <summary>
        /// Doctor related to this visit
        /// </summary>
        public virtual Doctors Doctors { get; set; }
        /// <summary>
        /// Client related to this visit
        /// </summary>
        public virtual Clients Clients { get; set; }
        /// <summary>
        /// Loction related to this visit
        /// </summary>
        public virtual Locations Locations { get; set; }
        /// <summary>
        /// List of Time rows this visit is related to
        /// </summary>
        public virtual ICollection<VisitTime> VisitTime
        { get; private set; } = new ObservableCollection<VisitTime>();
    }
}
