Imports Microsoft.VisualBasic

Public MustInherit Class clsValidator
    Public Shared Function validateEmptyOrNot(input As String, controlType As String) As List(Of String)
        Dim errors As New List(Of String)
        If input = "" And controlType.Contains("Item") Then
            errors.Add("Please enter or select an item name")
        ElseIf input = "" And controlType.Contains("Platform") Then
            errors.Add("Please enter or select an platform name")
        ElseIf input = "" And controlType.Contains("Subcategory") Then
            errors.Add("Please enter or select an subcategory name")
        ElseIf input = "" And controlType.Contains("Category") Then
            errors.Add("Please enter or select an category name")
        ElseIf input = "" And controlType.Contains("Price") Then
            errors.Add("Please enter a price")
        ElseIf input = "" And controlType.Contains("Review") Then
            errors.Add("Please enter a review")
        End If
        Return errors
    End Function
    Public Shared Function validatePrice(input As String) As List(Of String)
        Dim errors As New List(Of String)
        If input <> "" Then
            If Regex.IsMatch(input, "^\d+(\.\d{1,2})?$") Then
            Else
                errors.Add("Please enter a valid price")
            End If
        End If
        Return errors
    End Function
    Public Shared Function CheckNull(ByVal fieldValue As String) As Boolean
        If fieldValue.Equals(DBNull.Value) Then
            Return False
        Else
            Return True
        End If
    End Function
End Class
