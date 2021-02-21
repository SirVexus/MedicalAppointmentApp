using MedicalAppointmentApp.Pages;
using System.Windows;

namespace MedicalAppointmentApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// On Admin Click -> Redirect to Add data Page
    /// On Doctor Click -> Redirect to List data Page as doctor
    /// On Customer Click -> Redirect to List data Page as customer
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Main Window Page Constructor (no arguments)
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            this.Content = adminPage;
        }

        private void Doctors_Click(object sender, RoutedEventArgs e)
        {
            ListPage listPage = new ListPage(true);
            this.Content = listPage;
        }

        private void Customers_Click(object sender, RoutedEventArgs e)
        {
            ListPage listPage = new ListPage(false);
            this.Content = listPage;
        }
    }
}
