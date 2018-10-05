<%@ Page Title="" Language="VB" MasterPageFile="~/OnlineStore.master" AutoEventWireup="false" CodeFile="sell.aspx.vb" Inherits="sell" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            margin-bottom: 0;
        }

        .auto-style2 {
            margin-top: 6px;
            resize: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--    <div id="sellForm" style="width: 1500px; margin-left: auto; margin-right: auto;">--%>
    <div id="sellFormInner" style="max-width: 500px; margin-left: auto; margin-right: auto;">
        <p style="text-align: center; font-size: 15pt;">
            <asp:SqlDataSource ID="dsCategory" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>" ProviderName="<%$ ConnectionStrings:OnlineStoreConnectionString.ProviderName %>" SelectCommand="SELECT * FROM CATEGORY WHERE PARENT = 0"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsSubcategory" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>" ProviderName="<%$ ConnectionStrings:OnlineStoreConnectionString.ProviderName %>" SelectCommand="SELECT * FROM CATEGORY WHERE PARENT &gt; 0"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsPlatform" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>" ProviderName="<%$ ConnectionStrings:OnlineStoreConnectionString.ProviderName %>" SelectCommand="SELECT * FROM PLATFORM"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsProducts" runat="server" SelectCommand="SELECT ProductID, LTRIM(RTRIM([Products].ProductName)) +  ' (' + [Platform].ShortName + ')' as ProductPlatformName FROM [Products], [Platform] WHERE [Products].PlatformID = [Platform].Id and [Products].UserID = @userid" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>" ProviderName="<%$ ConnectionStrings:OnlineStoreConnectionString.ProviderName %>">
                <SelectParameters>
                    <asp:SessionParameter Name="userid" SessionField="user_id" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="dsDeveloper" runat="server" SelectCommand="SELECT * From Developer" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>" ProviderName="<%$ ConnectionStrings:OnlineStoreConnectionString.ProviderName %>">
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="dsGameRating" runat="server" SelectCommand="SELECT * FROM GAMERATING" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>" ProviderName="<%$ ConnectionStrings:OnlineStoreConnectionString.ProviderName %>">
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="dsPublisher" runat="server" SelectCommand="SELECT * FROM Publisher" ConnectionString="<%$ ConnectionStrings:OnlineStoreConnectionString %>" ProviderName="<%$ ConnectionStrings:OnlineStoreConnectionString.ProviderName %>">
            </asp:SqlDataSource>
            Sell a new/used game or gaming accessory today!
        </p>
        <p style="text-align:center;">Update an existing item or add a new item:</p>
        <asp:DropDownList ID="ddlProduct" runat="server" AppendDataBoundItems="True" DataSourceID="dsProducts" DataTextField="ProductPlatformName" DataValueField="ProductID" Width="99%" AutoPostBack="True">
            <asp:ListItem Selected="True">Add new item</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="lblItemName" runat="server" Text="Item Name: " Width="20%"></asp:Label>
        <asp:TextBox ID="txtItemName" runat="server" Width="99%"></asp:TextBox>
        <br />
        <asp:Label ID="lblDeveloper" runat="server" Text="Developer: " Width="20%"></asp:Label>
        <asp:DropDownList ID="ddlDeveloper" runat="server" DataSourceID="dsDeveloper" DataTextField="DeveloperName" DataValueField="Id" Width="99%">
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblDeveloperOther" runat="server" Text="Enter a new developer if it doesn't already exist."></asp:Label>
        <asp:TextBox ID="txtDeveloper" runat="server" Width="99%"></asp:TextBox>
        <br />
        <asp:Label ID="lblPublisher" runat="server" Text="Publisher: " Width="20%"></asp:Label>
        <asp:DropDownList ID="ddlPublisher" runat="server" DataSourceID="dsPublisher" DataTextField="PublisherName" DataValueField="Id" Width="99%">
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblPublisherOther" runat="server" Text="Enter a new publisher if it doesn't already exist."></asp:Label>
        <asp:TextBox ID="txtPublisher" runat="server" Width="99%"></asp:TextBox>
        <br />
        <asp:Label ID="lblGameRating" runat="server" Text="ESRB Rating: " Width="100px"></asp:Label>
        <asp:DropDownList ID="ddlGameRating" runat="server" DataSourceID="dsGameRating" DataTextField="ESRBRatingLong" DataValueField="Id" Width="99%">
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblPrice" runat="server" Text="Price:" Width="20%"></asp:Label>
        <asp:TextBox ID="txtPrice" runat="server" Width="99%"></asp:TextBox>
        <br />
        <asp:Label ID="lblCategory" runat="server" Text="Category:" Width="20%"></asp:Label>
        <asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="dsCategory" DataTextField="CategoryName" DataValueField="CategoryID" Width="99%">
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblCategoryOther" runat="server" Text="Enter a new category if it doesn't already exist."></asp:Label>
        <br />
        <asp:TextBox ID="txtCategory" runat="server" Width="99%"></asp:TextBox>
        <br />
        <asp:Label ID="lblSubcategory" runat="server" Text="Subcategory:" Width="20%"></asp:Label>
        <asp:DropDownList ID="ddlSubcategory" runat="server" DataSourceID="dsSubcategory" DataTextField="CategoryName" DataValueField="CategoryID" Width="99%">
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblSubcategoryOther" runat="server" Text="Enter a new subcategory if it doesn't already exist."></asp:Label>
        <br />
        <asp:TextBox ID="txtSubcategory" runat="server" Width="99%"></asp:TextBox>
        <br />
        <asp:Label ID="lblPlatform" runat="server" Text="Platforms:" Width="20%"></asp:Label>
        <asp:DropDownList ID="ddlPlatform" runat="server" CssClass="auto-style1" DataSourceID="dsPlatform" DataTextField="Name" DataValueField="ID" Width="99%" Visible="False">
        </asp:DropDownList>
        <br />
        <asp:CheckBoxList ID="platformChkLst" runat="server" DataSourceID="dsPlatform" DataTextField="Name" DataValueField="ID" RepeatDirection="Vertical" RepeatLayout="Table" RepeatColumns="3" Width="99%" Height="24px">
        </asp:CheckBoxList>
        <br />
        <asp:Label ID="lblPlatformOther" runat="server" Text="Enter a new platform if it doesn't already exist."></asp:Label>
        <br />
        <asp:TextBox ID="txtPlatform" runat="server" Width="99%"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblReleaseDate" runat="server" Text="Release Date:"></asp:Label>
        <br />   
        <asp:TextBox ID="txtDate" runat="server" TextMode="Date" Width="99%"></asp:TextBox>
<%--        <asp:Calendar ID="calReleaseDate" runat="server" Width="99%"></asp:Calendar>--%>
        <br />
        <asp:Label ID="lblImage" runat="server" Text="Upload an image of the game or accessory."></asp:Label>
        <br />
        <asp:FileUpload ID="FileUploadControl" runat="server" Width="99%" />
        <asp:Label ID="lblDescription" runat="server" Text="Description: "></asp:Label>
        <br />
        <asp:TextBox ID="txtDescription" runat="server" CssClass="auto-style2" Height="172px" TextMode="MultiLine"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtImageURL" runat="server" Visible="False"></asp:TextBox>
        <br />
        <asp:CheckBox ID="chkUpdateAll" runat="server" Text="Update information for all platforms" Visible="False" />
        <br />
        <asp:LinkButton ID="btnSell" runat="server" CssClass="order">Sell</asp:LinkButton>
    </div>
    <%--    </div>--%>
</asp:Content>

