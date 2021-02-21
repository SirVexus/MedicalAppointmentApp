using MedicalAppointmentApp.Context;
using MedicalAppointmentApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MedicalAppointmentApp.Pages
{
    /// <summary>
    /// Interaction logic for VisitsPage.xaml
    /// </summary>
    public partial class VisitsPage : Page
    {
        private MainWindow _window;
        private AppointmentsContext _context;
        private bool handle = true;
        public VisitsPage(MainWindow window)
        {
            InitializeComponent();
            this._window = window;
            this._context = new AppointmentsContext();
            _context.Database.EnsureCreated();
            _context.Locations.Load();
            _context.Doctors.Load();
            _context.Clients.Load();
            _context.VisitTime.Load();
            List<Locations> locations = _context.Locations.ToList();
            LocationVisitInput.ItemsSource = locations;
            LocationVisitInput.SelectedIndex = 0;
            List<Clients> clients = _context.Clients.ToList();
            List<DropDownElement> clientDropDown = new List<DropDownElement>();
            foreach (Clients client in clients) 
                clientDropDown.Add(new DropDownElement { Id = client.ClientId, Name = $"{client.Name} {client.LastName}" });
            CustomerVisitInput.ItemsSource = clientDropDown;
            CustomerVisitInput.SelectedIndex = 0;
            //private create date time selections and add to drop down
            ///fiil time
                }
        private void Back_Button_Click(object sender, RoutedEventArgs e)
            => _window.Content = new AdminPage(_window);
        
        private void Location_Visit_Input_DropDownClosed(object sender, EventArgs e)
        {
            if (handle) Handle();
            handle = true;
        }
        private void Location_Visit_Input_Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            handle = !cmb.IsDropDownOpen;
            Handle();
        }
        private void Handle()
        {
            int locationId = _context.Locations.ToList()[LocationVisitInput.SelectedIndex].LocationId;
            ///get all doctors with selected location and insert them into doctors dropdown
        }
        private void Add_Visit_Button_Click(object sender, RoutedEventArgs e)
        {
            ///verification if doctor have his location
            ///after selected location show only doctors for this location and reset index
            ///and make other drop downs enabled
            ///add verification if all data selected
        }
        private void SetErrorMessage(string message, Brush color)
        {
            errorMessage.Text = message;
            errorMessage.Foreground = color;
        }
        private int GenerateId()
        {
            byte[] bytes = new Guid().ToByteArray();
            return ((int)bytes[0]) | ((int)bytes[1] << 8) | ((int)bytes[2] << 16) | ((int)bytes[3] << 24);
        }
    }
}
