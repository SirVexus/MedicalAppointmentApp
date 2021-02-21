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
                SetErrorMessage("Region Input is Empty", Brushes.Red);
            else if (locationsNames.Contains(input))
                SetErrorMessage("Region already added", Brushes.Red);
            else
            {
                int id = GenerateId();
                _context.Add(new Locations { LocationId = id, Name = input });
                _context.SaveChanges();
                List<Locations> newLocations = _context.Locations.ToList();
                DoctorLocationInput.ItemsSource = newLocations;
                SetErrorMessage("Region Added Correctly", Brushes.Green);
            }
        }
        private void Add_Doctor_Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DoctorFirstNameInput.Text))
                SetErrorMessage("Doctor First Name Input is Empty", Brushes.Red);
            else if (string.IsNullOrWhiteSpace(DoctorLastNameInput.Text))
                SetErrorMessage("Doctor Last Name Input is Empty", Brushes.Red);
            else if (string.IsNullOrWhiteSpace(DoctorLocationInput.Text))
                SetErrorMessage("Doctor Location is Empty", Brushes.Red);
            else
            {
                _context.Add(new Doctors
                {
                    DoctorId = GenerateId(),
                    Name = DoctorFirstNameInput.Text,
                    LastName = DoctorLastNameInput.Text,
                    LocationId = _context.Locations.ToList()[DoctorLocationInput.SelectedIndex].LocationId
                });
                _context.SaveChanges();
                SetErrorMessage("Doctor Added Correctly", Brushes.Green);
            }
        }
        private void Add_Customer_Button_Clicked(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ClientFirstName.Text))
                SetErrorMessage("Client First Name is Empty", Brushes.Red);
            else if (string.IsNullOrWhiteSpace(ClientLastName.Text))
                SetErrorMessage("Client Last Name is Empty", Brushes.Red);
            else
            {
                _context.Add(new Clients
                {
                    ClientId = GenerateId(),
                    Name = ClientFirstName.Text,
                    LastName = ClientLastName.Text
                });
                _context.SaveChanges();
                SetErrorMessage("Customer Added Correctly", Brushes.Green);
            }
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
