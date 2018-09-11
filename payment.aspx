<%@ Page Language="VB" AutoEventWireup="false" CodeFile="payment.aspx.vb" Inherits="payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<%--  <form action="/Charge" method="POST">
    <script
        src="https://checkout.stripe.com/checkout.js" class="stripe-button"
        data-key="<%# stripePublishableKey %>"
        data-amount="500"
        data-name="Stripe.com"
        data-description="Sample Charge"
        data-locale="auto"
        data-zip-code="true">
    </script>
</form>--%>
<%--    <form id="form1" runat="server">--%>
 <%--   <div>    
        <asp:Label ID="Label1" runat="server" Text="Credit Card Number"></asp:Label>
        <asp:TextBox ID="txtCreditNumber" runat="server"></asp:TextBox>

        <asp:DropDownList ID="ddlMonth" runat="server" Visible="False">
            <asp:ListItem>01</asp:ListItem>
            <asp:ListItem>02</asp:ListItem>
            <asp:ListItem>03</asp:ListItem>
            <asp:ListItem>04</asp:ListItem>
            <asp:ListItem>05</asp:ListItem>
            <asp:ListItem>06</asp:ListItem>
            <asp:ListItem>07</asp:ListItem>
            <asp:ListItem>08</asp:ListItem>
            <asp:ListItem>09</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddlYear" runat="server" Visible="False">
        </asp:DropDownList>

        <asp:Label ID="Label2" runat="server" Text="Amount"></asp:Label>
        <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" Text="Button" />

    </div>--%>
<%--    </form>--%>
</body>
</html>
