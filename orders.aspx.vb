
Imports System.Data.SqlClient

Partial Class orders
    Inherits System.Web.UI.Page

    Private Sub orders_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("user_id") And Session("user_id") <> Nothing Then
        Else
            Response.Redirect("login.aspx")
        End If
        Dim strSQLOrders As String
        Dim cmdOrders As SqlCommand
        Dim drOrders As SqlDataReader
        Dim strConnectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString
        Dim conn As New SqlConnection(strConnectionString)
        Try
            strSQLOrders = "SELECT COUNT(CARTLINE.ID) as 'UnitsSold', SUM([Products].PRICE * CartLine.Quantity) as 'MoneyMade' FROM CartLine, [Products] WHERE Products.UserID = @userID and CartLine.ProductID = Products.ProductID"
            Dim userIDParam As New SqlParameter("@userID", Session("user_id"))
            cmdOrders = New SqlCommand(strSQLOrders, conn)
            cmdOrders.Parameters.Add(userIDParam)
            conn.Open()
            drOrders = cmdOrders.ExecuteReader()
            If drOrders.Read() Then
            Else
                noOrder1.Visible = True
            End If
            conn.Close()
        Catch existsex As Exception
            noOrder1.Visible = True
            'Response.Redirect("products.aspx")
        End Try
    End Sub
End Class
