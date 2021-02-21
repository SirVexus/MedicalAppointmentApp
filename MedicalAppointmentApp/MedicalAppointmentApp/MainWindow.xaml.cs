using MedicalAppointmentApp.Pages;
using System.Windows;

namespace MedicalAppointmentApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        /// <summary>
        /// Main Window Page Constructor (no arguments)
        /// Sets Main Window content to Navigation page on Initialization
        /// Passes refference to self as argument to Navigation Page
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.Content = new NavigationPage(this);
        }
    }
}
