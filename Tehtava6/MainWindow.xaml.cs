//Koodannut ja testannut toimivaksi 6.3.2014 EsaSalmik
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JAMK.ICT.ADOBlanco
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }

        private void IniMyStuff()
        {
            string message = "";
            cbCities.DataContext = null;
            cbCities.DataContext = Data.DBPlacebo.GetCities(out message);
            lbMessages.Content = message;
        }

        private void btnGet3_Click(object sender, RoutedEventArgs e)
        {
            dgCustomers.DataContext = null;
            dgCustomers.DataContext = Data.DBPlacebo.GetTestCustomers();
            lbMessages.Content = "Test data fetched";
        }

        private void btnGetAll_Click(object sender, RoutedEventArgs e)
        {
            string message = "";
            dgCustomers.DataContext = Data.DBPlacebo.GetAllCustomersFromSQLServer(out message);
            lbMessages.Content = message;
        }

        private void btnGetFrom_Click(object sender, RoutedEventArgs e)
        {
            if (cbCities.Text != "")
            {
                string message = "";
                dgCustomers.DataContext = Data.DBPlacebo.GetCustomersFromSQLServer(cbCities.Text, out message);
                lbMessages.Content = message;
            }
        }
    }
}
