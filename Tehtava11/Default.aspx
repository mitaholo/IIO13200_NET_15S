<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .input-container {
            margin: 10px 0 10px 0;
        }

        p.input-label {
            display:inline-block;
            width:100px;
            margin: 0;
        }
    </style>
</head>
<body>
    <form id="inputForm" runat="server">
    <div>
        <h1>Anna palaute</h1>
        <div class="input-container">
            <p class="input-label">Pvm:</p>
            <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator id="rfvDate" runat="server"
                ControlToValidate="txtDate"
                ErrorMessage="Pakollinen kenttä!"
                ForeColor="Red">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator id="revDate" runat="server" 
                ControlToValidate="txtDate" 
                ErrorMessage="Virheellinen päivämäärä"
                ValidationExpression="^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$"
                ForeColor="Red">
            </asp:RegularExpressionValidator>
        </div>

        <div class="input-container">
            <p class="input-label">Nimi:</p>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator id="rfvName" runat="server"
              ControlToValidate="txtName"
              ErrorMessage="Pakollinen kenttä!"
              ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>

        <div class="input-container">
            <p class="input-label">Opittu:</p>
            <asp:TextBox ID="txtHaveLearned" runat="server" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator id="rfvHaveLearned" runat="server"
              ControlToValidate="txtHaveLearned"
              ErrorMessage="Pakollinen kenttä!"
              ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>

        <div class="input-container">
            <p class="input-label">Oppimatta:</p>
            <asp:TextBox ID="txtWantToLearn" runat="server" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator id="rfvWantToLearn" runat="server"
              ControlToValidate="txtWantToLearn"
              ErrorMessage="Pakollinen kenttä!"
              ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>

        <div class="input-container">
            <p class="input-label">Hyvää:</p>
            <asp:TextBox ID="txtGood" runat="server" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator id="rfvGood" runat="server"
              ControlToValidate="txtGood"
              ErrorMessage="Pakollinen kenttä!"
              ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>

        <div class="input-container">
            <p class="input-label">Pahaa:</p>
            <asp:TextBox ID="txtBad" runat="server" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator id="rfvBad" runat="server"
              ControlToValidate="txtBad"
              ErrorMessage="Pakollinen kenttä!"
              ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>

        <div class="input-container">
            <p class="input-label">Muuta:</p>
            <asp:TextBox ID="txtMisc" runat="server" TextMode="MultiLine"></asp:TextBox>
        </div>

        <asp:Button ID="btnSend" runat="server" Text="Lähetä" PostBackUrl="~/Default.aspx" OnClientClick="SendClicked" />

        <p><asp:Literal ID="litError" runat="server"></asp:Literal></p>

        <p><a href="List.aspx">Annetut palautteet</a></p>
    </div>
    </form>
</body>
</html>
