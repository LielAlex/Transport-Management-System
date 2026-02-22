using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TransportManagementSystem.Pages
{
    public partial class VehiclesPage : Page
    {
        private ObservableCollection<Vehicle> vehicles = new ObservableCollection<Vehicle>();

        public VehiclesPage()
        {
            InitializeComponent();
            SeedCombos();
            SeedData();

            GridVehicles.ItemsSource = vehicles;
        }

        private void SeedCombos()
        {
            // Mark
            CmbMark.ItemsSource = new[] { "Nissan", "Toyota", "BMW", "Mercedes", "Kia" };

            // Year (2010 -> année actuelle)
            var years = Enumerable.Range(2010, DateTime.Now.Year - 2010 + 1).ToList();
            CmbYear.ItemsSource = years;

            // Engine type
            CmbEngineType.ItemsSource = new[] { "Petrol", "Diesel", "Hybrid", "Electric" };

            // Vehicle type
            CmbType.ItemsSource = new[] { "SUV", "Sedan", "Hatchback", "Van", "Bus" };

            // Drivers (exemples)
            CmbDriver.ItemsSource = new[] { "Suresh", "Danush", "John", "Ali" };

            // Defaults
            CmbBooked.SelectedIndex = 0;
        }

        private void SeedData()
        {
            vehicles.Add(new Vehicle
            {
                Vlp = "15KAR0...",
                Vmark = "Nissan",
                Vmodel = "Murano",
                VYear = 2012,
                VEngType = "Petrol",
                VColor = "Blue",
                VMileage = 5000,
                VType = "SUV",
                Booked = "No",
                Driver = "Suresh"
            });

            vehicles.Add(new Vehicle
            {
                Vlp = "20DEL2...",
                Vmark = "Toyota",
                Vmodel = "Prado",
                VYear = 2013,
                VEngType = "Diesel",
                VColor = "Gray",
                VMileage = 8500,
                VType = "SUV",
                Booked = "No",
                Driver = "Danush"
            });
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!TryReadForm(out var v)) return;

            // (Optionnel) éviter doublon de plaque
            if (vehicles.Any(x => string.Equals(x.Vlp, v.Vlp, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Cette licence plate existe déjà.");
                return;
            }

            vehicles.Add(v);
            ClearForm();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Vehicle selected = GridVehicles.SelectedItem as Vehicle;

            if (selected == null)
            {
                MessageBox.Show("Sélectionne une ligne à modifier.");
                return;
            }

            if (!TryReadForm(out var v)) return;

            // Update champs
            selected.Vlp = v.Vlp;
            selected.Vmark = v.Vmark;
            selected.Vmodel = v.Vmodel;
            selected.VYear = v.VYear;
            selected.VEngType = v.VEngType;
            selected.VColor = v.VColor;
            selected.VMileage = v.VMileage;
            selected.VType = v.VType;
            selected.Booked = v.Booked;
            selected.Driver = v.Driver;

            GridVehicles.Items.Refresh();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (GridVehicles.SelectedItem is Vehicle selected)
            {
                vehicles.Remove(selected);
                ClearForm();
            }
        }

        private void GridVehicles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Vehicle v = GridVehicles.SelectedItem as Vehicle;
            if (v == null)
                return;

            TxtPlate.Text = v.Vlp;
            CmbMark.SelectedItem = v.Vmark;
            TxtModel.Text = v.Vmodel;
            CmbYear.SelectedItem = v.VYear;
            CmbEngineType.SelectedItem = v.VEngType;

            // Booked est dans ComboBoxItem ("Yes/No")
            foreach (var item in CmbBooked.Items)
            {
                if (item is ComboBoxItem cbi && (cbi.Content?.ToString() == v.Booked))
                {
                    CmbBooked.SelectedItem = cbi;
                    break;
                }
            }

            CmbType.SelectedItem = v.VType;
            TxtMileage.Text = v.VMileage.ToString();
            TxtColor.Text = v.VColor;
            CmbDriver.SelectedItem = v.Driver;
        }

        private bool TryReadForm(out Vehicle v)
        {
            v = null;

            var booked = (CmbBooked.SelectedItem as ComboBoxItem)?.Content?.ToString();

            if (string.IsNullOrWhiteSpace(TxtPlate.Text))
            {
                MessageBox.Show("Licence Plate est obligatoire.");
                return false;
            }
            if (CmbMark.SelectedItem == null || CmbEngineType.SelectedItem == null || CmbYear.SelectedItem == null
                || CmbType.SelectedItem == null || CmbDriver.SelectedItem == null || string.IsNullOrWhiteSpace(booked))
            {
                MessageBox.Show("Remplis tous les champs (Mark, Year, Engine Type, Type, Driver, Booked).");
                return false;
            }
            if (!int.TryParse(TxtMileage.Text, out var mileage))
            {
                MessageBox.Show("Mileage doit être un nombre.");
                return false;
            }

            v = new Vehicle
            {
                Vlp = TxtPlate.Text.Trim(),
                Vmark = CmbMark.SelectedItem.ToString(),
                Vmodel = TxtModel.Text.Trim(),
                VYear = Convert.ToInt32(CmbYear.SelectedItem),
                VEngType = CmbEngineType.SelectedItem.ToString(),
                VColor = TxtColor.Text.Trim(),
                VMileage = mileage,
                VType = CmbType.SelectedItem.ToString(),
                Booked = booked,
                Driver = CmbDriver.SelectedItem.ToString()
            };

            return true;
        }

        private void ClearForm()
        {
            TxtPlate.Clear();
            TxtModel.Clear();
            TxtMileage.Clear();
            TxtColor.Clear();

            CmbMark.SelectedIndex = -1;
            CmbYear.SelectedIndex = -1;
            CmbEngineType.SelectedIndex = -1;
            CmbType.SelectedIndex = -1;
            CmbDriver.SelectedIndex = -1;
            CmbBooked.SelectedIndex = 0;

            GridVehicles.SelectedItem = null;
        }
    }

    public class Vehicle
    {
        public string Vlp { get; set; }
        public string Vmark { get; set; }
        public string Vmodel { get; set; }
        public int VYear { get; set; }
        public string VEngType { get; set; }
        public string VColor { get; set; }
        public int VMileage { get; set; }
        public string VType { get; set; }
        public string Booked { get; set; }
        public string Driver { get; set; }
    }
}