
Imports System.Data
Imports System.Data.SqlClient

Partial Class register
    Inherits System.Web.UI.Page

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        If loginreg.validateEmail(txtEmail.Text).Count = 0 AndAlso loginreg.validatePassword(txtPassword.Text, txtPasswordConfirm.Text).Count = 0 AndAlso loginreg.validateName(txtName.Text).Count = 0 Then
            Try
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
                connUser.Close()
                If drUser.Read() Then
                    lblError.Text += "Email already exists"
                    lblError.Visible = True
                Else
                End If
            Catch ex As Exception
                lblError.Text = "A server error has occurred. Please try again later."
                lblError.Visible = True
            End Try
            Try
                Dim connUser As SqlConnection
                connUser = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
                Dim strSQL = "INSERT INTO [Users] output INSERTED.Id VALUES (@email, @password, @name)"
                Dim cmdUser As SqlCommand
                Dim emailParam As New SqlParameter("@email", txtEmail.Text)
                Dim passwordParam As New SqlParameter("@password", loginreg.HashPassword(txtPassword.Text))
                Dim nameParam As New SqlParameter("@name", txtName.Text)
                connUser.Open()
                cmdUser = New SqlCommand(strSQL, connUser)
                cmdUser.Parameters.Add(emailParam)
                cmdUser.Parameters.Add(passwordParam)
                cmdUser.Parameters.Add(nameParam)
                cmdUser.CommandType = CommandType.Text
                Dim ID = cmdUser.ExecuteScalar()
                connUser.Close()
                Session("user_name") = txtName.Text
                Session("user_id") = ID
                Response.Redirect("index.aspx")
            Catch ex As Exception
                lblError.Text = "A server error has occurred. Please try again later."
                lblError.Visible = True
            End Try
        Else
            For Each itemError As String In loginreg.validateEmail(txtEmail.Text)
                lblError.Text += itemError + " <br />"
            Next
            For Each itemError As String In loginreg.validatePassword(txtPassword.Text, txtPasswordConfirm.Text)
                lblError.Text += itemError + " <br />"
            Next
            lblError.Visible = True
        End If
    End Sub

    Private Sub register_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("user_id") And Session("user_id") <> Nothing Then
            Response.Redirect("index.aspx")
        Else

        End If
    End Sub
End Class
