Imports System.Data.SqlClient
Partial Class cart
    Inherits System.Web.UI.Page
    Public strCartID As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        '*** get CartID
        'If Not IsPostBack Then
        If Not HttpContext.Current.Request.Cookies("CartID") Is Nothing Then
            Dim CookieBack As HttpCookie
            CookieBack = HttpContext.Current.Request.Cookies("CartID")
            strCartID = CookieBack.Value
            DSCart.SelectCommand = "Select * From CartLine Where CartID = '" & strCartID & "'"
            'Response.Write(DSCart.SelectCommand)
        End If
        'End If
        calculateGrandTotal()
    End Sub
    Protected Sub lvCart_OnItemCommand(ByVal sender As Object, ByVal e As ListViewCommandEventArgs)
        If e.CommandName = "cmdUpdateQuantity" Then
            Dim tbQuantity As TextBox = CType(e.Item.FindControl("tbQuantity"), TextBox)
            Dim strSQL As String = "Update CartLine Set Quantity = '" & CInt(tbQuantity.Text) & "' where CartID = '" & strCartID & "' and ProductID = '" & CInt(e.CommandArgument) & "'"
            ' update
            Dim strConn As String = ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString
            Dim connCart As SqlConnection
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
            Dim strConn As String = ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString
            Dim connCart As SqlConnection
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
        DSCart.DataBind()
        lvCart.DataBind()
        'Response.Redirect("cart.aspx")
        calculateGrandTotal()
    End Sub
    Private Sub calculateGrandTotal()
        Try
            Dim strSQL As String = "Select SUM((Price)*(Quantity)) as Total FROM CartLine Where CartID='" & strCartID & "'"
            ' update
            Dim strConn As String = ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString
            Dim connCart As SqlConnection
            Dim cmdCart As SqlCommand
            Dim drCart As SqlDataReader
            connCart = New SqlConnection(strConn)
            cmdCart = New SqlCommand(strSQL, connCart)
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
