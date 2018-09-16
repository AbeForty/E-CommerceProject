
Imports System.Data.SqlClient

Partial Class orders
    Inherits System.Web.UI.Page

    Private Sub orders_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("user_id") And Session("user_id") <> Nothing Then
            DSOrderList.SelectCommand = "SELECT Distinct CartID, OrderHead.Subtotal as Subtotal, OrderHead.Shipping as ShippingCost, OrderHead.Tax as Tax, OrderHead.Total as Total FROM CARTLINE, OrderHead Where OrderHead.Id = CartLine.CartID and OrderHead.AddressID = (SELECT [AddressInfo].Id from [AddressInfo] where [AddressInfo].UserID = @userID) and CartLine.Final = 1;"
            DSOrderList.SelectParameters.Add("userID", Session("user_id"))
            Dim strSQLOrders As String
            Dim cmdOrders As SqlCommand
            Dim drOrders As SqlDataReader
            Dim strConnectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString
            Dim conn As New SqlConnection(strConnectionString)
            Try
                strSQLOrders = "SELECT COUNT(OrderHead.ID) as 'NumberOfOrders' FROM [OrderHead], [AddressInfo] WHERE OrderHead.AddressID = AddressInfo.Id and AddressInfo.UserID = @userID"
                Dim userIDParam As New SqlParameter("userID", Session("user_id"))
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
        Else
            If Not String.IsNullOrEmpty(Request.QueryString("cartID")) Then
                DSOrderList.SelectCommand = "SELECT Distinct CartID, OrderHead.Subtotal as Subtotal, OrderHead.Shipping as ShippingCost, OrderHead.Tax as Tax, OrderHead.Total as Total FROM CARTLINE, OrderHead Where OrderHead.Id = CartLine.CartID and CartLine.CartID = @cartID and CartLine.Final = 1;"
                DSOrderList.SelectParameters.Add("cartID", Request.QueryString("cartID"))
            Else
                Response.Redirect("lookup.aspx")
            End If
            'Response.Redirect("login.aspx")
        End If
    End Sub
End Class
