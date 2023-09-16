<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="KpopZtation.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="NameLabel" runat="server" Text="Name: "></asp:Label>
            <asp:TextBox ID="NameText" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="EmailLabel" runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="EmailText" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="GenderLabel" runat="server" Text="Gender: "></asp:Label>
            <asp:TextBox ID="GenderText" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="AddressLabel" runat="server" Text="Address: "></asp:Label>
            <asp:TextBox ID="AddressText" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="PasswordLabel" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="PasswordText" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="RegisterBtn" runat="server" Text="Register" onclick="RegisterBtn_Click"/>

        </div>
    </form>
</body>
</html>
