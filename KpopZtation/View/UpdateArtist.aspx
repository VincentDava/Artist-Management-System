<%@ Page Language="C#" MasterPageFile="~/View/CustomerNavigation.Master" AutoEventWireup="true" CodeBehind="UpdateArtist.aspx.cs" Inherits="KpopZtation.UpdateArtist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
            <asp:Label ID="ArtistNameLabel" runat="server" Text="Artist Name: "></asp:Label>
            <asp:TextBox ID="ArtistNameText" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="ArtistImageLabel" runat="server" Text="Insert Artist Image Here: "></asp:Label>
            <br />
            <asp:FileUpload ID="ArtistImageInput" runat="server" />
            <asp:Image ID="ArtistImageFile" type="file" runat="server" />
            <br />
            <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="UpdateBtn" runat="server" Text="Button" OnClick="UpdateBtn_Click"/>
        </div>
</asp:Content>