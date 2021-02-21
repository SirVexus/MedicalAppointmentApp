using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MedicalAppointmentApp.Pages
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// Back Button Click -> Redirect user to main Page
    /// </summary>
    public partial class AdminPage : Page
    {
        private MainWindow _window;
        /// <summary>
        /// AdminPage Constructor (no arguments)
        /// </summary>
        public AdminPage(MainWindow window)
        {
            InitializeComponent();
            this._window = window;
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
            => _window.Content = new NavigationPage(_window);
        private void Add_Region_Button_Click(object sender, RoutedEventArgs e)
        {
            string input = this.RegionInput.Text;
            ///check if text is null if yes return error
            ///check if string exist in database if yes return error
            ///else add string to database
        }
        private void SetErrorMessage(string message, Brush color)
        {
            errorMessage.Text = message;
            errorMessage.Foreground = color;
            //Brushes.Red;
        }
    }
}
