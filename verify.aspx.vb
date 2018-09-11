
Partial Class verify
    Inherits System.Web.UI.Page
    Private Sub verify_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("verifyAge") <> Nothing Then
            For i As Integer = 1 To 99
                ddlAge.Items.Add(i)
            Next
            ddlAge.Items.Add("100+")
            If Session("currentAge") <> Nothing Then
                If Session("currentAge") > Session("verifyAge") Then
                    Session("verified") = True
                    Session("verifyAge") = Nothing
                    Response.Redirect(Request.QueryString("ReturnTo"))
                Else
                    Response.Redirect("index.aspx")
                End If
            End If
        Else
                Try
                Response.Redirect(Request.QueryString("ReturnTo"))
            Catch ex As Exception
                Response.Redirect("index.aspx")
            End Try
        End If
    End Sub

    Private Sub btnVerify_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
        Session("currentAge") = Integer.Parse(ddlAge.SelectedItem.Text.Replace("+", ""))
        If Integer.Parse(ddlAge.SelectedItem.Text.Replace("+", "")) > Session("verifyAge") Then
            Session("verified") = True
            Session("verifyAge") = Nothing
            Response.Redirect(Request.QueryString("ReturnTo"))
        Else
            Response.Redirect("index.aspx")
        End If
    End Sub
End Class
