
Partial Class OnlineStore
    Inherits System.Web.UI.MasterPage
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Response.Redirect("/products.aspx?search_query=" + txtSearch.Text)
    End Sub
End Class

