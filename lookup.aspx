<%@ Page Title="" Language="VB" MasterPageFile="~/OnlineStore.master" AutoEventWireup="false" CodeFile="lookup.aspx.vb" Inherits="lookup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width: 300px; margin-left: auto; margin-right: auto; text-align:center;">
        <asp:Label ID="lblEmail" runat="server" Text="Order #"></asp:Label>
        <br />
        <asp:TextBox ID="txtOrderNumber" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnLookup" runat="server" CssClass="order" Text="Lookup" Width="300px" />
    </div>
</asp:Content>

