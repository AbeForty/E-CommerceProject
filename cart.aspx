<%@ Page Title="" Language="VB" MasterPageFile="~/OnlineStore.master" AutoEventWireup="false" CodeFile="cart.aspx.vb" Inherits="cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="head-bread">
        <div class="container">
            <ol class="breadcrumb">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="products.aspx">Products</a></li>
                <li class="active">CART</li>
            </ol>
        </div>
    </div>
    <!-- check-out -->
    <div class="check">
        <div class="container">
            <div class="col-md-3 cart-total">
             <%--   <a class="continue" href="#">Continue to basket</a>--%>
                <div class="price-details">
                    <h3>Price Details</h3>
                    <span>Total</span>
                    <span class="total1"><asp:Label runat="server" ID="lblSubtotal"/></span>
                 <%--   <span>Discount</span>--%>
<%--                    <span class="total1">10%(Festival Offer)</span>--%>
                    <span>Shipping</span>
                    <span class="total1">Tax & Shipping will determined on checkout.</span>
                    <div class="clearfix"></div>
                </div>
                <hr class="featurette-divider">
                <ul class="total_price">
                    <li class="last_price">
                        <h4>TOTAL</h4>
                    </li>
                    <li class="last_price"><span><asp:Label runat="server" ID="lblTotal"/></span></li>
                    <div class="clearfix"></div>
                </ul>
                <div class="clearfix"></div>
                <asp:LinkButton ID="lbOrder" runat="server" cssclass="order" Enabled="False">Place Order</asp:LinkButton>
            </div>
            <div class="col-md-9 cart-items">

                <h1>My Shopping Bag</h1>
                   <asp:LinkButton runat="server" ID="lblEmptyCart" Text='Empty Cart'/>
<%--                <script>$(document).ready(function (c) {
    $('.close1').on('click', function (c) {
        $('.cart-header').fadeOut('slow', function (c) {
            $('.cart-header').remove();
        });
    });--%>
<%--//});--%>
              <%--  </script>--%>
                <asp:SqlDataSource ID="DSCart" runat="server"
                    DataSourceMode="DataSet"
                    ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:OnlineStoreConnectionString.ProviderName %>"></asp:SqlDataSource>
                <asp:ListView ID="lvCart" runat="server" DataSourceID="DSCart"
                    OnItemCommand="lvCart_OnItemCommand" CellPadding="3" DataKeyField="CartID,ProductID"
                    CellSpacing="0" RepeatColumns="1" DataKeyNames="CartID">
                    <LayoutTemplate>
                        <asp:PlaceHolder runat="server" ID="groupPlaceHolder" />
                    </LayoutTemplate>
                    <GroupTemplate>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                    </GroupTemplate>
                    <ItemTemplate>
                        <div class="cart-header">
                            <div class="close1">
                                <asp:ImageButton runat="server" ID="btnClose" CssClass="glyphicon glyphicon-remove" ImageUrl="~/images/DeleteBTN.png"  CommandName="cmdDelete" CommandArgument='<%# Eval("ProductID") %>'/><%--<span class="glyphicon glyphicon-remove" aria-hidden="true"></span>--%></div>
                            <div class="cart-sec simpleCart_shelfItem">
                                <div class="cart-item cyc">
                                    <img src="product-images/<%# Trim(Eval("ProductNo")) %>.jpg" class="img-responsive" alt="" />
                                </div>
                                <div class="cart-item-info">
                                    <ul class="qty">
                                        <li>
                                            <p>Item : <%#Eval("ProductName")%></p>
                                            <p><%#Eval("ProductID")%></p>
                                            <p><%#Eval("ProductNo")%></p>
                                        </li>
                                        <li>
                                            <p>Qty : <asp:TextBox runat ="server" ID ="tbQuantity" Text=<%#Eval("Quantity")%>/></p>
                                        <asp:LinkButton runat="server" ID="lbUpdateQuantity" Text='Update'
                                    CommandName="cmdUpdateQuantity" CommandArgument='<%# Eval("ProductID") %>' />
                                             </li>
                                        <li>
                                            <p>Item total : <asp:Label runat ="server" ID ="lblSubtotal" Text=<%# Eval("Quantity") * Eval("Price") %>/></p>
                                        <%-- <asp:LinkButton runat="server" ID="lbDelete" Text='Delete'
                                    CommandName="cmdDelete" CommandArgument='<%# Eval("ProductID") %>' />--%>
                                        </li>
                                    </ul>
                                    <div class="delivery">
                                        <%--<p>Service Charges : $5.00</p>--%>
                                        <span>Delivered in 2-3 bussiness days</span>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>

                            </div>
                        </div>
                        <script>$(document).ready(function (c) {
    $('.close2').on('click', function (c) {
        $('.cart-header2').fadeOut('slow', function (c) {
            $('.cart-header2').remove();
        });
    });
});
                        </script>
                    </ItemTemplate>
                </asp:ListView>
            </div>
</asp:Content>

