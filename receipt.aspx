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
                            <table class="centeredTable">
                                <tr>
                                    <td>Order ID: <asp:Label ID="lblOrderID" runat="server" Text="ID"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Name: <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Address: <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Subtotal: <asp:Label ID="lblSubtotal" runat="server" Text="Subtotal"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Shipping: <asp:Label ID="lblShipping" runat="server" Text="Shipping"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Tax: <asp:Label ID="lblTax" runat="server" Text="Tax"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Total: <asp:Label ID="lblTotal" runat="server" Text="Total"></asp:Label></td>
                                </tr>
                            </table>
                </td>
            </tr>
            <tr>
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
