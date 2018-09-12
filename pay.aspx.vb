Imports System.Data.SqlClient
Imports System.Web.Configuration
Partial Class paycard
    Inherits System.Web.UI.Page
    Protected stripePublishableKey As String = WebConfigurationManager.AppSettings("StripePublishableKey")
    Protected strCartID As String
    Protected amountTotal As Integer
    Protected email As String

    Private Sub paycard_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim CookieBack As HttpCookie
            CookieBack = HttpContext.Current.Request.Cookies("CartID")
            strCartID = CookieBack.Value
        Catch ex As Exception
            Response.Redirect("index.aspx")
        End Try
        If Session("user_id") And Session("user_id") <> Nothing Then
            Try
                Dim connCheckTotal As SqlConnection
                connCheckTotal = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
                Dim strCheckTotalSQL As String = "SELECT * FROM ORDERHEAD, AddressInfo, [Users] WHERE ORDERHEAD.ID = @cartID and OrderHead.AddressID = AddressInfo.Id and AddressInfo.UserID = [Users].Id"
                Dim cartIDParam As New SqlParameter("@cartID", strCartID)
                Dim cmdCheckTotal As SqlCommand
                Dim drCheckTotal As SqlDataReader
                connCheckTotal.Open()
                cmdCheckTotal = New SqlCommand(strCheckTotalSQL, connCheckTotal)
                cmdCheckTotal.Parameters.Add(cartIDParam)
                drCheckTotal = cmdCheckTotal.ExecuteReader()
                If drCheckTotal.Read() Then
                    amountTotal = (drCheckTotal.Item("Total") * 100)
                    email = drCheckTotal.Item("Email")
                End If
            Catch ex As Exception

            End Try
        Else
            email = ""
        End If
    End Sub
End Class
