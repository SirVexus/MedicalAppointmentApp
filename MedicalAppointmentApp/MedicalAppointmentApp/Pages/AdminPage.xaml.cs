using MedicalAppointmentApp.Context;
using MedicalAppointmentApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MedicalAppointmentApp.Pages
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        private MainWindow _window;
        private AppointmentsContext _context;
        /// <summary>
        /// AdminPage constructor with window refference as parameter
        /// Loads database context
        /// Fills Locations selectBox with Locations from database
        /// </summary>
        /// <param name="window"></param>
        public AdminPage(MainWindow window)
        {
            InitializeComponent();
            this._window = window;
            this._context = new AppointmentsContext();
            _context.Database.EnsureCreated();
            _context.Locations.Load();
            _context.Doctors.Load();
            _context.Clients.Load();
            List<Locations> locations = _context.Locations.ToList();
            DoctorLocationInput.ItemsSource = locations;
            DoctorLocationInput.SelectedIndex = 0;
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
            => _window.Content = new NavigationPage(_window);
        private void Visit_Button_Click(object sender, RoutedEventArgs e)
            => _window.Content = new VisitsPage(_window);
        private void Add_Region_Button_Click(object sender, RoutedEventArgs e)
        {
            string input = this.RegionInput.Text;
            List<Locations> locations = _context.Locations.ToList();
            List<string> locationsNames = new List<string>();
            foreach (Locations loc in locations) locationsNames.Add(loc.Name);
            if (string.IsNullOrWhiteSpace(input))
                Utilities.Utilities.SetErrorMessage(errorMessage, "Region Input is Empty", Brushes.Red);
            else if (locationsNames.Contains(input))
                Utilities.Utilities.SetErrorMessage(errorMessage, "Region already added", Brushes.Red);
            else
            {
                int id = Utilities.Utilities.GenerateId();
                _context.Add(new Locations { LocationId = id, Name = input });
                _context.SaveChanges();
                List<Locations> newLocations = _context.Locations.ToList();
                DoctorLocationInput.ItemsSource = newLocations;
                Utilities.Utilities.SetErrorMessage(errorMessage, "Region Added Correctly", Brushes.Green);
            }
        }
        private void Add_Doctor_Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DoctorFirstNameInput.Text))
                Utilities.Utilities.SetErrorMessage(errorMessage, "Doctor First Name Input is Empty", Brushes.Red);
            else if (string.IsNullOrWhiteSpace(DoctorLastNameInput.Text))
                Utilities.Utilities.SetErrorMessage(errorMessage, "Doctor Last Name Input is Empty", Brushes.Red);
            else if (string.IsNullOrWhiteSpace(DoctorLocationInput.Text))
                Utilities.Utilities.SetErrorMessage(errorMessage, "Doctor Location is Empty", Brushes.Red);
            else
            {
                _context.Add(new Doctors
                {
                    DoctorId = Utilities.Utilities.GenerateId(),
                    Name = DoctorFirstNameInput.Text,
                    LastName = DoctorLastNameInput.Text,
                    LocationId = _context.Locations.ToList()[DoctorLocationInput.SelectedIndex].LocationId
                });
                _context.SaveChanges();
                Utilities.Utilities.SetErrorMessage(errorMessage, "Doctor Added Correctly", Brushes.Green);
            }
        }
        private void Add_Customer_Button_Clicked(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ClientFirstName.Text))
                Utilities.Utilities.SetErrorMessage(errorMessage, "Client First Name is Empty", Brushes.Red);
            else if (string.IsNullOrWhiteSpace(ClientLastName.Text))
                Utilities.Utilities.SetErrorMessage(errorMessage, "Client Last Name is Empty", Brushes.Red);
            else
            {
                _context.Add(new Clients
                {
                    ClientId = Utilities.Utilities.GenerateId(),
                    Name = ClientFirstName.Text,
                    LastName = ClientLastName.Text
                });
                _context.SaveChanges();
                Utilities.Utilities.SetErrorMessage(errorMessage, "Customer Added Correctly", Brushes.Green);
            }
        }
    }
}
