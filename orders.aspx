<%@ Page Title="" Language="VB" MasterPageFile="~/OnlineStore.master" AutoEventWireup="false" CodeFile="orders.aspx.vb" Inherits="orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id ="orderList">
        <p class ="orderTitleBold">Orders</p>
        <asp:SqlDataSource ID="DSOrderList" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>">
        </asp:SqlDataSource>
        <p runat="server" style="margin: auto; text-align:center;" id="noOrder1" visible="False">You have not placed any orders yet.</p>
        <asp:DataList ID="dlOrders" runat="server" DataSourceID="DSOrderList">
            <ItemTemplate>
                <div class="orderRowScroll">
                    <span class ="orderDetailBold"><%# "Order Number: " & Trim(Eval("CartID"))%></span>
                    <br />
                    <span class="orderDetail"><%# "Subtotal: $" & Trim(Eval("Subtotal"))%></span>
                    <br />
                    <span class="orderDetail"><%# "Shipping: $" & Trim(Eval("ShippingCost"))%></span>
                    <br />
                    <span class="orderDetail"><%# "Tax: $" & Trim(Eval("Tax"))%></span>
                    <br />
                    <span class ="orderDetail"><%# "Total: $" & Trim(Eval("Total"))%></span>
                    <br />
                    <asp:HiddenField ID="cartIDField" runat="server" Value='<%# Trim(Eval("CartID"))%>'></asp:HiddenField>
                    <asp:SqlDataSource ID="DSProducts" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>" SelectCommand="Select * FROM CARTLINE, Products, [Platform], ShippingStatus WHERE CartLine.ShippingId = ShippingStatus.Id and [Products].PlatformID = [Platform].Id  and Products.ProductID = CartLine.ProductID and CARTID = @cartID">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="cartIDField" Name="cartID" PropertyName="Value" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <div class="orderRow">
                        <asp:DataList ID="dlProducts" runat="server" DataSourceID="DSProducts" RepeatDirection = "Horizontal" CssClass ="centeredContentTable orderRow">
                            <ItemTemplate>
                                <table class="col-md-4 grid-stn simpleCart_shelfItem" style="display: inline;">
                                    <tr>
                                        <td>
                                             <a href="details.aspx?ProductNo=<%# Trim(Eval("ProductID"))%>"><img alt="<%# Trim(Eval("ProductName"))%>" src='<%# Trim(Eval("ImageURL"))%>' class="img-responsive gri-wid"></a></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="orderProductDesc">
                                                <p title ="<%# Trim(Eval("ProductName"))%> (<%# Trim(Eval("ShortName"))%>)"><%# Trim(Eval("ProductName"))%> (<%# Trim(Eval("ShortName"))%>)</p>
                                                <p>
                                                    Qty:
                                                <asp:Label ID="lblQuantity" runat="server" Text='<%# Trim(Eval("Quantity"))%>' />
                                                </p>
                                                <p>
                                                    Price:
                                                <asp:Label ID="lblPrice" runat="server" Text='<%# Trim(Eval("Price"))%>' />
                                                </p>
                                                <p>
                                                    Status:
                                                <asp:Label ID="lblShippingStatus" runat="server" Text='<%# Trim(Eval("Status"))%>' />
                                                </p>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
                <hr />
            </ItemTemplate>
    </asp:DataList>
    </div>
</asp:Content>

