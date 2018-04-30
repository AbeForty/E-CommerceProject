
Imports System.Net.Mail
Partial Class receipt
    Inherits System.Web.UI.Page
    Dim strCartID As String
    Private Sub thankyou_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim CookieBack As HttpCookie
            CookieBack = HttpContext.Current.Request.Cookies("CartID")
            strCartID = CookieBack.Value
            DSSummary.SelectCommand = "Select * From CartLine Where CartID = '" & strCartID & "'"
            DSOrderHead.SelectCommand = "Select * From OrderHead Where CartId = '" & strCartID & "'"
            DSOrderHead.DeleteCommand = "Delete * From CartLine Where CartId = '" & strCartID & "'"
            'For i As Integer = 1 To HttpContext.Current.Request.Cookies.Count - 1
            '    HttpContext.Current.Request.Cookies.Remove(HttpContext.Current.Request.Cookies(i).Name)
            'Next
        Catch ex As Exception
            Response.Redirect("index.aspx")
        End Try
    End Sub
    Private Sub receipt_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim myCookies() = Request.Cookies.AllKeys
        For Each cookie As String In myCookies
            Response.Cookies(cookie).Expires = DateTime.Now.AddDays(-1)
        Next
        'If Not HttpContext.Current.Request.Cookies("CartID").Value = "" Then
        '    Dim myCookie As HttpCookie = New HttpCookie(strCartID)
        '    myCookie.Expires = DateTime.Now.AddDays(-1D)
        '    Response.Cookies.Add(myCookie)
        'End If
    End Sub
End Class
