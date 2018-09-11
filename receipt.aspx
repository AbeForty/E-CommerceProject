<%@ Page Title="" Language="VB" MasterPageFile="~/OnlineStore.master" AutoEventWireup="false" CodeFile="receipt.aspx.vb" Inherits="receipt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="thankyou" style="text-align: center;">
        <p style="font-size: x-large"><strong>Thank you. Your order has been placed.</strong></p>
        <p>An email of your receipt has been sent.</p>
    </div>
    <div class="summary" style ="width: 600px; margin-left:auto; margin-right:auto;">
        <table>
            <tr>
                <td>
                    <asp:SqlDataSource ID="DSOrderHead" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>"></asp:SqlDataSource>
                    <asp:DataList ID="dlOrderHead" runat="server" DataSourceID="DSOrderHead" RepeatColumns="1">
                        <ItemTemplate>
                            <table class="centeredTable">
                                <tr>
                                    <td>Order ID: <%# Eval("Id")%></td>
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
                    <asp:DataList ID="dlSummary" runat="server" DataSourceID="DSSummary" RepeatColumns="1">
                        <ItemTemplate>
                            <table class="centeredTable">
                                <tr>
                                    <td>
                                        <img style="height: 120px; width: 100px;" src="<%# Trim(Eval("ImageURL"))%>" alt="/"></td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td><%# Trim(Eval("ProductName"))%></td>
                                            </tr>
                                            <tr>
                                                <td>Qty :
                                                    <asp:Label runat="server" ID="lblQuantity" Text='<%#Trim(Eval("Quantity"))%>' /></td>
                                                <td></td>
                                                <td>Price :
                                                    <asp:Label runat="server" ID="lblPrice" Text='<%#Trim(Eval("Price"))%>' /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <a class="order" href="index.aspx">Return to Home Page</a>
    </div>
</asp:Content>
