<%@ Page Language="C#" MasterPageFile="~/View/CustomerNavigation.Master" AutoEventWireup="true" CodeBehind="ArtistDetail.aspx.cs" Inherits="KpopZtation.ArtistDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:GridView ID="GridViewArtist" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridViewArtist_RowDeleting" OnRowUpdating="GridViewArtist_RowUpdating">
            <Columns>
                <asp:HyperLinkField DataTextField="AlbumName" HeaderText="Album Name"  DataNavigateUrlFields="ArtistID, AlbumName" DataNavigateUrlFormatString="~/View/AlbumDetail.aspx?ArtistID={0}&AlbumName={1}"/>
                <asp:ImageField DataImageUrlField="AlbumImage" HeaderText="Album Image" ControlStyle-Width="100" ControlStyle-Height = "100">
                <ControlStyle Height="100px" Width="100px"></ControlStyle>
                </asp:ImageField>
                <asp:BoundField DataField="AlbumPrice" HeaderText="Album Price"/>
                <asp:BoundField DataField="AlbumStock" HeaderText="Album Stock"/>
                <asp:BoundField DataField="AlbumDescription" HeaderText="Album Description"/>
                <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" />
                <asp:ButtonField ButtonType="Button" CommandName="Update" Text="Update" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="InsertAlbumBtn" runat="server" Text="Insert Album" OnClick="InsertAlbumBtn_Click"/>
        This is the artist detail page
    </div>
</asp:Content>
