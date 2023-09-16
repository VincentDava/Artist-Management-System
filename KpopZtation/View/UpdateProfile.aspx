<%@ Page Language="C#" MasterPageFile="~/View/CustomerNavigation.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="KpopZtation.UpdateProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        <asp:Button ID="UpdateBtn" runat="server" Text="Update" onclick="UpdateBtn_Click"/>
    </div>
</asp:Content>
