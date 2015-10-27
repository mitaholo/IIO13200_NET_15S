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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Tehtava8
{
    /// <summary>
    /// Interaction logic for ListWindow.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
        XDocument xml;

        public ListWindow(XDocument xml)
        {
            InitializeComponent();
            this.xml = xml;

            var feedbackData =  from feedback in xml.Root.Descendants("palaute")
                                orderby (string)feedback.Element("pvm")
                                select new
                                {
                                    Date = (string)feedback.Element("pvm"),
                                    Name = (string)feedback.Element("tekija"),
                                    HasLearned = (string)feedback.Element("opittu"),
                                    WantsToLearn = (string)feedback.Element("haluanoppia"),
                                    Positive = (string)feedback.Element("hyvaa"),
                                    Negative = (string)feedback.Element("parannettavaa"),
                                    Misc = (string)feedback.Element("muuta"),
                                };
            var feedbackTable = new DataTable();
            feedbackTable.Columns.Add("Pvm", typeof(string));
            feedbackTable.Columns.Add("Nimi", typeof(string));
            feedbackTable.Columns.Add("Opittu", typeof(string));
            feedbackTable.Columns.Add("Haluaa oppia", typeof(string));
            feedbackTable.Columns.Add("Hyvää", typeof(string));
            feedbackTable.Columns.Add("Huonoa", typeof(string));
            feedbackTable.Columns.Add("Muuta", typeof(string));
            foreach (var feedbackElement in feedbackData)
            {
                feedbackTable.Rows.Add(
                    feedbackElement.Date,
                    feedbackElement.Name,
                    feedbackElement.HasLearned,
                    feedbackElement.WantsToLearn,
                    feedbackElement.Positive,
                    feedbackElement.Negative,
                    feedbackElement.Misc
                );
            }
            dgData.DataContext = feedbackTable;
        }
    }
}