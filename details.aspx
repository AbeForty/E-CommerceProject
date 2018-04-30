<%@ Page Title="" Language="VB" MasterPageFile="~/OnlineStore.master" AutoEventWireup="false" CodeFile="details.aspx.vb" Inherits="details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <!-- FlexSlider -->
            <script src="js/imagezoom.js"></script>
              <script defer src="js/jquery.flexslider.js"></script>
            <link rel="stylesheet" href="css/flexslider.css" type="text/css" media="screen" />

            <script>
            // Can also be used with $(document).ready()
            $(window).load(function() {
              $('.flexslider').flexslider({
                animation: "slide",
                controlNav: "thumbnails"
              });
            });
            </script>
        <!-- //FlexSlider-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          <div class="head-bread">
            <div class="container">
                <ol class="breadcrumb">
                    <li><a href="#">Home</a></li>
                    <li><%--a href="products.aspx?MainCatId=<%# Request.QueryString("MainCatID")%>&SubCatID=<%# Request.QueryString("SubCatID")%>">--%><asp:Label ID="lblBC2" runat="server"></asp:Label><%--</a>--%></li>
                    <li><%--<img src="images/show.jpg" data-imagezoom="true" class="img-responsive">--%><asp:Label ID="lblBC1" runat="server"></asp:Label><%--<li data-thumb="images/show1.jpg">
                                 <div class="thumb-image"> <img src="images/show1.jpg" data-imagezoom="true" class="img-responsive"> </div>
                            </li>
                            <li data-thumb="images/show2.jpg">
                               <div class="thumb-image"> <img src="images/show2.jpg" data-imagezoom="true" class="img-responsive"> </div>
                            </li>
                            <li data-thumb="images/show3.jpg">
                               <div class="thumb-image"> <img src="images/show3.jpg" data-imagezoom="true" class="img-responsive"> </div>
                            </li>--%></li>
                    <li><asp:Label ID="lblBC3" runat="server"></asp:Label></li>
                </ol>
            </div>
        </div>
        <div class="showcase-grid">
            <div class="container">
                <div class="col-md-8 showcase">
                    <div class="flexslider">
                          <ul class="slides">
                            <li data-thumb="images/show.jpg">
                                <div class="thumb-image"> <%--             <asp:SqlDataSource ID="DSProductList" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>"></asp:SqlDataSource>
                        <asp:Repeater ID="rpProductList" runat="server" DataSourceID="DSProductList">
                        <ItemTemplate>--%> <asp:Image ID="imgProduct" runat="server" CssClass="img-responsive" /> </div>
                            </li>
                                <%--                            <p>Men's running shoes</p>--%>
                          </ul>
                        <div class="clearfix"></div>
                    </div>
                </div>
                <div class="col-md-4 showcase">
                    <div class="showcase-rt-top">
                        <div class="pull-left shoe-name">
                            <%--                </ItemTemplate>
                         </asp:Repeater>--%>
                        <h3><asp:Label ID="lblProductName" runat="server" Text=""></asp:Label></h3>
                        <p>
                            <asp:Label ID="lblProductNo" runat="server" Text=""></asp:Label>&nbsp;
                            (<asp:Label ID="lblProductID" runat="server" Text=""></asp:Label>)
						</p>
                            <%--                                <a class="btn" href="#" role="button">Buy Now</a>--%>
                            <h4>&#36;<asp:Label ID="lblPrice" runat="server" Text=""></asp:Label></h4>
            <%--                </ItemTemplate>
                         </asp:Repeater>--%>
                        </div>
                        <div class="pull-left rating-stars">
                            <ul>
    <li><a href="#" class="active"><span class="glyphicon glyphicon-star star-stn" aria-hidden="true"></span></a></li>
    <li><a href="#" class="active"><span class="glyphicon glyphicon-star star-stn" aria-hidden="true"></span></a></li>
    <li><a href="#" class="active"><span class="glyphicon glyphicon-star star-stn" aria-hidden="true"></span></a></li>
    <li><a href="#"><span class="glyphicon glyphicon-star star-stn" aria-hidden="true"></span></a></li>
    <li><a href="#"><span class="glyphicon glyphicon-star star-stn" aria-hidden="true"></span></a></li>
                            </ul>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <hr class="featurette-divider">
                    <div class="shocase-rt-bot">
                        <div class="float-qty-chart">
                        <ul>
                           <li class="qty">
                                <h4>QTY</h4>
                                <asp:TextBox ID="tbQuantity" runat="server" Text ="1"></asp:TextBox>                         
                            </li>
                        </ul>
                        <div class="clearfix"></div>
                        </div>
                        <ul>
                            <li class="ad-2-crt simpleCart_shelfItem">
                                <asp:Button ID="btnAddToCart" runat="server" cssclass="btn item_add" Text="Add to Cart" />
