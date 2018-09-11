<%@ Page Title="" Language="VB" MasterPageFile="~/OnlineStore.master" AutoEventWireup="false" CodeFile="account.aspx.vb" Inherits="account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 548px;
            height: 237px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="sellFormInner" style="margin-left: auto; margin-right: auto;" class="auto-style1">
        <p style="text-align: center; font-size: 15pt;">
            Update Account Details
        </p>
        <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="lblUserName" runat="server" Text="User Name: " Width="80px"></asp:Label>
        <asp:TextBox ID="txtUserName" runat="server" Width="449px"></asp:TextBox>
        <br />
        <asp:Label ID="lblPrice" runat="server" Text="Email:" Width="80px"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" Width="450px" TextMode="Email"></asp:TextBox>
        <br />
        <asp:Label ID="lblOldPassword" runat="server" Text="Password:" Width="80px"></asp:Label>
        <asp:TextBox ID="txtOldPassword" runat="server" Width="452px" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="lblNewPassword" runat="server" Text="New Password:" Width="123px"></asp:Label>
        <asp:TextBox ID="txtNewPassword" runat="server" Width="410px" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="lblSubcategory" runat="server" Text="Confirm Password:" Width="123px"></asp:Label>
        <asp:TextBox ID="txtConfirmPassword" runat="server" Width="410px" TextMode="Password"></asp:TextBox>
        <br />
        <asp:LinkButton ID="btnUpdate" runat="server" CssClass="order">Update</asp:LinkButton>
    </div>
</asp:Content>

