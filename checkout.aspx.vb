Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail
Partial Class checkout
    Inherits System.Web.UI.Page
    Dim strCartID As String
    Private Sub checkout_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim CookieBack As HttpCookie
            CookieBack = HttpContext.Current.Request.Cookies("CartID")
            strCartID = CookieBack.Value
            Dim connProduct As SqlConnection
            connProduct = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
            Dim strSQL = "Select  SUM((Price) * (Quantity)) As Subtotal From CartLine Where CartID = '" & strCartID & "'"
            Dim drProduct As SqlDataReader
            Dim cmdProduct As SqlCommand
            connProduct.Open()
            cmdProduct = New SqlCommand(strSQL, connProduct)
            drProduct = cmdProduct.ExecuteReader(CommandBehavior.CloseConnection)
            If drProduct.Read() Then
                lblSubtotal.Text = FormatCurrency(drProduct.Item("Subtotal"))
            End If
            lblTotal.Text = lblSubtotal.Text
            'DSCheckoutDetails.ConnectionString = ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString
            'DSCheckoutDetails.SelectCommand = "Select SUM((Price) * (Quantity)) As Subtotal From CartLine Where CartID = '" & strCartID & "'"
            'Response.Write(DSCheckoutDetails.SelectCommand)
            For i As Integer = Today.Year.ToString() To 2037
                ddlCreditCardExpYear.Items.Add(i)
            Next
        Catch ex As Exception
            Response.Redirect("index.aspx")
        End Try
    End Sub
    Protected Sub btnCheckout_Click(sender As Object, e As EventArgs) Handles btnCheckout.Click

        If validateInfo() = True Then
            Try
                Dim connInsert As SqlConnection
                connInsert = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
                Dim strInsertSQL = "INSERT INTO OrderHead  Values ('" & strCartID & "','" & txtBillingFirstName.Text & "','" & txtBillingLastName.Text & "','" & txtBillingStreet.Text & "','" & txtBillingCity.Text & "','" & ddlBillingState.Text & "','" & txtBillingZip.Text & "','" & txtFirstName.Text & "','" & txtLastName.Text & "','" & txtStreet.Text & "','" & txtCity.Text & "','" & ddlState.Text & "','" & txtZip.Text & "','" & txtPhone.Text & "','" & txtEmail.Text & "','" & txtCreditCardNumber.Text & "','" & ddlCreditCardType.Text & "','" & ddlCreditCardExpMonth.Text & "','" & ddlCreditCardExpYear.Text & "','" & lblSubtotal.Text.Replace("$", "") & "','" & lblShippingCost.Text & "','" & lblTax.Text.Replace("$", "") & "','" & lblTotal.Text.Replace("$", "") & "')"
                Dim drInsert As SqlDataReader
                Dim cmdInsert As SqlCommand
                connInsert.Open()
                cmdInsert = New SqlCommand(strInsertSQL, connInsert)
                drInsert = cmdInsert.ExecuteReader()
            Catch ex As Exception
                Response.Write(ex.Message)
                Response.Write("We were unable to process your order. Please try again.")
                Response.Write("We were unable to process your order. You suck.")
                Exit Sub
            End Try
            Response.Redirect("receipt.aspx")
        Else
            Response.Redirect("receipt.aspx")
        End If
    End Sub
    Protected Sub ddlState_TextChanged(sender As Object, e As EventArgs) Handles ddlState.TextChanged
        If ddlState.SelectedItem.Text.Contains("California") Then
            lblShippingCost.Text = "FREE"
            lblTax.Text = FormatCurrency(Double.Parse(lblSubtotal.Text.Replace("$", "") * (0.0875)))
            lblTotal.Text = FormatCurrency(Double.Parse(lblSubtotal.Text.Replace("$", "") * (1 + 0.0875)))
        Else
            lblShippingCost.Text = "5.99"
            lblTotal.Text = FormatCurrency(Double.Parse(lblSubtotal.Text.Replace("$", "") + Double.Parse(lblShippingCost.Text)))
        End If
    End Sub
    Protected Function validateInfo() As Boolean
        Dim numberOfErrors As Integer = 0
        Dim visaRegEx As String = "^4[0-9]{12}(?:[0-9]{3})?$"
        Dim amexRegEx As String = "^3[47][0-9]{13}$"
        Dim mastercardRegEx As String = "^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$ "
        Dim discoverRegEx As String = "^6(?:011|5[0-9]{2})[0-9]{12}$"
        If txtFirstName.Text <> "" AndAlso System.Text.RegularExpressions.Regex.IsMatch(txtFirstName.Text, "^[A-Za-z]+$") Then
            lblFirstNameError.Visible = False
        Else
            numberOfErrors += 1
            lblFirstNameError.Visible = True
        End If
        If txtLastName.Text <> "" AndAlso System.Text.RegularExpressions.Regex.IsMatch(txtLastName.Text, "^[A-Za-z]+$") Then
            lblLastNameError.Visible = False
        Else
            numberOfErrors += 1
            lblLastNameError.Visible = True
        End If
        If txtStreet.Text <> "" AndAlso System.Text.RegularExpressions.Regex.IsMatch(txtStreet.Text, "\d{1,}(\s{1}\w{1,})(\s{1}?\w{1,})+") Then
            lblStreetError.Visible = False
        Else
            numberOfErrors += 1
            lblStreetError.Visible = True
        End If
        If txtPhone.Text <> "" AndAlso Regex.IsMatch(txtPhone.Text, "((\(\d{3}\))|(\(\d{3}\)-)|(\d{3}-)|(\d{3}))((\d{3}-\d{4})|(\d{3}\d{4}))") Then
            lblPhoneNumberError.Visible = False
        Else
            numberOfErrors += 1
            lblPhoneNumberError.Visible = True
        End If
        If txtCity.Text <> "" AndAlso System.Text.RegularExpressions.Regex.IsMatch(txtCity.Text, "^[A-Za-z]+$") Then
            lblCityError.Visible = False
        Else
            numberOfErrors += 1
            lblCityError.Visible = True
        End If
        If txtZip.Text.Length = 5 Then
            Dim aZip As Long = Long.Parse(txtZip.Text)
            lblZipCodeError.Visible = False
        Else
            numberOfErrors += 1
            lblZipCodeError.Visible = True
        End If
        'End
        If txtBillingFirstName.Text <> "" AndAlso System.Text.RegularExpressions.Regex.IsMatch(txtBillingFirstName.Text, "^[A-Za-z]+$") Then
            lblBillingFirstNameError.Visible = False
        Else
            numberOfErrors += 1
            lblBillingFirstNameError.Visible = True
        End If
        If txtBillingLastName.Text <> "" AndAlso System.Text.RegularExpressions.Regex.IsMatch(txtBillingLastName.Text, "^[A-Za-z]+$") Then
            lblBillingLastNameError.Visible = False
        Else
            numberOfErrors += 1
            lblBillingLastNameError.Visible = True
        End If
        If txtBillingStreet.Text <> "" AndAlso System.Text.RegularExpressions.Regex.IsMatch(txtBillingStreet.Text, "\d{1,}(\s{1}\w{1,})(\s{1}?\w{1,})+") Then
            lblBillingStreetError.Visible = False

        Else
            numberOfErrors += 1
            lblBillingStreetError.Visible = True
        End If
        If txtEmail.Text <> "" AndAlso Regex.IsMatch(txtEmail.Text, "^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$") Then
            lblEmailError.Visible = False
        Else
            numberOfErrors += 1
            lblEmailError.Visible = True
        End If
        If txtBillingCity.Text <> "" AndAlso System.Text.RegularExpressions.Regex.IsMatch(txtBillingCity.Text, "^[A-Za-z]+$") Then
            lblBillingCityError.Visible = False
        Else
            numberOfErrors += 1
            lblBillingCityError.Visible = True
        End If
        If txtBillingZip.Text.Length = 5 Then
            Dim aZip As Long = Long.Parse(txtZip.Text)
            lblBillingZipError.Visible = False
        Else
            numberOfErrors += 1
            lblBillingZipError.Visible = True
        End If
        If ddlCreditCardType.SelectedItem.Value = "American Express" Then
            If Regex.IsMatch(txtCreditCardNumber.Text, amexRegEx) Then
                lblCreditNumberError.Visible = False
            Else
                numberOfErrors += 1
                lblCreditNumberError.Visible = True
            End If
        ElseIf ddlCreditCardType.SelectedItem.Value = "MasterCard" Then
            If Regex.IsMatch(txtCreditCardNumber.Text, mastercardRegEx) Then
                lblCreditNumberError.Visible = False
            Else
                numberOfErrors += 1
                lblCreditNumberError.Visible = True
            End If
        ElseIf ddlCreditCardType.SelectedItem.Value = "Visa" Then
            If Regex.IsMatch(txtCreditCardNumber.Text, visaRegEx) Then
                lblCreditNumberError.Visible = False
            Else
                numberOfErrors += 1
                lblCreditNumberError.Visible = True
            End If
        ElseIf ddlCreditCardType.SelectedItem.Value = "Discover" Then
            If Regex.IsMatch(txtCreditCardNumber.Text, discoverRegEx) Then
                lblCreditNumberError.Visible = False
            Else
                numberOfErrors += 1
                lblCreditNumberError.Visible = True
            End If
        End If
        If numberOfErrors = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Sub chkSameAsBilling_CheckedChanged(sender As Object, e As EventArgs) Handles chkSameAsBilling.CheckedChanged
        If chkSameAsBilling.Checked = True Then
            txtFirstName.Text = txtBillingFirstName.Text
            txtFirstName.Enabled = False
            txtLastName.Text = txtBillingLastName.Text
            txtLastName.Enabled = False
            txtStreet.Text = txtBillingStreet.Text
            txtStreet.Enabled = False
            txtCity.Text = txtBillingCity.Text
            txtCity.Enabled = False
            ddlState.Text = ddlBillingState.Text
            If ddlState.SelectedItem.Text.Contains("California") Then
                lblShippingCost.Text = "0.00"
                lblTax.Text = FormatCurrency(Double.Parse(lblSubtotal.Text.Replace("$", "") * (0.0875)))
                lblTotal.Text = FormatCurrency(Double.Parse(lblSubtotal.Text.Replace("$", "") * (1 + 0.0875)))
            Else
                lblShippingCost.Text = "5.99"
                lblTotal.Text = FormatCurrency(Double.Parse(lblSubtotal.Text.Replace("$", "") + Double.Parse(lblShippingCost.Text)))
            End If
            ddlState.Enabled = False
            txtZip.Text = txtBillingZip.Text
            txtZip.Enabled = False
        Else
            txtFirstName.Text = ""
            txtFirstName.Enabled = True
            txtLastName.Text = ""
            txtLastName.Enabled = True
            txtStreet.Text = ""
            txtStreet.Enabled = True
            txtCity.Text = ""
            txtCity.Enabled = True
            ddlState.Enabled = True
            txtZip.Text = ""
            txtZip.Enabled = True
        End If
    End Sub
End Class