<%--                                <a class="btn" href="#" role="button">Buy Now</a>--%>
                                <asp:Label ID="lblIncorrectFormat" runat="server" ForeColor="Red" Text="Incorrect Number Format" Visible="False"></asp:Label>
                            </li>
                        </ul>
                    </div>
                    <div class="showcase-last">
                        <h3>product details</h3>
                        <ul>
                            <li>Internal bootie wraps your foot for a sock-like fit</li>
        <li>Unique eyestays work with the Flywire cables to create an even better glove-like fit</li>
                            <li>Waffle outsole for durability and multi-surface traction</li>
        <li>Sculpted Cushlon midsole combines plush cushioning and springy resilience for impact protection</li>
                            <li>Midsole flex grooves for greater forefoot flexibility</li>
                        </ul>
                    </div>
                </div>
        <div class="clearfix"></div>
            </div>
        </div>
        
        <div class="specifications">
            <div class="container">
              <h3>Item Details</h3> 
                <div class="detai-tabs">
                    <!-- Nav tabs -->
                    <ul class="nav nav-pills tab-nike" role="tablist">
                    <li role="presentation" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Highlights</a></li>
                    <li role="presentation"><a href="#profile" aria-controls="profile" role="tab" data-toggle="tab">Description</a></li>
                    <li role="presentation"><a href="#messages" aria-controls="messages" role="tab" data-toggle="tab">Terms & conditiona</a></li>
                    </ul>

                    <!-- Tab panes -->
                    <div class="tab-content">
                    <div role="tabpanel" class="tab-pane active" id="home">
                    <p>The full-length Max Air unit delivers excellent cushioning with enhanced flexibility for smoother transitions through footstrike.</p> 
                    <p>Dynamic Flywire cables integrate with the laces and wrap your midfoot for a truly adaptive, supportive fit.</p>
                    </div>
                    <div role="tabpanel" class="tab-pane" id="profile">
                    <p>Nike is one of the leading manufacturer and supplier of sports equipment, footwear and apparels. Nike is a global brand and it continuously creates products using high technology and design innovation. Nike has a vast collection of sports shoes for men at Snapdeal. You can explore our range of basketball shoes, football shoes, cricket shoes, tennis shoes, running shoes, daily shoes or lifestyle shoes. Take your pick from an array of sports shoes in vibrant colours like red, yellow, green, blue, brown, black, grey, olive, pink, beige and white. Designed for top performance, these shoes match the way you play or run. Available in materials like leather, canvas, suede leather, faux leather, mesh etc, these shoes are lightweight, comfortable, sturdy and extremely sporty. The sole of all Nike shoes is designed to provide an increased amount of comfort and the material is good enough to provide an improved fit. These shoes are easy to maintain and last for a really long time given to their durability. Buy Nike shoes for men online with us at some unbelievable discounts and great prices. So get faster and run farther with your Nike shoes and track how hard you can play.</p>    
                    </div>
                    <div role="tabpanel" class="tab-pane" id="messages">
                        The images represent actual product though color of the image and product may slightly differ.    
                    </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>

