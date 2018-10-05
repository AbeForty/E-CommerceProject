Imports System.Data
Imports System.Data.SqlClient

Partial Class login
    Inherits System.Web.UI.Page

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim password = ""
        Try
            Dim userId As Integer = 0
            Dim userName = ""
            Dim connUser As SqlConnection
            connUser = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
            Dim strSQL = "Select * From [Users] Where Email = @email"
            Dim drUser As SqlDataReader
            Dim cmdUser As SqlCommand
            Dim emailParam As New SqlParameter("@email", txtEmail.Text)
            connUser.Open()
            cmdUser = New SqlCommand(strSQL, connUser)
            cmdUser.Parameters.Add(emailParam)
            drUser = cmdUser.ExecuteReader()
            If drUser.Read() Then
                userId = Trim(drUser("Id"))
                userName = Trim(drUser("Name"))
                password = Trim(drUser("Password"))
            Else
                lblError.Text = "Email or Password incorrect"
                lblError.Visible = True
            End If
            connUser.Close()
            If loginreg.VerifyPassword(txtPassword.Text, password) Then
                Session("user_id") = userId
                Session("user_name") = userName
                If Request.QueryString.Count = 0 Then
                    Response.Redirect("index.aspx")
                Else
                    Response.Redirect(Request.QueryString("ReturnTo"))
                End If
            Else
                    lblError.Text = "Email or Password incorrect"
                lblError.Visible = True
            End If
        Catch ex As Exception
            lblError.Text = "A server error has occurred. Please try again later."
            lblError.Visible = True
        End Try
    End Sub
End Class
