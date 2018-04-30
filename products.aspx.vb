
Partial Class products
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            If Request.QueryString("MainCatID") <> "" Then
                DSSubCategory.SelectCommand = "Select * From Category Where Parent = " & CInt(Request.QueryString("MainCatID"))
                DSProductList.SelectCommand = "SELECT * FROM [Products], [Category]  WHERE [Products].CategoryId = [Category].CategoryID and Parent = " & CInt(Request.QueryString("MainCatID"))
                DSProductList.SelectCommand = "SELECT * FROM [Products], [Category]  WHERE [Products].CategoryId = [Category].CategoryID and Parent = " & CInt(Request.QueryString("MainCatID")) & " and [Products].Featured = 'Y'"
                DSBreadcrumbs1.SelectCommand = "Select * From Category Where CategoryID = " & CInt(Request.QueryString("MainCatID"))
            ElseIf Request.QueryString("search_query") <> "" Then
                lblBC1.Text = "Search results for: " + Request.QueryString("search_query")
                DSProductList.SelectCommand = "SELECT * FROM [Products] WHERE [Products].ProductName  LIKE '%" & Request.QueryString("search_query") & "%'"
                CType(Master.FindControl("txtSearch"), TextBox).Text = Request.QueryString("search_query")
            Else
                DSProductList.SelectCommand = "SELECT * FROM [Products], [Category]  WHERE [Products].CategoryId = [Category].CategoryID and [Products].Featured = 'Y'"
                DSSubCategory.SelectCommand = "SELECT [Category].CategoryName, [Category].CategoryID FROM [Category] WHERE Parent != 0"
            End If
            If Request.QueryString("SubCatID") <> "" Then
                DSProductList.SelectCommand = "Select * From Products Where CategoryID = " & CInt(Request.QueryString("SubCatID"))
                DSBreadcrumbs2.SelectCommand = "Select * From Category Where CategoryID = " & CInt(Request.QueryString("SubCatID"))
                'lblBC1.Text = "Products"
                'lblBC2.Text = Str(Request.QueryString("SubCatID"))
            End If
            'Else
            '    DSSubCategory.SelectCommand = "Select * From Category Where Parent = 0"
            'End If
        Else
            If Request.QueryString("search_query") <> "" Then
                lblBC1.Text = "Search results for: " + Request.QueryString("search_query")
                DSProductList.SelectCommand = "SELECT * FROM [Products] WHERE [Products].ProductName  LIKE '%" & Request.QueryString("search_query") & "%'"
                CType(Master.FindControl("txtSearch"), TextBox).Text = Request.QueryString("search_query")
            End If
        End If
    End Sub
End Class
