using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using Newtonsoft.Json;
using System.Data;

namespace Tehtava7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cbStation.DataContext = null;
            cbStation.DataContext = SonOfJ.fetchStations();
            cbStation.DisplayMemberPath = "StationName";
            cbStation.SelectedValuePath = "StationShortCode";
        }

        private void btnRequest_Click(object sender, RoutedEventArgs e)
        {
            if (cbStation.SelectedIndex >= 0)
            {
                DataTable dt = SonOfJ.fetchTrains((string)cbStation.SelectedValue);
                dgTrains.DataContext = null;
                dgTrains.DataContext = dt;
            }
        }

        private void cbStation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtStatus.Text = (string) cbStation.SelectedValue;
        }
    }
}
