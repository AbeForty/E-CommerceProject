<%@ Page Title="" Language="VB" MasterPageFile="~/OnlineStore.master" AutoEventWireup="false" CodeFile="verify.aspx.vb" Inherits="verify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="verifyForm" style="max-width: 500px; margin-left: auto; margin-right: auto; text-align:center;">
        <p style="font-size: 15pt; text-align: center;">This content is meant for a specific age group. Please verify your age to continue.</p>
        <asp:DropDownList ID="ddlAge" runat="server"></asp:DropDownList>
        <asp:LinkButton ID="btnVerify" runat="server" CssClass="order">Verify</asp:LinkButton>
    </div>
</asp:Content>


