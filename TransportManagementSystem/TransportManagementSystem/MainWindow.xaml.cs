using System.Windows;

namespace TransportManagementSystem
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new Pages.DriversPage());
        }

        private void BtnDrivers_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.DriversPage());
        }

        private void BtnCustomers_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.CustomersPage());
        }

        private void BtnVehicles_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.VehiclesPage());
        }

        private void BtnBookings_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.BookingsPage());
        }

        private void BtnDashboard_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.DashboardPage());
        }
    }
}