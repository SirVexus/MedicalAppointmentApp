using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentApp.Models
{
    /// <summary>
    /// Doctors Table Model
    /// </summary>
    public class Doctors
    {
        /// <summary>
        /// Unique Id of Doctor
        /// </summary>
        [Key, Required]
        public int DoctorId { get; set; }
        /// <summary>
        /// First Name of Doctor
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Last Name of Doctor
        /// </summary>
        [Required]
        public string LastName { get; set; }
        /// <summary>
        /// Doctors work locations Id
        /// </summary>
        public int LocationId { get; set; }
        /// <summary>
        /// Location this Doctor is related to
        /// </summary>
        public virtual Locations location { get; set; }
        /// <summary>
        /// Visists related to this Doctor
        /// </summary>
        public virtual ICollection<Visits> Visits
        { get; private set; } = new ObservableCollection<Visits>();
    }
}
