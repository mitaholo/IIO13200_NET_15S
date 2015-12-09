using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class _Default : System.Web.UI.Page
{
    XDocument xml;

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadXml();
        if (IsPostBack)
        {
            if (!String.IsNullOrEmpty(txtDate.Text) &&
                !String.IsNullOrEmpty(txtName.Text) &&
                !String.IsNullOrEmpty(txtHaveLearned.Text) &&
                !String.IsNullOrEmpty(txtWantToLearn.Text) &&
                !String.IsNullOrEmpty(txtGood.Text) &&
                !String.IsNullOrEmpty(txtBad.Text))
            {
                SaveResponse();
            }
            else litError.Text = "Täytä kaikki kentät!";
        }
    }

    private void LoadXml()
    {
        String rootPath = Server.MapPath("~");
        if (File.Exists(rootPath + ConfigurationManager.AppSettings["xmlpath"]))
        {
            xml = XDocument.Load(rootPath + ConfigurationManager.AppSettings["xmlpath"]);
        }
        else
        {
            string str =
                @"<?xml version=""1.0"" encoding=""utf-8""?>
                        <palautteet xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
                        </palautteet>";
            xml = XDocument.Parse(str);
        }
    }

    private void SaveResponse()
    {
        XElement xmlElement = new XElement("palaute",
            new XElement("pvm", txtDate.Text),
            new XElement("tekija", txtName.Text),
            new XElement("opittu", txtHaveLearned.Text),
            new XElement("haluanoppia", txtWantToLearn.Text),
            new XElement("hyvaa", txtGood.Text),
            new XElement("parannettavaa", txtBad.Text),
            new XElement("muuta", txtMisc.Text)
        );
        xml.Element("palautteet").Add(xmlElement);

        try
        {
            String rootPath = Server.MapPath("~");
            xml.Save(rootPath + ConfigurationManager.AppSettings["xmlpath"]);
            litError.Text = "Tiedot tallennettu";
        }
        catch (Exception)
        {
            litError.Text = "Tallennus epäonnistui";
        }
    }

    protected void SendClicked(object sender, EventArgs e)
    {
        Server.Transfer("Default.aspx", true);
    }
}