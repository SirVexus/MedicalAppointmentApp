using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedicalAppointmentApp.Models
{
    public class Clients
    {
        [Required]
        public int ClientId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        public virtual ICollection<Visits> Visits
        { get; private set; } = new ObservableCollection<Visits>();
    }
}
