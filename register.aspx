<%@ Page Title="" Language="VB" MasterPageFile="~/login.master" AutoEventWireup="false" CodeFile="register.aspx.vb" Inherits="register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div id="registerForm" style="width: 300px; margin-left: auto; margin-right: auto;">
            <p style="text-align: center; font-size: 15pt;">Register for an account</p>
            <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Visible="False"></asp:Label>
            <br />
            <asp:Label ID="lblName" runat="server" Text="Name: " Width="150px"></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblEmail" runat="server" Text="Email: " Width="150px"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPassword" runat="server" Text="Password: " Width="150px"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Label ID="lblPasswordConfirm" runat="server" Text="Confirm Password: " Width="150px"></asp:Label>
            <asp:TextBox ID="txtPasswordConfirm" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:LinkButton ID="btnRegister" runat="server" CssClass="order">Register</asp:LinkButton>
    </div>
</asp:Content>

