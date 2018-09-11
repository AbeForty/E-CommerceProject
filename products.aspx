<%@ Page Title="" Language="VB" MasterPageFile="~/OnlineStore.master" AutoEventWireup="false" CodeFile="products.aspx.vb" Inherits="products" %>

<%@ MasterType VirtualPath="~/OnlineStore.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="head-bread">
        <div class="container">
            <ol class="breadcrumb">
                <li><a href="index.aspx">Home</a></li>
                <li>
                    <asp:Label ID="lblBC1" runat="server" Text="<a href ='products.aspx'>PRODUCTS</a>"></asp:Label></li>
                <asp:SqlDataSource ID="DSBreadcrumbs1" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>"></asp:SqlDataSource>
                <asp:Repeater ID="rpBreadcrumbs1" runat="server" DataSourceID="DSBreadcrumbs1">
                    <ItemTemplate>
                        <li class="active"><a href="products.aspx?MainCatId=<%# Request.QueryString("MainCatID")%>">
                            <%# Trim(Eval("CategoryName"))%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:SqlDataSource ID="DSBreadcrumbs2" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>"></asp:SqlDataSource>
                <asp:Repeater ID="rpBreadcrumbs2" runat="server" DataSourceID="DSBreadcrumbs2">
                    <ItemTemplate>
                        <li class="active"><a href="products.aspx?MainCatId=<%# Request.QueryString("MainCatID")%>&SubCatId=<%# Eval("CategoryID")%>">
                            <%# Trim(Eval("CategoryName"))%></a></li>
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
                               <%--                                <% If Trim(Eval("imageURL")) <> Nothing Then %>--%>
                                <a href="details.aspx?ProductNo=<%# Trim(Eval("ProductID"))%>">
                                    <img src="<%# Trim(Eval("imageURL"))%>" alt="<%# Trim(Eval("ProductName")) & " (" & Trim(Eval("ShortName")) & ")"%>" class="img-responsive gri-wid"></a>
                                <%--            <%Else %>
                                    <a href="details.aspx?ProductNo=<%# Trim(Eval("ProductID"))%>">
                                    <img src="<%# Trim(Eval("imageURL"))%>" alt="<%# Trim(Eval("ProductName"))%>" class="img-responsive gri-wid"></a>
                                <%End If %>--%>
                            <div class="info">
                                <div class="styl-hdn">
                                    <h3 title ="<%# Trim(Eval("ProductName")) & " (" & Trim(Eval("ShortName")) & ")"%>"><%--<a href="details.aspx?ProductNo=<%# Trim(Eval("ProductNo"))%>">--%><%# Trim(Eval("ProductName")) & "<br /> (" & Trim(Eval("ShortName")) & ")"%><%--</a>--%></h3>
                                </div>
                                <div class="styl-price">
                                    <p><a href="#" class="item_add"><span class="glyphicon glyphicon-shopping-cart grid-cart" aria-hidden="true"></span><span class=" item_price">$<%# Eval("Price")%></span></a></p>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </div>
<%--                       <div class="clearfix"></div>--%>

                            <%--                            </div>--%>
                            <!-- end normal -->
                            <div class="quick-view">
                                <a href="details.aspx?ProductNo=<%# Trim(Eval("ProductID"))%><%--&MainCatID=<%# Request.QueryString("MainCatID")%>&SubCatID=<%# Request.QueryString("SubCatID")%>--%>">Quick view</a>
                            </div>                            

                      

<%--                        </div>--%>

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
                                    <a href="#">
                                        <span class="badge pull-right"></span>
                                        <%--                                    <a href="products.aspx?MainCatId=<%# Request.QueryString("MainCatID")%>"</a>--%>
                                        <a href="products.aspx">All Products</a>
                                    </a>
                                    <asp:SqlDataSource ID="DSCategory" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>" SelectCommand=""></asp:SqlDataSource>
                                    <asp:DataList ID="dlCategory" runat="server" DataSourceID="DSCategory"
                                        RepeatDirection="Vertical">
                                        <ItemTemplate>
                                            <a href="#">
                                                <span class="badge pull-right"></span>
                                                <%--                                    <a href="products.aspx?MainCatId=<%# Request.QueryString("MainCatID")%>"</a>--%>
                                                <a href="products.aspx?MainCatId=<%# Trim(Eval("CategoryID"))%>"><%# Trim(Eval("CategoryName"))%></a>
                                            </a>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                                <!--script-->
                            </div>
                        </div>
                        <div class="clearfix"></div>
                    </section>
                </div>
            </div>
            <div class="col-md-3 grid-details">
                <div class="grid-addon">
                    <section class="sky-form">
                        <div class="product_right">
                            <h4 class="m_2"><span class="glyphicon glyphicon-minus" aria-hidden="true"></span>Subcategories</h4>

                            <div class="tab1">
                                <div class="single-bottom">
                                    <asp:SqlDataSource ID="DSSubCategory" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>" SelectCommand=""></asp:SqlDataSource>
                                    <asp:DataList ID="dlSubCategory" runat="server" DataSourceID="DSSubCategory"
                                        RepeatDirection="Vertical">
                                        <ItemTemplate>
                                            <a href="#">
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
                    </section>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

