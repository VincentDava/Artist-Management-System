<%@ Page Language="C#" MasterPageFile="~/View/GuestNavigation.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="KpopZtation.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div> 
        <asp:GridView ID="GridViewHome" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridViewHome_RowDeleting" OnRowUpdating="GridViewHome_RowUpdating">
            <Columns>
                <asp:HyperLinkField HeaderText="Artist Name" DataTextField="ArtistName" DataNavigateUrlFields="ArtistID" DataNavigateUrlFormatString="~/View/ArtistDetail.aspx?ArtistID={0}"/>
                <asp:ImageField DataImageUrlField="ArtistImage" HeaderText="Artist Image" ControlStyle-Width="100" ControlStyle-Height = "100">
                <ControlStyle Height="100px" Width="100px"></ControlStyle>
                </asp:ImageField>
                <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" />
                <asp:ButtonField ButtonType="Button" CommandName="Update" Text="Update" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="InsertArtistBtn" runat="server" Text="Insert Artist" OnClick="InsertArtistBtn_Click"/>
    </div>
</asp:Content>
