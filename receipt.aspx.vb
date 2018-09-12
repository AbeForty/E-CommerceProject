
Imports System.Data.SqlClient
Imports System.Net.Mail
Partial Class receipt
    Inherits System.Web.UI.Page
    Dim strCartID As String
    Private Sub thankyou_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("user_id") And Session("user_id") <> Nothing Then
        Else
            Response.Redirect("login.aspx")
        End If
        Try
            Dim connUpdate As SqlConnection
            connUpdate = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
            Dim drUpdate As SqlDataReader
            Dim cmdUpdate As SqlCommand
            Dim strUpdateSQL = "UPDATE CartLine SET Final = 1 Where CartID = @cartID"
            Dim cartIDParam As New SqlParameter("@cartID", strCartID)
            cmdUpdate = New SqlCommand(strUpdateSQL, connUpdate)
            cmdUpdate.Parameters.Add(cartIDParam)
            connUpdate.Open()
            drUpdate = cmdUpdate.ExecuteReader()
            connUpdate.Close()
        Catch ex As Exception
        End Try
        Try
            Dim CookieBack As HttpCookie
            CookieBack = HttpContext.Current.Request.Cookies("CartID")
            strCartID = CookieBack.Value
            DSSummary.SelectCommand = "Select * From CartLine, Products, AddressInfo, OrderHead Where CartLine.CartID = OrderHead.Id and OrderHead.AddressID = AddressInfo.Id and Products.ProductID = CartLine.ProductID and CartID = '" & strCartID & "'"
            'DSOrderHead.SelectCommand = "Select * From OrderHead, AddressInfo Where [OrderHead].Id = '" & strCartID & "'"
            Try
                Dim connCheckTotal As SqlConnection
                connCheckTotal = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
                Dim strCheckTotalSQL As String = "Select CartLine.ID, AddressInfo.ShippingFirstName, AddressInfo.ShippingLastName, AddressInfo.ShippingStreet, AddressInfo.ShippingCity, AddressInfo.ShippingState, AddressInfo.ShippingZip, OrderHead.Subtotal, OrderHead.Shipping, OrderHead.Tax, OrderHead.Total From CartLine, AddressInfo, OrderHead Where CartLine.CartID = OrderHead.Id and OrderHead.AddressID = AddressInfo.Id and CartID = @cartID"
                Dim cartIDParam As New SqlParameter("@cartID", strCartID)
                Dim cmdheckTotal As SqlCommand
                Dim drCheckTotal As SqlDataReader
                connCheckTotal.Open()
                cmdheckTotal = New SqlCommand(strCheckTotalSQL, connCheckTotal)
                cmdheckTotal.Parameters.Add(cartIDParam)
                drCheckTotal = cmdheckTotal.ExecuteReader()
                If drCheckTotal.Read() Then
                    lblOrderID.Text = strCartID
                    lblName.Text = drCheckTotal.Item("ShippingFirstName") & " " & drCheckTotal.Item("ShippingLastName")
                    lblAddress.Text = drCheckTotal.Item("ShippingStreet")
                    lblSubtotal.Text = drCheckTotal.Item("Subtotal")
                    lblShipping.Text = drCheckTotal.Item("Shipping")
                    lblTax.Text = drCheckTotal.Item("Tax")
                    lblTotal.Text = drCheckTotal.Item("Total")
                End If
            Catch ex As Exception

            End Try
            'DSOrderHead.DeleteCommand = "Delete * From CartLine Where CartId = '" & strCartID & "'"
            'For i As Integer = 1 To HttpContext.Current.Request.Cookies.Count - 1
            '    HttpContext.Current.Request.Cookies.Remove(HttpContext.Current.Request.Cookies(i).Name)
            'Next
        Catch ex As Exception
            Response.Redirect("index.aspx")
        End Try
    End Sub
    Private Sub receipt_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim userID = Session("user_id")
        Dim myCookies() = Request.Cookies.AllKeys
        For Each cookie As String In myCookies
            Response.Cookies(cookie).Expires = DateTime.Now.AddDays(-1)
        Next
        Session("user_id") = userID
        'If Not HttpContext.Current.Request.Cookies("CartID").Value = "" Then
        '    Dim myCookie As HttpCookie = New HttpCookie(strCartID)
        '    myCookie.Expires = DateTime.Now.AddDays(-1D)
        '    Response.Cookies.Add(myCookie)
        'End If
    End Sub
End Class
