using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentApp.Models
{
    /// <summary>
    /// Location Table Model
    /// </summary>
    public class Locations
    {
        /// <summary>
        /// Unique Id of Location
        /// </summary>
        [Key, Required]
        public int LocationId { get; set; }
        /// <summary>
        /// Name of the Location
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Doctors related to this Location
        /// </summary>
        public virtual ICollection<Doctors> Doctors
        { get; private set; } = new ObservableCollection<Doctors>();
        /// <summary>
        /// Visits related to this Location
        /// </summary>
        public virtual ICollection<Visits> Visits
        { get; private set; } = new ObservableCollection<Visits>();
    }
}
