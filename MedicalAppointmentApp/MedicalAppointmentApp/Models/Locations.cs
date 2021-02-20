using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentApp.Models
{
    public class Locations
    {
        [Required]
        public int LocationId { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Doctors> Doctors
        { get; private set; } = new ObservableCollection<Doctors>();
    }
}
