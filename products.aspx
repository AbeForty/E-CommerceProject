<%@ Page Title="" Language="VB" MasterPageFile="~/OnlineStore.master" AutoEventWireup="false" CodeFile="products.aspx.vb" Inherits="products" %>
<%@ MasterType virtualpath="~/OnlineStore.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="head-bread">
        <div class="container">
            <ol class="breadcrumb">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="products.aspx">
                    <asp:Label ID="lblBC1" runat="server" Text="PRODUCTS"></asp:Label></a></li>
                <asp:SqlDataSource ID="DSBreadcrumbs1" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>"></asp:SqlDataSource>
                <asp:Repeater ID="rpBreadcrumbs1" runat="server" DataSourceID="DSBreadcrumbs1">
                    <ItemTemplate>
                        <li class="active"><a href="products.aspx?MainCatId=<%# Request.QueryString("MainCatID")%>">
                            <asp:Label ID="lblBC3" runat="server" Text='<%# Trim(Eval("CategoryName"))%>'></asp:Label></a></li>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:SqlDataSource ID="DSBreadcrumbs2" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>"></asp:SqlDataSource>
                <asp:Repeater ID="rpBreadcrumbs2" runat="server" DataSourceID="DSBreadcrumbs2">
                    <ItemTemplate>
                        <li class="active"><a href="products.aspx?MainCatId=<%# Request.QueryString("MainCatID")%>&SubCatId=<%# Eval("CategoryID")%>">
                            <asp:Label ID="lblBC2" runat="server" Text='<%# Trim(Eval("CategoryName"))%>'></asp:Label></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ol>
        </div>
    </div>
    <div class="products-gallery">
        <div class="container">
            <div class="col-md-9 grid-gallery">
                <asp:SqlDataSource ID="DSProductList" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>"></asp:SqlDataSource>
                <asp:Repeater ID="rpProductList" runat="server" DataSourceID="DSProductList">
                    <ItemTemplate>
                        <div class="col-md-4 grid-stn simpleCart_shelfItem">
                            <!-- normal -->
                            <%--                            <div class="ih-item square effect3 bottom_to_top">--%>
                            <%--    <div class="bottom-2-top">--%>

                            <div class="img">
                                <a href="details.aspx?ProductNo=<%# Trim(Eval("ProductNo"))%>"><img src="product-images/<%# Trim(Eval("ProductNo"))%>.jpg" alt="/" class="img-responsive gri-wid"></a>
                            </div>
                            <div class="info">
                                <div class="pull-left styl-hdn">
                                    <h3><%--<a href="details.aspx?ProductNo=<%# Trim(Eval("ProductNo"))%>">--%><%# Eval("ProductName")%><%--</a>--%></h3>
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
                            <a href="details.aspx?ProductNo=<%# Trim(Eval("ProductNo"))%><%--&MainCatID=<%# Request.QueryString("MainCatID")%>&SubCatID=<%# Request.QueryString("SubCatID")%>--%>">Quick view</a>
                        </div>
                        <%--                    </div>      --%>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="clearfix"></div>
            </div>
            <div class="col-md-3 grid-details">
                <div class="grid-addon">
                    <section class="sky-form">
                        <div class="product_right">
                            <h4 class="m_2"><span class="glyphicon glyphicon-minus" aria-hidden="true"></span>Categories</h4>

                            <div class="tab1">
                                <div class="single-bottom">
                                    <asp:SqlDataSource ID="DSSubCategory" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>" SelectCommand=""></asp:SqlDataSource>
                                    <asp:DataList ID="dlSubCategory" runat="server" DataSourceID="DSSubCategory"
                                        RepeatDirection="Vertical">
                                        <ItemTemplate>
                                            <a href="#sportswear">
                                                <span class="badge pull-right"></span>
                                                <%--                                    <a href="products.aspx?MainCatId=<%# Request.QueryString("MainCatID")%>"</a>--%>
                                                <a href="products.aspx?MainCatId=<%# Request.QueryString("MainCatID")%>&SubCatId=<%# Eval("CategoryID")%>"><%# Trim(Eval("CategoryName"))%></a>
                                            </a>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                                <!--script-->
                            </div>
                        </div>
                        <div class="clearfix"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

