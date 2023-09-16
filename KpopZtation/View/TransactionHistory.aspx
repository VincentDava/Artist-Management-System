<%@ Page Title="" Language="C#" MasterPageFile="~/View/CustomerNavigation.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="KpopZtation.View.TransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:GridView ID="GridViewTransaction" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID"/>
                <asp:BoundField DataField="TransactionDate" HeaderText="Date"/>
                <asp:BoundField DataField="CustomerName" HeaderText="Customer Name"/>
                <asp:ImageField DataImageUrlField="AlbumImage" HeaderText="Album Image" ControlStyle-Width="100" ControlStyle-Height = "100">
                <ControlStyle Height="100px" Width="100px"></ControlStyle>
                </asp:ImageField>
                <asp:BoundField DataField="AlbumName" HeaderText="Album Name"/>
                <asp:BoundField DataField="Qty" HeaderText="Quantity"/>
                <asp:BoundField DataField="AlbumPrice" HeaderText="Album Price"/>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
