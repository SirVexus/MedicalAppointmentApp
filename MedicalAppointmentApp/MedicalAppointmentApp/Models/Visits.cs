using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointmentApp.Models
{
    public class Visits
    {
        [Key, Required]
        public int VisitId { get; set; }
        public int ClientId { get; set; }
        public int DoctorId { get; set; }
        public int LocationId { get; set; }
        public int VisitTimeId { get; set; }
        public virtual Doctors Doctors { get; set; }
        public virtual Clients Clients { get; set; }
        public virtual Locations Locations { get; set; }
        public virtual ICollection<VisitTime> VisitTime
        { get; private set; } = new ObservableCollection<VisitTime>();
    }
}
