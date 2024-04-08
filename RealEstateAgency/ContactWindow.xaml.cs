using System.Windows;

namespace RealEstateAgency
{
    public partial class ContactWindow : Window
    {
        public ContactWindow()
        {
            InitializeComponent();
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Message sent successfully.");
            Close();
        }
    }
}