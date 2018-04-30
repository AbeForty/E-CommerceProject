﻿Imports System.Net
Imports System.IO
Partial Class payment
    Inherits System.Web.UI.Page

    Private Sub payment_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        'test server
        Dim post_url As String = "https://test.authorize.net/gateway/transact.dll"
        ' name/value pairs
        Dim post_values As New Dictionary(Of String, String)
        post_values.Add("x_login", "5G4t4y8DCb")  ' your login ID
        post_values.Add("x_tran_key", "48K55txEn4cqQ3Fw")  ' your transaction key
        post_values.Add("x_delim_data", "TRUE")
        post_values.Add("x_delim_char", ",")
        post_values.Add("x_relay_response", "FALSE")
        post_values.Add("x_type", "AUTH_CAPTURE")
        post_values.Add("x_method", "CC")
        post_values.Add("x_card_num", Long.Parse(txtCreditNumber.Text))
        post_values.Add("x_exp_date", "0619")
        post_values.Add("x_amount", Double.Parse(txtAmount.Text))
        post_values.Add("x_description", "Sample Transaction")
        post_values.Add("x_first_name", "John")
        post_values.Add("x_last_name", "Doe")
        post_values.Add("x_address", "1234 Street")
        post_values.Add("x_state", "WA")
        post_values.Add("x_zip", "98004")

        ' converts them to the proper format "x_login=username&x_tran_key=a1B2c3D4"
        Dim post_string As String = ""
        For Each field As KeyValuePair(Of String, String) In post_values
            post_string &= field.Key & "=" & HttpUtility.UrlEncode(field.Value) & "&"
        Next
        post_string = Left(post_string, Len(post_string) - 1)

        ' create an HttpWebRequest object to communicate with Authorize.net
        Dim objRequest As HttpWebRequest = CType(WebRequest.Create(post_url), HttpWebRequest)
        objRequest.Method = "POST"
        objRequest.ContentLength = post_string.Length
        objRequest.ContentType = "application/x-www-form-urlencoded"

        ' send the data in a stream
        Dim myWriter As StreamWriter = Nothing
        myWriter = New StreamWriter(objRequest.GetRequestStream())
        myWriter.Write(post_string)
        myWriter.Close()

        ' create an HttpWebRequest object to process the returned values in a stream and convert it into a string
        Dim objResponse As HttpWebResponse = CType(objRequest.GetResponse(), HttpWebResponse)
        Dim responseStream As New StreamReader(objResponse.GetResponseStream())
        Dim post_response As String = responseStream.ReadToEnd()
        responseStream.Close()

        ' break the response string into an array
        Dim response_array As Array = Split(post_response, post_values("x_delim_char"), -1)

        ' the results are output to the screen in the form of an html numbered list.
        Response.Write("<OL>")
        For Each value In response_array
            Response.Write("<LI>" & value & "&nbsp;</LI>" & vbCrLf)
            'resultSpan.InnerHtml += "<LI>" & value & "&nbsp;</LI>" & vbCrLf
        Next
        Response.Write("</OL>")
    End Sub
End Class
