Imports Microsoft.VisualBasic

Public MustInherit Class loginreg
    Private Shared Function GetRandomSalt() As String
        Return BCrypt.Net.BCrypt.GenerateSalt(12)
    End Function

    Public Shared Function HashPassword(ByVal password As String) As String
        Return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt())
    End Function

    Public Shared Function VerifyPassword(ByVal password As String, ByVal correctHash As String) As Boolean
        Return BCrypt.Net.BCrypt.Verify(password, correctHash)
    End Function
    Public Shared Function validateEmail(email As String) As List(Of String)
        Dim errors As New List(Of String)
        If email <> "" AndAlso Regex.IsMatch(email, "^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$") Then
            Return errors
        Else
            errors.Add("Email is invalid")
            Return errors
        End If
    End Function
    Public Shared Function validatePassword(password As String, confirmPassword As String) As List(Of String)
        Dim errors As New List(Of String)
        If password.Length >= 8 Then
            If password = confirmPassword Then
                Return errors
            Else
                errors.Add("Passwords do not match")
                Return errors
            End If
        Else
            errors.Add("Password must be at least 8 characters")
            Return errors
        End If
    End Function
    Public Shared Function validateName(name As String) As List(Of String)
        Dim errors As New List(Of String)
        If name.Length >= 3 Then
            Return errors
        Else
            errors.Add("Name must be at least three characters long")
            Return errors
        End If
    End Function
End Class
