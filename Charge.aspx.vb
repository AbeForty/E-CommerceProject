
Imports System.Data.SqlClient

Partial Class Charge
    Inherits System.Web.UI.Page
    Protected amountTotal As Integer
    Protected strCartID As String
    Private Sub Charge_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Request.Form("stripeToken") IsNot Nothing Then
            If Session("user_id") And Session("user_id") <> Nothing Then

            Else
            End If
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
            Dim customers = New Stripe.StripeCustomerService()
            Dim charges = New Stripe.StripeChargeService()
            Dim customer = customers.Create(New Stripe.StripeCustomerCreateOptions With {
                .Email = Request.Form("stripeEmail"),
                .SourceToken = Request.Form("stripeToken")
            })
            Dim charge = charges.Create(New Stripe.StripeChargeCreateOptions With {
                .Amount = amountTotal,
                .Description = ".",
                .Currency = "usd",
                .CustomerId = customer.Id
            })
            Console.WriteLine(charge)
            Response.Redirect("receipt.aspx")
        End If
    End Sub
End Class
