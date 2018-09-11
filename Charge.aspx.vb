
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
                Dim drCheckTotal As SqlDataReader
                connCheckTotal.Open()
                cmdheckTotal = New SqlCommand(strCheckTotalSQL, connCheckTotal)
                cmdheckTotal.Parameters.Add(cartIDParam)
                drCheckTotal = cmdheckTotal.ExecuteReader()
                If drCheckTotal.Read() Then
                    amountTotal = (drCheckTotal.Item("Total") * 100)
                End If
            Catch ex As Exception

            End Try
            Dim stripeID As String = ""
            Dim customers = New Stripe.StripeCustomerService()
            Dim customer
            Try
                Dim connCheckStripeID As SqlConnection
                connCheckStripeID = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
                Dim strCheckStripeIDSQL As String = "SELECT StripeID FROM Users WHERE [Users].Id = @userID"
                Dim userIDParam As New SqlParameter("@userID", Session("user_id"))
                Dim cmdheckTotal As SqlCommand
                Dim drCheckStripeID As SqlDataReader
                connCheckStripeID.Open()
                cmdheckTotal = New SqlCommand(strCheckStripeIDSQL, connCheckStripeID)
                cmdheckTotal.Parameters.Add(userIDParam)
                drCheckStripeID = cmdheckTotal.ExecuteReader()
                If drCheckStripeID.Read() Then
                    If Not IsDBNull(drCheckStripeID.Item("StripeID")) Then
                        stripeID = drCheckStripeID.Item("StripeID")
                    Else
                        customer = customers.Create(New Stripe.StripeCustomerCreateOptions With {
                            .Email = Request.Form("stripeEmail"),
                            .SourceToken = Request.Form("stripeToken")
                        })
                    End If
                End If
            Catch ex As Exception
                customer = customers.Create(New Stripe.StripeCustomerCreateOptions With {
                        .Email = Request.Form("stripeEmail"),
                        .SourceToken = Request.Form("stripeToken")
                    })
            End Try
            Dim charges = New Stripe.StripeChargeService()
            If String.IsNullOrEmpty(stripeID) Then
                Dim charge = charges.Create(New Stripe.StripeChargeCreateOptions With {
                .Amount = amountTotal,
                .Description = ".",
                .Currency = "usd",
                .CustomerId = customer.Id
            })
                Try
                    Dim connUpdateStripeID As SqlConnection
                    connUpdateStripeID = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
                    Dim strUpdateStripeIDSQL As String = "Update [Users] Set StripeID = @stripeID Where Id = @userID"
                    Dim stripeIDParam As New SqlParameter("@stripeID", customer.Id)
                    Dim userIDParam As New SqlParameter("@userID", Session("user_id"))
                    Dim cmdUpdateStripeID As SqlCommand
                    connUpdateStripeID.Open()
                    cmdUpdateStripeID = New SqlCommand(strUpdateStripeIDSQL, connUpdateStripeID)
                    cmdUpdateStripeID.Parameters.Add(stripeIDParam)
                    cmdUpdateStripeID.Parameters.Add(userIDParam)
                    cmdUpdateStripeID.ExecuteNonQuery()
                Catch ex As Exception

                End Try
            Else
                Dim charge = charges.Create(New Stripe.StripeChargeCreateOptions With {
                .Amount = amountTotal,
                .Description = ".",
                .Currency = "usd",
                .CustomerId = stripeID
            })
            End If
            'Console.WriteLine(Charge)
            Response.Redirect("receipt.aspx")
            End If
    End Sub
End Class
