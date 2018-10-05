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

        .txtInfo {
            width: 100%;
        }
        .marginCenter{
            margin-left:auto;
            margin-right:auto;     
        }
        .textCenter{
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:SqlDataSource ID="DSCheckoutDetails" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>" SelectCommand="SELECT * FROM ADDRESSINFO WHERE UserID = @userID">
        <SelectParameters>
            <asp:SessionParameter Name="userID" SessionField="user_id" />
        </SelectParameters>
    </asp:SqlDataSource>
    <table style="max-width: 550px; margin-left: auto; margin-right: auto;"class="textCenter">
        <tr>
            <td>
                <%--            </div>--%>

                <div class="price-details">
                    <h3>Price Details</h3>
                    <table>
                        <tr>
                            <td>
                                <div>Subtotal:&nbsp&nbsp</div>
                            </td>
                            <td>
                                <asp:Label ID="lblSubtotal" runat="server" Text='<%#Eval("Subtotal")%>' CssClass="total1"></asp:Label>
                                <%--            </div>--%>
                                <%--                    <span class="total1">10%(Festival Offer)</span>--%>
                            </td>
                            <td>
                                <div>&nbsp Shipping:&nbsp&nbsp</div>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblShippingCost" Text="0.00" CssClass="total1" />
                            </td>
                            <td>
                                <div>&nbsp Tax:&nbsp&nbsp</div>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblTax" Text="" CssClass="total1" />
                            </td>
                            <td>
                                <div class="clearfix"></div>
                            </td>
                        </tr>
                    </table>
                </div>
                <hr class="featurette-divider">
                <ul class="total_price textCenter">
                    <li class="last_price">
                        <h4>TOTAL</h4>
                    </li>
                    <li class="last_price"><span>
                        <asp:Label runat="server" ID="lblTotal" /></span></li>
                    <div class="clearfix"></div>
                </ul>
                <br />
                <%--            </div>--%>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblSavedAddress" runat="server" Text="Choose a previously saved address: "></asp:Label>
                <br />
                <asp:DropDownList ID="ddlAddressInfo" runat="server" DataSourceID="DSCheckoutDetails" DataTextField="BillingStreet" DataValueField="Id" Height="45px" Width="100%" AppendDataBoundItems="True" AutoPostBack="True">
                    <asp:ListItem>Manually type info</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <div class="orderform">
                    <table style="width:100%;">
                        <tr>
                            <td>
                                <asp:Label ID="lblBillingInfo" runat="server" Text="Billing Information " Font-Bold="True"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBillingFirstName" runat="server" Text="First Name "></asp:Label></td>
                        </tr>
                        <tr>
                            <td><span>
                                <asp:TextBox ID="txtBillingFirstName" runat="server" Width="100%"></asp:TextBox></span></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBillingFirstNameError" runat="server" ForeColor="Red" Text="First Name is invalid or empty" Visible="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBillingLastName" runat="server" Text="Last Name "></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtBillingLastName" runat="server" Width="100%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBillingLastNameError" runat="server" ForeColor="Red" Text="Last Name is invalid or empty" Visible="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBillingStreet" runat="server" Text="Street "></asp:Label></td>
                        </tr>
                        <tr>
                            <td><span>
                                <asp:TextBox ID="txtBillingStreet" runat="server" Width="100%"></asp:TextBox></span></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBillingStreetError" runat="server" ForeColor="Red" Text="Street is invalid or empty" Visible="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBillingCity" runat="server" Text="City "></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtBillingCity" runat="server" Width="100%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBillingCityError" runat="server" ForeColor="Red" Text="City is invalid or empty" Visible="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBillingState" runat="server" Text="State "></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlBillingState" runat="server" DataSourceID="DSStates" DataTextField="StateName" CssClass="txtInfo">
                                </asp:DropDownList></td>
                            <asp:SqlDataSource ID="DSStatesBilling" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>" SelectCommand="SELECT [StateName] FROM [States]"></asp:SqlDataSource>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBillingZip" runat="server" Text="Zip Code "></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtBillingZip" runat="server" Width="100%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBillingZipError" runat="server" ForeColor="Red" Text="Zip Code is invalid or empty" Visible="False"></asp:Label></td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="orderform">
                    <table  style="width:100%;">
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
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtFirstName" runat="server" Width="100%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblFirstNameError" runat="server" ForeColor="Red" Text="First Name is invalid or empty" Visible="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtLastName" runat="server" Width="100%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblLastNameError" runat="server" ForeColor="Red" Text="Last Name is invalid or empty" Visible="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblStreet" runat="server" Text="Street"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtStreet" runat="server" Width="100%"></asp:TextBox></td>
                            <tr>
                                <td>
                                    <asp:Label ID="lblStreetError" runat="server" ForeColor="Red" Text="Street is invalid or empty" Visible="False"></asp:Label></td>
                            </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtCity" runat="server" Width="100%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCityError" runat="server" ForeColor="Red" Text="City is invalid or empty" Visible="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblState" runat="server" Text="State"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlState" runat="server" DataSourceID="DSStates" DataTextField="StateName" CssClass="txtInfo">
                                </asp:DropDownList></td>
                            <td>
                                <asp:SqlDataSource ID="DSStates" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>" SelectCommand="SELECT [StateName] FROM [States]"></asp:SqlDataSource>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblZip" runat="server" Text="Zip Code"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtZip" runat="server" Width="100%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblZipCodeError" runat="server" ForeColor="Red" Text="Zip Code is invalid or empty" Visible="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPhone" runat="server" Text="Phone Number"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtPhone" runat="server" Width="100%"></asp:TextBox></td>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPhoneNumberError" runat="server" ForeColor="Red" Text="Phone Number is invalid or empty" Visible="False"></asp:Label></td>
                            </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblEmail" runat="server" Text="Email Address" Visible="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" Enabled="False" Visible="False" Width="100%"></asp:TextBox></td>
                            <td>
                        </tr>
                        <tr>
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
            <td>
                <asp:Label ID="lblCheckoutError" runat="server" ForeColor="Red" Text="We were unable to process your order. Please try again later." Visible="False"></asp:Label>
                <asp:LinkButton ID="btnCheckout" runat="server" Text="Checkout" CssClass="order" /></td>
        </tr>
    </table>
</asp:Content>


