Imports System.Data
Imports System.Data.SqlClient
Partial Class details
    Inherits System.Web.UI.Page
    Dim platformName As String = ""
    Dim userID As Integer = 0
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("user_id") And Session("user_id") <> Nothing Then
        Else
            Response.Redirect("login.aspx")
        End If
        If Request.QueryString("ProductNo") <> "" Then
            'Dim strConn As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\OnlineStore.mdf;Integrated Security=True;Connect Timeout=30"
            Dim connProduct As SqlConnection
            Dim connProduct2 As SqlConnection
            Dim connProduct3 As SqlConnection
            Dim connProduct4 As SqlConnection
            Dim cmdProduct As SqlCommand
            Dim cmdProduct2 As SqlCommand
            Dim cmdProduct3 As SqlCommand
            Dim cmdProduct4 As SqlCommand
            Dim drProduct As SqlDataReader
            Dim drProduct2 As SqlDataReader
            Dim drProduct3 As SqlDataReader
            Dim drProduct4 As SqlDataReader
            connProduct = New SqlConnection(ConfigurationManager.ConnectionStrings.Item(1).ConnectionString)
            connProduct2 = New SqlConnection(ConfigurationManager.ConnectionStrings.Item(1).ConnectionString)
            connProduct3 = New SqlConnection(ConfigurationManager.ConnectionStrings.Item(1).ConnectionString)
            connProduct4 = New SqlConnection(ConfigurationManager.ConnectionStrings.Item(1).ConnectionString)
            Dim strSQL As String = "SELECT [Products].ProductName, [Products].ProductID, [Products].Price, [Products].imageURL, [Users].Id as 'SellerID', [Users].Name as 'Seller', Description, [Platform].ShortName, [Platform].Name as 'LongName', [GameRating].RatingImage, [GameRating].ESRBRatingLong, [Developer].DeveloperName, [Publisher].PublisherName, [Products].ReleaseDate FROM Products, [Platform], [Users], [GameRating],[Developer], [Publisher] Where [Products].PublisherID = [Publisher].Id and [Products].DeveloperID = [Developer].Id and [Products].ESRBRatingID = [GameRating].Id and [Products].UserID = [Users].Id and [Products].PlatformID = [Platform].ID and [Products].ProductID = @productID"
            Dim strSQL2 As String = "SELECT [Category].CategoryName, [Category].Parent, [Category].CategoryID from [Category], [Products] where [Products].CategoryID = [Category].CategoryID and [Products].ProductID =@productID"
            Dim strSQL4 As String = "Select SUM(Rating)/COUNT(Rating) as OverallRating, Count(Rating) as numReviews FROM [Rating] Where ProductID = @productID"
            connProduct.Open()
            connProduct2.Open()
            Dim productIDParam As New SqlParameter("@productID", Integer.Parse(Request.QueryString("ProductNo")))
            Dim productIDParam2 As New SqlParameter("@productID", Integer.Parse(Request.QueryString("ProductNo")))
            Dim productIDParam3 As New SqlParameter("@productID", Integer.Parse(Request.QueryString("ProductNo")))
            cmdProduct2 = New SqlCommand(strSQL2, connProduct)
            cmdProduct4 = New SqlCommand(strSQL4, connProduct2)
            cmdProduct4.Parameters.Add(productIDParam3)
            cmdProduct2.Parameters.Add(productIDParam2)
            drProduct2 = cmdProduct2.ExecuteReader()
            drProduct4 = cmdProduct4.ExecuteReader()
            If drProduct4.Read() Then
                If DBNull.Value.Equals(drProduct4.Item("OverallRating")) Then
                    starOneActive.Visible = False
                    starTwoActive.Visible = False
                    starThreeActive.Visible = False
                    starFourActive.Visible = False
                    starFiveActive.Visible = False
                    starOneInactive.Visible = True
                    starTwoInactive.Visible = True
                    starThreeInactive.Visible = True
                    starFourInactive.Visible = True
                    starFiveInactive.Visible = True
                ElseIf Math.Round(drProduct4.Item("OverallRating")) = 1 Then
                    starOneActive.Visible = True
                    starTwoActive.Visible = False
                    starThreeActive.Visible = False
                    starFourActive.Visible = False
                    starFiveActive.Visible = False
                    starOneInactive.Visible = False
                    starTwoInactive.Visible = True
                    starThreeInactive.Visible = True
                    starFourInactive.Visible = True
                    starFiveInactive.Visible = True
                ElseIf Math.Round(drProduct4.Item("OverallRating")) = 2 Then
                    starOneActive.Visible = True
                    starTwoActive.Visible = True
                    starThreeActive.Visible = False
                    starFourActive.Visible = False
                    starFiveActive.Visible = False
                    starOneInactive.Visible = False
                    starTwoInactive.Visible = False
                    starThreeInactive.Visible = True
                    starFourInactive.Visible = True
                    starFiveInactive.Visible = True
                ElseIf Math.Round(drProduct4.Item("OverallRating")) = 3 Then
                    starOneActive.Visible = True
                    starTwoActive.Visible = True
                    starThreeActive.Visible = True
                    starFourActive.Visible = False
                    starFiveActive.Visible = False
                    starOneInactive.Visible = False
                    starTwoInactive.Visible = False
                    starThreeInactive.Visible = False
                    starFourInactive.Visible = True
                    starFiveInactive.Visible = True
                ElseIf Math.Round(drProduct4.Item("OverallRating")) = 4 Then
                    starOneActive.Visible = True
                    starTwoActive.Visible = True
                    starThreeActive.Visible = True
                    starFourActive.Visible = True
                    starFiveActive.Visible = False
                    starOneInactive.Visible = False
                    starTwoInactive.Visible = False
                    starThreeInactive.Visible = False
                    starFourInactive.Visible = False
                    starFiveInactive.Visible = True
                ElseIf Math.Round(drProduct4.Item("OverallRating")) = 5 Then
                    starOneActive.Visible = True
                    starTwoActive.Visible = True
                    starThreeActive.Visible = True
                    starFourActive.Visible = True
                    starFiveActive.Visible = True
                    starOneInactive.Visible = False
                    starTwoInactive.Visible = False
                    starThreeInactive.Visible = False
                    starFourInactive.Visible = False
                    starFiveInactive.Visible = False
                End If
                numReviewsTop.InnerText = " (" & drProduct4.Item("numReviews") & ")"
                If drProduct4.Item("numReviews") = 1 Then
                    lblRatings.InnerText = "Ratings & Reviews (" & drProduct4.Item("numReviews") & " review)"
                Else
                    lblRatings.InnerText = "Ratings & Reviews (" & drProduct4.Item("numReviews") & " reviews)"
                End If
            End If
            Dim catID
            If drProduct2.Read() Then
                lblBC1.Text = "<a href = 'products.aspx?MainCatId=" & drProduct2.Item("Parent") & "&SubCatID=" & drProduct2.Item("CategoryID") & "'>" & drProduct2.Item("CategoryName") & "</a>"
                catID = drProduct2.Item("Parent")
            End If
            connProduct.Close()
            connProduct2.Close()
            Dim strSQL3 As String = "SELECT [Category].CategoryName from [Category] where [Category].CategoryID = @catID"
            cmdProduct = New SqlCommand(strSQL, connProduct)
            cmdProduct3 = New SqlCommand(strSQL3, connProduct3)
            Dim catIDParam As New SqlParameter("@catID", catID)
            Dim catIDParam2 As New SqlParameter("@catID", catID)
            cmdProduct.Parameters.Add(catIDParam)
            cmdProduct.Parameters.Add(productIDParam)
            cmdProduct3.Parameters.Add(catIDParam2)
            connProduct.Open()
            connProduct3.Open()
            drProduct = cmdProduct.ExecuteReader(CommandBehavior.CloseConnection)
            drProduct3 = cmdProduct3.ExecuteReader(CommandBehavior.CloseConnection)
            If drProduct3.Read() Then
                lblBC2.Text = "<a href = 'products.aspx?MainCatId=" & catID & "'>" & drProduct3.Item("CategoryName") & "</a>"
            End If
            If drProduct.Read() Then
                lblBC3.Text = "<a href = '#'>" & drProduct.Item("ProductName") & " (" & drProduct.Item("ShortName") & ")" & "</a>"
                lblProductName.Text = drProduct.Item("ProductName") & " <br />(" & drProduct.Item("ShortName") & ")"
                'lblProductNo.Text = drProduct.Item("ProductNo")
                lblSeller.Text = "Seller: " & drProduct.Item("Seller")
                lblProductID.Text = drProduct.Item("ProductID")
                lblPrice.Text = drProduct.Item("Price")
                imgProduct.ImageUrl = Trim(drProduct.Item("imageURL"))
                lblDescription.Text = drProduct.Item("Description")
                platformName = Trim(drProduct.Item("LongName"))
                userID = Trim(drProduct.Item("SellerID"))
                lblDeveloper.Text = Trim(drProduct.Item("DeveloperName"))
                lblPublisher.Text = Trim(drProduct.Item("PublisherName"))
                lblGameRating.Text = Trim(drProduct.Item("ESRBRatingLong"))
                imgGameRating.ImageUrl = Trim(drProduct.Item("RatingImage"))
                lblReleaseDate.Text = Date.Parse(Trim(drProduct.Item("ReleaseDate"))).ToString("MM/dd/yyyy")
                If userID = Session("user_id") Then
                    btnAddToCart.Enabled = False
                    lblSellerError.Visible = True
                End If
            End If
        Else
            Response.Redirect("products.aspx")
        End If
        'If Session("verified") = False Or Session("verified") = Nothing Then
        '    If lblGameRating.Text = "Everyone 10+" Then
        '        Session("verifyAge") = 10
        '        Response.Redirect("verify.aspx?ReturnTo=" & HttpContext.Current.Request.Url.AbsoluteUri)
        '    ElseIf lblGameRating.Text = "Teen" Then
        '        Session("verifyAge") = 13
        '        Response.Redirect("verify.aspx?ReturnTo=" & HttpContext.Current.Request.Url.AbsoluteUri)
        '    ElseIf lblGameRating.Text = "Mature" Then
        '        Session("verifyAge") = 17
        '        Response.Redirect("verify.aspx?ReturnTo=" & HttpContext.Current.Request.Url.AbsoluteUri)
        '    ElseIf lblGameRating.Text = "Adults Only" Then
        '        Session("verifyAge") = 18
        '        Response.Redirect("verify.aspx?ReturnTo=" & HttpContext.Current.Request.Url.AbsoluteUri)
        '    Else
        '        Session("verified") = False
        '    End If
        'End If
        'Session("verified") = False
        'If IsPostBack = True Then
        'If Request.QueryString("ProductNo") <> "" Then
        '    DSProductList.SelectCommand = "Select * From Products Where ProductNo = '" & Request.QueryString("ProductNo") & "'"
        '    'DSBreadcrumbs1.SelectCommand = "Select * From Category Where CategoryID = " & CInt(Request.QueryString("MainCatID"))
        'End If
        'If Request.QueryString("SubCatID") <> "" Then
        '    DSProductList.SelectCommand = "Select * From Products Where CategoryID = " & CInt(Request.QueryString("SubCatID"))
        '    DSBreadcrumbs2.SelectCommand = "Select * From Category Where CategoryID = " & CInt(Request.QueryString("SubCatID"))
        '    'lblBC1.Text = "Products"
        '    'lblBC2.Text = Str(Request.QueryString("SubCatID"))
        'End If
        'Else
        '    DSSubCategory.SelectCommand = "Select * From Category Where Parent = 0"
        'End If
    End Sub
    Protected Sub btnAddToCart_Click(sender As Object, e As EventArgs) Handles btnAddToCart.Click
        Dim drCartLineCheckIfExists As SqlDataReader
        Dim drCartLine As SqlDataReader
        Dim strSQLStatementCheckIfExists As String
        Dim strSQLStatement As String
        Dim cmdSQLCheckIfExists As SqlCommand
        Dim cmdSQL As SqlCommand
        Dim cmdSQL2 As SqlCommand
        Dim strConnectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString
        Dim conn As New SqlConnection(strConnectionString)
        Dim conn2 As New SqlConnection(strConnectionString)
        Dim sngPrice As Single
        Dim quantity As Integer = 0
        Try
            conn.Open()
            ' *** get product price
            strSQLStatement = "SELECT * FROM Products WHERE ProductID = " & CInt(lblProductID.Text)
            cmdSQL = New SqlCommand(strSQLStatement, conn)
            drCartLine = cmdSQL.ExecuteReader()

            If drCartLine.Read() Then
                sngPrice = drCartLine.Item("Price")
            End If
            conn.Close()
        Catch ex As Exception
            'Response.Redirect("index.aspx")
        End Try
        '*** get CartID
        Dim strCartID As String
        If HttpContext.Current.Request.Cookies("CartID") Is Nothing Then
            Dim randomCartID As New Random
            strCartID = GenerateString()
            Dim CookieTo As New HttpCookie("CartID", strCartID)
            HttpContext.Current.Response.AppendCookie(CookieTo)
        Else
            Dim CookieBack As HttpCookie
            CookieBack = HttpContext.Current.Request.Cookies("CartID")
            strCartID = CookieBack.Value
        End If

        ' figure out if this product already exits in the cart
        ' hint: before you issue the insert command, you check the cart

        ' add to the cart
        Dim productIDRetreived As Integer
        Dim enteredQuantity As Integer
        Dim regexStr As String = "(^[1-9][0-9]*$)"
        If Regex.IsMatch(tbQuantity.Text, regexStr) Then
            enteredQuantity = Integer.Parse(tbQuantity.Text)
            Try
                productIDRetreived = Integer.Parse(lblProductID.Text)
                lblIncorrectFormat.Visible = False
                strSQLStatementCheckIfExists = "Select Quantity FROM CartLine Where ProductID = @productIDReceived and CartID =@cartID"
                Dim productIDReceivedParam As New SqlParameter("@productIDReceived", productIDRetreived)
                Dim cartIDParam As New SqlParameter("@cartID", Trim(strCartID))
                cmdSQLCheckIfExists = New SqlCommand(strSQLStatementCheckIfExists, conn)
                cmdSQLCheckIfExists.Parameters.Add(productIDReceivedParam)
                cmdSQLCheckIfExists.Parameters.Add(cartIDParam)
                conn.Open()
                drCartLineCheckIfExists = cmdSQLCheckIfExists.ExecuteReader(CommandBehavior.CloseConnection)
                If drCartLineCheckIfExists.Read() Then
                    quantity = drCartLineCheckIfExists.Item("Quantity")
                Else
                End If
                conn.Close()
            Catch existsex As Exception
                'Response.Redirect("products.aspx")
            End Try
            Try
                If quantity = 0 Then
                    'conn.Close()
                    strSQLStatement = "INSERT INTO CartLine (ProductID, Quantity,  Final, CartID) values( @productID, @tbquantity, 0, @cartID)"
                    Dim tbquantityParam2 As New SqlParameter("@tbquantity", CInt(tbQuantity.Text))
                    Dim productIDParam2 As New SqlParameter("@productID", CInt(lblProductID.Text))
                    Dim cartIDParam3 As New SqlParameter("@cartID", Trim(strCartID))
                    Dim userIDParam As New SqlParameter("@userID", Session("user_id"))
                    cmdSQL = New SqlCommand(strSQLStatement, conn)
                    cmdSQL.Parameters.Add(tbquantityParam2)
                    cmdSQL.Parameters.Add(productIDParam2)
                    cmdSQL.Parameters.Add(cartIDParam3)
                    cmdSQL.Parameters.Add(userIDParam)
                    conn.Open()
                    cmdSQL.ExecuteNonQuery()
                    conn.Close()
                Else
                    strSQLStatement = "UPDATE CartLine SET Quantity = (@tbQuantity + @quantity) Where ProductID= @productID and CartID = @cartID"
                    Dim tbquantityParam As New SqlParameter("@tbquantity", CInt(tbQuantity.Text))
                    Dim quantityParam As New SqlParameter("@quantity", quantity)
                    Dim productIDParam As New SqlParameter("@productID", CInt(lblProductID.Text))
                    Dim cartIDParam2 As New SqlParameter("@cartID", Trim(strCartID))
                    cmdSQL2 = New SqlCommand(strSQLStatement, conn2)
                    cmdSQL2.Parameters.Add(tbquantityParam)
                    cmdSQL2.Parameters.Add(quantityParam)
                    cmdSQL2.Parameters.Add(productIDParam)
                    cmdSQL2.Parameters.Add(cartIDParam2)
                    conn2.Open()
                    drCartLine = cmdSQL2.ExecuteReader(CommandBehavior.CloseConnection)
                End If
                Response.Redirect("cart.aspx")
            Catch ex As Exception
                'Response.Redirect("sell.aspx")
            End Try
        Else
            lblIncorrectFormat.Visible = True
            lblIncorrectFormat.Text = "Please enter a valid quantity."
        End If
    End Sub
    Private Function GenerateString() As String

        Dim xCharArray() As Char = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray
        Dim xNoArray() As Char = "0123456789".ToCharArray
        Dim xGenerator As System.Random = New System.Random()
        Dim xStr As String = String.Empty
        While xStr.Length < 6
            If xGenerator.Next(0, 2) = 0 Then
                xStr &= xCharArray(xGenerator.Next(0, xCharArray.Length))
            Else
                xStr &= xNoArray(xGenerator.Next(0, xNoArray.Length))
            End If
        End While
        Return xStr
    End Function

    Protected Sub btnReview_Click(sender As Object, e As EventArgs) Handles btnReview.Click
        Dim strSQLSubmitReview As String
        Dim strSQLcheckReview As String
        Dim strSQLeditReview As String
        Dim strSQLCheckProduct As String
        Dim cmdSubmitReview As SqlCommand
        Dim cmdCheckProduct As SqlCommand
        Dim cmdEditReview As SqlCommand
        Dim cmdCheckReview As SqlCommand
        Dim drProduct As SqlDataReader
        Dim productIDRetrieved = Integer.Parse(lblProductID.Text)
        Dim strConnectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString
        Dim conn As New SqlConnection(strConnectionString)
        Dim conn2 As New SqlConnection(strConnectionString)
        Dim reviewExists As Boolean = False
        If userID <> Session("user_id") Then
            Try
                strSQLCheckProduct = "SELECT Count(*) as 'CountItems' FROM CARTLINE, OrderHead, AddressInfo WHERE AddressInfo.UserID = @userID and PRODUCTID = @productID and CartLine.Final = 1 and CartLine.CartID = OrderHead.Id and OrderHead.AddressID = AddressInfo.Id"
                Dim productIDParam As New SqlParameter("@productID", productIDRetrieved)
                Dim userIDParam As New SqlParameter("@userid", Session("user_id"))
                cmdCheckProduct = New SqlCommand(strSQLCheckProduct, conn)
                cmdCheckProduct.Parameters.Add(productIDParam)
                cmdCheckProduct.Parameters.Add(userIDParam)
                conn.Open()
                drProduct = cmdCheckProduct.ExecuteReader()
                If drProduct.Read() Then
                    If Integer.Parse(Trim(drProduct.Item("CountItems"))) = 0 Then
                        lblReviewError.Text = "You must purchase the product before you can review it."
                        lblReviewError.Visible = True
                        Exit Sub
                    End If
                End If
                conn.Close()
            Catch existsex As Exception
                'Response.Redirect("products.aspx")
            End Try
        End If
        If clsValidator.validateEmptyOrNot(txtReview.Text, "Review").Count = 0 Then
            Try
                strSQLcheckReview = "SELECT COUNT(*) as CountItems FROM Rating WHERE userID = @userID and ProductID = @productID"
                Dim userIDParam As New SqlParameter("@userID", Session("user_id"))
                Dim productIDParam As New SqlParameter("@productID", productIDRetrieved)
                cmdCheckReview = New SqlCommand(strSQLcheckReview, conn)
                cmdCheckReview.Parameters.Add(userIDParam)
                cmdCheckReview.Parameters.Add(productIDParam)
                conn.Open()
                drProduct = cmdCheckReview.ExecuteReader()
                If drProduct.Read() Then
                    If Integer.Parse(Trim(drProduct.Item("CountItems"))) > 0 Then
                        reviewExists = True
                    End If
                End If
                conn.Close()
            Catch existsex As Exception
                'Response.Redirect("products.aspx")
            End Try
            If reviewExists = False Then
                Try
                    strSQLSubmitReview = "INSERT INTO Rating Values(@userID, @review, @rating, @productID, getdate(), getdate())"
                    Dim userIDParam As New SqlParameter("@userID", Session("user_id"))
                    Dim reviewParam As New SqlParameter("@review", txtReview.Text)
                    Dim ratingParam As New SqlParameter("@rating", hdFieldRating.Value)
                    Dim productIDParam As New SqlParameter("@productID", productIDRetrieved)
                    cmdSubmitReview = New SqlCommand(strSQLSubmitReview, conn)
                    cmdSubmitReview.Parameters.Add(userIDParam)
                    cmdSubmitReview.Parameters.Add(reviewParam)
                    cmdSubmitReview.Parameters.Add(ratingParam)
                    cmdSubmitReview.Parameters.Add(productIDParam)
                    conn.Open()
                    cmdSubmitReview.ExecuteNonQuery()
                    conn.Close()
                    lblReviewError.Visible = False
                Catch existsex As Exception
                    lblReviewError.Text = "Unable to create review. Please try again later."
                    lblReviewError.Visible = True
                    'Response.Redirect("products.aspx")
                End Try
            Else
                Try
                    strSQLeditReview = "UPDATE Rating SET Review = @review, Rating = @rating, updatedAt=getDate() Where ProductID = @productID"
                    Dim reviewParam As New SqlParameter("@review", txtReview.Text)
                    Dim ratingParam As New SqlParameter("@rating", hdFieldRating.Value)
                    Dim productIDParam As New SqlParameter("@productID", productIDRetrieved)
                    cmdEditReview = New SqlCommand(strSQLeditReview, conn)
                    cmdEditReview.Parameters.Add(reviewParam)
                    cmdEditReview.Parameters.Add(ratingParam)
                    cmdEditReview.Parameters.Add(productIDParam)
                    conn.Open()
                    cmdEditReview.ExecuteNonQuery()
                    conn.Close()
                Catch existsex As Exception
                    lblReviewError.Text = "Unable to update review. Please try again later."
                    lblReviewError.Visible = True
                    'Response.Redirect("products.aspx")
                End Try
            End If
        Else
            For Each itemError As String In clsValidator.validateEmptyOrNot(txtReview.Text, "Review")
                lblReviewError.Text += itemError + " <br />"
            Next
        End If
        hdFieldRating.Value = Nothing
        'If starOne.Attributes.Item("checkedValue") = "true" Then
        '    rating += 1
        'End If
        'If starTwo.Attributes.Item("checkedValue") = "true" Then
        '    rating += 1
        'End If
        'If starThree.Attributes.Item("checkedValue") = "true" Then
        '    rating += 1
        'End If
        'If starFour.Attributes.Item("checkedValue") = "true" Then
        '    rating += 1
        'End If
        'If starFive.Attributes.Item("checkedValue") = "true" Then
        '    rating += 1
        'End If
    End Sub

    Private Sub dlReviews_ItemCommand(source As Object, e As DataListCommandEventArgs) Handles dlReviews.ItemCommand
        Dim strConnectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString
        Dim conn As New SqlConnection(strConnectionString)
        Dim productIDRetrieved = Integer.Parse(lblProductID.Text)
        If e.CommandName = "EditReview" Then
            Dim strSQLEditReview As String
            Dim cmdEditReview As SqlCommand
            Dim drReview As SqlDataReader
            Try
                strSQLEditReview = "SELECT [Rating].UserID, [Rating].Review,[Rating].Rating, [Rating].CreatedAt, [Rating].UpdatedAt, [Users].Name FROM [Rating], [Users] Where [Rating].UserID = [Users].Id and [Rating].Id = @ratingID"
                Dim ratingIDParam As New SqlParameter("@ratingID", e.CommandArgument)
                cmdEditReview = New SqlCommand(strSQLEditReview, conn)
                cmdEditReview.Parameters.Add(ratingIDParam)
                conn.Open()
                drReview = cmdEditReview.ExecuteReader()
                If drReview.Read() Then
                    If drReview.Item("Rating") = 1 Then
                        starOneRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
                        starTwoRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#716969")
                        starThreeRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#716969")
                        starFourRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#716969")
                        starFiveRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#716969")
                    ElseIf drReview.Item("Rating") = 2 Then
                        starOneRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
                        starTwoRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
                        starThreeRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#716969")
                        starFourRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#716969")
                        starFiveRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#716969")
                    ElseIf drReview.Item("Rating") = 3 Then
                        starOneRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
                        starTwoRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
                        starThreeRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
                        starFourRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#716969")
                        starFiveRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#716969")
                    ElseIf drReview.Item("Rating") = 4 Then
                        starOneRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
                        starTwoRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
                        starThreeRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
                        starFourRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
                        starFiveRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#716969")
                    ElseIf drReview.Item("Rating") = 5 Then
                        starOneRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
                        starTwoRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
                        starThreeRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
                        starFourRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
                        starFiveRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
                    End If
                    'ddlRating.ClearSelection()
                    'ddlRating.Items.FindByText(drReview.Item("Rating")).Selected = True
                    txtReview.Text = drReview.Item("Review")
                End If
                conn.Close()
                btnReview.Text = "Update Review"
            Catch existsex As Exception
                'Response.Redirect("products.aspx")
            End Try
        ElseIf e.CommandName = "DeleteReview" Then
            Dim strSQLDeleteReview As String
            Dim cmdDeleteReview As SqlCommand
            Try
                strSQLDeleteReview = "DELETE FROM Rating Where Id = @ratingID"
                Dim ratingIDParam As New SqlParameter("@ratingID", e.CommandArgument)
                cmdDeleteReview = New SqlCommand(strSQLDeleteReview, conn)
                cmdDeleteReview.Parameters.Add(ratingIDParam)
                conn.Open()
                cmdDeleteReview.ExecuteNonQuery()
                conn.Close()
            Catch existsex As Exception
                lblReviewError.Text = "Unable to delete review. Please try again later."
                lblReviewError.Visible = True
                'Response.Redirect("products.aspx")
            End Try
        End If
    End Sub
    Protected Sub ddlPlatform_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPlatform.SelectedIndexChanged
        Response.Redirect("details.aspx?ProductNo=" & ddlPlatform.SelectedValue)
    End Sub

    Private Sub ddlPlatform_DataBound(sender As Object, e As EventArgs) Handles ddlPlatform.DataBound
        CType(sender, DropDownList).ClearSelection()
        CType(sender, DropDownList).Items.FindByText(platformName).Selected = True
    End Sub

    Private Sub starOneRating_ServerClick(sender As Object, e As EventArgs) Handles starOneRating.ServerClick
        hdFieldRating.Value = 1
        starOneRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
        starTwoRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#716969")
        starThreeRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#716969")
        starFourRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#716969")
        starFiveRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#716969")
    End Sub

    Private Sub starTwoRating_ServerClick(sender As Object, e As EventArgs) Handles starTwoRating.ServerClick
        hdFieldRating.Value = 2
        starOneRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
        starTwoRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
        starThreeRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#716969")
        starFourRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#716969")
        starFiveRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#716969")
    End Sub

    Private Sub starThreeRating_ServerClick(sender As Object, e As EventArgs) Handles starThreeRating.ServerClick
        hdFieldRating.Value = 3
        starOneRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
        starTwoRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
        starThreeRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
        starFourRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#716969")
        starFiveRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#716969")
    End Sub

    Private Sub starFourRating_ServerClick(sender As Object, e As EventArgs) Handles starFourRating.ServerClick
        hdFieldRating.Value = 4
        starOneRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
        starTwoRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
        starThreeRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
        starFourRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
        starFiveRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#716969")
    End Sub

    Private Sub starFiveRating_ServerClick(sender As Object, e As EventArgs) Handles starFiveRating.ServerClick
        hdFieldRating.Value = 5
        starOneRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
        starTwoRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
        starThreeRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
        starFourRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
        starFiveRating.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "#fb4c29")
    End Sub

    Private Sub ddlPlatform_TextChanged(sender As Object, e As EventArgs) Handles ddlPlatform.TextChanged
        Response.Redirect("details.aspx?ProductNo=" & ddlPlatform.SelectedValue)
    End Sub
End Class
