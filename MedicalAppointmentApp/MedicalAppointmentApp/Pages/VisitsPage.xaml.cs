﻿using MedicalAppointmentApp.Context;
using MedicalAppointmentApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
        private List<DropDownElement> _doctors;
        private List<DropDownElement> _fromHours;
        private List<DropDownElement> _toHours;
        /// <summary>
        /// VisitPage constructor takes refference to window as parameter
        /// Loads database context
        /// Fills dropdowns
        /// </summary>
        /// <param name="window"></param>
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
            _fromHours = FillTimeDropDown();
            FromTimeVisitInput.ItemsSource = _fromHours;
            FromTimeVisitInput.SelectedIndex = 0;
            _toHours = FillTimeDropDown();
            ToVisitInput.ItemsSource = _toHours;
            ToVisitInput.SelectedIndex = 0;
            DoctorVisitInput.IsEnabled = false;
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
            List<Doctors> doctors = _context.Doctors.Where(d => d.LocationId == locationId).ToList();
            _doctors = new List<DropDownElement>();
            foreach (Doctors doctor in doctors)
                _doctors.Add(new DropDownElement { Id=doctor.DoctorId, Name = $"{doctor.Name} {doctor.LastName}" });
            DoctorVisitInput.ItemsSource = _doctors;
            DoctorVisitInput.SelectedIndex = 0;
            DoctorVisitInput.IsEnabled = true;
        }
        private void Add_Visit_Button_Click(object sender, RoutedEventArgs e)
        {
            int selectedLocationId = _context.Locations.ToList()[LocationVisitInput.SelectedIndex].LocationId;
            int selectedDoctorId = _doctors[DoctorVisitInput.SelectedIndex].Id;
            int selectedDoctorLocationId = _context.Doctors
                .Where(d => d.DoctorId == selectedDoctorId).FirstOrDefault().LocationId;
            int fromTimeId = _fromHours[FromTimeVisitInput.SelectedIndex].Id;
            int toTimeId = _toHours[ToVisitInput.SelectedIndex].Id;
            if (selectedDoctorLocationId != selectedLocationId)
                SetErrorMessage("Selected Doctor isn't available at Selected Location", Brushes.Red);
            else if (fromTimeId > toTimeId)
                SetErrorMessage("Visit End Time can't be lower than Visit Start Time", Brushes.Red);
            else if (fromTimeId == toTimeId)
                SetErrorMessage("Visit End Time can't be equal to Visit Start Time", Brushes.Red);
            else if (string.IsNullOrWhiteSpace(LocationVisitInput.Text))
                SetErrorMessage("Location not selected", Brushes.Red);
            else if (string.IsNullOrWhiteSpace(CustomerVisitInput.Text))
                SetErrorMessage("Customer not selected", Brushes.Red);
            else if (string.IsNullOrWhiteSpace(FromTimeVisitInput.Text))
                SetErrorMessage("From hour not selected", Brushes.Red);
            else if (string.IsNullOrWhiteSpace(ToVisitInput.Text))
                SetErrorMessage("To hour not selected", Brushes.Red);
            else if (string.IsNullOrWhiteSpace(DoctorVisitInput.Text))
                SetErrorMessage("Doctor not selected", Brushes.Red);
            else
            {
                int visitTimeId = GenerateId();
                _context.Add(new VisitTime
                {
                    VisitTimeId = visitTimeId,
                    From = TimeSpan.Parse(_fromHours[FromTimeVisitInput.SelectedIndex].Name),
                    To = TimeSpan.Parse(_toHours[ToVisitInput.SelectedIndex].Name)
                });
                _context.Add(new Visits
                {
                    VisitId = GenerateId(),
                    ClientId = _context.Clients.ToList()[CustomerVisitInput.SelectedIndex].ClientId,
                    DoctorId = selectedDoctorId,
                    LocationId = selectedLocationId,
                    VisitTimeId = visitTimeId
                });
                SetErrorMessage("Visit Added Correctly", Brushes.Green);
            }
        }
        private List<DropDownElement> FillTimeDropDown()
        {
            List<DropDownElement> timeElements = new List<DropDownElement>();
            for (int i = 0; i < 24; i++)
                timeElements.Add(new DropDownElement { Id=i, Name=$"{i}:00" });
            return timeElements;
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
