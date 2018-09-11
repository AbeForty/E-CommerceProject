<%@ Page Title="" Language="VB" MasterPageFile="~/OnlineStore.master" AutoEventWireup="false" CodeFile="checkout.aspx.vb" Inherits="checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 300px;
            height: 21px;
        }
        .auto-style2 {
            height: 38px;
        }
        .auto-style3 {
            width: 25px;
            height: 38px;
        }
        .auto-style4 {
            width: 244px
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 1500px; margin-left: auto; margin-right: auto;">
        <tr>
            <td class="auto-style4" rowspan="2">
                <%--            </div>--%>
            
                <div class="price-details">
                    <h3>Price Details</h3>
                    <table>
                        <tr>
                            <td>
                                <div>Subtotal</div>
                                <span class="total1">
                                     <asp:SqlDataSource ID="DSCheckoutDetails" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>" SelectCommand="SELECT * FROM ADDRESSINFO WHERE UserID = @userID">
                                         <SelectParameters>
                                             <asp:SessionParameter Name="userID" SessionField="user_id" />
                                         </SelectParameters>
                                </asp:SqlDataSource>
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
            <td class="auto-style2">    
                <asp:Label ID="lblSavedAddress" runat="server" Text="Choose a previously saved address: "></asp:Label>
                <asp:DropDownList ID="ddlAddressInfo" runat="server" DataSourceID="DSCheckoutDetails" DataTextField="BillingStreet" DataValueField="Id" Height="45px" Width="469px" AppendDataBoundItems="True" AutoPostBack="True">
                    <asp:ListItem>Manually type info</asp:ListItem>
                </asp:DropDownList>
            </td> 
            <td class="auto-style3"></td>
            <td class="auto-style2">
            </td>
        </tr>
        <tr>
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
                <asp:TextBox ID="txtEmail" runat="server" Enabled="False"></asp:TextBox></td>
            <td>
                <asp:Label ID="lblEmailError" runat="server" ForeColor="Red" Text="Email Address is invalid or empty" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:CheckBox ID="chkSaveInfo" runat="server" Text="Save address info for future use" />
            </td>
        </tr>
              </table>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblCheckoutError" runat="server" ForeColor="Red" Text="We were unable to process your order. Please try again later." Visible="False"></asp:Label>
                <asp:LinkButton ID="btnCheckout" runat="server" Text="Checkout" CssClass="order" /></td>
        </tr>
    </table>
</asp:Content>


