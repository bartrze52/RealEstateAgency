using System;
using System.Windows;

namespace RealEstateAgency
{
    public partial class AddEditRealEstateWindow : Window
    {
        public RealEstate RealEstate { get; set; }

        public AddEditRealEstateWindow(RealEstate realEstate = null)
        {
            InitializeComponent();
            if (realEstate != null)
            {
                RealEstate = realEstate;
                idTextBox.Text = realEstate.Id.ToString();
                osiedleTextBox.Text = realEstate.Osiedle;
                adresTextBox.Text = realEstate.Adres;
                hasGarageCheckBox.IsChecked = realEstate.HasGarage;
                typeComboBox.SelectedValue = realEstate.Type;
                areaTextBox.Text = realEstate.Area.ToString();
                availabilityCheckBox.IsChecked = realEstate.Availability;
                descriptionTextBox.Text = realEstate.Description;
            }
            else
            {
                RealEstate = new RealEstate();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RealEstate.Id = int.Parse(idTextBox.Text);
                RealEstate.Osiedle = osiedleTextBox.Text;
                RealEstate.Adres = adresTextBox.Text;
                RealEstate.HasGarage = hasGarageCheckBox.IsChecked ?? false;
                RealEstate.Type = typeComboBox.SelectedValue.ToString();
                RealEstate.Area = int.Parse(areaTextBox.Text);
                RealEstate.Availability = availabilityCheckBox.IsChecked ?? false;
                RealEstate.Description = descriptionTextBox.Text;
                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}