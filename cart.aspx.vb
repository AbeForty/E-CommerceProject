Imports System.Data.SqlClient
Partial Class cart
    Inherits System.Web.UI.Page
    Public strCartID As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        '*** get CartID
        'If Not IsPostBack Then
        'If Session("user_id") And Session("user_id") <> Nothing Then
        'Else
        '    Response.Redirect("login.aspx")
        'End If
        If Not HttpContext.Current.Request.Cookies("CartID") Is Nothing Then
            Dim CookieBack As HttpCookie
            CookieBack = HttpContext.Current.Request.Cookies("CartID")
            strCartID = CookieBack.Value
            DSCart.SelectCommand = "Select * From CartLine, Products Where Products.ProductID = CartLine.ProductID and CartID = '" & strCartID & "'"
            'Response.Write(DSCart.SelectCommand)
        End If
        'End If
        calculateGrandTotal()
    End Sub
    Protected Sub lvCart_OnItemCommand(ByVal sender As Object, ByVal e As ListViewCommandEventArgs)
        Dim strConn As String = ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString
        Dim connCart As SqlConnection
        If e.CommandName = "cmdUpdateQuantity" Then
            Dim tbQuantity As TextBox = CType(e.Item.FindControl("tbQuantity"), TextBox)
            Dim strSQL As String = "Update CartLine Set Quantity = '" & CInt(tbQuantity.Text) & "' where CartID = '" & strCartID & "' and ProductID = '" & CInt(e.CommandArgument) & "'"
            ' update
            Dim cmdCart As SqlCommand
            Dim drCart
            connCart = New SqlConnection(strConn)
            cmdCart = New SqlCommand(strSQL, connCart)
            connCart.Open()
            drCart = cmdCart.ExecuteNonQuery()
            DSCart.DataBind()
            lvCart.DataBind()
            'Response.Redirect("Cart.aspx")
            calculateGrandTotal()
        ElseIf e.CommandName = "cmdDelete" Then
            Dim strSQL As String = "DELETE FROM CartLine WHERE cartid = '" & strCartID & "' and productid = " & CInt(e.CommandArgument)
            ' update
            Dim cmdCart As SqlCommand
            Dim drCart
            connCart = New SqlConnection(strConn)
            cmdCart = New SqlCommand(strSQL, connCart)
            connCart.Open()
            drCart = cmdCart.ExecuteNonQuery()
            DSCart.DataBind()
            lvCart.DataBind()
            'Response.Redirect("Cart.aspx")
            calculateGrandTotal()
        End If
        Try
            Dim strConnectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString
            Dim conn As New SqlConnection(strConnectionString)
            Dim drNumberOfItems As SqlDataReader
            Dim strSQLNumberOfItems As String = "SELECT Count(*) as 'NumberOfRows' FROM CartLine Where CartID = @cartID"
            Dim cmdNumberOfItems As New SqlCommand(strSQLNumberOfItems, conn)
            Dim numberOfItemsParam As New SqlParameter("@cartID", strCartID)
            cmdNumberOfItems.Parameters.Add(numberOfItemsParam)
            conn.Open()
            drNumberOfItems = cmdNumberOfItems.ExecuteReader()
            If drNumberOfItems.Read() Then
                CType(Master.FindControl("lblCartItems"), Label).Text = "View Cart (" & drNumberOfItems.Item("NumberOfRows") & ")"
            End If
            conn.Close()
        Catch ex As Exception
            CType(Master.FindControl("lblCartItems"), Label).Text = "View Cart (0)"
        End Try
    End Sub
    Protected Sub lblEmptyCart_Click(sender As Object, e As EventArgs) Handles lblEmptyCart.Click
        Dim strSQL As String = "DELETE FROM CartLine WHERE CartID = '" & strCartID & "'"
        ' update
        Dim strConn As String = ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString
        Dim connCart As SqlConnection
        Dim cmdCart As SqlCommand
        Dim drCart
        connCart = New SqlConnection(strConn)
        cmdCart = New SqlCommand(strSQL, connCart)
        connCart.Open()
        drCart = cmdCart.ExecuteNonQuery()
        connCart.Close()
        DSCart.DataBind()
        lvCart.DataBind()
        'Response.Redirect("cart.aspx")
        calculateGrandTotal()
        CType(Master.FindControl("lblCartItems"), Label).Text = "View Cart (0)"
    End Sub
    Private Sub calculateGrandTotal()
        Try
            Dim strSQL As String = "Select SUM((Price)*(Quantity)) as Total FROM CartLine, Products Where Products.ProductID = CartLine.ProductID and CartID=@cartID"
            ' update
            Dim strConn As String = ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString
            Dim connCart As SqlConnection
            Dim cmdCart As SqlCommand
            Dim cartIDParam As New SqlParameter("@cartID", strCartID)
            Dim drCart As SqlDataReader
            connCart = New SqlConnection(strConn)
            cmdCart = New SqlCommand(strSQL, connCart)
            cmdCart.Parameters.Add(cartIDParam)
            connCart.Open()
            drCart = cmdCart.ExecuteReader()
            If drCart.Read() Then
                lblSubtotal.Text = drCart.Item("Total")
                lblTotal.Text = drCart.Item("Total")
            End If
        Catch ex As Exception
            lblSubtotal.Text = "$0.00"
            lblTotal.Text = "$0.00"
        End Try
        If Not lblSubtotal.Text = "$0.00" Then
            lbOrder.Enabled = True
        Else
            lbOrder.Enabled = False
        End If
    End Sub
    Protected Sub lbOrder_Click(sender As Object, e As EventArgs) Handles lbOrder.Click
        Response.Redirect("checkout.aspx")
    End Sub
End Class
