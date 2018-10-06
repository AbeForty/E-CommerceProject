<%@ Page Title="" Language="VB" MasterPageFile="~/OnlineStore.master" AutoEventWireup="false" CodeFile="details.aspx.vb" Inherits="details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- FlexSlider -->
    <script src="js/imagezoom.js"></script>
    <script defer src="js/jquery.flexslider.js"></script>
    <link rel="stylesheet" href="css/flexslider.css" type="text/css" media="screen" />

    <script>
        // Can also be used with $(document).ready()
        $(window).load(function () {
            $('.flexslider').flexslider({
                animation: "slide",
                controlNav: "thumbnails"
            });
        });
    </script>
    <!-- //FlexSlider-->
    <script src="js/rating.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="head-bread">
        <div class="container">
            <ol class="breadcrumb">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="products.aspx">Products</a></li>
                <li>
                    <asp:Label ID="lblBC2" runat="server"></asp:Label>
                </li>
                <li>
                    <asp:Label ID="lblBC1" runat="server"></asp:Label></li>
                <li>
                    <asp:Label ID="lblBC3" runat="server"></asp:Label></li>
            </ol>
            <asp:SqlDataSource ID="DSPlatform" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>" ProviderName="<%$ ConnectionStrings:OnlineStoreConnectionString.ProviderName %>" SelectCommand="SELECT * FROM Products, [Platform] WHERE Products.PlatformID = [Platform].Id and Products.ProductName = (SELECT ProductName from Products Where ProductID = @productID)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lblProductID" Name="productID" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </div>
    <div class="showcase-grid">
        <div class="container">
            <div class="col-md-12 showcase">
                <div class="flexslider">
                    <ul class="slides">
                        <li data-thumb="images/show.jpg">
                            <div class="thumb-image">
                                <asp:Image ID="imgProduct" runat="server" CssClass="img-detail" />
                            </div>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="col-md-6 showcase">
                   <%-- <table style="width: 100%">
                        <tr>
                            <td style="width: 50%;">--%>
                                <div class="showcase-last shoe-name" style="width:100%">
                                    <h3>
                                        <asp:Label ID="lblProductName" runat="server" Text=""></asp:Label></h3>
                                    <h4>&#36;<asp:Label ID="lblPrice" runat="server" Text=""></asp:Label></h4>
                                    <div class="rating-stars">
                                        <ul>
                                            <li><span runat="server" id="starOneActive" style="color: #fb4c29;" class="glyphicon glyphicon-star star-stn ratingStar noClick" aria-hidden="true"></span></li>
                                            <li><span runat="server" id="starTwoActive" style="color: #fb4c29;" class="glyphicon glyphicon-star star-stn ratingStar noClick" aria-hidden="true"></span></li>
                                            <li><span runat="server" id="starThreeActive" style="color: #fb4c29;" class="glyphicon glyphicon-star star-stn ratingStar noClick" aria-hidden="true"></span></li>
                                            <li><span runat="server" id="starFourActive" style="color: #fb4c29;" class="glyphicon glyphicon-star star-stn ratingStar noClick" aria-hidden="true"></span></li>
                                            <li><span runat="server" id="starFiveActive" style="color: #fb4c29;" class="glyphicon glyphicon-star star-stn ratingStar noClick" aria-hidden="true"></span></li>
                                            <li><span runat="server" id="starOneInactive" style="color: #716969;" class="glyphicon glyphicon-star star-stn ratingStar noClick" aria-hidden="true"></span></li>
                                            <li><span runat="server" id="starTwoInactive" style="color: #716969;" class="glyphicon glyphicon-star star-stn ratingStar noClick" aria-hidden="true"></span></li>
                                            <li><span runat="server" id="starThreeInactive" style="color: #716969;" class="glyphicon glyphicon-star star-stn ratingStar noClick" aria-hidden="true"></span></li>
                                            <li><span runat="server" id="starFourInactive" style="color: #716969;" class="glyphicon glyphicon-star star-stn ratingStar noClick" aria-hidden="true"></span></li>
                                            <li><span runat="server" id="starFiveInactive" style="color: #716969;" class="glyphicon glyphicon-star star-stn ratingStar noClick" aria-hidden="true"></span></li>
                                            <li><span runat="server" id="numReviewsTop"></span></li>
                                        </ul>
                                    </div>
                                    <p>
                                        <asp:Label ID="lblProductNo" runat="server" Visible="False"></asp:Label>
                                        (<asp:Label ID="lblProductID" runat="server" Text=""></asp:Label>)
						        <asp:Label ID="lblSeller" runat="server"></asp:Label>
                                    </p>
                                    <p>
                                        Release Date: 
                            <asp:Label ID="lblReleaseDate" runat="server"></asp:Label>
                                    </p>
                                    <p>
                                        Developer:
                                <asp:Label ID="lblDeveloper" runat="server" Text="Developer"></asp:Label>
                                        </p>
                                    <p>
                                        Publisher:
                                <asp:Label ID="lblPublisher" runat="server" Text="Publisher"></asp:Label>
                                    </p>
                                    <br />
                                    <p>
                                        <asp:Image ID="imgGameRating" runat="server" Height="65px" Width="46px" />
                                        <asp:Label ID="lblGameRating" runat="server" Text="Game Rating"></asp:Label>
                                    </p>
                                    <br />
                                    </div>
                        <table class="shocase-rt-bot" style="width:100%">
                            <tr>
                                <td style="width:50%">
                                    <div class="qty" id="listItemPlatform">
                                        <h3 style="margin-bottom: 5px;">Platform</h3>
                                        <asp:DropDownList ID="ddlPlatform" runat="server" AutoPostBack="True" DataSourceID="DSPlatform" DataTextField="Name" DataValueField="ProductID" Width="100%" Height="25px"></asp:DropDownList>
                                    </div>
                                </td>
                                <td>&nbsp&nbsp</td>
                                <td style="width:50%">
                                    <div class="qty"  id="listItemQuantity">
                                        <h3 style="margin-bottom: 5px;">Quantity</h3>
                                        <asp:TextBox ID="tbQuantity" runat="server" Text="1" Height="25px" Width="100%" TextMode="Number"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                        </table>
                                <ul>
                                    <li class="ad-2-crt simpleCart_shelfItem">
                                        <asp:Label ID="lblSellerError" runat="server" ForeColor="Red" Text="You cannot purchase your own item." Visible="False"></asp:Label>
                                        <asp:Button ID="btnAddToCart" runat="server" CssClass="continue" Width="100%" Text="ADD TO CART" />           
                                        <asp:Label ID="lblIncorrectFormat" runat="server" ForeColor="Red" Text="Incorrect Number Format" Visible="False"></asp:Label>
                                    </li>
                                </ul>
