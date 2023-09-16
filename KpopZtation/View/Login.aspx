<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KpopZtation.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="EmailLabel" runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="EmailText" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="PasswordLabel" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="PasswordText" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="RememberLabel" runat="server" Text="Remember me?"></asp:Label>
            <asp:CheckBox ID="RememberCheckbox" runat="server"/>
            <br />
            <asp:Label ID="ErrorLabel" runat="server" Text="" ></asp:Label>
            <br />
            <asp:Button ID="LoginBtn" runat="server" Text="Login" onclick="LoginBtn_Click"/>
        </div>
    </form>
</body>
</html>
