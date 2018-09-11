﻿<%@ Page Title="" Language="VB" MasterPageFile="~/login.master" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <p style="font-size: 15pt; text-align:center;">Login</p>
        <div style="width: 300px; margin-left: auto; margin-right: auto;">
            <asp:Label ID="lblError" runat="server" Text="Errors" ForeColor="Red" Visible="False"></asp:Label>
            <br />
            <asp:Label ID="lblEmail" runat="server" Text="Email: " Width="150px"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>     
            <br />
            <asp:Label ID="lblPassword" runat="server" Text="Password: " Width="150px"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:LinkButton ID="btnLogin" runat="server" CssClass="order">Log In</asp:LinkButton>
            <a class = "order"  href="register.aspx">Register</a>
        </div>
    </div>
</asp:Content>
