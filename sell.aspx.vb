
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class sell
    Inherits System.Web.UI.Page
    Dim categoryID As Integer = 0
    Dim subcategoryID As Integer = 0
    Dim platformID As Integer = 0
    Dim imageURL As String = ""
    Dim publisherID As Integer = 0
    Dim developerID As Integer = 0
    Protected Sub btnSell_Click(sender As Object, e As EventArgs) Handles btnSell.Click
        Try
            If ddlProduct.SelectedItem.Text = "Add new item" Then
                If FileUploadControl.HasFile Then
                    Try
                        Dim fileName As String = Path.GetFileName(FileUploadControl.FileName)
                        FileUploadControl.SaveAs(Server.MapPath("~/product-images/") + fileName)
                        imageURL = "product-images/" + fileName
                    Catch ex As Exception
                        lblError.Text += "Image upload failed" + " <br />"
                        Exit Sub
                    End Try
                Else
                    imageURL = "product-images/NoPoster.jpg"
                End If
                If numberOfSelectedItems(platformChkLst) > 0 And txtPlatform.Text = "" Then
                    For i As Integer = 0 To selectedItems(platformChkLst).Count - 1
                        sellFunction(selectedItems(platformChkLst)(i))
                    Next
                ElseIf numberOfSelectedItems(platformChkLst) = 0 And txtPlatform.Text <> "" Then
                    sellFunction(0)
                End If
            Else
                If FileUploadControl.HasFile Then
                    Try
                        Dim fileName As String = Path.GetFileName(FileUploadControl.FileName)
                        FileUploadControl.SaveAs(Server.MapPath("~/product-images/") + fileName)
                        imageURL = "product-images/" + fileName
                    Catch ex As Exception
                        lblError.Text += "Image upload failed" + " <br />"
                        Exit Sub
                    End Try
                Else
                End If
                If chkUpdateAll.Checked = True Then
                    If numberOfSelectedItems(platformChkLst) > 0 And txtPlatform.Text = "" Then
                        For i As Integer = 0 To selectedItems(platformChkLst).Count - 1
                            updateFunction(selectedItems(platformChkLst)(i))
                        Next
                    ElseIf numberOfSelectedItems(platformChkLst) = 0 And txtPlatform.Text <> "" Then
                        updateFunction(0)
                    End If
                Else
                    updateFunction(platformID)
                End If
            End If
            Response.Redirect("index.aspx")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub sellFunction(platform As Integer)
        If clsValidator.validateEmptyOrNot(txtItemName.Text, "Item").Count = 0 AndAlso clsValidator.validatePrice(txtPrice.Text).Count = 0 AndAlso (clsValidator.validateEmptyOrNot(txtCategory.Text, "Category").Count = 0 Or clsValidator.validateEmptyOrNot(ddlCategory.SelectedItem.Text, "Category").Count = 0) AndAlso (clsValidator.validateEmptyOrNot(txtPlatform.Text, "Platform").Count = 0 Or numberOfSelectedItems(platformChkLst) > 0) Then
            If txtCategory.Text = "" Then
                categoryID = ddlCategory.SelectedValue
            ElseIf txtCategory.Text <> "" And categoryID = 0 Then
                Try
                    Dim connProduct As SqlConnection
                    connProduct = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
                    Dim strSQL = "INSERT INTO [Category] output INSERTED.CategoryID VALUES (@name, 0)"
                    Dim cmdProduct As SqlCommand
                    Dim nameParam As New SqlParameter("@name", txtCategory.Text)
                    connProduct.Open()
                    cmdProduct = New SqlCommand(strSQL, connProduct)
                    cmdProduct.Parameters.Add(nameParam)
                    cmdProduct.CommandType = CommandType.Text
                    categoryID = cmdProduct.ExecuteScalar()
                    connProduct.Close()
                Catch ex As Exception
                    'lblError.Text = ex.Message
                    If ex.Message.Contains("String or binary data would be truncated") Then
                        lblError.Text = "One or more fields is too long in length."
                    Else
                        lblError.Text = "A server error has occurred. Please try again later."
                    End If
                    lblError.Visible = True
                End Try
            End If
            If txtDeveloper.Text = "" Then
                developerID = ddlDeveloper.SelectedValue
            ElseIf txtDeveloper.Text <> "" And developerID = 0 Then
                Try
                    Dim connProduct As SqlConnection
                    connProduct = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
                    Dim strSQL = "INSERT INTO [Developer] output INSERTED.ID VALUES (@name)"
                    Dim cmdProduct As SqlCommand
                    Dim nameParam As New SqlParameter("@name", txtDeveloper.Text)
                    connProduct.Open()
                    cmdProduct = New SqlCommand(strSQL, connProduct)
                    cmdProduct.Parameters.Add(nameParam)
                    cmdProduct.CommandType = CommandType.Text
                    developerID = cmdProduct.ExecuteScalar()
                    connProduct.Close()
                Catch ex As Exception
                    'lblError.Text = ex.Message
                    If ex.Message.Contains("String or binary data would be truncated") Then
                        lblError.Text = "One or more fields is too long in length."
                    Else
                        lblError.Text = "A server error has occurred. Please try again later."
                    End If
                    lblError.Visible = True
                End Try
            End If
            If txtPublisher.Text = "" Then
                publisherID = ddlPublisher.SelectedValue
            ElseIf txtPublisher.Text <> "" And publisherID = 0 Then
                Try
                    Dim connProduct As SqlConnection
                    connProduct = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
                    Dim strSQL = "INSERT INTO [Publisher] output INSERTED.ID VALUES (@name)"
                    Dim cmdProduct As SqlCommand
                    Dim nameParam As New SqlParameter("@name", txtPublisher.Text)
                    connProduct.Open()
                    cmdProduct = New SqlCommand(strSQL, connProduct)
                    cmdProduct.Parameters.Add(nameParam)
                    cmdProduct.CommandType = CommandType.Text
                    publisherID = cmdProduct.ExecuteScalar()
                    connProduct.Close()
                Catch ex As Exception
                    'lblError.Text = ex.Message
                    If ex.Message.Contains("String or binary data would be truncated") Then
                        lblError.Text = "One or more fields is too long in length."
                    Else
                        lblError.Text = "A server error has occurred. Please try again later."
                    End If
                    lblError.Visible = True
                End Try
            End If
            If txtSubcategory.Text = "" Then
                subcategoryID = ddlSubcategory.SelectedValue
            ElseIf txtSubcategory.Text <> "" And subcategoryID = 0 Then
                Try
                    Dim connProduct As SqlConnection
                    connProduct = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
                    Dim strSQL = "INSERT INTO [Category] output INSERTED.CategoryID VALUES (@name, @categoryID)"
                    Dim cmdProduct As SqlCommand
                    Dim nameParam As New SqlParameter("@name", txtSubcategory.Text)
                    Dim categoryParam As New SqlParameter("@categoryID", categoryID)
                    connProduct.Open()
                    cmdProduct = New SqlCommand(strSQL, connProduct)
                    cmdProduct.Parameters.Add(nameParam)
                    cmdProduct.Parameters.Add(categoryParam)
                    cmdProduct.CommandType = CommandType.Text
                    subcategoryID = cmdProduct.ExecuteScalar()
                    connProduct.Close()
                Catch ex As Exception
                    'lblError.Text = ex.Message
                    If ex.Message.Contains("String or binary data would be truncated") Then
                        lblError.Text = "One or more fields is too long in length."
                    Else
                        lblError.Text = "A server error has occurred. Please try again later."
                    End If
                    lblError.Visible = True
                End Try
            End If
            If txtPlatform.Text = "" Then
                platformID = platform
            Else
                Try
                    Dim connProduct As SqlConnection
                    connProduct = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
                    Dim strSQL = "INSERT INTO [Platform] output INSERTED.ID VALUES (@name)"
                    Dim cmdProduct As SqlCommand
                    Dim nameParam As New SqlParameter("@name", txtPlatform.Text)
                    connProduct.Open()
                    cmdProduct = New SqlCommand(strSQL, connProduct)
                    cmdProduct.Parameters.Add(nameParam)
                    cmdProduct.CommandType = CommandType.Text
                    platformID = cmdProduct.ExecuteScalar()
                    connProduct.Close()
                Catch ex As Exception
                    'lblError.Text = ex.Message
                    If ex.Message.Contains("String or binary data would be truncated") Then
                        lblError.Text = "One or more fields is too long in length."
                    Else
                        lblError.Text = "A server error has occurred. Please try again later."
                    End If
                    lblError.Visible = True
                End Try
            End If
            Try
                Dim connProduct As SqlConnection
                connProduct = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
                Dim strSQL = "INSERT INTO [Products] VALUES (@name, @price, @categoryID, 1, 0, @userID, @imageURL, @platformID, @description, @gameRatingID, @releaseDate, @developerID, @publisherID)"
                Dim cmdProduct As SqlCommand
                Dim nameParam As New SqlParameter("@name", txtItemName.Text)
                Dim priceParam As New SqlParameter("@price", txtPrice.Text)
                Dim categoryParam As New SqlParameter("@categoryID", subcategoryID)
                Dim platformParam As New SqlParameter("@platformID", platformID)
                Dim userParam As New SqlParameter("@userID", Session("user_id"))
                Dim imageParam As New SqlParameter("@imageURL", imageURL)
                Dim descriptionParam As New SqlParameter("@description", txtDescription.Text)
                Dim developerParam As New SqlParameter("@developerID", developerID)
                Dim publisherParam As New SqlParameter("@publisherID", publisherID)
                Dim gameRatingParam As New SqlParameter("@gameRatingID", ddlGameRating.SelectedValue)
                Dim releaseDateParam As New SqlParameter("@releaseDate", txtDate.Text)
                connProduct.Open()
                cmdProduct = New SqlCommand(strSQL, connProduct)
                cmdProduct.Parameters.Add(nameParam)
                cmdProduct.Parameters.Add(priceParam)
                cmdProduct.Parameters.Add(categoryParam)
                cmdProduct.Parameters.Add(platformParam)
                cmdProduct.Parameters.Add(userParam)
                cmdProduct.Parameters.Add(imageParam)
                cmdProduct.Parameters.Add(descriptionParam)
                cmdProduct.Parameters.Add(developerParam)
                cmdProduct.Parameters.Add(publisherParam)
                cmdProduct.Parameters.Add(gameRatingParam)
                cmdProduct.Parameters.Add(releaseDateParam)
                cmdProduct.CommandType = CommandType.Text
                cmdProduct.ExecuteNonQuery()
                connProduct.Close()
            Catch ex As Exception
                'lblError.Text = ex.Message
                If ex.Message.Contains("String or binary data would be truncated") Then
                    lblError.Text = "One or more fields is too long in length."
                Else
                    lblError.Text = "A server error has occurred. Please try again later."
                End If
                lblError.Visible = True
            End Try
        Else
            For Each itemError As String In clsValidator.validateEmptyOrNot(txtItemName.Text, "Item")
                lblError.Text += itemError + " <br />"
            Next
            For Each itemError As String In clsValidator.validatePrice(txtPrice.Text)
                lblError.Text += itemError + " <br />"
            Next
        End If
    End Sub
    Private Sub updateFunction(platform As Integer)
        If clsValidator.validateEmptyOrNot(txtItemName.Text, "Item").Count = 0 AndAlso clsValidator.validatePrice(txtPrice.Text).Count = 0 AndAlso (clsValidator.validateEmptyOrNot(txtCategory.Text, "Category").Count = 0 Or clsValidator.validateEmptyOrNot(ddlCategory.SelectedItem.Text, "Category").Count = 0) AndAlso (clsValidator.validateEmptyOrNot(txtPlatform.Text, "Platform").Count = 0 Or numberOfSelectedItems(platformChkLst) > 0) Then
            If txtCategory.Text = "" Then
                categoryID = ddlCategory.SelectedValue
            ElseIf txtCategory.Text <> "" And categoryID = 0 Then
                Try
                    Dim connProduct As SqlConnection
                    connProduct = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
                    Dim strSQL = "INSERT INTO [Category] output INSERTED.CategoryID VALUES (@name, 0)"
                    Dim cmdProduct As SqlCommand
                    Dim nameParam As New SqlParameter("@name", txtCategory.Text)
                    connProduct.Open()
                    cmdProduct = New SqlCommand(strSQL, connProduct)
                    cmdProduct.Parameters.Add(nameParam)
                    cmdProduct.CommandType = CommandType.Text
                    categoryID = cmdProduct.ExecuteScalar()
                    connProduct.Close()
                Catch ex As Exception
                    'lblError.Text = ex.Message
                    If ex.Message.Contains("String or binary data would be truncated") Then
                        lblError.Text = "One or more fields is too long in length."
                    Else
                        lblError.Text = "A server error has occurred. Please try again later."
                    End If
                    lblError.Visible = True
                End Try
            End If
            If txtSubcategory.Text = "" Then
                subcategoryID = ddlSubcategory.SelectedValue
            ElseIf txtSubcategory.Text <> "" And subcategoryID = 0 Then
                Try
                    Dim connProduct As SqlConnection
                    connProduct = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
                    Dim strSQL = "INSERT INTO [Category] output INSERTED.CategoryID VALUES (@name, @categoryID)"
                    Dim cmdProduct As SqlCommand
                    Dim nameParam As New SqlParameter("@name", txtSubcategory.Text)
                    Dim categoryParam As New SqlParameter("@categoryID", categoryID)
                    connProduct.Open()
                    cmdProduct = New SqlCommand(strSQL, connProduct)
                    cmdProduct.Parameters.Add(nameParam)
                    cmdProduct.Parameters.Add(categoryParam)
                    cmdProduct.CommandType = CommandType.Text
                    subcategoryID = cmdProduct.ExecuteScalar()
                    connProduct.Close()
                Catch ex As Exception
                    'lblError.Text = ex.Message
                    If ex.Message.Contains("String or binary data would be truncated") Then
                        lblError.Text = "One or more fields is too long in length."
                    Else
                        lblError.Text = "A server error has occurred. Please try again later."
                    End If
                    lblError.Visible = True
                End Try
            End If
            If txtDeveloper.Text = "" Then
                developerID = ddlDeveloper.SelectedValue
            ElseIf txtDeveloper.Text <> "" And developerID = 0 Then
                Try
                    Dim connProduct As SqlConnection
                    connProduct = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
                    Dim strSQL = "INSERT INTO [Developer] output INSERTED.ID VALUES (@name)"
                    Dim cmdProduct As SqlCommand
                    Dim nameParam As New SqlParameter("@name", txtDeveloper.Text)
                    connProduct.Open()
                    cmdProduct = New SqlCommand(strSQL, connProduct)
                    cmdProduct.Parameters.Add(nameParam)
                    cmdProduct.CommandType = CommandType.Text
                    developerID = cmdProduct.ExecuteScalar()
                    connProduct.Close()
                Catch ex As Exception
                    'lblError.Text = ex.Message
                    If ex.Message.Contains("String or binary data would be truncated") Then
                        lblError.Text = "One or more fields is too long in length."
                    Else
                        lblError.Text = "A server error has occurred. Please try again later."
                    End If
                    lblError.Visible = True
                End Try
            End If
            If txtPublisher.Text = "" Then
                publisherID = ddlPublisher.SelectedValue
            ElseIf txtPublisher.Text <> "" And publisherID = 0 Then
                Try
                    Dim connProduct As SqlConnection
                    connProduct = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
                    Dim strSQL = "INSERT INTO [Publisher] output INSERTED.ID VALUES (@name)"
                    Dim cmdProduct As SqlCommand
                    Dim nameParam As New SqlParameter("@name", txtPublisher.Text)
                    connProduct.Open()
                    cmdProduct = New SqlCommand(strSQL, connProduct)
                    cmdProduct.Parameters.Add(nameParam)
                    cmdProduct.CommandType = CommandType.Text
                    publisherID = cmdProduct.ExecuteScalar()
                    connProduct.Close()
                Catch ex As Exception
                    'lblError.Text = ex.Message
                    If ex.Message.Contains("String or binary data would be truncated") Then
                        lblError.Text = "One or more fields is too long in length."
                    Else
                        lblError.Text = "A server error has occurred. Please try again later."
                    End If
                    lblError.Visible = True
                End Try
            End If
            If txtPlatform.Text = "" Then
                platformID = platform
            Else
                Try
                    Dim connProduct As SqlConnection
                    connProduct = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
                    Dim strSQL = "INSERT INTO [Platform] output INSERTED.ID VALUES (@name)"
                    Dim cmdProduct As SqlCommand
                    Dim nameParam As New SqlParameter("@name", txtPlatform.Text)
                    connProduct.Open()
                    cmdProduct = New SqlCommand(strSQL, connProduct)
                    cmdProduct.Parameters.Add(nameParam)
                    cmdProduct.CommandType = CommandType.Text
                    platformID = cmdProduct.ExecuteScalar()
                    connProduct.Close()
                Catch ex As Exception
                    'lblError.Text = ex.Message
                    If ex.Message.Contains("String or binary data would be truncated") Then
                        lblError.Text = "One or more fields is too long in length."
                    Else
                        lblError.Text = "A server error has occurred. Please try again later."
                    End If
                    lblError.Visible = True
                End Try
            End If
            Try
                Dim connProduct As SqlConnection
                connProduct = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
                Dim strSQL As String = ""
                If chkUpdateAll.Checked = False Then
                    strSQL = "Update PRODUCTS Set ProductName = @name, Price = @price, CategoryId = @categoryID, Featured = 1, OnSale = 0, UserID = @userID, ImageURL = @imageURL, Description = @description, DeveloperID = @developerID, PublisherID = @publisherID, ESRBRatingID = @gameRatingID, ReleaseDate = @releaseDate where Products.ProductID = @productID"
                Else
                    strSQL = "Update PRODUCTS Set ProductName = @name, Price = @price, CategoryId = @categoryID, Featured = 1, OnSale = 0, UserID = @userID, ImageURL = @imageURL, PlatformID = @platformID, Description = @description, DeveloperID = @developerID, PublisherID = @publisherID, ESRBRatingID = @gameRatingID, ReleaseDate = @releaseDate where ProductName = @productName"
                End If
                Dim cmdProduct As SqlCommand
                Dim nameParam As New SqlParameter("@name", txtItemName.Text)
                Dim priceParam As New SqlParameter("@price", txtPrice.Text)
                Dim categoryParam As New SqlParameter("@categoryID", subcategoryID)
                Dim platformParam As New SqlParameter("@platformID", platformID)
                Dim userParam As New SqlParameter("@userID", Session("user_id"))
                Dim imageParam As New SqlParameter("@imageURL", imageURL)
                Dim descriptionParam As New SqlParameter("@description", txtDescription.Text)
                Dim developerParam As New SqlParameter("@developerID", developerID)
                Dim publisherParam As New SqlParameter("@pubisherID", publisherID)
                Dim gameRatingParam As New SqlParameter("@gameRatingID", ddlGameRating.SelectedValue)
                Dim releaseDateParam As New SqlParameter("@releaseDate", txtDate.Text)
                Dim productIDParam As SqlParameter
                Dim productNameParam As SqlParameter
                cmdProduct = New SqlCommand(strSQL, connProduct)
                If chkUpdateAll.Checked = False Then
                    productIDParam = New SqlParameter("@productID", ddlProduct.SelectedValue)
                    cmdProduct.Parameters.Add(productIDParam)
                Else
                    productNameParam = New SqlParameter("@productName", txtItemName.Text)
                    cmdProduct.Parameters.Add(productNameParam)
                End If
                connProduct.Open()
                cmdProduct.Parameters.Add(nameParam)
                cmdProduct.Parameters.Add(priceParam)
                cmdProduct.Parameters.Add(categoryParam)
                cmdProduct.Parameters.Add(platformParam)
                cmdProduct.Parameters.Add(userParam)
                cmdProduct.Parameters.Add(imageParam)
                cmdProduct.Parameters.Add(descriptionParam)
                cmdProduct.Parameters.Add(developerParam)
                cmdProduct.Parameters.Add(publisherParam)
                cmdProduct.Parameters.Add(gameRatingParam)
                cmdProduct.Parameters.Add(releaseDateParam)
                cmdProduct.CommandType = CommandType.Text
                cmdProduct.ExecuteNonQuery()
                connProduct.Close()
            Catch ex As Exception
                'lblError.Text = ex.Message
                If ex.Message.Contains("String or binary data would be truncated") Then
                    lblError.Text = "One or more fields is too long in length."
                Else
                    lblError.Text = "A server error has occurred. Please try again later."
                End If
                lblError.Visible = True
            End Try
        Else
            For Each itemError As String In clsValidator.validateEmptyOrNot(txtItemName.Text, "Item")
                lblError.Text += itemError + " <br />"
            Next
            For Each itemError As String In clsValidator.validatePrice(txtPrice.Text)
                lblError.Text += itemError + " <br />"
            Next
        End If
    End Sub
    Private Function numberOfSelectedItems(lst As CheckBoxList) As Integer
        Dim count = 0
        For i As Integer = 0 To lst.Items.Count - 1
            If lst.Items(i).Selected Then
                count += 1
            End If
        Next
        Return count
    End Function
    Private Function selectedItems(lst As CheckBoxList) As List(Of Integer)
        Dim myList As New List(Of Integer)
        For i As Integer = 0 To lst.Items.Count - 1
            If lst.Items(i).Selected Then
                myList.Add(lst.Items(i).Value)
            End If
        Next
        Return myList
    End Function
    Private Sub sell_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("user_id") And Session("user_id") <> Nothing Then
        Else
            Response.Redirect("login.aspx?ReturnTo=" & HttpContext.Current.Request.Url.AbsoluteUri)
        End If
        If txtImageURL.Text <> "" Then
            imageURL = txtImageURL.Text
        End If
    End Sub
    Protected Sub ddlProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProduct.SelectedIndexChanged
        If ddlProduct.SelectedItem.Text = "Add New item" Then

        Else
            Try
                Dim connProduct As SqlConnection
                connProduct = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
                Dim strSQL = "Select *, (SELECT CategoryName  FROM Category Where CategoryID = (SELECT Category.Parent FROM Category WHERE CategoryID = Products.CategoryID)) As 'ParentCategoryName' FROM [PRODUCTS], [Category] WHERE Category.CategoryID = Products.CategoryID and Products.ProductID = @productID;"
                Dim cmdProduct As SqlCommand
                Dim drProduct As SqlDataReader
                Dim productIDParam As New SqlParameter("@productID", ddlProduct.SelectedValue)
                connProduct.Open()
                cmdProduct = New SqlCommand(strSQL, connProduct)
                cmdProduct.Parameters.Add(productIDParam)
                cmdProduct.CommandType = CommandType.Text
                drProduct = cmdProduct.ExecuteReader()
                If drProduct.Read() Then
                    txtItemName.Text = drProduct.Item("ProductName")
                    txtPrice.Text = drProduct.Item("Price")
                    txtDescription.Text = drProduct.Item("Description")
                    platformID = drProduct.Item("PlatformID")
                    txtImageURL.Text = drProduct.Item("ImageURL")
                    ddlCategory.ClearSelection()
                    ddlCategory.Items.FindByText(drProduct.Item("ParentCategoryName")).Selected = True
                    categoryID = ddlCategory.SelectedValue
                    ddlDeveloper.ClearSelection()
                    ddlDeveloper.Items.FindByValue(drProduct.Item("DeveloperID")).Selected = True
                    developerID = ddlDeveloper.SelectedValue
                    ddlPublisher.ClearSelection()
                    ddlPublisher.Items.FindByValue(drProduct.Item("PublisherID")).Selected = True
                    publisherID = ddlPublisher.SelectedValue
                    ddlSubcategory.ClearSelection()
                    ddlSubcategory.Items.FindByText(drProduct.Item("CategoryName")).Selected = True
                    subcategoryID = ddlSubcategory.SelectedValue
                    chkUpdateAll.Visible = True
                    txtDate.Text = Date.Parse(drProduct.Item("ReleaseDate"))
                End If
                connProduct.Close()
            Catch ex As Exception
                'lblError.Text = ex.Message
                lblError.Text = "A server error has occurred. Please try again later."
                lblError.Visible = True
            End Try
            Try
                Dim connProduct As SqlConnection
                connProduct = New SqlConnection(ConfigurationManager.ConnectionStrings("OnlineStoreConnectionString").ConnectionString)
                Dim strSQL = "SELECT [Platform].Name FROM [Products], [Platform] WHERE [Products].PlatformID = [Platform].Id and [Products].ProductName = @productName"
                Dim cmdProduct As SqlCommand
                Dim drProduct As SqlDataReader
                Dim productNameParam As New SqlParameter("@productName", txtItemName.Text)
                connProduct.Open()
                cmdProduct = New SqlCommand(strSQL, connProduct)
                cmdProduct.Parameters.Add(productNameParam)
                cmdProduct.CommandType = CommandType.Text
                drProduct = cmdProduct.ExecuteReader()
                While drProduct.Read()
                    platformChkLst.Items.FindByText(drProduct.Item("Name")).Selected = True
                End While
                connProduct.Close()
            Catch ex As Exception
                'lblError.Text = ex.Message
                lblError.Text = "A server error has occurred. Please try again later."
                lblError.Visible = True
            End Try
        End If
    End Sub
End Class
