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
