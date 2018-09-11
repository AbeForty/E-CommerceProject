
Imports System.Data.SqlClient

Partial Class index
    Inherits System.Web.UI.Page

    Private Sub index_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("user_id") And Session("user_id") <> Nothing Then
        Else
            Response.Redirect("login.aspx")
        End If
    End Sub
    Public Function getPlatformShortName(platformID As Integer) As String
        Dim strSQLPlatformName As String
        Dim cmdPlatformName As SqlCommand
        Dim drPlatformName As SqlDataReader
        Dim strConnectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString
        Dim conn As New SqlConnection(strConnectionString)
        Try
            strSQLPlatformName = "SELECT [Platform].ShortName FROM [Platform] WHERE [Platform].Id = @platformID"
            Dim platformIDParam As New SqlParameter("@platformID", platformID)
            cmdPlatformName = New SqlCommand(strSQLPlatformName, conn)
            cmdPlatformName.Parameters.Add(platformIDParam)
            conn.Open()
            drPlatformName = cmdPlatformName.ExecuteReader()
            If drPlatformName.Read() Then
                Return " (" & drPlatformName.Item("ShortName") & ")"
            End If
            conn.Close()
        Catch ex As Exception
            Return ""
        End Try
        Return ""
    End Function
End Class
