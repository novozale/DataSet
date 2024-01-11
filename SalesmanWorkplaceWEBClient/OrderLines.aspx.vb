Imports System.Data.OleDb
Imports System.IO

Public Class OrderLines
    Inherits System.Web.UI.Page
    Public Shared GridView1_SelRow As Integer = 0
    Public Shared GridView1_SelRowOld As Integer = 0
    Public Shared GridView2_SelRow As Integer = 0
    Public Shared GridView2_SelRowOld As Integer = 0
    Public Shared GridView3_SelRow As Integer = 0
    Public Shared GridView3_SelRowOld As Integer = 0
    Public Shared SuppStrQTY As Integer = 0

    '////////////////////////////////////////////////////////////////////////////////
    '//
    '// переменные сессии для данного окна
    '//
    '////////////////////////////////////////////////////////////////////////////////
    '//
    '//     ItemList_Substring1                             '--строка поиска 1
    '//     ItemList_Substring2                             '--строка поиска 1
    '//     CPNumber                                        '--ID коммерческого предложения
    '//     ItemList_Item_PageNum                           '--номер выводимой страницы товаров
    '//     ItemList_Item_QTYOn                             '--количество на странице товаров
    '//     ItemList_Item_TotalQTY                          '--общее кол-во строк в запросе
    '//     ItemList_Item_SelIndex                          '--выделенная строка
    '//     ItemList_Item_ColumnCode                        '--код колонки, в которой ведется поиск в товарах
    '//     ItemList_ItemCode                               '--Код выбранного продукта для добавления в КП
    '//     ItemList_ProductGroup                           '--код группы продуктов
    '//     ItemList_Availability                           '--доступность продуктов на складе
    '//     ItemList_Supplier                               '--код поставщика
    '//     ItemList_WHNum                                  '--номер склада отгрузки
    '//     ItemList_WHName                                 '--название склада отгрузки
    '//     ItemList_CurrExchRate                           '--текущий курс валюты КП
    '//     ItemList_CurrName                               '--имя валюты КП
    '//     ItemList_CPItem_PageNum                         '--номер выводимой страницы товаров КП
    '//     ItemList_CPItem_QTYOn                           '--количество на странице товаров в КП
    '//     ItemList_CPItem_TotalQTY                        '--общее кол-во строк в запросе в запасах КП
    '//     ItemList_CPItem_SelIndex                        '--выделенная строка в запасах КП
    '//     ItemList_CPItem_StrNum                          '--номер строки в КП (для редактирования)
    '//     SupplierList_PageNum                            '--номер строки в списке поставщиков
    '//     SupplierList_QTYOnPage                          '--кол - во строк на странице поставщиков
    '//     SupplierList_SelectIndex                        '--выбранная строка на странице поставщиков
    '//     ItemList_ErrSaveBG                              '--закрывать или нет серый блок слой при закрытии окна с ошибкой

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// загрузка страницы, параметры
        '//
        '////////////////////////////////////////////////////////////////////////////////

        If Session("AgentFullName") = "" Then
            Response.Redirect("Login.aspx", True)
        End If

        Page.ClientScript.GetPostBackEventReference(GridView1, "")

        If Not IsPostBack Then
            Dim obj As New ServiceReference1.SWIServiceClient
            Dim MyParam As New ServiceReference1.SWIServiceGetProductListParameters
            Dim MyParam1 As New ServiceReference1.SWIServiceGetCPProductListParameters
            Dim MyParam2 As New ServiceReference1.SWIServiceGetWHParameters
            Dim MyRetParam() As ServiceReference1.SWIServiceGetWHParametersRet
            Dim MyParam4 As New ServiceReference1.SWIServiceGetMarginLevelsParameters
            Dim MyRetParam2() As ServiceReference1.SWIServiceGetMarginLevelsParametersRet

            obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
            obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

            If Session("ItemList_Item_ColumnCode") = "" Then
                Session("ItemList_Item_ColumnCode") = "---"
            End If
            If Session("ItemList_ProductGroup") = "" Then
                Session("ItemList_ProductGroup") = "01"
            End If
            If Session("ItemList_Availability") = "" Then
                Session("ItemList_Availability") = "1"
            End If
            If Session("ItemList_Supplier") = "" Then
                Session("ItemList_Supplier") = "---"
            End If
            If Session("ItemList_Item_PageNum") = "" Then
                Session("ItemList_Item_PageNum") = "0"
            End If
            If Session("ItemList_Item_QTYOn") = "" Then
                Session("ItemList_Item_QTYOn") = "10"
            End If
            If Session("ItemList_WHNum") = "" Then
                Session("ItemList_WHNum") = "01"
            End If
            If Session("ItemList_WHName") = "" Then
                Session("ItemList_WHName") = "СПб Основной"
            End If
            If Session("ItemList_CurrExchRate") = "" Then
                Session("ItemList_CurrExchRate") = "1"
            End If
            If Session("ItemList_CurrName") = "" Then
                Session("ItemList_CurrName") = "RUB"
            End If
            If Session("ItemList_Substring1") = "" Then
                Session("ItemList_Substring1") = ""
            End If
            If Session("ItemList_Substring2") = "" Then
                Session("ItemList_Substring2") = ""
            End If
            If Session("ItemList_CPItem_PageNum") = "" Then
                Session("ItemList_CPItem_PageNum") = "0"
            End If
            If Session("ItemList_CPItem_QTYOn") = "" Then
                Session("ItemList_CPItem_QTYOn") = "8"
            End If
            If Session("ItemList_ErrSaveBG") = "" Then
                Session("ItemList_ErrSaveBG") = "No"
            End If
            If Session("ItemList_Item_SelIndex") = "" Then
                Session("ItemList_Item_SelIndex") = "0"
            End If

            '----изменение переменных сессии в зависимости от того, что за возврат-------
            If Session("OrderLinesReturn") = "Yes" And Trim(Session("OrderLinesItemSelect")) <> "" Then
                Session("ItemList_Substring1") = Trim(Session("OrderLinesItemSelect"))
                Session("ItemList_Substring2") = ""
                Session("ItemList_Item_ColumnCode") = "1"
                Session("ItemList_Availability") = "0"
                Session("ItemList_ProductGroup") = "---"
                Session("ItemList_Supplier") = "---"
                Session("ItemList_Item_PageNum") = "0"
                Session("ItemList_Item_SelIndex") = "0"
            End If

            '---подстрока 1--------------------------------------------------------------
            Substring1.Text = Session("ItemList_Substring1")

            '---подстрока 2--------------------------------------------------------------
            Substring2.Text = Session("ItemList_Substring2")

            '--Список - по каким колонкам производится поиск товара----------------------
            DropDownListFields.DataSource = obj.GetProductColumns().Tables(0)
            DropDownListFields.DataTextField = "ColumnName"
            DropDownListFields.DataValueField = "ColumnCode"
            DropDownListFields.DataBind()
            DropDownListFields.SelectedValue = Session("ItemList_Item_ColumnCode")

            '--Список - по каким колонкам производится поиск поставщика------------------
            DropDownListSuppFields.DataSource = obj.GetSupplierColumns().Tables(0)
            DropDownListSuppFields.DataTextField = "ColumnName"
            DropDownListSuppFields.DataValueField = "ColumnCode"
            DropDownListSuppFields.DataBind()

            '---список - доступность товаров на складе-----------------------------------
            DropDownListAvlItems.SelectedValue = Session("ItemList_Availability")

            '---Категории продуктов------------------------------------------------------
            DropDownListCategories.DataSource = obj.GetCategories().Tables(0)
            DropDownListCategories.DataTextField = "GroupName"
            DropDownListCategories.DataValueField = "GroupCode"
            DropDownListCategories.DataBind()
            DropDownListCategories.SelectedValue = Session("ItemList_ProductGroup")

            '---поставщик----------------------------------------------------------------
            TextBoxSupplierCode.Text = Session("ItemList_Supplier")

            '---склад КП-----------------------------------------------------------------
            MyParam2.MyCPID = Session("CPNumber")
            MyRetParam = obj.GetWH(MyParam2)
            Session("ItemList_WHNum") = MyRetParam(0).MyWHCode
            Session("ItemList_WHName") = MyRetParam(0).MyWHName

            '----Список товаров----------------------------------------------------------
            MyParam.MySubstring1 = Session("ItemList_Substring1")
            MyParam.MySubstring2 = Session("ItemList_Substring2")
            MyParam.MyGroupCode = DropDownListCategories.SelectedValue
            MyParam.MyProductsSearchColumns = DropDownListFields.SelectedValue
            MyParam.MyAvailabilityFlag = DropDownListAvlItems.SelectedValue
            MyParam.MySupplierCode = Trim(TextBoxSupplierCode.Text)
            MyParam.MyWHNum = Session("ItemList_WHNum")
            MyParam.MyCurrExchangeRate = Session("ItemList_CurrExchRate")
            MyParam.MyPageNum = Session("ItemList_Item_PageNum")
            MyParam.MyQTYOnPage = Session("ItemList_Item_QTYOn")
            GridView1.Columns(10).Visible = True
            GridView1.Columns(11).Visible = True
            GridView1.DataSource = obj.GetProductList(MyParam).Tables(0)
            GridView1.DataBind()
            GridView1.HeaderRow.Cells(6).Text = "Баланс на складе " & Session("ItemList_WHName")
            GridView1.HeaderRow.Cells(7).Text = "Доступно на складе " & Session("ItemList_WHName")

            '---формирование списка страниц запасов, выставление кол-ва на странице и выбранной строки---------
            If GridView1.Rows.Count > 0 Then
                Session("ItemList_Item_TotalQTY") = GridView1.Rows(0).Cells(11).Text
            Else
                Session("ItemList_Item_TotalQTY") = "0"
            End If

            For i As Integer = 1 To System.Math.Ceiling(Session("ItemList_Item_TotalQTY") / Session("ItemList_Item_QTYOn"))
                PagesList1.Items.Insert(i - 1, i.ToString())
            Next
            QTYOnPageList1.SelectedValue = Session("ItemList_Item_QTYOn")

            GridView1_SelRowOld = 0
            GridView1_SelRow = Session("ItemList_Item_SelIndex")
            Try
                GridView1.SelectedIndex = GridView1_SelRow
            Catch ex As Exception
            End Try
            ChangeSelRow()


            '---номер страницы на странице запасов---------------------------------------
            Try
                PagesList1.SelectedIndex = Session("ItemList_Item_PageNum")
            Catch ex As Exception
            End Try

            LabelQTYPages.Text = " из " + CStr(System.Math.Ceiling(Session("ItemList_Item_TotalQTY") / Session("ItemList_Item_QTYOn")))


            '---выставление переменных сессии в зависимости от - возврат это или нет-----
            If Session("OrderLinesReturn") = "Yes" Or Session("OrderLinesReturn") = "Yes+1" Then
            Else
                Session("ItemList_CPItem_SelIndex") = "0"
                Session("ItemList_CPItem_SelPage") = "0"
            End If

            If Session("OrderLinesReturn") = "Yes+1" Then
                Session("ItemList_CPItem_PageNum") = CStr(System.Math.Ceiling((Session("ItemList_CPItem_TotalQTY") + 1) / Session("ItemList_CPItem_QTYOn")) - 1)
            End If

            '----Список товаров, включенных в заказ--------------------------------------
            MyParam1.MyCPID = Session("CPNumber")
            MyParam1.MyPageNum = Session("ItemList_CPItem_PageNum")
            MyParam1.MyQTYOnPage = Session("ItemList_CPItem_QTYOn")
            GridView2.Columns(16).Visible = True
            GridView2.DataSource = obj.GetCPProductList(MyParam1).Tables(0)
            GridView2.DataBind()

            '---формирование списка страниц запасов КП, выставление кол-ва на странице и выбранной строки
            If GridView2.Rows.Count > 0 Then
                Session("ItemList_CPItem_TotalQTY") = GridView2.Rows(0).Cells(16).Text
            Else
                Session("ItemList_CPItem_TotalQTY") = "0"
            End If

            For i As Integer = 1 To System.Math.Ceiling(Session("ItemList_CPItem_TotalQTY") / Session("ItemList_CPItem_QTYOn"))
                PagesList2.Items.Insert(i - 1, i.ToString())
            Next

            QTYOnPageList2.SelectedValue = Session("ItemList_CPItem_QTYOn")

            '---количество строк на странице запасов-------------------------------------
            Try
                PagesList2.SelectedIndex = Session("ItemList_CPItem_PageNum")
            Catch ex As Exception
            End Try

            LabelQTYPages1.Text = " из " + CStr(System.Math.Ceiling(Session("ItemList_CPItem_TotalQTY") / Session("ItemList_CPItem_QTYOn")))

            If Session("OrderLinesReturn") = "Yes+1" Then
                GridView2_SelRowOld = 0
                GridView2_SelRow = GridView2.Rows.Count - 1
                Try
                    GridView2.SelectedIndex = GridView2_SelRow
                    Session("ItemList_CPItem_SelIndex") = CStr(GridView2.SelectedIndex)
                Catch ex As Exception
                End Try
            Else
                GridView2_SelRowOld = 0
                GridView2_SelRow = Session("ItemList_CPItem_SelIndex")
                Try
                    GridView2.SelectedIndex = GridView2_SelRow
                Catch ex As Exception
                End Try
            End If
            ChangeSelRow1()



            '----итоговые цифры по КП----------------------------------------------------
            TextBoxCPNumber.Text = Session("CPNumber")
            RefreshTotal()

            MyParam4.MyCPID = Session("CPNumber")
            MyRetParam2 = obj.GetMarginLevels(MyParam4)

            TextBoxMarginLevelManager.Text = MyRetParam2(0).MarginLevelManager
            TextBoxMarginLevelDirector.Text = MyRetParam2(0).MarginLevelDirector

            '----закрываем ненужные колонки----------------------------------------------
            GridView1.Columns(10).Visible = False
            GridView1.Columns(11).Visible = False

            GridView2.Columns(16).Visible = False

            CheckButtonsState()
            Session("OrderLinesReturn") = ""
            Session("OrderLinesItemSelect") = ""
        End If
    End Sub

    Private Sub RefreshTotal()
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// обновление итоговых цифр КП
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim obj As New ServiceReference1.SWIServiceClient
        Dim MyParam3 As New ServiceReference1.SWIServiceGetCPTotalParameters
        Dim MyRetParam1() As ServiceReference1.SWIServiceGetCPTotalParametersRet

        obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
        obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

        MyParam3.MyCPID = Session("CPNumber")
        MyRetParam1 = obj.GetCPTotal(MyParam3)

        Try
            Session("ItemList_CurrName") = MyRetParam1(0).MyCurrName
            TextBoxCurrName.Text = Session("ItemList_CurrName")
            Session("ItemList_CurrExchRate") = CStr(MyRetParam1(0).MyCurrExchangeRate)
            TextBoxCurrValue.Text = Session("ItemList_CurrExchRate")
            TextBoxPriCost.Text = MyRetParam1(0).MyPrimaryCost
            TextBoxSumm.Text = MyRetParam1(0).MySumm
            TextBoxSummVithVAT.Text = MyRetParam1(0).MySummWithVAT
            TextBoxMargin.Text = MyRetParam1(0).MyMargin
            TextBoxDeliverySumm.Text = MyRetParam1(0).MyDeliverySumm
            TextBoxSummVithoutDelivery.Text = MyRetParam1(0).MySummWithoutDelivery
            TextBoxMarginWithDelivery.Text = MyRetParam1(0).MyMarginWithDelivery
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// подсвечивание строк в списке товаров
        '//
        '////////////////////////////////////////////////////////////////////////////////

        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" & e.Row.RowIndex)
            e.Row.Attributes.Add("OnMouseOver", "this.style.cursor = 'pointer'")

            If e.Row.RowIndex = GridView1.SelectedIndex Then
                e.Row.BackColor = Drawing.Color.FromArgb(68, 68, 255)
            Else
                If Trim(e.Row.Cells(10).Text) = "1" Then
                    e.Row.BackColor = Drawing.Color.FromArgb(209, 255, 209)
                Else
                    e.Row.BackColor = Drawing.Color.White
                End If
            End If
        End If
    End Sub

    Private Sub GridView2_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView2.RowDataBound
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// подсвечивание строк в списке товаров, включенных в КП
        '//
        '////////////////////////////////////////////////////////////////////////////////

        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView2, "Select$" & e.Row.RowIndex)
            e.Row.Attributes.Add("OnMouseOver", "this.style.cursor = 'pointer'")

            If e.Row.RowIndex = GridView2.SelectedIndex Then
                e.Row.BackColor = Drawing.Color.FromArgb(68, 68, 255)
            Else
                If Trim(e.Row.Cells(14).Text) = "+" Then
                    e.Row.BackColor = Drawing.Color.LightPink
                Else
                    e.Row.BackColor = Drawing.Color.White
                End If
            End If
        End If
    End Sub

    Private Sub ButtonQuit_Click(sender As Object, e As EventArgs) Handles ButtonQuit.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// выход из редактирования строк
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Response.Redirect("EditHeader.aspx", True)
    End Sub

    Private Sub ButtonPrint_Click(sender As Object, e As EventArgs) Handles ButtonPrint.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// переход в окно печати КП
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("CPPrintFrom") = "Rows"
        Response.Redirect("CPPrint.aspx", True)
    End Sub

    Protected Sub CheckButtonsState()
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// проверка и выставление состояния кнопок
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Try
            If GridView1.Rows.Count = 0 Then
                ButtonAlternateItems.Enabled = False
                ButtonDetails.Enabled = False
                ButtonAddToCP.Enabled = False
            Else
                ButtonAlternateItems.Enabled = True
                ButtonDetails.Enabled = True
                ButtonAddToCP.Enabled = True
            End If

            If GridView2.Rows.Count = 0 Then
                ButtonDelFromCP.Enabled = False
                ButtonEditInCP.Enabled = False
                ButtonSearch.Enabled = False
            Else
                ButtonDelFromCP.Enabled = True
                ButtonEditInCP.Enabled = True
                ButtonSearch.Enabled = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub ChangeSelRow()
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение подсветки выбранной строки в запасах
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Try
            If GridView1_SelRow <> GridView1_SelRowOld Then
                GridView1.Rows(GridView1_SelRow).BackColor = Drawing.Color.FromArgb(68, 68, 255)
                If GridView1.DataKeys(GridView1_SelRowOld).Values("IsDead") = "1" Then
                    'If Trim(GridView1.Rows(GridView1_SelRowOld).Cells(10).Text) = "1" Then
                    GridView1.Rows(GridView1_SelRowOld).BackColor = Drawing.Color.FromArgb(209, 255, 209)
                Else
                    GridView1.Rows(GridView1_SelRowOld).BackColor = Drawing.Color.White
                End If
            Else
                GridView1.Rows(GridView1_SelRow).BackColor = Drawing.Color.FromArgb(68, 68, 255)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub ChangeSelRow1()
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение подсветки выбранной строки в запасах в КП
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Try
            If GridView2_SelRow <> GridView2_SelRowOld Then
                GridView2.Rows(GridView2_SelRow).BackColor = Drawing.Color.FromArgb(68, 68, 255)
                If Trim(GridView2.Rows(GridView2_SelRowOld).Cells(14).Text) = "+" Then
                    GridView2.Rows(GridView2_SelRowOld).BackColor = Drawing.Color.LightPink
                Else
                    GridView2.Rows(GridView2_SelRowOld).BackColor = Drawing.Color.White
                End If
            Else
                GridView2.Rows(GridView2_SelRow).BackColor = Drawing.Color.FromArgb(68, 68, 255)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение выделенной строки после того, как событие свершилось
        '//
        '////////////////////////////////////////////////////////////////////////////////

        GridView1.SelectedIndex = GridView1_SelRow
        Session("ItemList_Item_SelIndex") = CStr(GridView1.SelectedIndex)
        ChangeSelRow()
        CheckButtonsState()
    End Sub

    Private Sub GridView1_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение выделенной строки до того, как событие свершилось
        '//
        '////////////////////////////////////////////////////////////////////////////////

        GridView1_SelRowOld = GridView1_SelRow
        GridView1_SelRow = e.NewSelectedIndex
    End Sub

    Private Sub ButtonRefresh_Click(sender As Object, e As EventArgs) Handles ButtonRefresh.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// загрузка по новой данных в список товаров
        '//
        '////////////////////////////////////////////////////////////////////////////////

        RefreshItems(0)
    End Sub

    Protected Sub RefreshItems(MyType As Integer)
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// повторная загрузка страницы (списка товаров)
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim obj As New ServiceReference1.SWIServiceClient
        Dim MyParam As New ServiceReference1.SWIServiceGetProductListParameters

        obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
        obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

        If MyType = 0 Then    '---загрузка по кнопке обновить
            Session("ItemList_Item_PageNum") = "0"
        ElseIf MyType = 1 Then

        End If

        '----Список товаров----------------------------------------------------------
        Session("ItemList_Substring1") = Trim(Substring1.Text)
        MyParam.MySubstring1 = Session("ItemList_Substring1")
        Session("ItemList_Substring2") = Trim(Substring2.Text)
        MyParam.MySubstring2 = Session("ItemList_Substring2")
        MyParam.MyGroupCode = DropDownListCategories.SelectedValue
        MyParam.MyProductsSearchColumns = DropDownListFields.SelectedValue
        MyParam.MyAvailabilityFlag = DropDownListAvlItems.SelectedValue
        MyParam.MySupplierCode = Trim(TextBoxSupplierCode.Text)
        MyParam.MyWHNum = Session("ItemList_WHNum")
        MyParam.MyCurrExchangeRate = Session("ItemList_CurrExchRate")
        MyParam.MyPageNum = Session("ItemList_Item_PageNum")
        MyParam.MyQTYOnPage = Session("ItemList_Item_QTYOn")
        GridView1.Columns(10).Visible = True
        GridView1.Columns(11).Visible = True
        GridView1.DataSource = obj.GetProductList(MyParam).Tables(0)
        GridView1.DataBind()
        GridView1.HeaderRow.Cells(6).Text = "Баланс на складе " & Session("ItemList_WHName")
        GridView1.HeaderRow.Cells(7).Text = "Доступно на складе " & Session("ItemList_WHName")

        GridView1_SelRowOld = GridView1_SelRow

        '---номер страницы запасов---------------------------------------------------
        If GridView1.Rows.Count > 0 Then
            Session("ItemList_Item_TotalQTY") = GridView1.Rows(0).Cells(11).Text
        Else
            Session("ItemList_Item_TotalQTY") = "0"
        End If

        PagesList1.Items.Clear()
        For i As Integer = 1 To System.Math.Ceiling(Session("ItemList_Item_TotalQTY") / Session("ItemList_Item_QTYOn"))
            PagesList1.Items.Insert(i - 1, i.ToString())
        Next

        '---количество строк на странице запасов-------------------------------------
        Try
            PagesList1.SelectedIndex = Session("ItemList_Item_PageNum")
        Catch ex As Exception
        End Try

        LabelQTYPages.Text = " из " + CStr(System.Math.Ceiling(Session("ItemList_Item_TotalQTY") / Session("ItemList_Item_QTYOn")))

        If MyType = 0 Or MyType = 1 Then
            Try
                GridView1.SelectedIndex = 0
                GridView1_SelRow = 0
            Catch ex As Exception
            End Try
        Else
        End If

        '----закрываем ненужные колонки----------------------------------------------
        GridView1.Columns(10).Visible = False
        GridView1.Columns(11).Visible = False

        ChangeSelRow()
        CheckButtonsState()
    End Sub

    Private Sub PagesList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PagesList1.SelectedIndexChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение номера выводимой страницы
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Try
            Session("ItemList_Item_PageNum") = CStr(PagesList1.SelectedIndex)
        Catch ex As Exception
        End Try
        RefreshItems(1)
    End Sub

    Private Sub QTYOnPageList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles QTYOnPageList1.SelectedIndexChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение выводимого на странице количества
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("ItemList_Item_QTYOn") = QTYOnPageList1.SelectedValue
        RefreshItems(0)
    End Sub

    Private Sub GridView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView2.SelectedIndexChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение выделенной строки после того, как событие свершилось
        '//
        '////////////////////////////////////////////////////////////////////////////////

        GridView2.SelectedIndex = GridView2_SelRow
        Session("ItemList_CPItem_SelIndex") = GridView2.SelectedIndex
        ChangeSelRow1()
        CheckButtonsState()
    End Sub

    Private Sub GridView2_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles GridView2.SelectedIndexChanging
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение выделенной строки до того, как событие свершилось
        '//
        '////////////////////////////////////////////////////////////////////////////////

        GridView2_SelRowOld = GridView2_SelRow
        GridView2_SelRow = e.NewSelectedIndex
    End Sub

    Private Sub PagesList2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PagesList2.SelectedIndexChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение номера выводимой страницы списка запасов в КП
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Try
            Session("ItemList_CPItem_PageNum") = CStr(PagesList2.SelectedIndex)
        Catch ex As Exception
        End Try
        RefreshItems1(1)
    End Sub

    Protected Sub RefreshItems1(MyType As Integer)
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// повторная загрузка страницы (списка товаров в КП)
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim obj As New ServiceReference1.SWIServiceClient
        Dim MyParam1 As New ServiceReference1.SWIServiceGetCPProductListParameters
        Dim MyReducePage = 0

        obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
        obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

        If MyType = 0 Then    '---загрузка по кнопке обновить
            Session("ItemList_CPItem_PageNum") = "0"
        ElseIf MyType = 1 Then

        ElseIf MyType = 3 Then '---после удаления строки
            If CInt(Session("ItemList_CPItem_PageNum")) > System.Math.Ceiling((Session("ItemList_CPItem_TotalQTY") - 1) / Session("ItemList_CPItem_QTYOn")) - 1 Then
                '---кол - во страниц уменьшилось на 1
                If Session("ItemList_CPItem_PageNum") > 0 Then
                    Session("ItemList_CPItem_PageNum") = CStr(CInt(Session("ItemList_CPItem_PageNum")) - 1)
                End If
                MyReducePage = 1
            Else
                '---кол - во страниц не изменилось
            End If
        End If

        '----Список товаров, включенных в заказ--------------------------------------
        MyParam1.MyCPID = Session("CPNumber")
        MyParam1.MyPageNum = Session("ItemList_CPItem_PageNum")
        MyParam1.MyQTYOnPage = Session("ItemList_CPItem_QTYOn")
        GridView2.Columns(16).Visible = True
        GridView2.DataSource = obj.GetCPProductList(MyParam1).Tables(0)
        GridView2.DataBind()

        GridView2_SelRowOld = GridView2_SelRow

        '---номер страницы запасов включенных в КП-----------------------------------
        If GridView2.Rows.Count > 0 Then
            Session("ItemList_CPItem_TotalQTY") = GridView2.Rows(0).Cells(16).Text
        Else
            Session("ItemList_CPItem_TotalQTY") = "0"
        End If

        PagesList2.Items.Clear()
        For i As Integer = 1 To System.Math.Ceiling(Session("ItemList_CPItem_TotalQTY") / Session("ItemList_CPItem_QTYOn"))
            PagesList2.Items.Insert(i - 1, i.ToString())
        Next

        '---количество строк на странице запасов-------------------------------------
        Try
            PagesList2.SelectedIndex = Session("ItemList_CPItem_PageNum")
        Catch ex As Exception
        End Try

        LabelQTYPages1.Text = " из " + CStr(System.Math.Ceiling(Session("ItemList_CPItem_TotalQTY") / Session("ItemList_CPItem_QTYOn")))

        If MyType = 0 Or MyType = 1 Then
            Try
                GridView2.SelectedIndex = 0
                GridView2_SelRow = 0
            Catch ex As Exception
            End Try
        ElseIf MyType = 3 Then
            If MyReducePage = 1 Then
                If GridView2.Rows.Count = 0 Then
                    GridView2_SelRow = 0
                Else
                    GridView2_SelRow = GridView2.Rows.Count - 1
                End If
            Else
                If GridView2_SelRow = 0 Then
                    GridView2_SelRow = 0
                Else
                    GridView2_SelRow = GridView2_SelRow - 1
                End If
            End If
        End If
        Try
            GridView2.SelectedIndex = GridView2_SelRow
        Catch ex As Exception
        End Try

        '----закрываем ненужные колонки----------------------------------------------
        GridView2.Columns(16).Visible = False

        ChangeSelRow1()
        CheckButtonsState()
    End Sub

    Private Sub QTYOnPageList2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles QTYOnPageList2.SelectedIndexChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение выводимого на странице количества
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("ItemList_CPItem_QTYOn") = QTYOnPageList2.SelectedValue
        RefreshItems1(0)
    End Sub

    Private Sub ButtonReCalcMarginDisc_Click(sender As Object, e As EventArgs) Handles ButtonReCalcMarginDisc.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// пересчет КП с заданной скидкой и / или маржой
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim MyStr As String

        MyStr = CheckMarginDiscFields()
        If MyStr <> "" Then
            Session("ItemList_ErrSaveBG") = "No"
            LabelErr.Text = MyStr
            DivErr.Disabled = False
            DivErr.Visible = True
            DivBG.Disabled = False
            DivBG.Visible = True
        Else
            Dim obj As New ServiceReference1.SWIServiceClient
            Dim MyParam As New ServiceReference1.SWIServiceReCalcCPParameters

            obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
            obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

            MyParam.MyCPID = Session("CPNumber")
            If Trim(TextBoxNewDiscount.Text) = "" Then
                MyParam.MyDiscount = -1
            Else
                MyParam.MyDiscount = CDbl(TextBoxNewDiscount.Text)
            End If
            If Trim(TextBoxNewMargin.Text) = "" Then
                MyParam.MyMargin = -1
            Else
                MyParam.MyMargin = CDbl(TextBoxNewMargin.Text)
            End If
            MyStr = obj.ReCalcCP(MyParam)
            TextBoxNewDiscount.Text = ""
            TextBoxNewMargin.Text = ""
            If MyStr = "" Then
                '---обновляем тоталы по КП
                RefreshTotal()

                '---обновляем информацию по строкам КП
                RefreshItems1(0)
            Else
                Session("ItemList_ErrSaveBG") = "No"
                LabelErr.Text = MyStr
                DivErr.Disabled = False
                DivErr.Visible = True
                DivBG.Disabled = False
                DivBG.Visible = True
            End If
        End If
    End Sub

    Private Function CheckMarginDiscFields() As String
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// проверка правильности заполнения полей скидки и маржи
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim MyDbl As Double

        If Trim(TextBoxNewDiscount.Text) = "" And Trim(TextBoxNewMargin.Text) = "" Then
            CheckMarginDiscFields = "Как минимум что то одно должно быть заполнено - Скидка (%): или Маржа (%): "
            Exit Function
        End If

        If Trim(TextBoxNewDiscount.Text) <> "" Then
            Try
                MyDbl = CDbl(TextBoxNewDiscount.Text)
            Catch ex As Exception
                CheckMarginDiscFields = "В поле Скидка (%): должно быть введено число. "
                Exit Function
            End Try
        End If

        If Trim(TextBoxNewMargin.Text) <> "" Then
            Try
                MyDbl = CDbl(TextBoxNewMargin.Text)
            Catch ex As Exception
                CheckMarginDiscFields = "В поле Маржа (%): должно быть введено число. "
                Exit Function
            End Try
        End If
        CheckMarginDiscFields = ""
    End Function

    Private Sub ButtonErr_Click(sender As Object, e As EventArgs) Handles ButtonErr.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// закрытие слоя с сообщением об ошибке
        '//
        '////////////////////////////////////////////////////////////////////////////////

        LabelErr.Text = ""
        DivErr.Disabled = True
        DivErr.Visible = False
        If Session("ItemList_ErrSaveBG") = "No" Then
            DivBG.Disabled = True
            DivBG.Visible = False
        End If
    End Sub

    Private Sub ButtonIncreasePerCent_Click(sender As Object, e As EventArgs) Handles ButtonIncreasePerCent.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение цены строк на %
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim MyStr As String

        MyStr = CheckPerCentFields()
        If MyStr <> "" Then
            Session("ItemList_ErrSaveBG") = "No"
            LabelErr.Text = MyStr
            DivErr.Disabled = False
            DivErr.Visible = True
            DivBG.Disabled = False
            DivBG.Visible = True
        Else
            Dim obj As New ServiceReference1.SWIServiceClient
            Dim MyParam As New ServiceReference1.SWIServiceIncreaseCPPerCentParameters

            obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
            obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

            MyParam.MyCPID = Session("CPNumber")
            MyParam.MyPerCent = CDbl(TextBoxPerCentIncreasing.Text)
            MyStr = obj.IncreaseCPPerCent(MyParam)
            TextBoxPerCentIncreasing.Text = ""
            If MyStr = "" Then
                '---обновляем тоталы по КП
                RefreshTotal()

                '---обновляем информацию по строкам КП
                RefreshItems1(0)
            Else
                Session("ItemList_ErrSaveBG") = "No"
                LabelErr.Text = MyStr
                DivErr.Disabled = False
                DivErr.Visible = True
                DivBG.Disabled = False
                DivBG.Visible = True
            End If
        End If
    End Sub

    Private Function CheckPerCentFields() As String
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// проверка правильности заполнения поля %
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim MyDbl As Double

        If Trim(TextBoxPerCentIncreasing.Text) = "" Then
            CheckPerCentFields = "Поле Увеличить цену строк на (%): должно быть заполнено "
            Exit Function
        End If

        Try
            MyDbl = CDbl(TextBoxPerCentIncreasing.Text)
        Catch ex As Exception
            CheckPerCentFields = "В поле Увеличить цену строк на (%): должно быть введено число. "
            Exit Function
        End Try

        CheckPerCentFields = ""
    End Function

    Private Sub ButtonSupplierClear_Click(sender As Object, e As EventArgs) Handles ButtonSupplierClear.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// очистка поля "поставщик" (выставление параметра "---")
        '//
        '////////////////////////////////////////////////////////////////////////////////

        TextBoxSupplierCode.Text = "---"
        Session("ItemList_Supplier") = "---"
    End Sub

    Private Sub ButtonSupplierSearch_Click(sender As Object, e As EventArgs) Handles ButtonSupplierSearch.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// выбор поставщика из списка
        '//
        '////////////////////////////////////////////////////////////////////////////////


        DivBG.Disabled = False
        DivBG.Visible = True
        DivSuppliers.Disabled = False
        DivSuppliers.Visible = True
    End Sub

    Private Sub ButtonSuppCancel_Click(sender As Object, e As EventArgs) Handles ButtonSuppCancel.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// отмена выбора скальского поставщика из списка
        '//
        '////////////////////////////////////////////////////////////////////////////////


        DivBG.Disabled = True
        DivBG.Visible = False
        DivSuppliers.Disabled = True
        DivSuppliers.Visible = False
    End Sub

    Private Sub ButtonSuppSearch_Click(sender As Object, e As EventArgs) Handles ButtonSuppSearch.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// поиск поставщика 
        '//
        '////////////////////////////////////////////////////////////////////////////////

        SupplierListLoad(0)
        CheckSupplierButtonState()
    End Sub

    Protected Sub CheckSupplierButtonState()
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// проверка состояния кнопок в слое списка поставщиков
        '//
        '////////////////////////////////////////////////////////////////////////////////

        If GridView3.Rows.Count = 0 Then
            ButtonSuppSelect.Enabled = False
        Else
            ButtonSuppSelect.Enabled = True
        End If
    End Sub

    Protected Sub SupplierListLoad(MyType As Integer)
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// загрузка данных в таблицу поставщиков
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim obj As New ServiceReference1.SWIServiceClient
        Dim MyParam As New ServiceReference1.SWIServiceGetSupplierListParameters

        obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
        obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

        If Session("SupplierList_PageNum") = "" Then
            Session("SupplierList_PageNum") = "0"
        End If
        If Session("SupplierList_QTYOnPage") = "" Then
            Session("SupplierList_QTYOnPage") = "20"
            QTYOnPageListSupp.SelectedValue = "20"
        End If

        Try
            MyParam.MyPageNum = Session("SupplierList_PageNum")
            MyParam.MySubstring1 = Trim(SuppSubstring1.Text)
            MyParam.MySubstring2 = Trim(SuppSubstring2.Text)
            MyParam.MyProductsSearchColumns = DropDownListSuppFields.SelectedValue
            MyParam.MyQTYOnPage = Session("SupplierList_QTYOnPage")
            GridView3.DataSource = obj.GetSupplierList(MyParam).Tables(0)
            GridView3.Columns(4).Visible = True
            GridView3.SelectedIndex = 0
            GridView3.DataBind()
        Catch
        End Try

        If GridView3.Rows.Count > 0 Then
            SuppStrQTY = GridView3.Rows(0).Cells(4).Text
            GridView3.Columns(4).Visible = False
        Else
            SuppStrQTY = 0
        End If

        If MyType = 0 Then
            PagesListSupp.Items.Clear()
            For i As Integer = 1 To System.Math.Ceiling(SuppStrQTY / Session("SupplierList_QTYOnPage"))
                PagesListSupp.Items.Insert(i - 1, i.ToString())
            Next
            LabelSuppQTYPages.Text = " из " + CStr(System.Math.Ceiling(SuppStrQTY / Session("SupplierList_QTYOnPage")))
        End If

        ChangeSelRow2()
    End Sub

    Private Sub ChangeSelRow2()
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение подсветки выбранной строки
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Try
            If GridView3_SelRow <> GridView3_SelRowOld Then
                GridView3.Rows(GridView3_SelRow).BackColor = Drawing.Color.FromArgb(68, 68, 255)
                GridView3.Rows(GridView3_SelRowOld).BackColor = Drawing.Color.White
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GridView3_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView3.RowDataBound
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// подсвечивание строк в списке поставщиков
        '//
        '////////////////////////////////////////////////////////////////////////////////

        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView3, "Select$" & e.Row.RowIndex)
            e.Row.Attributes.Add("OnMouseOver", "this.style.cursor = 'pointer'")

            If e.Row.RowIndex = GridView3.SelectedIndex Then
                e.Row.BackColor = Drawing.Color.FromArgb(68, 68, 255)
            Else
                e.Row.BackColor = Drawing.Color.White
            End If
        End If
    End Sub

    Private Sub GridView3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView3.SelectedIndexChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение выделенной строки после того, как событие свершилось (поставщики)
        '//
        '////////////////////////////////////////////////////////////////////////////////

        GridView3.SelectedIndex = GridView3_SelRow
        Session("SupplierList_SelectIndex") = GridView3.SelectedIndex
        ChangeSelRow2()
        CheckSupplierButtonState()
    End Sub

    Private Sub GridView3_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles GridView3.SelectedIndexChanging
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// выбор строки с поставщиком
        '//
        '////////////////////////////////////////////////////////////////////////////////

        GridView3_SelRowOld = GridView3_SelRow
        GridView3_SelRow = e.NewSelectedIndex
    End Sub

    Private Sub PagesListSupp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PagesListSupp.SelectedIndexChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение номера выводимой страницы с поставщиками
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Try
            Session("SupplierList_PageNum") = CStr(PagesListSupp.SelectedIndex)
        Catch ex As Exception
        End Try
        GridView3_SelRowOld = GridView3_SelRow
        GridView3_SelRow = 0
        Session("SupplierList_SelectIndex") = "0"
        SupplierListLoad(1)
        CheckSupplierButtonState()
    End Sub

    Private Sub QTYOnPageListSupp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles QTYOnPageListSupp.SelectedIndexChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение выводимого на странице количества поставщиков
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("SupplierList_QTYOnPage") = QTYOnPageListSupp.SelectedValue
        PagesListSupp.Items.Clear()
        For i As Integer = 1 To System.Math.Ceiling(SuppStrQTY / Session("SupplierList_QTYOnPage"))
            PagesListSupp.Items.Insert(i - 1, i.ToString())
        Next
        LabelSuppQTYPages.Text = " из " + CStr(System.Math.Ceiling(SuppStrQTY / Session("SupplierList_QTYOnPage")))
        Session("SupplierList_PageNum") = "0"

        Try
            Session("SupplierList_PageNum") = CStr(PagesListSupp.SelectedIndex)
        Catch ex As Exception
        End Try
        GridView3_SelRowOld = GridView3_SelRow
        GridView3_SelRow = 0
        Session("SupplierList_SelectIndex") = "0"

        SupplierListLoad(1)
        CheckSupplierButtonState()
    End Sub

    Private Sub ButtonSuppSelect_Click(sender As Object, e As EventArgs) Handles ButtonSuppSelect.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Поставщик выбран в списке
        '//
        '////////////////////////////////////////////////////////////////////////////////

        TextBoxSupplierCode.Text = Trim(GridView3.Rows(GridView3_SelRow).Cells(0).Text)
        Session("ItemList_Supplier") = TextBoxSupplierCode.Text
        DivBG.Disabled = True
        DivBG.Visible = False
        DivSuppliers.Disabled = True
        DivSuppliers.Visible = False
    End Sub

    Private Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// поиск товара,  подсвеченного в списке товаров в КП, в общем списке товаров
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Substring1.Text = GridView2.Rows(GridView2_SelRow).Cells(1).Text
        Substring2.Text = ""
        DropDownListFields.SelectedValue = 1
        Session("ItemList_Item_ColumnCode") = "1"
        DropDownListAvlItems.SelectedValue = 0
        Session("ItemList_Availability") = "0"
        DropDownListCategories.SelectedValue = "---"
        Session("ItemList_ProductGroup") = "---"
        TextBoxSupplierCode.Text = "---"
        Session("ItemList_Supplier") = "---"
        RefreshItems(0)
    End Sub

    Private Sub ButtonDelFromCP_Click(sender As Object, e As EventArgs) Handles ButtonDelFromCP.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// удаление выделенной строки КП
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim obj As New ServiceReference1.SWIServiceClient
        Dim MyParam As New ServiceReference1.SWIServiceDelOrderParameters
        Dim MyStr As String

        obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
        obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

        MyParam.MyOrder = Session("CPNumber")
        MyParam.MyStr = GridView2.Rows(GridView2_SelRow).Cells(0).Text
        MyStr = obj.DelOrder(MyParam)
        If Trim(MyStr) = "" Then
            RefreshItems1(3)
        Else
            Session("ItemList_ErrSaveBG") = "No"
            LabelErr.Text = MyStr
            DivErr.Disabled = False
            DivErr.Visible = True
            DivBG.Disabled = False
            DivBG.Visible = True
        End If
    End Sub

    Private Sub ButtonDelivery_Click(sender As Object, e As EventArgs) Handles ButtonDelivery.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Кнопка ввода стоимости доставки
        '//
        '////////////////////////////////////////////////////////////////////////////////

        DivDeliveryCost.Disabled = False
        DivDeliveryCost.Visible = True
        DivBG.Disabled = False
        DivBG.Visible = True
    End Sub

    Private Sub ButtonDeliveryCancel_Click(sender As Object, e As EventArgs) Handles ButtonDeliveryCancel.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Отмена ввода стоимости доставки
        '//
        '////////////////////////////////////////////////////////////////////////////////

        DivDeliveryCost.Disabled = True
        DivDeliveryCost.Visible = False
        DivBG.Disabled = True
        DivBG.Visible = False
    End Sub

    Private Sub ButtonDeliverySave_Click(sender As Object, e As EventArgs) Handles ButtonDeliverySave.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// запись стоимости доставки
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim MyStr As String

        MyStr = CheckDeliveryFilled()
        If MyStr = "" Then
            Dim obj As New ServiceReference1.SWIServiceClient
            Dim MyParam As New ServiceReference1.SWIServiceSetCPDelCostParameters

            obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
            obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

            MyParam.MyCPID = Session("CPNumber")
            MyParam.MyDelCost = CDbl(TextBoxDeliveryCost.Text)
            If CheckBoxAddDelivery.Checked = True Then
                MyParam.MyCostUpdateFlag = 1
            Else
                MyParam.MyCostUpdateFlag = 0
            End If

            MyStr = obj.SetCPDelCost(MyParam)
            If Trim(MyStr) = "" Then
                '---обновляем тоталы по КП
                RefreshTotal()

                DivDeliveryCost.Disabled = True
                DivDeliveryCost.Visible = False
                DivBG.Disabled = True
                DivBG.Visible = False
            Else
                Session("ItemList_ErrSaveBG") = "Yes"
                LabelErr.Text = MyStr
                DivErr.Disabled = False
                DivErr.Visible = True
            End If
        Else
            Session("ItemList_ErrSaveBG") = "Yes"
            LabelErr.Text = MyStr
            DivErr.Disabled = False
            DivErr.Visible = True
        End If
    End Sub

    Private Function CheckDeliveryFilled() As String
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// проверка правильности заполнения поля стоимости доставки
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim MyDbl As Double

        If Trim(TextBoxDeliveryCost.Text) = "" Then
            CheckDeliveryFilled = "Поле Увеличить цену строк на (%): должно быть заполнено "
            Exit Function
        End If

        Try
            MyDbl = CDbl(TextBoxDeliveryCost.Text)
        Catch ex As Exception
            CheckDeliveryFilled = "В поле Увеличить цену строк на (%): должно быть введено число. "
            Exit Function
        End Try

        CheckDeliveryFilled = ""
    End Function

    Private Sub ButtonAlternateItems_Click(sender As Object, e As EventArgs) Handles ButtonAlternateItems.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// открытие окна с альтернативными товарами
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("ItemCode") = Server.HtmlDecode(GridView1.Rows(GridView1_SelRow).Cells(0).Text)
        Session("ItemName") = Server.HtmlDecode(GridView1.Rows(GridView1_SelRow).Cells(1).Text)
        Response.Redirect("AltItems.aspx", True)
    End Sub

    Private Sub DropDownListFields_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListFields.SelectedIndexChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// смена выбора - в каких колонках производить поиск
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("ItemList_Item_ColumnCode") = CStr(DropDownListFields.SelectedValue)
    End Sub

    Private Sub DropDownListAvlItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListAvlItems.SelectedIndexChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// смена выбора - искать в доступных товарах или во всех
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("ItemList_Availability") = CStr(DropDownListAvlItems.SelectedValue)
    End Sub

    Private Sub DropDownListCategories_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListCategories.SelectedIndexChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// смена выбора категории продукта
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("ItemList_ProductGroup") = CStr(DropDownListCategories.SelectedValue)
    End Sub

    Private Sub ButtonDetails_Click(sender As Object, e As EventArgs) Handles ButtonDetails.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// открытие окна с детальной информацией по товарам
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("ItemCode") = Server.HtmlDecode(GridView1.Rows(GridView1_SelRow).Cells(0).Text)
        Response.Redirect("ItemsDetail.aspx", True)
    End Sub

    Private Sub ButtonEditInCP_Click(sender As Object, e As EventArgs) Handles ButtonEditInCP.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// открытие окна редактирования выделенной строки КП
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("ItemList_CPItem_StrNum") = Server.HtmlDecode(GridView2.Rows(GridView2_SelRow).Cells(0).Text)
        Response.Redirect("CPStrEdit.aspx", True)
    End Sub

    Private Sub ButtonAddToCP_Click(sender As Object, e As EventArgs) Handles ButtonAddToCP.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// открытие окна добавления новой строки в КП
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("ItemList_ItemCode") = Server.HtmlDecode(GridView1.Rows(GridView1_SelRow).Cells(0).Text)
        Response.Redirect("CPStrAdd.aspx", True)
    End Sub

    Private Sub ButtonUpload_Click(sender As Object, e As EventArgs) Handles ButtonUpload.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// выгрузка коммерческого предложения в файл спецификации Excel
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim Srcfile As IO.FileInfo = New IO.FileInfo("C:\SW_WEB\Template\Спецификация Электроскандия.xls")
        Dim DstFile As IO.FileInfo
        Dim MyStr As String

        If (Srcfile.Exists) Then
            Dim MyGuid As Guid
            Dim sqlds As New DataSet()


            Try
                MyGuid = Guid.NewGuid
                MyStr = "C:\SW_WEB\Temp\Спецификация Электроскандия_" & MyGuid.ToString & ".xls"
                Srcfile.CopyTo(MyStr)
                DstFile = New IO.FileInfo(MyStr)

                Dim obj As New ServiceReference1.SWIServiceClient
                Dim MyParam As New ServiceReference1.SWIServiceGetCPToExcelParameters

                obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
                obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

                MyParam.MyCPID = Session("CPNumber")
                sqlds = obj.GetCPToExcel(MyParam)

                'Dim connString As String = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & Replace(MyStr, "\", "\\") & "; Extended Properties=""Excel 8.0;HDR=No;"""
                Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & Replace(MyStr, "\", "\\") & "; Extended Properties=""Excel 8.0;HDR=No;FirstRowHasNames=False"""
                Dim oledbConn As OleDbConnection = New OleDbConnection(connString)
                oledbConn.Open()
                Dim oledbCmd As OleDbCommand
                For i As Integer = 0 To sqlds.Tables(0).Rows.Count - 1
                    MyStr = "UPDATE [Data$B" & CStr(i + 11) & ":G" & CStr(i + 11) & "] SET F1 = '" & sqlds.Tables(0).Rows(i).ItemArray(0).ToString & "', F2 = '" & _
                        sqlds.Tables(0).Rows(i).ItemArray(1).ToString & "', F3 = '" & sqlds.Tables(0).Rows(i).ItemArray(2).ToString & "', F4 = '" & _
                        sqlds.Tables(0).Rows(i).ItemArray(3).ToString & "', F5 = '" & _
                        sqlds.Tables(0).Rows(i).ItemArray(4).ToString & "', F6 = '" & sqlds.Tables(0).Rows(i).ItemArray(5).ToString & "'"
                    oledbCmd = New OleDbCommand(MyStr, oledbConn)
                    oledbCmd.ExecuteNonQuery()

                    MyStr = "UPDATE [Data$I" & CStr(i + 11) & ":I" & CStr(i + 11) & "] SET F1 = '" & sqlds.Tables(0).Rows(i).ItemArray(6).ToString & "'"
                    oledbCmd = New OleDbCommand(MyStr, oledbConn)
                    oledbCmd.ExecuteNonQuery()
                Next
                oledbConn.Close()

            Catch ex As Exception
                LabelErr.Text = ex.Message
                DivErr.Disabled = False
                DivErr.Visible = True
                DivBG.Disabled = False
                DivBG.Visible = True
                Exit Sub
            End Try
            Try
                Dim fl As Long
                Dim bt As Byte()
                Using stream As New FileStream(DstFile.FullName, FileMode.Open)
                    fl = stream.Length
                    ReDim bt(fl - 1)
                    stream.Read(bt, 0, stream.Length)
                End Using
                DstFile.Delete()

                Response.Clear()
                Response.ClearHeaders()
                Response.ClearContent()
                If Left(Request.Browser.Type, 7).ToUpper = "FIREFOX" Then
                    Response.AddHeader("content-disposition", "attachment; filename*=" + """Спецификация Электроскандия.xls""")
                Else
                    Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlPathEncode("Спецификация Электроскандия.xls"))
                End If
                Response.ContentType = "application/octet-stream"
                Response.AddHeader("Content-Length", fl.ToString())
                Response.BinaryWrite(bt)
                Response.End()
            Catch ex As Exception
                LabelErr.Text = ex.Message
                DivErr.Disabled = False
                DivErr.Visible = True
                DivBG.Disabled = False
                DivBG.Visible = True
            End Try
        End If
    End Sub
End Class