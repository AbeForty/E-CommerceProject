
Partial Class lookup
    Inherits System.Web.UI.Page

    Protected Sub btnLookup_Click(sender As Object, e As EventArgs) Handles btnLookup.Click
        Response.Redirect("orders.aspx?CartID=" & txtOrderNumber.Text)
    End Sub

    Private Sub lookup_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("user_id") And Session("user_id") <> Nothing Then
            Response.Redirect("orders.aspx")
        Else
        End If
    End Sub
End Class
