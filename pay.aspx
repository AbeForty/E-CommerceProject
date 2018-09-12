<%@ Page Language="VB" AutoEventWireup="false" CodeFile="pay.aspx.vb" Inherits="paycard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>N-GAME a E-commerce category Flat Bootstrap Responsive Website Template | Home :: w3layouts</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="N-Air Responsive web template, Bootstrap Web Templates, Flat Web Templates, Andriod Compatible web template, Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyErricsson, Motorola web design" />
    <script type="application/x-javascript"> addEventListener("load", function() {setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <meta charset utf="8">
    <!--fonts-->
    <link href='//fonts.googleapis.com/css?family=Fredoka+One' rel='stylesheet' type='text/css'>

    <!--fonts-->
    <!--bootstrap-->
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css">
    <!--coustom css-->
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <!--shop-kart-js-->
    <script src="js/simpleCart.min.js"></script>
    <!--default-js-->
    <script src="js/jquery-2.1.4.min.js"></script>
    <!--bootstrap-js-->
    <script src="js/bootstrap.min.js"></script>
    <!--script-->
</head>
<body>
    <div>
        <div class="header">
            <div class="container">
                <div class="header-top">
                    <div class="logo">
                        <a href="index.aspx">N-GAME</a>
                    </div>
                </div>
                <!--header-bottom-->
            </div>
        </div>
 <div id="paymentForm" style="margin-left: auto; margin-right:auto; width:1200px; text-align:center;">
        <p style="font-size: x-large"><strong>Please click "Pay with Card" and enter your payment information to continue.</strong></p>
        <form action="Charge.aspx" method="POST" runat ="server">
            <script
                src="https://checkout.stripe.com/checkout.js" class="stripe-button"
                data-key="<%= stripePublishableKey %>"
                data-amount="<%= amountTotal %>"
                data-name="N-GAME"
                data-description="Order Number: <%= strCartID %>"
                data-email="<%= email%>"
                data-locale="auto"
                data-zip-code="false">
            </script>
        </form>
    </div>
        <footer id="footer">
            <!--Footer-->
            <div class="footer-grid">
                <div class="container">

                    <%--    <div class="col-md-6 re-ft-grd">
                            <h3>Short links</h3>
                            <ul class="short-links">
                                <li><a href="contactus.aspx">Contact Us</a></li>
                                <li><a href="support.aspx">Support</a></li>
                                <li><a href="aboutus.aspx">About Us</a></li>
                            </ul>
                        </div>--%>
                    <div class="clearfix"></div>
                </div>
                <div class="copy-rt">
                    <div class="container">
                        <p>&copy;   2017 N-GAME All Rights Reserved. Based on N-AIR design by <a href="http://www.w3layouts.com">w3layouts</a></p>
                    </div>
                </div>
            </div>
        </footer>
</body>
</html>
