using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointmentApp.Models
{
    /// <summary>
    /// Schema for custom ComboBox elements
    /// </summary>
    public class DropDownElement
    {
        /// <summary>
        /// Key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Value
        /// </summary>
        public string Name { get; set; }
    }
}
