<%@ Page Title="" Language="VB" MasterPageFile="~/OnlineStore.master" AutoEventWireup="false" CodeFile="account.aspx.vb" Inherits="account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            max-width: 548px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="accountFormInner" style="margin-left: auto; margin-right: auto;" class="auto-style1">
        <p style="text-align: center; font-size: 15pt;">
            Update Account Details
        </p>
        <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="lblUserName" runat="server" Text="User Name: " Width="99%"></asp:Label>
        <br />
        <asp:TextBox ID="txtUserName" runat="server" Width="99%"></asp:TextBox>
        <br />
        <asp:Label ID="lblPrice" runat="server" Text="Email:" Width="99%"></asp:Label>
        <br />
        <asp:TextBox ID="txtEmail" runat="server" Width="99%" TextMode="Email"></asp:TextBox>
        <br />
        <asp:Label ID="lblOldPassword" runat="server" Text="Password:" Width="99%"></asp:Label>
        <br />
        <asp:TextBox ID="txtOldPassword" runat="server" Width="99%" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="lblNewPassword" runat="server" Text="New Password:" Width="99%"></asp:Label>
        <br />
        <asp:TextBox ID="txtNewPassword" runat="server" Width="99%" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="lblSubcategory" runat="server" Text="Confirm Password:" Width="99%"></asp:Label>
        <br />
        <asp:TextBox ID="txtConfirmPassword" runat="server" Width="99%" TextMode="Password"></asp:TextBox>
        <br />
        <asp:LinkButton ID="btnUpdate" runat="server" CssClass="order">Update</asp:LinkButton>
    </div>
</asp:Content>

