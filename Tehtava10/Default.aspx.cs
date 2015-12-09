using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String rootPath = Server.MapPath("~");
        XDocument xml;
        IEnumerable<XElement> records;

        if (File.Exists(rootPath + "/LevykauppaX.xml"))
        {
            xml = XDocument.Load(rootPath + "/LevykauppaX.xml");
            records = xml.Root.Descendants("record");

            rptRecords.DataSource = records;
            rptRecords.DataBind();
        }
    }
}