<%--                                </div>--%>
<%--                            </td>--%>
<%--                            <td style="width: 50%;">--%>
             
<%--                            </td>
                        </tr>
                    </table>--%>
                </div>
    <div class="col-md-6 showcase showcase-last">
                        <h3>product details</h3>
                        <ul>
                            <li>
                                <asp:Label ID="lblDescription" runat="server" Text="Product Description"></asp:Label></li>
                        </ul>
                    </div>
            </div>
        </div>
    </div>

    <div class="col-md-12 specifications">
        <div class="container">
            <h3 runat="server" id="lblRatings"></h3>
            <p style="font-size:12pt;">Leave a rating and review. You can only leave a rating and review if you have purchased the product. Reviews can only be altered or deleted by you.</p>
            <br />
            <div class="rating-stars" style="padding: 0px !important; width: 300px;">
                <ul>
                    <li style="font-size:12pt;">Rating: </li>
                    <li><a runat="server" style="text-decoration: none; color: #716969;" class="glyphicon glyphicon-star star-stn ratingStar" aria-hidden="true" id="starOneRating"></a></li>
                    <li><a runat="server" style="text-decoration: none; color: #716969;" class="glyphicon glyphicon-star star-stn ratingStar" aria-hidden="true" id="starTwoRating"></a></li>
                    <li><a runat="server" style="text-decoration: none; color: #716969;" class="glyphicon glyphicon-star star-stn ratingStar" aria-hidden="true" id="starThreeRating"></a></li>
                    <li><a runat="server" style="text-decoration: none; color: #716969;" class="glyphicon glyphicon-star star-stn ratingStar" aria-hidden="true" id="starFourRating"></a></li>
                    <li><a runat="server" style="text-decoration: none; color: #716969;" class="glyphicon glyphicon-star star-stn ratingStar" aria-hidden="true" id="starFiveRating"></a></li>
                </ul>
            </div>
            <asp:HiddenField ID="hdFieldRating" runat="server" />
            <div class="clearfix"></div>
            <br />
            <asp:Label ID="lblReviewError" runat="server" ForeColor="Red" Text="Error" Visible="False"></asp:Label>
            <asp:TextBox ID="txtReview" runat="server" TextMode="MultiLine" Height="88px"></asp:TextBox>
            <asp:LinkButton ID="btnReview" CssClass="order" runat="server" Text="Submit Review"></asp:LinkButton>
            <div id="reviewSection">
                <asp:SqlDataSource ID="DSReviews" runat="server" SelectCommand="SELECT [Rating].Id, [Rating].UserID, [Rating].Review,[Rating].Rating, [Rating].CreatedAt, [Rating].UpdatedAt, [Users].Name FROM [Rating], [Users] Where [Rating].UserID = [Users].Id and ProductID = @productID" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>" ProviderName="<%$ ConnectionStrings:OnlineStoreConnectionString.ProviderName %>">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="lblProductID" Name="productID" PropertyName="Text" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:DataList ID="dlReviews" runat="server" DataSourceID="DSReviews" RepeatDirection="Vertical" RepeatColumns="1">
                    <ItemTemplate>
                        <div class="review">
                            <asp:HiddenField ID="hdFieldReview" runat="server" Value='<%# Trim(Eval("Id")) %>' />
                            <%--                                <span>Rating: </span>--%>
                            <span class="rating-stars">
                                <ul style="width: 25s0px;">
                                    <li>Rating: </li>
                                    <li><span runat="server" style="color: #fb4c29;" class="glyphicon glyphicon-star star-stn ratingStar" aria-hidden="true" visible='<%# Eval("Rating") >= 1 %>'></span></li>
                                    <li><span runat="server" style="color: #fb4c29;" class="glyphicon glyphicon-star star-stn ratingStar" aria-hidden="true" visible='<%# Eval("Rating") >= 2 %>'></span></li>
                                    <li><span runat="server" style="color: #fb4c29;" class="glyphicon glyphicon-star star-stn ratingStar" aria-hidden="true" visible='<%# Eval("Rating") >= 3 %>'></span></li>
                                    <li><span runat="server" style="color: #fb4c29;" class="glyphicon glyphicon-star star-stn ratingStar" aria-hidden="true" visible='<%# Eval("Rating") >= 4 %>'></span></li>
                                    <li><span runat="server" style="color: #fb4c29;" class="glyphicon glyphicon-star star-stn ratingStar" aria-hidden="true" visible='<%# Eval("Rating") = 5 %>'></span></li>
                                    <li><span runat="server" style="color: #716969;" class="glyphicon glyphicon-star star-stn ratingStar" aria-hidden="true" visible='<%# Eval("Rating") = 0 %>'></span></li>
                                    <li><span runat="server" style="color: #716969;" class="glyphicon glyphicon-star star-stn ratingStar" aria-hidden="true" visible='<%# Eval("Rating") = 1 %>'></span></li>
                                    <li><span runat="server" style="color: #716969;" class="glyphicon glyphicon-star star-stn ratingStar" aria-hidden="true" visible='<%# Eval("Rating") = 2 %>'></span></li>
                                    <li><span runat="server" style="color: #716969;" class="glyphicon glyphicon-star star-stn ratingStar" aria-hidden="true" visible='<%# Eval("Rating") = 3 %>'></span></li>
                                    <li><span runat="server" style="color: #716969;" class="glyphicon glyphicon-star star-stn ratingStar" aria-hidden="true" visible='<%# Eval("Rating") = 4 %>'></span></li>
                                </ul>
                            </span>
                            <%--                                <asp:Label ID="lblRating" runat="server" Text=<%# Eval("Rating")%>></asp:Label>--%>
                            <asp:Label ID="reviewText" runat="server" Text='<%# Eval("Review")%>'></asp:Label>
                            <br />
                            <div class="reviewCommands">
                                <asp:Label ID="lblReviewerName" runat="server" CssClass="boldFont" Text='<%# Eval("Name")%>'></asp:Label>
                                -
                                   <asp:Label ID="lblReviewDate" runat="server" Text='<%#Eval("UpdatedAt", "{0:M/dd/yyyy}")%>'></asp:Label>
                                <asp:LinkButton ID="btnEdit" CommandName="EditReview" CommandArgument='<%# Eval("Id") %>' runat="server" Text="Edit" Visible='<%# Eval("UserID") = Session("user_id")%>'></asp:LinkButton>
                                <asp:LinkButton ID="btnDelete" CommandName="DeleteReview" CommandArgument='<%# Eval("Id") %>' runat="server" Text="Delete" Visible='<%#Eval("UserID") = Session("user_id")%>'></asp:LinkButton>
                            </div>
                        </div>
                        <hr />
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <%--     <div class="detai-tabs">
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
                </div>--%>
        </div>
    </div>
</asp:Content>

