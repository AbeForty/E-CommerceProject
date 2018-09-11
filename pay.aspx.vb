Imports System.Data.SqlClient
Imports System.Web.Configuration
Partial Class paycard
    Inherits System.Web.UI.Page
    Protected stripePublishableKey As String = WebConfigurationManager.AppSettings("StripePublishableKey")
    Protected strCartID As String
    Protected amountTotal As Integer

    Private Sub paycard_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim CookieBack As HttpCookie
            CookieBack = HttpContext.Current.Request.Cookies("CartID")
            strCartID = CookieBack.Value
        Catch ex As Exception
            Response.Redirect("index.aspx")
        End Try
        Try
            Dim connCheckTotal As SqlConnection
            connCheckTotal = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
            Dim strCheckTotalSQL As String = "SELECT * FROM ORDERHEAD WHERE ORDERHEAD.ID = @cartID"
            Dim cartIDParam As New SqlParameter("@cartID", strCartID)
            Dim cmdheckTotal As SqlCommand
            Dim drheckTotal As SqlDataReader
            connCheckTotal.Open()
            cmdheckTotal = New SqlCommand(strCheckTotalSQL, connCheckTotal)
            cmdheckTotal.Parameters.Add(cartIDParam)
            drheckTotal = cmdheckTotal.ExecuteReader()
            If drheckTotal.Read() Then
                amountTotal = (drheckTotal.Item("Total") * 100)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
