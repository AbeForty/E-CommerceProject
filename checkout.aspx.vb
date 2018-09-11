Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail
Partial Class checkout
    Inherits System.Web.UI.Page
    Dim strCartID As String
    Private Sub checkout_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("user_id") And Session("user_id") <> Nothing Then
        Else
            Response.Redirect("login.aspx")
        End If
        Try
            Dim CookieBack As HttpCookie
            CookieBack = HttpContext.Current.Request.Cookies("CartID")
            strCartID = CookieBack.Value
            Dim connProduct As SqlConnection
            connProduct = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
            Dim strSQL As String = "Select SUM((Price)*(Quantity)) as Subtotal FROM CartLine, Products Where Products.ProductID = CartLine.ProductID and CartID=@cartID"
            Dim drProduct As SqlDataReader
            Dim cmdProduct As SqlCommand
            Dim cartIDParam As New SqlParameter("@cartID", strCartID)
            connProduct.Open()
            cmdProduct = New SqlCommand(strSQL, connProduct)
            cmdProduct.Parameters.Add(cartIDParam)
            drProduct = cmdProduct.ExecuteReader(CommandBehavior.CloseConnection)
            If drProduct.Read() Then
                lblSubtotal.Text = FormatCurrency(drProduct.Item("Subtotal"))
            End If
            'lblTotal.Text = lblSubtotal.Text
            lblTax.Text = FormatCurrency(Double.Parse(lblSubtotal.Text.Replace("$", "") * (0.0875)))
            lblTotal.Text = FormatCurrency(Double.Parse(lblSubtotal.Text.Replace("$", "") * (1 + 0.0875)))
            'DSCheckoutDetails.ConnectionString = ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString
            'DSCheckoutDetails.SelectCommand = "Select SUM((Price) * (Quantity)) As Subtotal From CartLine Where CartID = '" & strCartID & "'"
            'Response.Write(DSCheckoutDetails.SelectCommand)
            'For i As Integer = Today.Year.ToString() To 2037
            '    ddlCreditCardExpYear.Items.Add(i)
            'Next
        Catch ex As Exception
            Response.Redirect("index.aspx")
        End Try
    End Sub
    Protected Sub btnCheckout_Click(sender As Object, e As EventArgs) Handles btnCheckout.Click
        If validateInfo() = True Then
            Dim exists = False
            Try
                Dim connCheckOrderExists As SqlConnection
                connCheckOrderExists = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
                Dim strCheckOrderExistsSQL As String = "SELECT * FROM ORDERHEAD WHERE ORDERHEAD.ID = @cartID"
                Dim cartIDParam As New SqlParameter("@cartID", strCartID)
                Dim cmdCheckOrderExits As SqlCommand
                Dim drOrderCheckExists As SqlDataReader
                connCheckOrderExists.Open()
                cmdCheckOrderExits = New SqlCommand(strCheckOrderExistsSQL, connCheckOrderExists)
                cmdCheckOrderExits.Parameters.Add(cartIDParam)
                drOrderCheckExists = cmdCheckOrderExits.ExecuteReader()
                If drOrderCheckExists.Read() Then
                    exists = True
                End If
            Catch ex As Exception

            End Try
            If exists = False Then
                Try
                    Dim connInsert As SqlConnection
                    connInsert = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
                    Dim strInsertOrderHeadSQL As String = "INSERT INTO OrderHead Values (@cartID, @subtotal, @shippingCost, @tax, @total, @addressID)"
                    Dim strInsertSQL As String
                    Dim addressID As Integer = 0
                    If Session("user_id") And Session("user_id") <> Nothing Then
                        strInsertSQL = "INSERT INTO AddressInfo output Inserted.Id Values (@billingFirstName, @billingLastName, @billingStreet, @billingCity, @billingState, @billingZip, @firstName, @LastName, @street, @city, @state, @zip, @phone, @userID)"
                    Else
                        strInsertSQL = "INSERT INTO AddressInfo output Inserted.Id Values (@billingFirstName, @billingLastName, @billingStreet, @billingCity, @billingState, @billingZip, @firstName, @LastName, @street, @city, @state, @zip, @phone)"
                    End If
                    Dim cartIDParam As New SqlParameter("@cartID", strCartID)
                    Dim billingFirstNameParam As New SqlParameter("@billingFirstName", txtBillingFirstName.Text)
                    Dim billingLastNameParam As New SqlParameter("@billingLastName", txtBillingLastName.Text)
                    Dim billingStreetParam As New SqlParameter("@billingStreet", txtBillingStreet.Text)
                    Dim billingCityParam As New SqlParameter("@billingCity", txtBillingCity.Text)
                    Dim billingStateParam As New SqlParameter("@billingState", ddlBillingState.Text)
                    Dim billingZipParam As New SqlParameter("@billingZip", txtBillingZip.Text)
                    Dim firstNameParam As New SqlParameter("@firstName", txtFirstName.Text)
                    Dim lastNameParam As New SqlParameter("@lastName", txtLastName.Text)
                    Dim streetParam As New SqlParameter("@street", txtStreet.Text)
                    Dim cityParam As New SqlParameter("@city", txtCity.Text)
                    Dim stateParam As New SqlParameter("@state", ddlState.Text)
                    Dim zipParam As New SqlParameter("@zip", txtZip.Text)
                    Dim phoneParam As New SqlParameter("@phone", txtPhone.Text)
                    Dim subtotalParam As New SqlParameter("@subtotal", lblSubtotal.Text.Replace("$", ""))
                    Dim shippingCostParam As SqlParameter
                    If lblShippingCost.Text = "FREE" Or lblShippingCost.Text = "0.00" Then
                        shippingCostParam = New SqlParameter("@shippingCost", 0)
                    Else
                        shippingCostParam = New SqlParameter("@shippingCost", lblShippingCost.Text.Replace("$", ""))
                    End If
                    Dim taxParam As New SqlParameter("@tax", lblTax.Text.Replace("$", ""))
                    Dim totalParam As New SqlParameter("@total", lblTotal.Text.Replace("$", ""))
                    Dim userIDParam As SqlParameter
                    If Session("user_id") And Session("user_id") <> Nothing Then
                        userIDParam = New SqlParameter("@userID", Session("user_id"))
                    ElseIf chkSaveInfo.Checked = False Or Session("user_id") = Nothing Then
                        'userIDParam = New SqlParameter("@userID", 0)
                    End If
                    Dim cmdInsert As SqlCommand
                    Dim cmdInsertOrderHead As SqlCommand
                    connInsert.Open()
                    cmdInsert = New SqlCommand(strInsertSQL, connInsert)
                    cmdInsertOrderHead = New SqlCommand(strInsertOrderHeadSQL, connInsert)
                    cmdInsert.Parameters.Add(billingFirstNameParam)
                    cmdInsert.Parameters.Add(billingLastNameParam)
                    cmdInsert.Parameters.Add(billingStreetParam)
                    cmdInsert.Parameters.Add(billingCityParam)
                    cmdInsert.Parameters.Add(billingStateParam)
                    cmdInsert.Parameters.Add(billingZipParam)
                    cmdInsert.Parameters.Add(firstNameParam)
                    cmdInsert.Parameters.Add(lastNameParam)
                    cmdInsert.Parameters.Add(streetParam)
                    cmdInsert.Parameters.Add(cityParam)
                    cmdInsert.Parameters.Add(stateParam)
                    cmdInsert.Parameters.Add(zipParam)
                    cmdInsert.Parameters.Add(phoneParam)
                    If Session("user_id") And Session("user_id") <> Nothing Then
                        cmdInsert.Parameters.Add(userIDParam)
                    Else
                    End If
                    cmdInsertOrderHead.Parameters.Add(cartIDParam)
                    cmdInsertOrderHead.Parameters.Add(subtotalParam)
                    cmdInsertOrderHead.Parameters.Add(shippingCostParam)
                    cmdInsertOrderHead.Parameters.Add(taxParam)
                    cmdInsertOrderHead.Parameters.Add(totalParam)
                    If ddlAddressInfo.SelectedItem.Text = "Manually type info" Then
                        addressID = cmdInsert.ExecuteScalar()
                    Else
                        addressID = ddlAddressInfo.SelectedValue
                    End If
                    Dim addressParam As New SqlParameter("@addressID", addressID)
                    cmdInsertOrderHead.Parameters.Add(addressParam)
                    'If chkSaveInfo.Checked = True Then
                    cmdInsertOrderHead.ExecuteNonQuery()
                    'End If
                    connInsert.Close()
                Catch ex As Exception
                    lblCheckoutError.Visible = True
                    'Response.Write(ex.Message)
                    'Response.Write("We  were unable to process your order. Please try again later.")
                    'Response.Write("We were unable to process your order. You suck.")
                    Exit Sub
                End Try
                Response.Redirect("pay.aspx")
            End If
        Else
                'Response.Redirect("receipt.aspx")
            End If
    End Sub
    Protected Sub ddlState_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlState.SelectedIndexChanged
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
        If txtCity.Text <> "" AndAlso System.Text.RegularExpressions.Regex.IsMatch(txtCity.Text, "^[A-Za-z\s]+$") Then
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
        'If txtEmail.Text <> "" AndAlso Regex.IsMatch(txtEmail.Text, "^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$") Then
        '    lblEmailError.Visible = False
        'Else
        '    numberOfErrors += 1
        '    lblEmailError.Visible = True
        'End If
        If txtBillingCity.Text <> "" AndAlso System.Text.RegularExpressions.Regex.IsMatch(txtBillingCity.Text, "^[A-Za-z\s]+$") Then
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
        'If ddlCreditCardType.SelectedItem.Value = "American Express" Then
        '    If Regex.IsMatch(txtCreditCardNumber.Text, amexRegEx) Then
        '        lblCreditNumberError.Visible = False
        '    Else
        '        numberOfErrors += 1
        '        lblCreditNumberError.Visible = True
        '    End If
        'ElseIf ddlCreditCardType.SelectedItem.Value = "MasterCard" Then
        '    If Regex.IsMatch(txtCreditCardNumber.Text, mastercardRegEx) Then
        '        lblCreditNumberError.Visible = False
        '    Else
        '        numberOfErrors += 1
        '        lblCreditNumberError.Visible = True
        '    End If
        'ElseIf ddlCreditCardType.SelectedItem.Value = "Visa" Then
        '    If Regex.IsMatch(txtCreditCardNumber.Text, visaRegEx) Then
        '        lblCreditNumberError.Visible = False
        '    Else
        '        numberOfErrors += 1
        '        lblCreditNumberError.Visible = True
        '    End If
        'ElseIf ddlCreditCardType.SelectedItem.Value = "Discover" Then
        '    If Regex.IsMatch(txtCreditCardNumber.Text, discoverRegEx) Then
        '        lblCreditNumberError.Visible = False
        '    Else
        '        numberOfErrors += 1
        '        lblCreditNumberError.Visible = True
        '    End If
        'End If
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
    Protected Sub ddlAddressInfo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAddressInfo.SelectedIndexChanged
        Try
            Dim connAddress As SqlConnection
            connAddress = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
            Dim strSQL = "Select  * From AddressInfo Where Id = @addressID"
            Dim drAddress As SqlDataReader
            Dim cmdAddress As SqlCommand
            Dim addressParam As New SqlParameter("@addressID", CType(sender, DropDownList).SelectedValue)
            connAddress.Open()
            cmdAddress = New SqlCommand(strSQL, connAddress)
            cmdAddress.Parameters.Add(addressParam)
            drAddress = cmdAddress.ExecuteReader(CommandBehavior.CloseConnection)
            If drAddress.Read() Then
                txtBillingCity.Text = drAddress.Item("BillingCity")
                txtBillingFirstName.Text = drAddress.Item("BillingFirstName")
                txtBillingLastName.Text = drAddress.Item("BillingLastName")
                txtBillingStreet.Text = drAddress.Item("BillingStreet")
                txtBillingZip.Text = drAddress.Item("BillingZip")
                ddlBillingState.ClearSelection()
                ddlBillingState.Items.FindByText(drAddress.Item("BillingState")).Selected = True
                txtCity.Text = drAddress.Item("ShippingCity")
                txtFirstName.Text = drAddress.Item("ShippingFirstName")
                txtLastName.Text = drAddress.Item("ShippingLastName")
                txtPhone.Text = drAddress.Item("PhoneNumber")
                txtStreet.Text = drAddress.Item("ShippingStreet")
                ddlState.ClearSelection()
                ddlState.Items.FindByText(drAddress.Item("ShippingState")).Selected = True
                txtZip.Text = drAddress.Item("ShippingZip")
            End If
            If ddlState.SelectedItem.Text.Contains("California") Then
                lblShippingCost.Text = "0.00"
                lblTax.Text = FormatCurrency(Double.Parse(lblSubtotal.Text.Replace("$", "") * (0.0875)))
                lblTotal.Text = FormatCurrency(Double.Parse(lblSubtotal.Text.Replace("$", "") * (1 + 0.0875)))
            Else
                lblShippingCost.Text = "5.99"
                lblTotal.Text = FormatCurrency(Double.Parse(lblSubtotal.Text.Replace("$", "") + Double.Parse(lblShippingCost.Text)))
            End If
            'DSCheckoutDetails.ConnectionString = ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString
            'DSCheckoutDetails.SelectCommand = "Select SUM((Price) * (Quantity)) As Subtotal From CartLine Where CartID = '" & strCartID & "'"
            'Response.Write(DSCheckoutDetails.SelectCommand)
            'For i As Integer = Today.Year.ToString() To 2037
            '    ddlCreditCardExpYear.Items.Add(i)
            'Next
        Catch ex As Exception

        End Try
    End Sub
End Class
