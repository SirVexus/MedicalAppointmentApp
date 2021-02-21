using System.Windows;
using System.Windows.Controls;

namespace MedicalAppointmentApp.Pages
{
    /// <summary>
    /// Interaction logic for NavigationPage.xaml
    /// </summary>
    public partial class NavigationPage : Page
    {
        private MainWindow _window; 
        /// <summary>
        /// NavigationPage constructor, gets refference to mainWindow as argument
        /// </summary>
        /// <param name="window"></param>
        public NavigationPage(MainWindow window)
        {
            this._window = window;
            InitializeComponent();
        }
        private void Admin_Click(object sender, RoutedEventArgs e)
            => _window.Content = new AdminPage(_window);

        private void Doctors_Click(object sender, RoutedEventArgs e)
            => _window.Content = new ListPage(_window,true);

        private void Customers_Click(object sender, RoutedEventArgs e)
            => _window.Content = new ListPage(_window, false);
    }
}
