Public Class CPStrAdd
    Inherits System.Web.UI.Page
    Public Shared GridView3_SelRow As Integer = 0
    Public Shared GridView3_SelRowOld As Integer = 0
    Public Shared SuppStrQTY As Integer = 0
    Public Shared GridView1_SelRow As Integer = 0
    Public Shared GridView1_SelRowOld As Integer = 0
    Public Shared SICStrQTY As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// загрузка страницы, параметры
        '//
        '////////////////////////////////////////////////////////////////////////////////

        If Session("AgentFullName") = "" Then
            Response.Redirect("Login.aspx", True)
        End If

        Page.ClientScript.GetPostBackEventReference(GridView3, "")

        If Not IsPostBack Then
            Dim obj As New ServiceReference1.SWIServiceClient
            Dim MyParam As New ServiceReference1.SWIServiceGetItemParameters
            Dim MyParamRet() As ServiceReference1.SWIServiceGetItemParametersRet
            Dim MyParam1 As New ServiceReference1.SWIServiceGetNewStrNumParameters

            obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
            obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

            TextBoxCurrName.Text = Session("ItemList_CurrName")
            TextBoxCurrValue.Text = Session("ItemList_CurrExchRate")

            '--Список - по каким колонкам производится поиск поставщика------------------
            DropDownListSuppFields.DataSource = obj.GetSupplierColumns().Tables(0)
            DropDownListSuppFields.DataTextField = "ColumnName"
            DropDownListSuppFields.DataValueField = "ColumnCode"
            DropDownListSuppFields.DataBind()

            '--Номер новой строки--------------------------------------------------------
            MyParam1.MyCPID = Session("CPNumber")
            Session("ItemList_CPItem_StrNum") = obj.GetNewStrNum(MyParam1)
            LabelStrNum.Text = "Добавление строки " + Session("ItemList_CPItem_StrNum")

            '--Список единиц измерения---------------------------------------------------
            DropDownListUOM.DataSource = obj.GetUOMList().Tables(0)
            DropDownListUOM.DataTextField = "UOMName"
            DropDownListUOM.DataValueField = "UOMCode"
            DropDownListUOM.DataBind()

            '--------Данные на редактирование--------------------------------------------
            MyParam.MyCPID = Session("CPNumber")
            MyParam.MyItemCode = Session("ItemList_ItemCode")
            MyParamRet = obj.GetItem(MyParam)

            '--------данные по элементам-------------------------------------------------
            '---комментарий по товару
            If Trim(MyParamRet(0).MyPrice) = 0 Then
                LabelRecommendedPrice.Text = "Рекомендованная цена и себестоимость  для этого запаса должны быть определены самостоятельно"
                LabelRecommendedPrice.ForeColor = Drawing.Color.DarkRed
            Else
                LabelRecommendedPrice.Text = "Рекомендованная цена и себестоимость этого запаса на основе прайс - листа на закупку"
                LabelRecommendedPrice.ForeColor = Drawing.Color.DarkGreen
            End If
            '---признак складской
            If Trim(MyParamRet(0).MyIsWHAssort) = "" Then
                LabelWHAssortiment.Text = ""
            Else
                LabelWHAssortiment.Text = "Складской ассортимент"
            End If
            '---кратность в упаковке
            TextBoxQTYInPack.Text = MyParamRet(0).MyQTYInPack.ToString()
            '---мин кол - во в заказе на закупку
            TextBoxMinQTY.Text = MyParamRet(0).MyMinOrderQTY
            '---срок поставки по прайсу поставщика
            TextBoxLT.Text = MyParamRet(0).MyLT
            '---код запаса
            TextBoxScalaItemCode.Text = Session("ItemList_ItemCode")
            '---название запаса
            TextBoxItemName.Text = MyParamRet(0).MyItemName
            '---код товара поставщика
            TextBoxSupplierItemCode.Text = MyParamRet(0).MySupplierItemCode
            '---код поставщика
            TextBoxSupplierCode.Text = MyParamRet(0).MySupplierCode
            '---название поставщика
            TextBoxSupplierName.Text = MyParamRet(0).MySupplierName
            '---единица измерения
            DropDownListUOM.SelectedValue = MyParamRet(0).MyUOMCode
            '---количество
            TextBoxQTY.Text = "1"
            '---цена
            TextBoxPrice.Text = MyParamRet(0).MyPrice
            '---себестоимость
            TextBoxPriCost.Text = MyParamRet(0).MyPriCost
            If MyParamRet(0).MyPriCost = 0 Then
                TextBoxPriCost.Enabled = True
            Else
                TextBoxPriCost.Enabled = False
            End If
            '---Скидка
            TextBoxDiscount.Text = "0"
            '---Срок готовности на складе (нед)
            TextBoxCPLT.Text = "1"
            '---Срок доставки до клиента (нед)
            TextBoxCPDelTime.Text = "0"

            If Trim(CheckData()) = "" Then
                MarginCalculation()
            End If
        End If
    End Sub

    Private Sub Quit_Click(sender As Object, e As EventArgs) Handles Quit.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// выход из окна без сохранения
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("OrderLinesReturn") = "Yes"
        Session("OrderLinesItemSelect") = ""
        Response.Redirect("OrderLines.aspx", True)
    End Sub

    Private Sub ButtonScalaItemClear_Click(sender As Object, e As EventArgs) Handles ButtonScalaItemClear.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Удаление Скальских параметров и открытие полей для ввода "нескальского" товара
        '//
        '////////////////////////////////////////////////////////////////////////////////

        LabelRecommendedPrice.Text = "Рекомендованная цена и себестоимость  для этого запаса должны быть определены самостоятельно"
        LabelRecommendedPrice.ForeColor = Drawing.Color.DarkRed
        LabelWHAssortiment.Text = ""
        TextBoxQTYInPack.Text = "0"
        TextBoxMinQTY.Text = "0"
        TextBoxLT.Text = "0"
        TextBoxScalaItemCode.Text = "xxxxxx"
        ButtonScalaItemClear.Enabled = False
        TextBoxItemName.Text = ""
        TextBoxItemName.Enabled = True
        TextBoxSupplierItemCode.Text = ""
        TextBoxSupplierItemCode.Enabled = True
        ButtonSuppItemCodeClear.Enabled = True
        ButtonSuppItemCodeSelect.Enabled = True
        TextBoxSupplierCode.Text = "xxxxxx"
        ButtonSupplierClear.Enabled = True
        ButtonSupplierSelect.Enabled = True
        TextBoxSupplierName.Text = ""
        TextBoxSupplierName.Enabled = True
        TextBoxQTY.Text = "1"
        DropDownListUOM.Enabled = True
        TextBoxPrice.Text = "0"
        TextBoxPriCost.Text = "0"
        TextBoxPriCost.Enabled = True
        TextBoxDiscount.Text = "0"
        TextBoxMargin.Text = "0"
        TextBoxCPLT.Text = "1"
        TextBoxCPDelTime.Text = "0"

        If Trim(CheckData()) = "" Then
            MarginCalculation()
        End If
    End Sub

    Private Sub ButtonSuppItemCodeClear_Click(sender As Object, e As EventArgs) Handles ButtonSuppItemCodeClear.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Очистка кода товара поставщика и открытие полей для ввода "нескальского" товара
        '//
        '////////////////////////////////////////////////////////////////////////////////

        LabelRecommendedPrice.Text = "Рекомендованная цена и себестоимость  для этого запаса должны быть определены самостоятельно"
        LabelRecommendedPrice.ForeColor = Drawing.Color.DarkRed
        LabelWHAssortiment.Text = ""
        TextBoxMinQTY.Text = "0"
        TextBoxLT.Text = "0"
        TextBoxSupplierItemCode.Text = ""
        TextBoxSupplierItemCode.Enabled = True
        TextBoxSupplierCode.Text = "xxxxxx"
        TextBoxSupplierName.Text = ""
        TextBoxSupplierName.Enabled = True
        TextBoxQTY.Text = "1"
        TextBoxPrice.Text = "0"
        TextBoxPriCost.Text = "0"
        TextBoxPriCost.Enabled = True
        TextBoxDiscount.Text = "0"
        TextBoxCPLT.Text = "1"
        TextBoxCPDelTime.Text = "0"

        If Trim(CheckData()) = "" Then
            MarginCalculation()
        End If
    End Sub

    Private Sub ButtonSupplierClear_Click(sender As Object, e As EventArgs) Handles ButtonSupplierClear.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Очистка кода поставщика и открытие поля для редактирования
        '//
        '////////////////////////////////////////////////////////////////////////////////

        TextBoxSupplierCode.Text = "xxxxxx"
        TextBoxSupplierName.Text = ""
        TextBoxSupplierName.Enabled = True
    End Sub

    Private Sub ButtonSupplierSelect_Click(sender As Object, e As EventArgs) Handles ButtonSupplierSelect.Click
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

        TextBoxSupplierCode.Text = Trim(Server.HtmlDecode(GridView3.Rows(GridView3_SelRow).Cells(0).Text))
        TextBoxSupplierName.Text = Trim(Server.HtmlDecode(GridView3.Rows(GridView3_SelRow).Cells(1).Text))
        TextBoxSupplierName.Enabled = False
        DivBG.Disabled = True
        DivBG.Visible = False
        DivSuppliers.Disabled = True
        DivSuppliers.Visible = False
    End Sub

    Private Sub ButtonSuppItemCodeSelect_Click(sender As Object, e As EventArgs) Handles ButtonSuppItemCodeSelect.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// поиск кодов товара поставщика 
        '//
        '////////////////////////////////////////////////////////////////////////////////

        DivBG.Disabled = False
        DivBG.Visible = True
        DivSuppItemCodes.Disabled = False
        DivSuppItemCodes.Visible = True
    End Sub

    Protected Sub SICListLoad(MyType As Integer)
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// загрузка данных в таблицу кодов товара поставщика
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim obj As New ServiceReference1.SWIServiceClient
        Dim MyParam As New ServiceReference1.SWIServiceGetItemSuppParameters

        obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
        obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

        If Session("SICList_PageNum") = "" Then
            Session("SICList_PageNum") = "0"
        End If
        If Session("SICList_QTYOnPage") = "" Then
            Session("SICList_QTYOnPage") = "20"
            QTYOnPageListSupp.SelectedValue = "20"
        End If

        Try
            MyParam.MyCPID = Session("CPNumber")
            MyParam.MyPageNum = Session("SICList_PageNum")
            MyParam.MySubstring1 = Trim(SICSubstring1.Text)
            MyParam.MySubstring2 = Trim(SICSubstring2.Text)
            MyParam.MyQTYOnPage = Session("SICList_QTYOnPage")
            GridView1.DataSource = obj.GetItemSupp(MyParam).Tables(0)
            GridView1.Columns(8).Visible = True
            GridView1.SelectedIndex = 0
            GridView1.DataBind()
        Catch
        End Try

        If GridView1.Rows.Count > 0 Then
            SICStrQTY = GridView1.Rows(0).Cells(8).Text
            GridView1.Columns(8).Visible = False
        Else
            SICStrQTY = 0
        End If

        If MyType = 0 Then
            PagesListSIC.Items.Clear()
            For i As Integer = 1 To System.Math.Ceiling(SICStrQTY / Session("SICList_QTYOnPage"))
                PagesListSIC.Items.Insert(i - 1, i.ToString())
            Next
            LabelSICQTYPages.Text = " из " + CStr(System.Math.Ceiling(SICStrQTY / Session("SICList_QTYOnPage")))
        End If

        ChangeSelRow1()
    End Sub

    Protected Sub CheckSICButtonState()
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// проверка состояния кнопок в слое списка поставщиков
        '//
        '////////////////////////////////////////////////////////////////////////////////

        If GridView1.Rows.Count = 0 Then
            ButtonSICSelect.Enabled = False
        Else
            ButtonSICSelect.Enabled = True
        End If
    End Sub

    Private Sub ChangeSelRow1()
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение подсветки выбранной строки в списке кодов товара поставщика
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Try
            If GridView1_SelRow <> GridView1_SelRowOld Then
                GridView1.Rows(GridView1_SelRow).BackColor = Drawing.Color.FromArgb(68, 68, 255)
                GridView1.Rows(GridView1_SelRowOld).BackColor = Drawing.Color.White
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// подсвечивание строк в списке кодов товара поставщика
        '//
        '////////////////////////////////////////////////////////////////////////////////

        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" & e.Row.RowIndex)
            e.Row.Attributes.Add("OnMouseOver", "this.style.cursor = 'pointer'")

            If e.Row.RowIndex = GridView1.SelectedIndex Then
                e.Row.BackColor = Drawing.Color.FromArgb(68, 68, 255)
            Else
                e.Row.BackColor = Drawing.Color.White
            End If
        End If
    End Sub

    Private Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение выделенной строки после того, как событие свершилось (поставщики)
        '//
        '////////////////////////////////////////////////////////////////////////////////

        GridView1.SelectedIndex = GridView1_SelRow
        Session("SICList_SelectIndex") = GridView1.SelectedIndex
        ChangeSelRow1()
        CheckSICButtonState()
    End Sub

    Private Sub GridView1_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// выбор строки с кодом товара поставщика
        '//
        '////////////////////////////////////////////////////////////////////////////////

        GridView1_SelRowOld = GridView1_SelRow
        GridView1_SelRow = e.NewSelectedIndex
    End Sub

    Private Sub PagesListSIC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PagesListSIC.SelectedIndexChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение номера выводимой страницы с кодом товара поставщика
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Try
            Session("SICList_PageNum") = CStr(PagesListSIC.SelectedIndex)
        Catch ex As Exception
        End Try
        GridView1_SelRowOld = GridView1_SelRow
        GridView1_SelRow = 0
        Session("SICList_SelectIndex") = "0"
        SICListLoad(1)
        CheckSICButtonState()
    End Sub

    Private Sub QTYOnPageListSIC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles QTYOnPageListSIC.SelectedIndexChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение выводимого на странице количества кодов товара поставщиков
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("SICList_QTYOnPage") = QTYOnPageListSIC.SelectedValue
        PagesListSIC.Items.Clear()
        For i As Integer = 1 To System.Math.Ceiling(SICStrQTY / Session("SICList_QTYOnPage"))
            PagesListSIC.Items.Insert(i - 1, i.ToString())
        Next
        LabelSICQTYPages.Text = " из " + CStr(System.Math.Ceiling(SICStrQTY / Session("SICList_QTYOnPage")))
        Session("SICList_PageNum") = "0"

        Try
            Session("SICList_PageNum") = CStr(PagesListSIC.SelectedIndex)
        Catch ex As Exception
        End Try
        GridView1_SelRowOld = GridView1_SelRow
        GridView1_SelRow = 0
        Session("SICList_SelectIndex") = "0"

        SICListLoad(1)
        CheckSICButtonState()
    End Sub

    Private Sub ButtonSICCancel_Click(sender As Object, e As EventArgs) Handles ButtonSICCancel.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// отмена выбора кода товара поставщика из списка
        '//
        '////////////////////////////////////////////////////////////////////////////////

        DivBG.Disabled = True
        DivBG.Visible = False
        DivSuppItemCodes.Disabled = True
        DivSuppItemCodes.Visible = False
    End Sub

    Private Sub ButtonSICSearch_Click(sender As Object, e As EventArgs) Handles ButtonSICSearch.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Поиск кода товара поставщика
        '//
        '////////////////////////////////////////////////////////////////////////////////

        SICListLoad(0)
        CheckSICButtonState()
    End Sub

    Private Sub ButtonSICSelect_Click(sender As Object, e As EventArgs) Handles ButtonSICSelect.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Код товара поставщика выбран в списке
        '//
        '////////////////////////////////////////////////////////////////////////////////

        LabelRecommendedPrice.Text = "Рекомендованная цена и себестоимость этого запаса на основе прайс - листа на закупку"
        LabelRecommendedPrice.ForeColor = Drawing.Color.DarkGreen
        LabelWHAssortiment.Text = ""
        TextBoxMinQTY.Text = Trim(Server.HtmlDecode(GridView1.Rows(GridView1_SelRow).Cells(5).Text))
        TextBoxLT.Text = Trim(Server.HtmlDecode(GridView1.Rows(GridView1_SelRow).Cells(6).Text))
        TextBoxSupplierItemCode.Text = Trim(Server.HtmlDecode(GridView1.Rows(GridView1_SelRow).Cells(0).Text))
        TextBoxSupplierItemCode.Enabled = False
        TextBoxSupplierCode.Text = Trim(Server.HtmlDecode(GridView1.Rows(GridView1_SelRow).Cells(3).Text))
        TextBoxSupplierName.Text = Trim(Server.HtmlDecode(GridView1.Rows(GridView1_SelRow).Cells(4).Text))
        TextBoxSupplierName.Enabled = False
        TextBoxQTY.Text = "1"
        TextBoxPrice.Text = Trim(Server.HtmlDecode(GridView1.Rows(GridView1_SelRow).Cells(1).Text))
        TextBoxPriCost.Text = Trim(Server.HtmlDecode(GridView1.Rows(GridView1_SelRow).Cells(2).Text))
        TextBoxPriCost.Enabled = False
        TextBoxDiscount.Text = "0"
        TextBoxCPLT.Text = Trim(Server.HtmlDecode(GridView1.Rows(GridView1_SelRow).Cells(7).Text))

        If Trim(CheckData()) = "" Then
            MarginCalculation()
        End If

        DivBG.Disabled = True
        DivBG.Visible = False
        DivSuppItemCodes.Disabled = True
        DivSuppItemCodes.Visible = False
    End Sub

    Private Function CheckData() As String
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// проверка ввода данных в поля 
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim ErrMessage As String
        Dim MyRez As Double

        '------------себестоимость
        If Trim(TextBoxPriCost.Text) = "" And TextBoxPriCost.Enabled = True Then
            ErrMessage = "Необходимо заполнить поле ""Себестоимость единицы""."
            CheckData = ErrMessage
            Exit Function
        End If

        Try
            MyRez = CDbl(TextBoxPriCost.Text)
            TextBoxPriCost.Text = CStr(CDbl(TextBoxPriCost.Text))
        Catch ex As Exception
            ErrMessage = "В поле ""Себестоимость единицы"" должно быть введено число."
            CheckData = ErrMessage
            Exit Function
        End Try

        '-------------Цена
        If Trim(TextBoxPrice.Text) = "" Then
            ErrMessage = "Необходимо заполнить поле ""Цена за единицу""."
            CheckData = ErrMessage
            Exit Function
        End If

        Try
            MyRez = CDbl(TextBoxPrice.Text)
            TextBoxPrice.Text = CStr(CDbl(TextBoxPrice.Text))
        Catch ex As Exception
            ErrMessage = "В поле ""Цена за единицу"" должно быть введено число."
            CheckData = ErrMessage
            Exit Function
        End Try

        '-------------Скидка
        If Trim(TextBoxDiscount.Text) = "" Then
            ErrMessage = "Необходимо заполнить поле ""Скидка"". Если скидки нет - в поле должен быть введен 0"
            CheckData = ErrMessage
            Exit Function
        End If

        Try
            MyRez = CDbl(TextBoxDiscount.Text)
            TextBoxDiscount.Text = CStr(CDbl(TextBoxDiscount.Text))
        Catch ex As Exception
            ErrMessage = "В поле ""Скидка"" должно быть введено число."
            CheckData = ErrMessage
            Exit Function
        End Try
    End Function

    Private Function CheckDataFilling() As String
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// проверка заполнения полей данных
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim ErrMessage As String
        Dim MyRez As Double

        '------------название запаса
        If Trim(TextBoxItemName.Text) = "" And TextBoxItemName.Enabled = True Then
            ErrMessage = "Необходимо заполнить поле ""название запаса""."
            CheckDataFilling = ErrMessage
            Exit Function
        End If

        '------------название поставщика
        If Trim(TextBoxSupplierName.Text) = "" And TextBoxSupplierName.Enabled = True Then
            ErrMessage = "Необходимо заполнить поле ""название поставщика""."
            CheckDataFilling = ErrMessage
            Exit Function
        End If

        '------------количество
        If Trim(TextBoxQTY.Text) = "" Then
            ErrMessage = "Необходимо заполнить поле ""Количество""."
            CheckDataFilling = ErrMessage
            Exit Function
        End If

        Try
            MyRez = CDbl(TextBoxQTY.Text)
            TextBoxQTY.Text = CStr(CDbl(TextBoxQTY.Text))
        Catch ex As Exception
            ErrMessage = "В поле ""Количество"" должно быть введено число."
            CheckDataFilling = ErrMessage
            Exit Function
        End Try

        '------------срок поставки в неделях
        If Trim(TextBoxCPLT.Text) = "" Then
            ErrMessage = "Необходимо заполнить поле ""Срок поставки (нед)""."
            CheckDataFilling = ErrMessage
            Exit Function
        End If

        Try
            MyRez = CDbl(TextBoxCPLT.Text)
            TextBoxCPLT.Text = CStr(CDbl(TextBoxCPLT.Text))
        Catch ex As Exception
            ErrMessage = "В поле ""Срок поставки (нед)"" должно быть введено число."
            CheckDataFilling = ErrMessage
            Exit Function
        End Try

        '------------срок доставки до клиента в неделях
        If Trim(TextBoxCPDelTime.Text) = "" Then
            ErrMessage = "Необходимо заполнить поле ""Срок доставки до клиента (нед)""."
            CheckDataFilling = ErrMessage
            Exit Function
        End If

        Try
            MyRez = CDbl(TextBoxCPDelTime.Text)
            TextBoxCPDelTime.Text = CStr(CDbl(TextBoxCPDelTime.Text))
        Catch ex As Exception
            ErrMessage = "В поле ""Срок доставки до клиента (нед)"" должно быть введено число."
            CheckDataFilling = ErrMessage
            Exit Function
        End Try

        '------------срок доставки до клиента в неделях должен быть меньше или равен сроку поставки
        If CDbl(TextBoxCPDelTime.Text) > CDbl(TextBoxCPLT.Text) Then
            ErrMessage = "Срок доставки до клиента не может быть больше всего срока поставки. Откорректируйте срок поставки или срок доставки до клиента."
            CheckDataFilling = ErrMessage
            Exit Function
        End If


        CheckDataFilling = ""
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
        DivBG.Disabled = True
        DivBG.Visible = False
    End Sub

    Private Sub TextBoxPrice_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPrice.TextChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Введено новое значение цены 
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim ErrMessage As String

        ErrMessage = Trim(CheckData())
        If ErrMessage = "" Then
            MarginCalculation()
        Else
            LabelErr.Text = ErrMessage
            DivErr.Disabled = False
            DivErr.Visible = True
            DivBG.Disabled = False
            DivBG.Visible = True
        End If
    End Sub

    Private Sub TextBoxPriCost_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPriCost.TextChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Введено новое значение себестоимости 
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim ErrMessage As String

        ErrMessage = Trim(CheckData())
        If ErrMessage = "" Then
            MarginCalculation()
        Else
            LabelErr.Text = ErrMessage
            DivErr.Disabled = False
            DivErr.Visible = True
            DivBG.Disabled = False
            DivBG.Visible = True
        End If
    End Sub

    Private Sub TextBoxDiscount_TextChanged(sender As Object, e As EventArgs) Handles TextBoxDiscount.TextChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Введено новое значение скидки 
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim ErrMessage As String

        ErrMessage = Trim(CheckData())
        If ErrMessage = "" Then
            MarginCalculation()
        Else
            LabelErr.Text = ErrMessage
            DivErr.Disabled = False
            DivErr.Visible = True
            DivBG.Disabled = False
            DivBG.Visible = True
        End If
    End Sub

    Private Sub MarginCalculation()
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// расчет и демонстрация нового значения маржи
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim DiscPrice As Double

        If CDbl(TextBoxPrice.Text) = 0 Then
            TextBoxMargin.Text = "0"
        Else
            DiscPrice = CDbl(TextBoxPrice.Text) * (100 - CDbl(TextBoxDiscount.Text)) / 100
            TextBoxMargin.Text = CStr(Math.Round((DiscPrice - CDbl(TextBoxPriCost.Text)) / DiscPrice * 100, 2))
        End If
    End Sub

    Private Sub SaveQuit_Click(sender As Object, e As EventArgs) Handles SaveQuit.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// выход с запоминанием
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim ErrMessage As String

        ErrMessage = Trim(CheckDataFilling())
        If ErrMessage = "" Then
            ErrMessage = Trim(CheckData())
            If ErrMessage = "" Then
                Dim obj As New ServiceReference1.SWIServiceClient
                Dim MyParam As New ServiceReference1.SWIServiceAddOrderParameters

                obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
                obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

                MyParam.MyOrder = Session("CPNumber")
                MyParam.MyStr = Session("ItemList_CPItem_StrNum")
                MyParam.MyCode = Trim(TextBoxScalaItemCode.Text)
                MyParam.MyName1 = Left(Trim(TextBoxItemName.Text), 25)
                MyParam.MyName2 = Mid(Trim(TextBoxItemName.Text), 26, 25)
                MyParam.MyCost = CDbl(TextBoxPrice.Text)
                MyParam.MyCostIntr = CDbl(TextBoxPriCost.Text)
                MyParam.MyQty = CDbl(TextBoxQTY.Text)
                MyParam.MyWh = Session("ItemList_WHNum")
                MyParam.MyUnit = DropDownListUOM.SelectedValue
                MyParam.MyDiscount = CDbl(TextBoxDiscount.Text)
                MyParam.MyWeekQTY = CDbl(TextBoxCPLT.Text)
                MyParam.MyDelWeekQTY = CDbl(TextBoxCPDelTime.Text)
                obj.AddOrder(MyParam)

                Session("OrderLinesReturn") = "Yes+1"
                Session("OrderLinesItemSelect") = ""
                Response.Redirect("OrderLines.aspx", True)
            Else
                LabelErr.Text = ErrMessage
                DivErr.Disabled = False
                DivErr.Visible = True
                DivBG.Disabled = False
                DivBG.Visible = True
            End If
        Else
            LabelErr.Text = ErrMessage
            DivErr.Disabled = False
            DivErr.Visible = True
            DivBG.Disabled = False
            DivBG.Visible = True
        End If
    End Sub
End Class