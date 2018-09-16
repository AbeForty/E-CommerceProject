<%@ Page Title="" Language="VB" MasterPageFile="~/OnlineStore.master" AutoEventWireup="false" CodeFile="index.aspx.vb" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" style = "margin-left: auto; margin-right: auto;">
        <p style="font-size: 15pt; font-weight: bold; text-align:center;">FEATURED GAMES</p>
        <br />
        <div class="col-md-18 grid-gallery" style="width: 800px; margin-left: auto; margin-right: auto;">
            <asp:SqlDataSource ID="DSProductList" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>" SelectCommand="SELECT distinct TOP(6) Products.ProductName, Products.ImageURL, Products.Price, MAX(ProductID) as 'ProductID', MAX([Platform].Id) as 'PlatformID' FROM Products, [Platform] WHERE [Products].PlatformID = [Platform].Id GROUP BY Products.ProductName, Products.ImageURL, Products.Price ORDER BY MAX(ProductID) DESC"></asp:SqlDataSource>
            <asp:Repeater ID="rpProductList" runat="server" DataSourceID="DSProductList">
                <ItemTemplate>
                    <div class="col-md-4 grid-stn simpleCart_shelfItem">
                        <!-- normal -->
                        <%--                            <div class="ih-item square effect3 bottom_to_top">--%>
                        <%--    <div class="bottom-2-top">--%>

                        <div class="img">
                            <a href="details.aspx?ProductNo=<%# Trim(Eval("ProductID"))%>">
                                <img src="<%# Trim(Eval("ImageURL"))%>" alt="/" class="img-responsive gri-wid"></a>
                        </div>
                        <div class="info">
                            <div class="pull-left styl-hdn">
                                <h3><%--<a href="details.aspx?ProductNo=<%# Trim(Eval("ProductNo"))%>">--%><%# Eval("ProductName")%><br /><%# getPlatformShortName(Trim(Eval("PlatformID")))%><%--</a>--%><%--</a>--%></h3>
                            </div>
                            <div class="pull-right styl-price">
                                <p><a href="#" class="item_add"><span class="glyphicon glyphicon-shopping-cart grid-cart" aria-hidden="true"></span><span class=" item_price">$<%# Eval("Price")%></span></a></p>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                    <%--                            </div>--%>
                    <!-- end normal -->
                    <div class="quick-view">
                        <a href="details.aspx?ProductNo=<%# Trim(Eval("ProductID"))%><%--&MainCatID=<%# Request.QueryString("MainCatID")%>&SubCatID=<%# Request.QueryString("SubCatID")%>--%>">Quick view</a>
                    </div>
                    <%--                    </div>      --%>
                </ItemTemplate>
            </asp:Repeater>
            <div class="clearfix"></div>
        </div>
    </div>
</asp:Content>

