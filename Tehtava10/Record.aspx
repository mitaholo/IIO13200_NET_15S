<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Record.aspx.cs" Inherits="Record" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="recordForm" runat="server">
    <div runat="server" id="MyServerControlDiv">
        <asp:Label ID="lblError" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Image ID="imgCover" runat="server" height="200" width="200" Visible="false"/>
        <h2><asp:Label ID="lblHeader" runat="server" Text=""/></h2>
        <p><asp:Label ID="lblIsbn" runat="server" Text=""/></p>
        <p><asp:Label ID="lblPrice" runat="server" Text=""/></p>
        <asp:Repeater ID="rptSongs" runat="server">
            <HeaderTemplate>
                <p>Levyn biisit:</p>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li><%# (Container.DataItem as XElement).Attribute("name").Value %></li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
        <p><a href="Default.aspx">Takaisin</a></p>
    </div>
    </form>
</body>
</html>
