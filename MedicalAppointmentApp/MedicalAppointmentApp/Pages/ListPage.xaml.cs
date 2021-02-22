using MedicalAppointmentApp.Context;
using MedicalAppointmentApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MedicalAppointmentApp.Pages
{
    /// <summary>
    /// Interaction logic for ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        private MainWindow _window;
        private bool _handle = true;
        private List<Doctors> _doctors;
        private List<Clients> _customers;
        private AppointmentsContext _context;
        private bool _isDoctor;
        /// <summary>
        /// ListPage constructor gets two parameters refference to window and bool if list is for doctors or for customers
        /// Loads database, puts data into drop down (based on bool doctors list or clients list) and data grid
        /// </summary>
        /// <param name="window"></param>
        /// <param name="isDoctor"></param>
        public ListPage(MainWindow window, bool isDoctor)
        {
            InitializeComponent();
            this._context = new AppointmentsContext();
            _context.Database.EnsureCreated();
            _context.Locations.Load();
            _context.Doctors.Load();
            _context.Clients.Load();
            _context.Visits.Load();
            _context.VisitTime.Load();
            this._window = window;
            this._isDoctor = isDoctor;
            List<DropDownElement> dropDownElements = new List<DropDownElement>();
            visitsDataGrid.ItemsSource = CreateDataGridSource(false, false);
            if (isDoctor)
            {
                SelectBoxLabel.Content = "Select Doctor:";
                _doctors = _context.Doctors.ToList();
                foreach (Doctors doctor in _doctors)
                    dropDownElements.Add(new DropDownElement { Id=doctor.DoctorId, Name = $"{doctor.Name} {doctor.LastName}" });
            }
            else
            {
                SelectBoxLabel.Content = "Select Customer:";
                _customers = _context.Clients.ToList();
                foreach (Clients customer in _customers)
                    dropDownElements.Add(new DropDownElement { Id = customer.ClientId, Name = $"{customer.Name} {customer.LastName}" });
            }
            FilterDropDown.ItemsSource = dropDownElements;
            FilterDropDown.SelectedIndex = 0;
        }
        private void Back_Button_Click(object sender, RoutedEventArgs e)
            => _window.Content = new NavigationPage(_window);

        private void Filter_Drop_Down_Closed(object sender, EventArgs e)
        {
            if (_handle) Handle();
            _handle = true;
        }
        private void Filter_Selection_Changed(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            _handle = !cmb.IsDropDownOpen;
            Handle();
        }
        private void Handle()
        {
            if (_isDoctor)
                visitsDataGrid.ItemsSource = CreateDataGridSource(true, false);
            else
                visitsDataGrid.ItemsSource = CreateDataGridSource(false, true);
        }
        private List<DataGridElement> CreateDataGridSource(bool doctorsFilter, bool customersFilter)
        {
            List<DataGridElement> elements = new List<DataGridElement>();
            List<Visits> visits = new List<Visits>();
            if (doctorsFilter)
                visits = _context.Visits
                    .Where(visit => visit.DoctorId == _doctors[FilterDropDown.SelectedIndex].DoctorId)
                    .ToList();
            else if (customersFilter)
                visits = _context.Visits
                    .Where(visit => visit.ClientId == _customers[FilterDropDown.SelectedIndex].ClientId)
                    .ToList();
            else
                visits = _context.Visits.ToList();
            foreach (Visits visit in visits)
            {
                Clients client = _context.Clients.Where(x => x.ClientId == visit.ClientId).FirstOrDefault();
                Doctors doctor = _context.Doctors.Where(x => x.DoctorId == visit.DoctorId).FirstOrDefault();
                Locations location = _context.Locations.Where(x => x.LocationId == visit.LocationId).FirstOrDefault();
                VisitTime time = _context.VisitTime.Where(x => x.VisitTimeId == visit.VisitTimeId).FirstOrDefault(); 
                elements.Add(new DataGridElement
                {
                    clientName = $"{client.Name} {client.LastName}",
                    doctorName = $"{doctor.Name} {doctor.LastName}",
                    location = location.Name,
                    from = time.From.ToString(@"hh\:mm"),
                    to = time.To.ToString(@"hh\:mm")
                });
            };
            return elements;
        }
    }
}
