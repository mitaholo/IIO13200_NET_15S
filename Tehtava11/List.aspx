<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="listForm" runat="server">
    <div>
        <h1>Annetut palautteet</h1>
        <p><a href="Default.aspx">Anna palautetta</a></p>
        <p><asp:Literal ID="litError" runat="server"></asp:Literal></p>
        <asp:GridView ID="gvResponses" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>
