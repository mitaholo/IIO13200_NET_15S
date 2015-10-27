using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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
using System.Xml.Linq;

namespace Tehtava8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        XDocument xml;

        public MainWindow()
        {
            InitializeComponent();

            LoadXml();
        }

        private void LoadXml()
        {
            if (File.Exists(ConfigurationManager.AppSettings["xmlpath"]))
            {
                xml = XDocument.Load(ConfigurationManager.AppSettings["xmlpath"]);
                txtStatus.Text = "Tiedosto avattu";
            }
            else
            {
                string str =
                    @"<?xml version=""1.0"" encoding=""utf-8""?>
                        <palautteet xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
                        </palautteet>";
                xml = XDocument.Parse(str);
                txtStatus.Text = "Uusi tiedosto luotu";
            }
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if(txtDate.Text != "" && txtName.Text != "" && txtHaveLearned.Text != "" && txtWantToLearn.Text != "" && txtPositive.Text != "" && txtNegative.Text != "")
            {
                XElement xmlElement = new XElement("palaute",
                    new XElement("pvm", txtDate.Text),
                    new XElement("tekija", txtName.Text),
                    new XElement("opittu", txtHaveLearned.Text),
                    new XElement("haluanoppia", txtWantToLearn.Text),
                    new XElement("hyvaa", txtPositive.Text),
                    new XElement("parannettavaa", txtNegative.Text),
                    new XElement("muuta", txtMisc.Text)
                );
                xml.Element("palautteet").Add(xmlElement);

                try
                {
                    xml.Save(ConfigurationManager.AppSettings["xmlpath"]);
                    txtStatus.Text = "Tiedot tallennettu";
                }
                catch (Exception)
                {
                    txtStatus.Text = "Tallennus epäonnistui";
                }
            }
            else
            {
                txtStatus.Text = "Täytä kaikki kentät";
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ListWindow listWindow = new ListWindow(xml);
            listWindow.Show();
        }
    }
}
