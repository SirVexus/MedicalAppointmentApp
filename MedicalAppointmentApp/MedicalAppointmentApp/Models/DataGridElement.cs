namespace MedicalAppointmentApp.Models
{
    /// <summary>
    /// Model for DataGrid Element of Data Grid in ListPage
    /// </summary>
    public class DataGridElement
    {
        /// <summary>
        /// Client First Name and Last Name
        /// </summary>
        public string clientName { get; set; }
        /// <summary>
        /// Doctor First Name and Last Name
        /// </summary>
        public string doctorName { get; set; }
        /// <summary>
        /// Visit Location
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// Visit Start Time
        /// </summary>
        public string from { get; set; }
        /// <summary>
        /// Visit End Time
        /// </summary>
        public string to { get; set; }
    }
}
