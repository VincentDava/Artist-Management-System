<%@ Page Language="C#" MasterPageFile="~/View/AdminNavigation.Master" AutoEventWireup="true" CodeBehind="InsertArtist.aspx.cs" Inherits="KpopZtation.InsertArtist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="ArtistNameLabel" runat="server" Text="Artist Name: "></asp:Label>
        <asp:TextBox ID="ArtistNameText" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="ArtistImageLabel" runat="server" Text="Insert Image Here: "></asp:Label>
        <br />
        <asp:FileUpload ID="ArtistImageInput" runat="server" />
        <asp:Image ID="ArtistImageFile" type="file" runat="server" />
        <br />
        <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="InsertBtn" runat="server" Text="Button" OnClick="InsertBtn_Click"/>
    </div>
</asp:Content>
