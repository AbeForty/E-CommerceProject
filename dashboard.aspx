<%@ Page Title="" Language="VB" MasterPageFile="~/OnlineStore.master" AutoEventWireup="false" CodeFile="dashboard.aspx.vb" Inherits="dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="insightHeader">
        <p class="orderTitleBold">Insights</p>
        <asp:Label ID="lblNumberOfItemsSold" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblMoneyMade" runat="server"></asp:Label>
    </div>
    <br />
    <p class="orderTitleBold">High Selling Items</p>
    <br />
    <asp:SqlDataSource ID="DSHighSellItems" runat="server" SelectCommand="SELECT TOP(6) Count(ProductName) as 'NumberOfOrders', CartLine.ProductID, ProductName,ImageURL, Products.PlatformID, [PLATFORM].Name, [Platform].ShortName, UserID FROM CARTLINE, Products, [Platform] WHERE Products.PlatformID = [Platform].Id and CartLine.ProductID = Products.ProductID and Final = 1 and Products.UserID = @userID GROUP BY ProductName, CartLine.ProductID, ImageURL, Products.UserID, Products.PlatformID, [PLATFORM].Name, [Platform].ShortName ORDER BY Count(ProductName) DESC" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>" ProviderName="<%$ ConnectionStrings:OnlineStoreConnectionString.ProviderName %>">
        <SelectParameters>
            <asp:SessionParameter Name="userID" SessionField="user_id" />
        </SelectParameters>
    </asp:SqlDataSource>
    <p runat="server" style="margin: auto; text-align: center;" id="noOrder1" visible="False">You have yet to have any orders on your products.</p>
    <div class="orderRow">
        <asp:DataList ID="dlHighSellItems" runat="server" DataSourceID="DSHighSellItems" RepeatDirection="Horizontal" CssClass="centeredContentTable">
            <ItemTemplate>
                <table class="col-md-4 grid-stn simpleCart_shelfItem" style="display: inline;">
                    <tr>
                        <td>
                            <a href="details.aspx?ProductNo=<%# Trim(Eval("ProductID"))%>">
                                <img alt="<%# Trim(Eval("ProductName"))%>" src='<%# Trim(Eval("ImageURL"))%>' class="img-responsive gri-wid"></a></td>
                    </tr>
                    <tr>
                        <td>
                            <div class="orderProductDesc">
                                <p title="<%# Trim(Eval("ProductName"))%> (<%# Trim(Eval("ShortName"))%>)"><%# Trim(Eval("ProductName"))%>
                                    <br />
                                    (<%# Trim(Eval("ShortName"))%>)</p>
                                <p>Units sold: <%# Trim(Eval("NumberOfOrders"))%></p>
                            </div>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </div>
    <br />
    <p class="orderTitleBold">Recently Ordered Items</p>
    <br />
    <asp:SqlDataSource ID="DSRecentItems" runat="server" SelectCommand="SELECT Distinct TOP(6) Max(CartLine.Id), CartLine.ProductID, ProductName, ImageURL, [Platform].ShortName FROM CARTLINE, Products, [Platform] WHERE [Products].PlatformID = [Platform].Id and CartLine.ProductID = Products.ProductID and Final = 1 and Products.UserID = 1 GROUP BY ProductName, Products.ImageURL, [Platform].ShortName, Products.UserID, CartLine.ProductID ORDER BY Max(CartLine.Id) DESC" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>" ProviderName="<%$ ConnectionStrings:OnlineStoreConnectionString.ProviderName %>">
        <SelectParameters>
            <asp:SessionParameter Name="userID" SessionField="user_id" />
        </SelectParameters>
    </asp:SqlDataSource>
    <p runat="server" style="margin: auto; text-align: center;" id="noOrder2" visible="False">You have yet to have any orders on your products.</p>
    <div class="orderRow">
        <asp:DataList ID="dlRecentItems" runat="server" DataSourceID="DSRecentItems" RepeatDirection="Horizontal" CssClass="centeredContentTable">
            <ItemTemplate>
                <table class="col-md-4 grid-stn simpleCart_shelfItem" style="display: inline;">
                    <tr>
                        <td>
                            <a href="details.aspx?ProductNo=<%# Trim(Eval("ProductID"))%>">
                                <img alt="<%# Trim(Eval("ProductName"))%>" src='<%# Trim(Eval("ImageURL"))%>' class="img-responsive gri-wid"></a></td>
                    </tr>
                    <tr>
                        <td>
                            <div class="orderProductDesc">
                                <p title="<%# Trim(Eval("ProductName"))%> (<%# Trim(Eval("ShortName"))%>)"><%# Trim(Eval("ProductName"))%><br />
                                    (<%# Trim(Eval("ShortName"))%>)</p>
                            </div>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </div>
    <p class="orderTitleBold">Open Orders</p>
    <br />
    <asp:SqlDataSource ID="DSOpenOrders" runat="server" SelectCommand="SELECT CartLine.ProductID, Final, ShippingId, CartID, ProductName,ImageURL,[Platform].ShortName, UserID FROM CARTLINE, Products, [Platform] WHERE [Products].PlatformID = [Platform].Id and CartLine.ProductID = Products.ProductID and Final = 1 and Products.UserID = @userID" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>" ProviderName="<%$ ConnectionStrings:OnlineStoreConnectionString.ProviderName %>">
        <SelectParameters>
            <asp:SessionParameter Name="userID" SessionField="user_id" />
        </SelectParameters>
    </asp:SqlDataSource>
    <p runat="server" style="margin: auto; text-align: center;" id="noOrder3" visible="False">You have yet to have any orders on your products.</p>
    <div class="orderRow">
        <asp:DataList ID="dlOpenOrders" runat="server" DataSourceID="DSOpenOrders" RepeatDirection="Horizontal" CssClass="centeredContentTable">
            <ItemTemplate>
                <table class="col-md-4 grid-stn simpleCart_shelfItem" style="display: inline;">
                    <tr>
                        <td>
                            <asp:HiddenField ID="hdFieldCartID" runat="server" Value='<%# Trim(Eval("CartID"))%>' />
                            <asp:HiddenField ID="hdFieldProductID" runat="server" Value='<%# Trim(Eval("ProductID"))%>' />
                            <a href="details.aspx?ProductNo=<%# Trim(Eval("ProductID"))%>">
                                <img alt="<%# Trim(Eval("ProductName"))%>" src='<%# Trim(Eval("ImageURL"))%>' class="img-responsive gri-wid"></a></td>
                    </tr>
                    <tr>
                        <td>
                            <div class="orderProductDesc">
                                <asp:SqlDataSource ID="DSShippingStatus" runat="server" SelectCommand="SELECT * from ShippingStatus" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>" ProviderName="<%$ ConnectionStrings:OnlineStoreConnectionString.ProviderName %>"></asp:SqlDataSource>
                                <p title="<%# Trim(Eval("ProductName"))%> (<%# Trim(Eval("ShortName"))%>)"><%# Trim(Eval("ProductName"))%><br />
                                    (<%# Trim(Eval("ShortName"))%>)</p>
                                <span>Order #: <%# Trim(Eval("CartID"))%></span>
                                <asp:DropDownList ID="ddlShippingStatus" runat="server" DataSourceID="DSShippingStatus" DataTextField="Status" DataValueField="Id" OnSelectedIndexChanged="ddlShippingStatus_SelectedIndexChanged" AutoPostBack="True" OnDataBound="ddlShippingStatus_DataBound"></asp:DropDownList>
                            </div>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>

