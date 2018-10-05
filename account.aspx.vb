
Imports System.Data.SqlClient

Partial Class account
    Inherits System.Web.UI.Page
    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Dim password = ""
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
                userName = Trim(drUser("Name"))
                password = Trim(drUser("Password"))
            Else
                lblError.Text = "Email doesn't exist"
                lblError.Visible = True
            End If
            connUser.Close()
            If loginreg.validateEmail(txtEmail.Text).Count = 0 AndAlso loginreg.validateName(txtUserName.Text).Count = 0 Then
                If loginreg.VerifyPassword(txtOldPassword.Text, password) Then
                    If txtNewPassword.Text <> "" Or txtConfirmPassword.Text <> "" Then
                        If loginreg.validatePassword(txtNewPassword.Text, txtConfirmPassword.Text).Count = 0 Then
                        Else
                            lblError.Text = "Passwords do not match."
                            lblError.Visible = True
                            Exit Sub
                        End If
                    End If

                    Try
                        Dim connUpdate As SqlConnection
                        connUpdate = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
                        Dim strUpdateSQL = "UPDATE [USERS] SET Name = @name, Email = @email, password = @password  Where Id = @user_id"
                        'Dim drUpdate As SqlDataReader
                        Dim cmdUpdate As SqlCommand
                        connUpdate.Open()
                        Dim nameUpdateParam = New SqlParameter("@name", txtUserName.Text)
                        Dim emailUpdateParam = New SqlParameter("@email", txtEmail.Text)
                        Dim userIDParam = New SqlParameter("@user_id", Session("user_id"))
                        Dim passwordUpdateParam = New SqlParameter("@password", loginreg.HashPassword(txtNewPassword.Text))
                        cmdUpdate = New SqlCommand(strUpdateSQL, connUpdate)
                        cmdUpdate.Parameters.Add(nameUpdateParam)
                        cmdUpdate.Parameters.Add(emailUpdateParam)
                        cmdUpdate.Parameters.Add(userIDParam)
                        cmdUpdate.Parameters.Add(passwordUpdateParam)
                        cmdUpdate.ExecuteNonQuery()
                        connUpdate.Close()
                        Response.Redirect("index.aspx")
                    Catch ex As Exception
                        'lblError.Text = ex.Message
                        lblError.Text = "Account update failed."
                        lblError.Visible = True
                    End Try
                Else
                    lblError.Text = "Your current password is incorrect."
                    lblError.Visible = True
                End If
            End If
        Catch ex As Exception
            'lblError.Text = ex.Message
            lblError.Text = "A server error has occurred. Please try again later."
            lblError.Visible = True
        End Try
    End Sub

    Private Sub account_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("user_id") And Session("user_id") <> Nothing Then
        Else
            Response.Redirect("login.aspx?ReturnTo=" & HttpContext.Current.Request.Url.AbsoluteUri)
        End If
        Try
            Dim connUser As SqlConnection
            connUser = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
            Dim strSQL = "Select * From [Users] Where Id = @userID"
            Dim drUser As SqlDataReader
            Dim cmdUser As SqlCommand
            Dim userIDParam As New SqlParameter("@userID", Session("user_id"))
            connUser.Open()
            cmdUser = New SqlCommand(strSQL, connUser)
            cmdUser.Parameters.Add(userIDParam)
            drUser = cmdUser.ExecuteReader()
            If drUser.Read() Then
                txtUserName.Text = Trim(drUser("Name"))
                txtEmail.Text = Trim(drUser("Email"))
            Else
                lblError.Text = "Email doesn't exist"
                lblError.Visible = True
            End If
            connUser.Close()
        Catch ex As Exception
            'lblError.Text = ex.Message
            lblError.Text = "A server error has occurred. Please try again later."
            lblError.Visible = True
        End Try
    End Sub
End Class
