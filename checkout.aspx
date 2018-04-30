<%@ Page Title="" Language="VB" MasterPageFile="~/OnlineStore.master" AutoEventWireup="false" CodeFile="checkout.aspx.vb" Inherits="checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td style="width: 300px">
                <%--                    <span class="total1">10%(Festival Offer)</span>--%>
            
                <div class="price-details">
                    <h3>Price Details</h3>
                    <table>
                        <tr>
                            <td>
                                <div>Subtotal</div>
                                <span class="total1">
                                     <asp:SqlDataSource ID="DSCheckoutDetails" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>"></asp:SqlDataSource>
                               <asp:Label ID="lblSubtotal" runat="server" Text=<%#Eval("Subtotal")%>></asp:label></span>
                                
                                <%--            </div>--%>
                                <%--                    <span class="total1">10%(Festival Offer)</span>--%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div>Shipping &nbsp &nbsp</div>
                                </td>
                                <td>
                                <span class="total1">
                                    <asp:Label runat="server" ID="lblShippingCost" Text="0.00" /></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div>Tax</div>
                                </td>
                            <td>
                                    <span class="total1">
                                    <asp:Label runat="server" ID="lblTax" Text="" /></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="clearfix"></div>
                            </td>
                        </tr>
                    </table>
                </div>
                <hr class="featurette-divider">
                <ul class="total_price">
                    <li class="last_price">
                        <h4>TOTAL</h4>
                    </li>
                    <li class="last_price"><span>
                        <asp:Label runat="server" ID="lblTotal" /></span></li>
                    <div class="clearfix"></div>
                </ul>
                <%--            </div>--%>
            </td>    
            <td>    
                <div class="orderform">  
                    <table>
                        <tr>
                        <td><asp:Label ID="lblBillingInfo" runat="server" Text="Billing Information" Font-Bold="True"></asp:Label></td>
                     </tr>   
                     <tr>
                        <td><asp:Label ID="lblBillingFirstName" runat="server" Text="First Name "></asp:Label></td>
                        <td><span><asp:TextBox ID="txtBillingFirstName" runat="server"></asp:TextBox></span></td>
                       <td class="auto-style1"> <asp:Label ID="lblBillingFirstNameError" runat="server" ForeColor="Red" Text="First Name is invalid or empty" Visible="False"></asp:Label></td>
                      </tr>
                    <tr>
                       <td> <asp:Label ID="lblBillingLastName" runat="server" Text="Last Name "></asp:Label></td>
                        <td><span><asp:TextBox ID="txtBillingLastName" runat="server"></asp:TextBox></span></td>
                       <td class="auto-style1"> <asp:Label ID="lblBillingLastNameError" runat="server" ForeColor="Red" Text="Last Name is invalid or empty" Visible="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblBillingStreet" runat="server" Text="Street "></asp:Label></td>
                        <td><span><asp:TextBox ID="txtBillingStreet" runat="server"></asp:TextBox></span></td>
                       <td class="auto-style1"> <asp:Label ID="lblBillingStreetError" runat="server" ForeColor="Red" Text="Street is invalid or empty" Visible="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblBillingCity" runat="server" Text="City "></asp:Label></td>
                        <td><asp:TextBox ID="txtBillingCity" runat="server"></asp:TextBox></td>
                        <td class="auto-style1"><asp:Label ID="lblBillingCityError" runat="server" ForeColor="Red" Text="City is invalid or empty" Visible="False"></asp:Label></td>
                    </tr>
                    <tr>
                       <td> <asp:Label ID="lblBillingState" runat="server" Text="State "></asp:Label></td>
                       <td> <asp:DropDownList ID="ddlBillingState" runat="server" DataSourceID="DSStates" DataTextField="StateName" Height="21px" Width="140px">
                        </asp:DropDownList></td>
                        <asp:SqlDataSource ID="DSStatesBilling" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>" SelectCommand="SELECT [StateName] FROM [States]"></asp:SqlDataSource>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblBillingZip" runat="server" Text="Zip Code "></asp:Label></td>
                        <td><asp:TextBox ID="txtBillingZip" runat="server"></asp:TextBox></td>
                       <td class="auto-style1"> <asp:Label ID="lblBillingZipError" runat="server" ForeColor="Red" Text="Zip Code is invalid or empty" Visible="False"></asp:Label></td>
                    </tr>
                    </table>
                    <div>
                    </div>
                </div>
            </td> 
            <td style="width: 25px"></td>
            <td>
        <div class="orderform">
            <table>
                <tr>
                    <td>
                        <asp:CheckBox ID="chkSameAsBilling" runat="server" Text="Same as Billing Info" AutoPostBack="True"></asp:CheckBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPersonalInformation" runat="server" Text="Shipping Information" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
            <td>
                <asp:Label ID="lblFirstNameError" runat="server" ForeColor="Red" Text="First Name is invalid or empty" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
            <td>
                <asp:Label ID="lblLastNameError" runat="server" ForeColor="Red" Text="Last Name is invalid or empty" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblStreet" runat="server" Text="Street"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox></td>
            <td>
                <asp:Label ID="lblStreetError" runat="server" ForeColor="Red" Text="Street is invalid or empty" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox></td>
            <td>
                <asp:Label ID="lblCityError" runat="server" ForeColor="Red" Text="City is invalid or empty" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblState" runat="server" Text="State"></asp:Label></td>
            <td>
        <asp:DropDownList ID="ddlState" runat="server" DataSourceID="DSStates" DataTextField="StateName" Width="141px">                    
                </asp:DropDownList></td>
            <td>
                <asp:SqlDataSource ID="DSStates" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>" SelectCommand="SELECT [StateName] FROM [States]"></asp:SqlDataSource>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblZip" runat="server" Text="Zip Code"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtZip" runat="server"></asp:TextBox></td>
            <td>
                <asp:Label ID="lblZipCodeError" runat="server" ForeColor="Red" Text="Zip Code is invalid or empty" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPhone" runat="server" Text="Phone Number"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
            <td>
                <asp:Label ID="lblPhoneNumberError" runat="server" ForeColor="Red" Text="Phone Number is invalid or empty" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEmail" runat="server" Text="Email Address"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
            <td>
                <asp:Label ID="lblEmailError" runat="server" ForeColor="Red" Text="Email Address is invalid or empty" Visible="False"></asp:Label></td>
        </tr>
              </table>
                </div>
            </td>
                   <td style="width: 25px"></td>
            <td>
                <div class="creditCardInfo">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblCreditCardInfo" runat="server" Text="Credit Card Info" Font-Bold="True"></asp:Label></td>
                              <td style="width: 25px"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCreditCardNumber" runat="server" Text="Credit Card Number"></asp:Label></td>
                              <td style="width: 25px"></td>
                            <td>
                                <asp:TextBox ID="txtCreditCardNumber" runat="server" Width="173px"></asp:TextBox></td>
                            <td>
                                <asp:Label ID="lblCreditNumberError" runat="server" ForeColor="Red" Text="Credit Card Number is invalid or empty" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCreditCardType" runat="server" Text="Credit Card Type"></asp:Label></td>
              <td style="width: 25px"></td>
            <td>
                <asp:DropDownList ID="ddlCreditCardType" runat="server" Height="23px" Width="172px">
                    <asp:ListItem>American Express</asp:ListItem>
                    <asp:ListItem>MasterCard</asp:ListItem>
                    <asp:ListItem>Visa</asp:ListItem>
                    <asp:ListItem>Discover</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblExpiration" runat="server" Text="Expiration"></asp:Label>
                  <td style="width: 25px"></td>
                </td>
                <td><asp:Label ID="lblCreditCardExpMonth" runat="server" Text="Month"></asp:Label>
                <asp:DropDownList ID="ddlCreditCardExpMonth" runat="server">
                    <asp:ListItem>01</asp:ListItem>
                    <asp:ListItem>02</asp:ListItem>
                    <asp:ListItem>03</asp:ListItem>
                    <asp:ListItem>04</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>06</asp:ListItem>
                    <asp:ListItem>07</asp:ListItem>
                    <asp:ListItem>08</asp:ListItem>
                    <asp:ListItem>09</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="lblCreditCardExpYear" runat="server" Text="Year"></asp:Label>
                <asp:DropDownList ID="ddlCreditCardExpYear" runat="server"></asp:DropDownList></td>
        </tr>
    </table>
                </div>
            </td>
        </tr>
    </table>
    <div>
        <asp:LinkButton ID="btnCheckout" runat="server" Text="Checkout" CssClass="order" />
    </div>

</asp:Content>


