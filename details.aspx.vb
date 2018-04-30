Imports System.Data
Imports System.Data.SqlClient
Partial Class details
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Request.QueryString("ProductNo") <> "" Then
            'Dim strConn As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\OnlineStore.mdf;Integrated Security=True;Connect Timeout=30"
            Dim connProduct As SqlConnection
            Dim connProduct2 As SqlConnection
            Dim connProduct3 As SqlConnection
            Dim cmdProduct As SqlCommand
            Dim cmdProduct2 As SqlCommand
            Dim cmdProduct3 As SqlCommand
            Dim drProduct As SqlDataReader
            Dim drProduct2 As SqlDataReader
            Dim drProduct3 As SqlDataReader
            connProduct = New SqlConnection(ConfigurationManager.ConnectionStrings.Item(1).ConnectionString)
            connProduct2 = New SqlConnection(ConfigurationManager.ConnectionStrings.Item(1).ConnectionString)
            connProduct3 = New SqlConnection(ConfigurationManager.ConnectionStrings.Item(1).ConnectionString)
            Dim strSQL As String = "SELECT * FROM Products Where ProductNo = '" & Request.QueryString("ProductNo") & "'"
            Dim strSQL2 As String = "SELECT [Category].CategoryName, [Category].Parent from [Category], [Products] where [Products].CategoryID = [Category].CategoryID and [Products].ProductNo ='" & Request.QueryString("ProductNo") & "'"
            connProduct3.Open()
            cmdProduct2 = New SqlCommand(strSQL2, connProduct3)
            drProduct2 = cmdProduct2.ExecuteReader(CommandBehavior.CloseConnection)
            Dim catID
            If drProduct2.Read() Then
                lblBC1.Text = drProduct2.Item("CategoryName")
                catID = drProduct2.Item("Parent")
            End If
            Dim strSQL3 As String = "SELECT [Category].CategoryName from [Category] where [Category].CategoryID = '" & catID & "'"
            cmdProduct = New SqlCommand(strSQL, connProduct)
            cmdProduct3 = New SqlCommand(strSQL3, connProduct2)
            connProduct2.Open()
            connProduct.Open()
            drProduct = cmdProduct.ExecuteReader(CommandBehavior.CloseConnection)
            drProduct3 = cmdProduct3.ExecuteReader(CommandBehavior.CloseConnection)
            If drProduct3.Read() Then
                lblBC2.Text = drProduct3.Item("CategoryName")
            End If
            If drProduct.Read() Then
                lblBC3.Text = drProduct.Item("ProductName")
                lblProductName.Text = drProduct.Item("ProductName")
                lblProductNo.Text = drProduct.Item("ProductNo")
                lblProductID.Text = drProduct.Item("ProductID")
                lblPrice.Text = drProduct.Item("Price")
                imgProduct.ImageUrl = "product-images/" + Trim(drProduct.Item("ProductNo")) + ".jpg"
            End If
        End If
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
        conn.Open()
        ' *** get product price
        strSQLStatement = "SELECT * FROM Products WHERE ProductID = " & CInt(lblProductID.Text)
        cmdSQL = New SqlCommand(strSQLStatement, conn)
        drCartLine = cmdSQL.ExecuteReader()
        Dim sngPrice As Single
        Dim quantity As Integer
        If drCartLine.Read() Then
            sngPrice = drCartLine.Item("Price")
        End If
        conn.Close()
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
                strSQLStatementCheckIfExists = "Select Quantity FROM CartLine Where ProductID =" & productIDRetreived & "and CartID ='" & Trim(strCartID) & "'"
                cmdSQLCheckIfExists = New SqlCommand(strSQLStatementCheckIfExists, conn)
                conn.Open()
                drCartLineCheckIfExists = cmdSQLCheckIfExists.ExecuteReader(CommandBehavior.CloseConnection)
                If drCartLineCheckIfExists.Read() Then
                    quantity = drCartLineCheckIfExists.Item("Quantity")
                Else
                End If
                conn.Close()
                strSQLStatement = "UPDATE CartLine SET Quantity =" & quantity + CInt(tbQuantity.Text) & "Where ProductID=" & CInt(lblProductID.Text) & "and CartID ='" & Trim(strCartID) & "'"
                cmdSQL2 = New SqlCommand(strSQLStatement, conn2)
                conn2.Open()
                drCartLine = cmdSQL2.ExecuteReader(CommandBehavior.CloseConnection)
                Response.Redirect("cart.aspx")
            Catch existsex As Exception
                If quantity = Nothing Then
                    lblIncorrectFormat.Visible = True
                    lblIncorrectFormat.Text = existsex.Message
                    conn.Close()
                    strSQLStatement = "INSERT INTO CartLine (CartID, ProductID, ProductName, ProductNo, Quantity, Price) values('" & Trim(strCartID) & "', " & CInt(lblProductID.Text) & ", '" & lblProductName.Text & "', '" & lblProductNo.Text & "', " & CInt(tbQuantity.Text) & ", " & sngPrice & ")"
                    cmdSQL = New SqlCommand(strSQLStatement, conn)
                    conn.Open()
                    drCartLine = cmdSQL.ExecuteReader(CommandBehavior.CloseConnection)
                    Response.Redirect("cart.aspx")
                Else
                End If
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
End Class
