<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="mainForm" runat="server">
    <div>
            <asp:Repeater runat="server" id="rptRecords">
                <HeaderTemplate>
                    <table>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <img src="/Images/<%# (Container.DataItem as XElement).Attribute("ISBN").Value %>.jpg" height="200" width="200"/>
                        </td>
                        <td>
                            <h2><%# (Container.DataItem as XElement).Attribute("Artist").Value %>: <%# (Container.DataItem as XElement).Attribute("Title").Value %></h2>
                            <p>ISBN: <a href="Record.aspx?isbn=<%# (Container.DataItem as XElement).Attribute("ISBN").Value %>"><%# (Container.DataItem as XElement).Attribute("ISBN").Value %></a></p>
                            <p>Hinta: <%# (Container.DataItem as XElement).Attribute("Price").Value %> €</p>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
    </div>
    </form>
</body>
</html>
