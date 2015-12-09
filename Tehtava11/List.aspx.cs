using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class List : System.Web.UI.Page
{
    XDocument xml;

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadXml();
        IEnumerable<XElement> responses = null;
        if (xml != null)
        {
            responses = xml.Root.Descendants("palaute");

            if (responses.Count<XElement>() > 0)
            {
                DataTable responseTable = new DataTable();
                responseTable.Columns.Add("Päivämäärä", typeof(string));
                responseTable.Columns.Add("Nimi", typeof(string));
                responseTable.Columns.Add("Opittu", typeof(string));
                responseTable.Columns.Add("Opittavaa", typeof(string));
                responseTable.Columns.Add("Hyvää", typeof(string));
                responseTable.Columns.Add("Pahaa", typeof(string));
                responseTable.Columns.Add("Muuta", typeof(string));

                foreach (var response in responses)
                {
                    responseTable.Rows.Add(
                        response.Element("pvm").Value,
                        response.Element("tekija").Value,
                        response.Element("opittu").Value,
                        response.Element("haluanoppia").Value,
                        response.Element("hyvaa").Value,
                        response.Element("parannettavaa").Value,
                        response.Element("muuta").Value
                    );
                }

                gvResponses.DataSource = responseTable;
                gvResponses.DataBind();
            }
            else litError.Text = "Ei palautteita";
        }
        else litError.Text = "Tiedoston avaaminen epäonnistui";
    }

    private void LoadXml()
    {
        String rootPath = Server.MapPath("~");
        if (File.Exists(rootPath + ConfigurationManager.AppSettings["xmlpath"]))
        {
            xml = XDocument.Load(rootPath + ConfigurationManager.AppSettings["xmlpath"]);
        }
    }
}