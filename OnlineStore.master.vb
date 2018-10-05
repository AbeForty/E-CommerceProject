
Imports System.Data.SqlClient

Partial Class OnlineStore
    Inherits System.Web.UI.MasterPage
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If Not String.IsNullOrEmpty(txtSearch.Text) Then
            Response.Redirect("products.aspx?search_query=" + txtSearch.Text)
        End If
    End Sub

    Private Sub OnlineStore_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("user_id") And Session("user_id") <> Nothing Then
            lblLogout.Text = "Logout"
            lblUserName.Text = "<a href = 'account.aspx'>" & Session("user_name") & "</a>"
        Else
            lblLogout.Text = "Login"
            lblUserName.Text = "Guest"
        End If
        Dim strCartID = ""
        If Not HttpContext.Current.Request.Cookies("CartID") Is Nothing Then
            Dim CookieBack As HttpCookie
            CookieBack = HttpContext.Current.Request.Cookies("CartID")
            strCartID = CookieBack.Value
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
                    lblCartItems.Text = "View Cart (" & drNumberOfItems.Item("NumberOfRows") & ")"
                End If
                conn.Close()
            Catch ex As Exception
                lblCartItems.Text = "View Cart (0)"
            End Try
        Else
            lblCartItems.Text = "View Cart (0)"
        End If

    End Sub

    Private Sub lblLogout_Click(sender As Object, e As EventArgs) Handles lblLogout.Click
        Session.Clear()
        Response.Redirect("login.aspx")
    End Sub
End Class

