using System.Windows;
using System.Windows.Controls;

namespace TransportManagementSystem.Pages
{
    public partial class BookingsPage : Page
    {
        public BookingsPage()
        {
            InitializeComponent();

            // Exemples (à remplacer par DB)
            CmbCustomer.Items.Add("Customer 1");
            CmbCustomer.Items.Add("Customer 2");
            CmbCustomer.SelectedIndex = 0;

            CmbVehicle.Items.Add("Vehicle A");
            CmbVehicle.Items.Add("Vehicle B");
            CmbVehicle.SelectedIndex = 0;

            DpPickupDate.SelectedDate = System.DateTime.Today;
            DpReturnDate.SelectedDate = System.DateTime.Today;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Save booking");
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Edit booking");
        }

        private void BtnFire_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Delete/Cancel booking");
        }
    }
}