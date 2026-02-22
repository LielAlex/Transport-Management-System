using System.Windows.Controls;

namespace TransportManagementSystem.Pages
{
    public partial class DashboardPage : Page
    {
        public DashboardPage()
        {
            InitializeComponent();

            // Examples
            TxtVehicleCount.Text = "2";
            TxtUsersCount.Text = "2";
            TxtDriversCount.Text = "3";
            TxtBookingsCount.Text = "6";
            TxtCustomersCount.Text = "3";
            TxtIncome.Text = "Rs 76650";
        }
    }
}