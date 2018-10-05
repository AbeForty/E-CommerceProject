
Imports System.Data.SqlClient

Partial Class dashboard
    Inherits System.Web.UI.Page

    Protected Sub ddlShippingStatus_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim strSQLUpdateShipping As String
        Dim cmdCheckProduct As SqlCommand
        Dim shippingStatus = CType(sender, DropDownList).SelectedItem.Value
        Dim strConnectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString
        Dim conn As New SqlConnection(strConnectionString)
        Try
            strSQLUpdateShipping = "Update CartLine Set ShippingId = @shippingID  WHERE CartLine.CartID = @cartID and CartLine.ProductID = @productID"
            Dim shippingIDParam As New SqlParameter("@shippingID", shippingStatus)
            Dim cartIDParam As New SqlParameter("@cartID", CType(CType(sender, DropDownList).NamingContainer.FindControl("hdFieldCartID"), HiddenField).Value)
            Dim productIDParam As New SqlParameter("@productID", CType(CType(sender, DropDownList).NamingContainer.FindControl("hdFieldProductID"), HiddenField).Value)
            cmdCheckProduct = New SqlCommand(strSQLUpdateShipping, conn)
            cmdCheckProduct.Parameters.Add(shippingIDParam)
            cmdCheckProduct.Parameters.Add(cartIDParam)
            cmdCheckProduct.Parameters.Add(productIDParam)
            conn.Open()
            cmdCheckProduct.ExecuteNonQuery()
            conn.Close()
        Catch existsex As Exception
            'Response.Redirect("products.aspx")
        End Try
    End Sub
    Protected Sub ddlShippingStatus_DataBound(sender As Object, e As EventArgs)
        Dim strSQLCheckShipping As String
        Dim cmdCheckShipping As SqlCommand
        Dim drShipping As SqlDataReader
        Dim strConnectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString
        Dim conn As New SqlConnection(strConnectionString)
        Dim conn2 As New SqlConnection(strConnectionString)
        Try
            strSQLCheckShipping = "SELECT ShippingId FROM CartLine WHERE CartLine.CartID = @cartID and CartLine.ProductID = @productID"
            Dim cartIDParam As New SqlParameter("@cartID", CType(CType(sender, DropDownList).NamingContainer.FindControl("hdFieldCartID"), HiddenField).Value)
            Dim productIDParam As New SqlParameter("@productID", CType(CType(sender, DropDownList).NamingContainer.FindControl("hdFieldProductID"), HiddenField).Value)
            cmdCheckShipping = New SqlCommand(strSQLCheckShipping, conn)
            cmdCheckShipping.Parameters.Add(productIDParam)
            cmdCheckShipping.Parameters.Add(cartIDParam)
            conn.Open()
            drShipping = cmdCheckShipping.ExecuteReader()
            If drShipping.Read() Then
                CType(sender, DropDownList).ClearSelection()
                CType(sender, DropDownList).Items.FindByValue(drShipping.Item("ShippingID")).Selected = True
            End If
            conn.Close()
        Catch existsex As Exception
            'Response.Redirect("products.aspx")
        End Try
    End Sub

    Private Sub dashboard_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("user_id") And Session("user_id") <> Nothing Then
        Else
            Response.Redirect("login.aspx?ReturnTo=" & HttpContext.Current.Request.Url.AbsoluteUri)
        End If
        Dim strSQLInsights As String
        Dim cmdInsights As SqlCommand
        Dim drInsights As SqlDataReader
        Dim strConnectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString
        Dim conn As New SqlConnection(strConnectionString)
        Try
            strSQLInsights = "SELECT COUNT(CARTLINE.ID) as 'UnitsSold', SUM([Products].PRICE * CartLine.Quantity) as 'MoneyMade' FROM CartLine, [Products] WHERE Products.UserID = @userID and CartLine.ProductID = Products.ProductID"
            Dim userIDParam As New SqlParameter("@userID", Session("user_id"))
            cmdInsights = New SqlCommand(strSQLInsights, conn)
            cmdInsights.Parameters.Add(userIDParam)
            conn.Open()
            drInsights = cmdInsights.ExecuteReader()
            If drInsights.Read() Then
                lblMoneyMade.Text = "Number of Units Sold: " & drInsights.Item("UnitsSold")
                lblNumberOfItemsSold.Text = "Money Made: $" & drInsights.Item("MoneyMade")
            Else
                lblMoneyMade.Text = "Number of Units Sold: " & "0"
                lblNumberOfItemsSold.Text = "Money Made: $" & "0"
                noOrder1.Visible = True
                noOrder2.Visible = True
                noOrder3.Visible = True
            End If
            conn.Close()
        Catch existsex As Exception
            lblMoneyMade.Text = "Number of Units Sold: " & "0"
            lblNumberOfItemsSold.Text = "Money Made: $" & "0"
            noOrder1.Visible = True
            noOrder2.Visible = True
            noOrder3.Visible = True
            'Response.Redirect("products.aspx")
        End Try
    End Sub
End Class
