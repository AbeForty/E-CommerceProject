﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="errorpage.aspx.vb" Inherits="errorpage" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>N-GAME: Social E-Commerce Site for Gamers</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="N-GAME, Games, Social E-Commerce" />
    <script type="application/x-javascript"> addEventListener("load", function() {setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
<%--    <meta charset utf="8">--%>
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
    <form id="form1" runat="server">
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
            <section>
                <div id="errorDiv" style="margin-left: auto; margin-right: auto; max-width: 1200px; text-align: center;">
                    <p style="text-align: center; font-size: 20pt;">I feel sorry for you, really, you're not even in the right place. </p>
                    <p style="text-align: center; font-size: 20pt; font-weight:bold">- GLaDOS</p>
                    <a class="order" href="index.aspx">Return to Homepage</a>
                </div>
            </section>
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
        </div>
    </form>
</body>
</html>
