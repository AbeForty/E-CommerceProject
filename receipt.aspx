<%@ Page Title="" Language="VB" MasterPageFile="~/OnlineStore.master" AutoEventWireup="false" CodeFile="receipt.aspx.vb" Inherits="receipt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="thankyou" style="text-align:center;">
        <p style ="font-size:x-large"><strong>Thank you. Your order has been placed.</strong></p>
         <p>An email of your receipt has been sent.</p>
        </div>
          <div class="summary">
<table>
<tr>
<td>
       <asp:SqlDataSource ID="DSOrderHead" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>"></asp:SqlDataSource>                 
           <asp:DataList ID="dlOrderHead" runat ="server"  DataSourceID="DSOrderHead" RepeatColumns="1">
                <ItemTemplate>
                 <table class="centeredTable">
                    <tr>
                    <td>Order ID: <%# Eval("CartId")%></td>
                    </tr>            
                    <tr>
                    <td>Name: <%# Eval("ShippingFirstName") & " "%> <%# Eval("ShippingLastName")%></td>
                    </tr>
                    <tr>
                    <td>Address: <%# Eval("ShippingStreet")%></td>
                    </tr>
                    <tr>
                    <td>Subtotal: <%# Eval("Subtotal")%></td>
                    </tr>
                    <tr>
                    <td>Shipping: <%# Eval("Shipping")%></td>
                   </tr>
                   <tr>
                    <td>Tax: <%# Eval("Tax")%></td>
                    </tr>
                    <tr>
                    <td>Total: <%# Eval("Total")%></td>
                    </tr>
                </table>
                </ItemTemplate>
                </asp:DataList>
</td>                  
<td style="width: 25px"></td>
<td>
        <asp:SqlDataSource ID="DSSummary" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>"></asp:SqlDataSource>                 
           <asp:DataList ID="dlSummary" runat ="server"  DataSourceID="DSSummary" RepeatColumns="1">
            <ItemTemplate>
                <table class="centeredTable">
                    <tr>
                    <td><img style="height:120px; width:100px;" src="product-images/<%# Trim(Eval("ProductNo"))%>.jpg" alt="/"></td>
                        <td><table>
                        <tr><td><%# Trim(Eval("ProductName"))%></td></tr>
                         <tr><td>Qty : <asp:label runat ="server" ID ="lblQuantity" Text=<%#Trim(Eval("Quantity"))%>/></td>
                             <td></td>
                        <td>Price : <asp:label runat ="server" ID ="lblPrice" Text=<%#Trim(Eval("Price"))%>/></td></tr></table></td>
                        </tr>                 
                </table>
            </ItemTemplate>
        </asp:DataList>
            </div>
</td>
</tr>
</table>
            <div>
        <a class="order" href="index.aspx">Return to Home Page</a>
        </div>
</asp:Content>
