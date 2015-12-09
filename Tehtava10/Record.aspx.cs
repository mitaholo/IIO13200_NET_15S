using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class Record : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(Request.QueryString["isbn"]))
        {
            String rootPath = Server.MapPath("~");
            XDocument xml;
            IEnumerable<XElement> records;

            if (File.Exists(rootPath + "/LevykauppaX.xml"))
            {
                xml = XDocument.Load(rootPath + "/LevykauppaX.xml");

                records = from record in xml.Root.Descendants("record")
                          where record.Attribute("ISBN").Value == Request.QueryString["isbn"]
                          select record;

                if (records.Count<XElement>() == 1)
                {
                    XElement record = records.First<XElement>();

                    if (File.Exists(rootPath + "Images\\" + record.Attribute("ISBN").Value + ".jpg"))
                    {
                        imgCover.Visible = true;
                        imgCover.ImageUrl = "Images/" + record.Attribute("ISBN").Value + ".jpg";
                    }

                    lblHeader.Text = record.Attribute("Artist").Value + ": " + record.Attribute("Title").Value;
                    lblIsbn.Text = "ISBN: " + record.Attribute("ISBN").Value;
                    lblPrice.Text = "Hinta: " + record.Attribute("Price").Value + " €";

                    IEnumerable<XElement> songs = record.Descendants("song");
                    if (songs.Count<XElement>() > 0)
                    {
                        rptSongs.DataSource = record.Descendants("song");
                        rptSongs.DataBind();
                    }
                }
                else ShowError("Levyä ei löytynyt!");
            }
            else ShowError("Tietokantavirhe!");
        }
        else ShowError("Käyttäjän moka!");
    }

    private void ShowError(string text)
    {
        lblError.Visible = true;
        lblError.Text = text;
    }

    protected void RecordBound(object sender, RepeaterItemEventArgs args)
    {
        Repeater repeaterRecord = sender as Repeater;
        IEnumerable<XElement> enumerableRecord = repeaterRecord.DataSource as IEnumerable<XElement>;
        XElement elementRecord = enumerableRecord.First<XElement>();

        if (args.Item.ItemType == ListItemType.Item || args.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater childRepeater = (Repeater)args.Item.FindControl("ChildRepeater");
            childRepeater.DataSource = elementRecord.Descendants("song");
            childRepeater.DataBind();
        }
    }
}