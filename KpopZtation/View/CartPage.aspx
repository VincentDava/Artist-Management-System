<%@ Page Title="" Language="C#" MasterPageFile="~/View/CustomerNavigation.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="KpopZtation.View.CartPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:GridView ID="GridViewCart" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridViewCart_RowDeleting">
            <Columns>
                <asp:BoundField DataField="AlbumName" HeaderText="Album Name"/>
                <asp:ImageField DataImageUrlField="AlbumImage" HeaderText="Album Image" ControlStyle-Width="100" ControlStyle-Height = "100">
                <ControlStyle Height="100px" Width="100px"></ControlStyle>
                </asp:ImageField>
                <asp:BoundField DataField="AlbumPrice" HeaderText="Album Price"/>
                <asp:BoundField DataField="Quantity" HeaderText="Quantity"/>
                <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" />
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <asp:Button ID="CheckoutBtn" runat="server" Text="Checkout" OnClick="CheckoutBtn_Click"/>
    </div>
</asp:Content>
