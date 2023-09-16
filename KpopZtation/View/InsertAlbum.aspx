<%@ Page Language="C#" MasterPageFile="~/View/AdminNavigation.Master" AutoEventWireup="true" CodeBehind="InsertAlbum.aspx.cs" Inherits="KpopZtation.InsertAlbum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="AlbumNameLabel" runat="server" Text="Album Name: "></asp:Label>
        <asp:TextBox ID="AlbumNameText" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="AlbumImageLabel" runat="server" Text="Insert Image Here: "></asp:Label>
        <br />
        <asp:FileUpload ID="AlbumImageInput" runat="server" />
        <asp:Image ID="AlbumImageFile" type="file" runat="server" />
        <br />
        <asp:Label ID="AlbumPriceLabel" runat="server" Text="Album Price: "></asp:Label>
        <asp:TextBox ID="AlbumPriceText" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="AlbumStockLabel" runat="server" Text="Album Stock: "></asp:Label>
        <asp:TextBox ID="AlbumStockText" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="AlbumDescLabel" runat="server" Text="Album Description: "></asp:Label>
        <asp:TextBox ID="AlbumDescText" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="InsertBtn" runat="server" Text="Button" OnClick="InsertBtn_Click"/>
    </div>
</asp:Content>
