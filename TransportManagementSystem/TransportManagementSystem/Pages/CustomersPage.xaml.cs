using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace TransportManagementSystem.Pages
{
    public partial class CustomersPage : Page
    {
        ObservableCollection<Customer> customers =
            new ObservableCollection<Customer>();

        public CustomersPage()
        {
            InitializeComponent();

            // Exemple de données
            customers.Add(new Customer
            {
                CustId = 2,
                CustName = "Sunila",
                CustAdd = "Kolar",
                CustPhone = "35475454",
                CustGen = "Female"
            });

            GridCustomers.ItemsSource = customers;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            customers.Add(new Customer
            {
                CustId = customers.Count + 1,
                CustName = TxtCustName.Text,
                CustAdd = TxtAddress.Text,
                CustPhone = TxtPhone.Text,
                CustGen = (CmbGender.SelectedItem as ComboBoxItem)?.Content.ToString()
            });

            ClearFields();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (GridCustomers.SelectedItem is Customer selected)
            {
                selected.CustName = TxtCustName.Text;
                selected.CustAdd = TxtAddress.Text;
                selected.CustPhone = TxtPhone.Text;
                selected.CustGen = (CmbGender.SelectedItem as ComboBoxItem)?.Content.ToString();

                GridCustomers.Items.Refresh();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (GridCustomers.SelectedItem is Customer selected)
            {
                customers.Remove(selected);
                ClearFields();
            }
        }

        private void GridCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GridCustomers.SelectedItem is Customer selected)
            {
                TxtCustName.Text = selected.CustName;
                TxtAddress.Text = selected.CustAdd;
                TxtPhone.Text = selected.CustPhone;
            }
        }

        private void ClearFields()
        {
            TxtCustName.Clear();
            TxtAddress.Clear();
            TxtPhone.Clear();
            CmbGender.SelectedIndex = -1;
        }
    }

    public class Customer
    {
        public int CustId { get; set; }
        public string CustName { get; set; }
        public string CustAdd { get; set; }
        public string CustPhone { get; set; }
        public string CustGen { get; set; }
    }
}