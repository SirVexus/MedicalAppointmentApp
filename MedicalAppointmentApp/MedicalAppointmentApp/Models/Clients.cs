using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentApp.Models
{
    /// <summary>
    /// Clients Table Model
    /// </summary>
    public class Clients
    {
        /// <summary>
        /// Unique Id of Client
        /// </summary>
        [Key, Required]
        public int ClientId { get; set; }
        /// <summary>
        /// First Name of Client
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Last Name of Client
        /// </summary>
        [Required]
        public string LastName { get; set; }
        /// <summary>
        /// Visits related to this Client
        /// </summary>
        public virtual ICollection<Visits> Visits
        { get; private set; } = new ObservableCollection<Visits>();
    }
}
