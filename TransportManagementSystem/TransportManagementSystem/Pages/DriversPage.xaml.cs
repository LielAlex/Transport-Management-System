using System.Windows;
using System.Windows.Controls;

namespace TransportManagementSystem.Pages
{
    public partial class DriversPage : Page
    {
        public DriversPage()
        {
            InitializeComponent();

            // Exemple : remplir la combo (à remplacer par DB)
            CmbDrivers.Items.Add("John Doe");
            CmbDrivers.Items.Add("Ali Ahmed");
            CmbDrivers.SelectedIndex = 0;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // Ici tu mets l'insertion DB
            MessageBox.Show("Save clicked");
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            // Ici tu mets la mise à jour DB
            MessageBox.Show("Edit clicked");
        }

        private void BtnFire_Click(object sender, RoutedEventArgs e)
        {
            // Ici tu mets la suppression / désactivation
            MessageBox.Show("Fire clicked");
        }
    }
}