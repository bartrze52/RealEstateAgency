using System.Collections.ObjectModel;
using System.IO;
using Microsoft.Win32;
using System.Linq;
using System.Text.Json;
using System.Windows;

namespace RealEstateAgency
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<RealEstate> realEstates = new ObservableCollection<RealEstate>();

        public MainWindow()
        {
            InitializeComponent();
            listView.ItemsSource = realEstates;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                string jsonData = JsonSerializer.Serialize(realEstates);
                File.WriteAllText(saveFileDialog.FileName, jsonData);
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string jsonData = File.ReadAllText(openFileDialog.FileName);
                realEstates = JsonSerializer.Deserialize<ObservableCollection<RealEstate>>(jsonData);
                listView.ItemsSource = realEstates;
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string searchText = searchTextBox.Text.ToLower();
            if (!string.IsNullOrEmpty(searchText))
            {
                var filteredList = realEstates.Where(r =>
                    r.Id.ToString().ToLower().Contains(searchText) ||
                    r.Osiedle.ToLower().Contains(searchText) ||
                    r.Adres.ToLower().Contains(searchText) ||
                    r.Type.ToLower().Contains(searchText) ||
                    r.Description.ToLower().Contains(searchText)
                ).ToList();

                listView.ItemsSource = filteredList;
            }
            else
            {
                listView.ItemsSource = realEstates;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddEditRealEstateWindow addEditRealEstateWindow = new AddEditRealEstateWindow();
            if (addEditRealEstateWindow.ShowDialog() == true)
            {
                realEstates.Add(addEditRealEstateWindow.RealEstate);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                AddEditRealEstateWindow addEditRealEstateWindow = new AddEditRealEstateWindow((RealEstate)listView.SelectedItem);
                if (addEditRealEstateWindow.ShowDialog() == true)
                {
                    int index = realEstates.IndexOf((RealEstate)listView.SelectedItem);
                    realEstates[index] = addEditRealEstateWindow.RealEstate;
                }
            }
            else
            {
                MessageBox.Show("Wybierz nieruchomość do edycji.");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                realEstates.Remove((RealEstate)listView.SelectedItem);
            }
            else
            {
                MessageBox.Show("Wybierz nieruchomość do usunięcia.");
            }
        }

        private void Contact_Click(object sender, RoutedEventArgs e)
        {
            ContactWindow contactWindow = new ContactWindow();
            contactWindow.ShowDialog();
        }
    }
}