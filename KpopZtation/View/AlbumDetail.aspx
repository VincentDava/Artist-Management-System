<%@ Page Language="C#" MasterPageFile="~/View/CustomerNavigation.Master" AutoEventWireup="true" CodeBehind="AlbumDetail.aspx.cs" Inherits="KpopZtation.AlbumDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:GridView ID="GridViewAlbum" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="AlbumName" HeaderText="Album Name"/>
                <asp:BoundField DataField="AlbumDescription" HeaderText="Album Description"/>
                <asp:BoundField DataField="AlbumPrice" HeaderText="Album Price"/>
                <asp:BoundField DataField="AlbumStock" HeaderText="Album Stock"/>
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <asp:Label ID="QuantityLabel" runat="server" Text="Quantity: "></asp:Label>
        <asp:TextBox ID="QuantityText" runat="server" ></asp:TextBox>
        <br />
        <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <asp:Button ID="AddToCartBtn" runat="server" Text="Add To Cart" OnClick="AddToCartBtn_Click"/>
    </div>
</asp:Content>
