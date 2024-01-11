Imports System.Data.OleDb

Public Class EditHeader
    Inherits System.Web.UI.Page
    Public Shared GridView1_SelRow As Integer = 0
    Public Shared GridView1_SelRowOld As Integer = 0
    Public Shared StrQTY As Integer = 0
    Public Shared ErrMessage As String = ""
    Public Shared MyQuestion As String = ""

    '////////////////////////////////////////////////////////////////////////////////
    '//
    '// переменные сессии для данного окна
    '//
    '////////////////////////////////////////////////////////////////////////////////
    '//
    '//     CPNumber                                        '--ID коммерческого предложения
    '//     CPMode                                          '--режим открытия окна "New" - новое КП "Edit" - открытие на редактирование
    '//     CustomerList_PageNum                            '--номер выводимой страницы клиента
    '//     CustomerList_QTYOnPage                          '--количество записей клиентов на странице
    '//     CustomerList_SelectIndex                        '--выбранная строка в Grid
    '//     
    '//     
    '//     
    '//
    '//
    '//
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// загрузка страницы, параметры
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim obj As New ServiceReference1.SWIServiceClient
        Dim MyParam1 As New ServiceReference1.SWIServiceGetSalesmanListParameters
        Dim MyParam2 As New ServiceReference1.SWIServiceGetCPHeaderParameters
        Dim MyRetParam() As ServiceReference1.SWIServiceGetCPHeaderParametersRet

        obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
        obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

        If Session("AgentFullName") = "" Then
            Response.Redirect("Login.aspx", True)
        End If

        Page.ClientScript.GetPostBackEventReference(GridView1, "")

        If Not IsPostBack Then
            AgentName.Text = Session("AgentFullName")
            '-------------Список продавцов-----------------------------------------------
            MyParam1.MyAllSalesmanFlag = 0
            DropDownListSalesman.Items.Add(New ListItem("    Выберите продавца", "---"))
            DropDownListSalesman.DataSource = obj.GetSalesmanList(MyParam1).Tables(0)
            DropDownListSalesman.DataTextField = "SalesmanName"
            DropDownListSalesman.DataValueField = "SalesmanCode"
            DropDownListSalesman.DataBind()

            '-------------Список складов-------------------------------------------------
            DropDownListWH.Items.Add(New ListItem("    Выберите склад", "---"))
            DropDownListWH.DataSource = obj.GetWHList().Tables(0)
            DropDownListWH.DataTextField = "WHName"
            DropDownListWH.DataValueField = "WHCode"
            DropDownListWH.DataBind()

            '-------------код документа--------------------------------------------------
            DropDownListDocCodes.Items.Add(New ListItem("    Выберите код документа", "---"))
            DropDownListDocCodes.DataSource = obj.GetDocCodesList().Tables(0)
            DropDownListDocCodes.DataTextField = "DocName"
            DropDownListDocCodes.DataValueField = "DocCode"
            DropDownListDocCodes.DataBind()

            '-------------Список валют---------------------------------------------------
            DropDownListCurr.Items.Add(New ListItem("    Выберите валюту КП", "---"))
            DropDownListCurr.DataSource = obj.GetCurrencyList().Tables(0)
            DropDownListCurr.DataTextField = "CurrName"
            DropDownListCurr.DataValueField = "CurrCode"
            DropDownListCurr.DataBind()

            '-------------список условий выставления цены--------------------------------
            DropDownListPriceCond.Items.Add(New ListItem("    Выберите условие выставления цены", "---"))
            DropDownListPriceCond.DataSource = obj.GetPriceConditionList().Tables(0)
            DropDownListPriceCond.DataTextField = "CondName"
            DropDownListPriceCond.DataValueField = "CondName"
            DropDownListPriceCond.DataBind()

            '-------------список возможностей частичной поставки-------------------------
            DropDownListPartialDel.Items.Add(New ListItem("    Выберите возможность частичной поставки", "---"))
            DropDownListPartialDel.DataSource = obj.GetPartialDeliveryVariantsList().Tables(0)
            DropDownListPartialDel.DataTextField = "VName"
            DropDownListPartialDel.DataValueField = "VCode"
            DropDownListPartialDel.DataBind()

            '--Список - по каким колонкам производится поиск клиента---------------------
            DropDownListFields.DataSource = obj.GetCustomerColumns().Tables(0)
            DropDownListFields.DataTextField = "ColumnName"
            DropDownListFields.DataValueField = "ColumnCode"
            DropDownListFields.DataBind()


            If Session("CPMode") = "New" Then
                '-----Получение нового кода КП-------------------------------------------
                CPNumber.Text = obj.GetCPNewNumber()
                Session("CPNumber") = CPNumber.Text
                CustomerNumber.Text = "XXXXXX"
                CustomerName.Enabled = True
                CustomerAddress.Enabled = True
                CPValidTo.Text = Right("00" + CStr(Day(DateAdd(DateInterval.Day, 5, System.DateTime.Now))), 2) + "/" + Right("00" + CStr(Month(DateAdd(DateInterval.Day, 5, System.DateTime.Now))), 2) + "/" + CStr(Year(DateAdd(DateInterval.Day, 5, System.DateTime.Now)))
            Else
                CPNumber.Text = Session("CPNumber")

                '----------Получение данных по редактируемому заказу---------------------
                MyParam2.MyCPID = Session("CPNumber")
                MyRetParam = obj.GetCPHeader(MyParam2)
                If Trim(MyRetParam(0).MyScalaCustomerCode) = "" Then
                    CustomerName.Enabled = True
                    CustomerAddress.Enabled = True
                    CustomerNumber.Text = "XXXXXX" 'MyRetParam(0).MyCPCustomerCode
                    CustomerName.Text = MyRetParam(0).MyCPCustomerName
                    CustomerAddress.Text = MyRetParam(0).MyCPCustomerAddress
                Else
                    CustomerName.Enabled = False
                    CustomerAddress.Enabled = False
                    CustomerNumber.Text = MyRetParam(0).MyScalaCustomerCode
                    CustomerName.Text = MyRetParam(0).MyScalaCustomerName
                    CustomerAddress.Text = MyRetParam(0).MyScalaCustomerAddress
                End If
                DropDownListSalesman.SelectedValue = MyRetParam(0).MySalesmanCode
                DropDownListWH.SelectedValue = MyRetParam(0).MyWHCode
                DropDownListDocCodes.SelectedValue = MyRetParam(0).MyDocCode
                DropDownListCurr.SelectedValue = MyRetParam(0).MyCPCurrencyCode
                Comments.Text = MyRetParam(0).MyCPComment
                DropDownListPriceCond.SelectedValue = MyRetParam(0).MyPriceCond
                PaymentsCondition.Text = MyRetParam(0).MyPaymentCond
                If CDate(MyRetParam(0).MyExpirationDate) < CDate(Right("00" + CStr(Day(System.DateTime.Now)), 2) + "/" + Right("00" + CStr(Month(System.DateTime.Now)), 2) + "/" + CStr(Year(System.DateTime.Now))) Then
                    CPValidTo.Text = Right("00" + CStr(Day(DateAdd(DateInterval.Day, 5, System.DateTime.Now))), 2) + "/" + Right("00" + CStr(Month(DateAdd(DateInterval.Day, 5, System.DateTime.Now))), 2) + "/" + CStr(Year(DateAdd(DateInterval.Day, 5, System.DateTime.Now)))
                Else
                    CPValidTo.Text = MyRetParam(0).MyExpirationDate
                End If
                DropDownListPartialDel.SelectedValue = MyRetParam(0).MyPartialShipmentCode
            End If
        End If
    End Sub

    Private Sub ButtonDateExp_Click(sender As Object, e As EventArgs) Handles ButtonDateExp.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// При открытии календаря "дата С" выставляем на нем дату из строки и место открытия
        '//
        '////////////////////////////////////////////////////////////////////////////////

        CalendarExp.SelectedDate = CPValidTo.Text
        CalendarExp.VisibleDate = CPValidTo.Text

        MyDate1.Disabled = False
        MyDate1.Visible = True
        DivBG.Disabled = False
        DivBG.Visible = True
    End Sub

    Private Sub ButtonSelectData1_Click(sender As Object, e As EventArgs) Handles ButtonSelectData1.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// При закрытии календаря "дата С" проверяем выбор и пишем в строку выбранную дату из календаря
        '//
        '////////////////////////////////////////////////////////////////////////////////

        If CalendarExp.SelectedDate < Now Then
            '---ошибка - дата меньше текущей
            LabelErr.Text = "Внимание! Дата действительности коммерческого предложения не может быть меньше текущей даты!"
            DivErr.Disabled = False
            DivErr.Visible = True
            MyDate1.Disabled = True
            MyDate1.Visible = False
        Else
            CPValidTo.Text = Right("00" + CStr(Day(CalendarExp.SelectedDate)), 2) + "/" + Right("00" + CStr(Month(CalendarExp.SelectedDate)), 2) + "/" + CStr(Year(CalendarExp.SelectedDate))
            MyDate1.Disabled = True
            MyDate1.Visible = False
            DivBG.Disabled = True
            DivBG.Visible = False
        End If

    End Sub

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

    Private Sub ButtonCustomCustomer_Click(sender As Object, e As EventArgs) Handles ButtonCustomCustomer.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// клиент не из Scala - ввод вручную
        '//
        '////////////////////////////////////////////////////////////////////////////////

        CustomerName.Enabled = True
        CustomerAddress.Enabled = True
        CustomerNumber.Text = "XXXXXX"
        CustomerName.Text = ""
        CustomerAddress.Text = ""
    End Sub

    Private Sub SelectCustomer_Click(sender As Object, e As EventArgs) Handles SelectCustomer.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// выбор скальского клиента из списка
        '//
        '////////////////////////////////////////////////////////////////////////////////


        DivBG.Disabled = False
        DivBG.Visible = True
        DivCustomers.Disabled = False
        DivCustomers.Visible = True
    End Sub

    Private Sub ButtonCustomCancel_Click(sender As Object, e As EventArgs) Handles ButtonCustomCancel.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// отмена выбора скальского клиента из списка
        '//
        '////////////////////////////////////////////////////////////////////////////////


        DivBG.Disabled = True
        DivBG.Visible = False
        DivCustomers.Disabled = True
        DivCustomers.Visible = False
    End Sub

    Private Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// поиск скальского клиента 
        '//
        '////////////////////////////////////////////////////////////////////////////////

        CustomerListLoad(0)
        CheckCustomerButtonState()
    End Sub


    Protected Sub CustomerListLoad(MyType As Integer)
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// загрузка данных в таблицу клиентов 
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim obj As New ServiceReference1.SWIServiceClient
        Dim MyParam As New ServiceReference1.SWIServiceGetCustomerListParameters

        obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
        obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

        If Session("CustomerList_PageNum") = "" Then
            Session("CustomerList_PageNum") = "0"
        End If
        If Session("CustomerList_QTYOnPage") = "" Then
            Session("CustomerList_QTYOnPage") = "20"
            QTYOnPageList.SelectedValue = "20"
        End If

        Try
            MyParam.MyPageNum = Session("CustomerList_PageNum")
            MyParam.MySubstring1 = Trim(Substring1.Text)
            MyParam.MySubstring2 = Trim(Substring2.Text)
            MyParam.MyProductsSearchColumns = DropDownListFields.SelectedValue
            MyParam.MyQTYOnPage = Session("CustomerList_QTYOnPage")
            GridView1.DataSource = obj.GetCustomerList(MyParam).Tables(0)
            GridView1.Columns(4).Visible = True
            GridView1.SelectedIndex = 0
            GridView1.DataBind()


        Catch
        End Try

        If GridView1.Rows.Count > 0 Then
            StrQTY = GridView1.Rows(0).Cells(4).Text
            GridView1.Columns(4).Visible = False
        Else
            StrQTY = 0
        End If

        If MyType = 0 Then
            PagesList.Items.Clear()
            For i As Integer = 1 To System.Math.Ceiling(StrQTY / Session("CustomerList_QTYOnPage"))
                PagesList.Items.Insert(i - 1, i.ToString())
            Next
            LabelQTYPages.Text = " из " + CStr(System.Math.Ceiling(StrQTY / Session("CustomerList_QTYOnPage")))
        End If

        ChangeSelRow()
    End Sub

    Protected Sub CheckCustomerButtonState()
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// проверка состояния кнопок в слое списка клиентов
        '//
        '////////////////////////////////////////////////////////////////////////////////

        If GridView1.Rows.Count = 0 Then
            ButtonCustomSelect.Enabled = False
        Else
            ButtonCustomSelect.Enabled = True
        End If
    End Sub

    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// подсвечивание строк
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

    Protected Sub ChangeSelRow()
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение подсветки выбранной строки
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

    Private Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение выделенной строки после того, как событие свершилось
        '//
        '////////////////////////////////////////////////////////////////////////////////

        GridView1.SelectedIndex = GridView1_SelRow
        Session("CustomerList_SelectIndex") = GridView1.SelectedIndex
        ChangeSelRow()
        CheckCustomerButtonState()
    End Sub

    Private Sub GridView1_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// выбор строки
        '//
        '////////////////////////////////////////////////////////////////////////////////

        GridView1_SelRowOld = GridView1_SelRow
        GridView1_SelRow = e.NewSelectedIndex
    End Sub

    Private Sub PagesList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PagesList.SelectedIndexChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение номера выводимой страницы
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Try
            Session("CustomerList_PageNum") = CStr(PagesList.SelectedIndex)
        Catch ex As Exception
        End Try
        GridView1_SelRowOld = GridView1_SelRow
        GridView1_SelRow = 0
        Session("CustomerList_SelectIndex") = "0"
        CustomerListLoad(1)
        CheckCustomerButtonState()
    End Sub

    Private Sub QTYOnPageList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles QTYOnPageList.SelectedIndexChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение выводимого на странице количества
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("CustomerList_QTYOnPage") = QTYOnPageList.SelectedValue
        PagesList.Items.Clear()
        For i As Integer = 1 To System.Math.Ceiling(StrQTY / Session("CustomerList_QTYOnPage"))
            PagesList.Items.Insert(i - 1, i.ToString())
        Next
        LabelQTYPages.Text = " из " + CStr(System.Math.Ceiling(StrQTY / Session("CustomerList_QTYOnPage")))
        Session("CustomerList_PageNum") = "0"

        Try
            Session("CustomerList_PageNum") = CStr(PagesList.SelectedIndex)
        Catch ex As Exception
        End Try
        GridView1_SelRowOld = GridView1_SelRow
        GridView1_SelRow = 0
        Session("CustomerList_SelectIndex") = "0"

        CustomerListLoad(1)
        CheckCustomerButtonState()
    End Sub

    Private Sub ButtonCustomSelect_Click(sender As Object, e As EventArgs) Handles ButtonCustomSelect.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// клиент выбран в списке
        '//
        '////////////////////////////////////////////////////////////////////////////////

        CustomerNumber.Text = Server.HtmlDecode(GridView1.Rows(GridView1_SelRow).Cells(0).Text)
        CustomerName.Text = Server.HtmlDecode(GridView1.Rows(GridView1_SelRow).Cells(1).Text)
        CustomerAddress.Text = Server.HtmlDecode(GridView1.Rows(GridView1_SelRow).Cells(2).Text)
        CustomerName.Enabled = False
        CustomerAddress.Enabled = False
        DivBG.Disabled = True
        DivBG.Visible = False
        DivCustomers.Disabled = True
        DivCustomers.Visible = False
    End Sub

    Private Sub Quit_Click(sender As Object, e As EventArgs) Handles Quit.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// выход из окна без сохранения результатов
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("CPList_Return") = "Yes"
        Response.Redirect("ProposalList.aspx", True)
    End Sub

    Private Sub CPPrint_Click(sender As Object, e As EventArgs) Handles CPPrint.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Печать коммерческого предложения
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim MyStr As String

        If CheckDataFilling() = True Then
            '----------проверка данных в КП
            MyStr = Trim(CheckCPData())
            If MyStr = "" Then
                SaveCP()
                '--------перем сессии
                If Session("CPMode") = "New" Then
                    If Session("CPList_Sel_Index") = Session("CPList_QTYOn") Then
                        Session("CPList_Return") = "Yes+2"
                    Else
                        Session("CPList_Return") = "Yes+1"
                    End If
                Else
                    Session("CPList_Return") = "Yes"
                End If
                Session("CPPrintFrom") = "Header"
                Response.Redirect("CPPrint.aspx", True)
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

    Private Sub SaveQuit_Click(sender As Object, e As EventArgs) Handles SaveQuit.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// выход из окна c сохранением результатов
        '//
        '////////////////////////////////////////////////////////////////////////////////

        If CheckDataFilling() = True Then
            '----------------проверка - есть ли строки в КП
            If CheckEmptyHDR() = -1 Then
                LabelErr.Text = ErrMessage
                DivErr.Disabled = False
                DivErr.Visible = True
                DivBG.Disabled = False
                DivBG.Visible = True
                Exit Sub
            ElseIf CheckEmptyHDR() = 0 Then
                MyQuestion = "EmptyCP"
                LabelQuestion.Text = "В вашем коммерческом предложении нет ни одной строки. Удалить заголовок этого коммерческого предложения?"
                DivQuestion.Disabled = False
                DivQuestion.Visible = True
                DivBG.Disabled = False
                DivBG.Visible = True
            Else
                SaveQuit_CheckData()
            End If
        Else
            LabelErr.Text = ErrMessage
            DivErr.Disabled = False
            DivErr.Visible = True
            DivBG.Disabled = False
            DivBG.Visible = True
        End If
    End Sub

    Private Sub SaveQuit_DeleteCP()
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Удаление КП при проверке на 0 строк при сохранении и выходе
        '//
        '////////////////////////////////////////////////////////////////////////////////

        '----------удаление КП
        DeleteCP()
        If Session("CPMode") = "New" Then
            Session("CPList_Return") = "Yes"
        Else
            If Session("CPList_Sel_Index") = 0 Then
                Session("CPList_Return") = "Yes-2"
            Else
                Session("CPList_Return") = "Yes-1"
            End If

        End If
        Response.Redirect("ProposalList.aspx", True)
    End Sub

    Private Sub SaveQuit_CheckData()
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// проверка данных в КП при сохранении и выходе
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim MyStr As String

        '----------проверка данных в КП
        MyStr = Trim(CheckCPData())
        If MyStr = "" Then
            SaveQuit_SaveCP()
        Else
            MyQuestion = "ErrorCP"
            LabelQuestion.Text = "В строках вашего коммерческого предложения есть проблема: " & MyStr & ". Вы хотите отменить операцию сохранения и отредактировать строки?"
            DivQuestion.Disabled = False
            DivQuestion.Visible = True
            DivBG.Disabled = False
            DivBG.Visible = True
        End If
    End Sub

    Private Sub SaveQuit_SaveCP()
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Сохранение данных в КП при сохранении и выходе
        '//
        '////////////////////////////////////////////////////////////////////////////////

        '------------сохранение КП
        SaveCP()
        If Session("CPMode") = "New" Then
            If Session("CPList_LastStr") = Session("CPList_QTYOn") Then
                Session("CPList_Return") = "Yes+2"
            Else
                Session("CPList_Return") = "Yes+1"
            End If
        Else
            Session("CPList_Return") = "Yes"
        End If
        Response.Redirect("ProposalList.aspx", True)
    End Sub

    Private Function CheckDataFilling() As Boolean
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Проверка заполнения полей формы
        '//
        '////////////////////////////////////////////////////////////////////////////////

        '------------продавец
        If DropDownListSalesman.SelectedValue = "---" Then
            ErrMessage = "Необходимо выбрать продавца, который отвечает за коммерческое предложение."
            CheckDataFilling = False
            Exit Function
        End If

        '------------имя покупателя
        If Trim(CustomerName.Text) = "" And CustomerName.Enabled = True Then
            ErrMessage = "Необходимо заполнить поле ""Покупатель""."
            CheckDataFilling = False
            Exit Function
        End If

        '------------адрес покупателя
        If Trim(CustomerAddress.Text) = "" And CustomerAddress.Enabled = True Then
            ErrMessage = "Необходимо заполнить поле ""Адрес покупателя""."
            CheckDataFilling = False
            Exit Function
        End If

        '------------склад
        If DropDownListWH.SelectedValue = "---" Then
            ErrMessage = "Необходимо выбрать склад, с которого будет осуществляться отгрузка."
            CheckDataFilling = False
            Exit Function
        End If

        '------------Код документа
        If DropDownListDocCodes.SelectedValue = "---" Then
            ErrMessage = "Необходимо код документа для данного коммерческого предложения."
            CheckDataFilling = False
            Exit Function
        End If

        '------------Валюта
        If DropDownListCurr.SelectedValue = "---" Then
            ErrMessage = "Необходимо выбрать валюту для данного коммерческого предложения."
            CheckDataFilling = False
            Exit Function
        End If

        '------------Условие выставления цены
        If DropDownListPriceCond.SelectedValue = "---" Then
            ErrMessage = "Необходимо выбрать условие выставления цены для данного коммерческого предложения."
            CheckDataFilling = False
            Exit Function
        End If

        '------------Условия оплаты
        If Trim(PaymentsCondition.Text) = "" Then
            ErrMessage = "Необходимо заполнить поле ""Условия оплаты""."
            CheckDataFilling = False
            Exit Function
        End If

        '------------срок действия КП
        If CDate(CPValidTo.Text) < Now Then
            ErrMessage = "Срок действия предложения должен быть больше текущей даты."
            CheckDataFilling = False
            Exit Function
        End If

        '------------Возможность частичной поставки
        If DropDownListPartialDel.SelectedValue = "---" Then
            ErrMessage = "Необходимо выбрать возможность частичной поставки."
            CheckDataFilling = False
            Exit Function
        End If

        CheckDataFilling = True
    End Function

    Private Function CheckEmptyHDR() As Integer
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Проверка - есть ли строки в коммерческом предложении
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim obj As New ServiceReference1.SWIServiceClient
        Dim MyParam1 As New ServiceReference1.SWIServiceCPHasStringsParameters
        Dim MyQty As Integer

        obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
        obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

        MyParam1.MyCPID = Session("CPNumber")
        ErrMessage = obj.CPHasStrings(MyParam1)
        Try
            MyQty = CInt(ErrMessage)
            CheckEmptyHDR = MyQty
            Exit Function
        Catch ex As Exception
            CheckEmptyHDR = -1
        End Try
    End Function

    Private Function CheckCPData() As String
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Проверка правильности заполнения строк в КП
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim obj As New ServiceReference1.SWIServiceClient
        Dim MyParam1 As New ServiceReference1.SWIServiceCheckCPDataParameters

        obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
        obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

        MyParam1.MyCPID = Session("CPNumber")
        ErrMessage = obj.CheckCPData(MyParam1)
        CheckCPData = ErrMessage
    End Function

    Private Sub DeleteCP()
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Удаление КП
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim obj As New ServiceReference1.SWIServiceClient
        Dim MyParam1 As New ServiceReference1.SWIServiceDeleteCPParameters

        obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
        obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

        MyParam1.MyCPNumber = Session("CPNumber")
        obj.DeleteCP(MyParam1)
    End Sub

    Private Sub SaveCP()
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Сохранение КП
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim obj As New ServiceReference1.SWIServiceClient
        Dim MyParam1 As New ServiceReference1.SWIServiceAddOrderHeaderParameters

        obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
        obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

        MyParam1.MyAgentName = Session("AgentFullName")
        MyParam1.MyCAddr = Trim(CustomerAddress.Text)
        MyParam1.MyCCode = Trim(CustomerNumber.Text)
        MyParam1.MyCName = Trim(CustomerName.Text)
        MyParam1.MyComment = Trim(Comments.Text)
        MyParam1.MyDeliveryAddr = ""
        MyParam1.MyDeliveryDate = "01/01/1900"
        MyParam1.MyDocLayout = DropDownListDocCodes.SelectedValue
        MyParam1.MyExpirationDate = CPValidTo.Text
        MyParam1.MyPRCurrCode = DropDownListCurr.SelectedValue
        MyParam1.MyInvCurrCode = 0
        MyParam1.MyPartialShipment = DropDownListPartialDel.SelectedValue
        MyParam1.MyPaymentCond = Trim(PaymentsCondition.Text)
        MyParam1.MyPriceCond = DropDownListPriceCond.SelectedValue
        MyParam1.MyPRID = Session("CPNumber")
        MyParam1.MyReadyDate = "01/01/1900"
        MyParam1.MySalesmanCode = DropDownListSalesman.SelectedValue
        MyParam1.MyWHNum = DropDownListWH.SelectedValue
        obj.AddOrderHeader(MyParam1)
    End Sub

    Private Sub CPStringEdit_Click(sender As Object, e As EventArgs) Handles CPStringEdit.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Сохранение заголовка КП и переход к редактированию строк
        '//
        '////////////////////////////////////////////////////////////////////////////////

        If CheckDataFilling() = True Then
            SaveCP()
            Response.Redirect("OrderLines.aspx", True)
        Else
            LabelErr.Text = ErrMessage
            DivErr.Disabled = False
            DivErr.Visible = True
            DivBG.Disabled = False
            DivBG.Visible = True
        End If
    End Sub

    Private Sub ButtonYes_Click(sender As Object, e As EventArgs) Handles ButtonYes.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// выбор ответа "Да" при заданиии вопроса
        '//
        '////////////////////////////////////////////////////////////////////////////////

        LabelQuestion.Text = ""
        DivQuestion.Disabled = True
        DivQuestion.Visible = False
        DivBG.Disabled = True
        DivBG.Visible = False

        If MyQuestion = "EmptyCP" Then
            '---удаление заголовка КП с пустыми строками
            '---ответ "Да" - удаляем заголовок
            SaveQuit_DeleteCP()
        ElseIf MyQuestion = "ErrorCP" Then
            '---сохранение заголовка КП с ошибками в строках
            '---ответ "Да" - остаемся в КП
        End If
    End Sub

    Private Sub ButtonNo_Click(sender As Object, e As EventArgs) Handles ButtonNo.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// выбор ответа "Нет" при заданиии вопроса
        '//
        '////////////////////////////////////////////////////////////////////////////////

        LabelQuestion.Text = ""
        DivQuestion.Disabled = True
        DivQuestion.Visible = False
        DivBG.Disabled = True
        DivBG.Visible = False

        If MyQuestion = "EmptyCP" Then
            '---удаление заголовка КП с пустыми строками
            '---ответ "Нет" - продолжаем проверки и сохранение заголовка
            SaveQuit_CheckData()
        ElseIf MyQuestion = "ErrorCP" Then
            '---сохранение заголовка КП с ошибками в строках
            '---ответ "Нет" - сохраняем КП несмотря на ошибки
            SaveQuit_SaveCP()
        End If

    End Sub

    Private Sub ButtonUploadExcel_Click(sender As Object, e As EventArgs) Handles ButtonUploadExcel.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// загрузка спецификации Excel в КП
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim MyRezStr As String
        Dim MyFileFlag As Integer

        If CheckDataFilling() = True Then
            SaveCP()
            If (FileUpload1.HasFile) Then
                If Not IsDBNull(FileUpload1.PostedFile) And _
                    FileUpload1.PostedFile.ContentLength > 0 Then
                    If IO.Path.GetExtension(FileUpload1.FileName()).ToUpper = ".XLS" Or IO.Path.GetExtension(FileUpload1.FileName()).ToUpper = ".XLSX" Then
                        Try
                            Dim MyGuid As Guid
                            Dim MyStr As String
                            MyGuid = Guid.NewGuid
                            If IO.Path.GetExtension(FileUpload1.FileName()).ToUpper = ".XLS" Then
                                MyStr = "C:\SW_WEB\Temp\Спецификация Электроскандия_" & MyGuid.ToString & ".xls"
                                MyFileFlag = 1
                            Else
                                MyStr = "C:\SW_WEB\Temp\Спецификация Электроскандия_" & MyGuid.ToString & ".xlsx"
                                MyFileFlag = 2
                            End If
                            FileUpload1.SaveAs(MyStr)
                            MyRezStr = UploadDataFromExcel(MyStr, MyFileFlag)
                            If Trim(MyRezStr) = "" Then
                                IO.File.Delete(MyStr)
                                LabelErr.Text = "Процедура загрузки файла завершена."
                                DivErr.Disabled = False
                                DivErr.Visible = True
                                DivBG.Disabled = False
                                DivBG.Visible = True
                            Else
                                IO.File.Delete(MyStr)
                                TextBoxErrTxt.Text = MyRezStr
                                DivErrTxt.Disabled = False
                                DivErrTxt.Visible = True
                                DivBG.Disabled = False
                                DivBG.Visible = True
                            End If
                        Catch ex As Exception
                            LabelErr.Text = ex.Message
                            DivErr.Disabled = False
                            DivErr.Visible = True
                            DivBG.Disabled = False
                            DivBG.Visible = True
                        End Try
                    Else
                        LabelErr.Text = "Загружать можно только файлы Excel."
                        DivErr.Disabled = False
                        DivErr.Visible = True
                        DivBG.Disabled = False
                        DivBG.Visible = True
                    End If
                Else
                    LabelErr.Text = "Размер загружаемого файла должен быть больше 0."
                    DivErr.Disabled = False
                    DivErr.Visible = True
                    DivBG.Disabled = False
                    DivBG.Visible = True
                End If
            Else
                LabelErr.Text = "Для загрузки файл необходимо сначала выбрать."
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

    Private Sub ButtonErrTxt_Click(sender As Object, e As EventArgs) Handles ButtonErrTxt.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// закрытие окна с ошибкой, выводимой в текстовое поле
        '//
        '////////////////////////////////////////////////////////////////////////////////

        DivErrTxt.Disabled = True
        DivErrTxt.Visible = False
        DivBG.Disabled = True
        DivBG.Visible = False
    End Sub

    Private Function UploadDataFromExcel(MyStr As String, MyFileFlag As Integer) As String
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Загрузка данных из спецификации в КП
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim MyRezStr As String
        Dim MySQLStr As String
        Dim connString As String


        MyRezStr = ""
        If MyFileFlag = 1 Then
            connString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & Replace(MyStr, "\", "\\") & "; Extended Properties=""Excel 8.0;HDR=No;FirstRowHasNames=False"""
        Else
            connString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & Replace(MyStr, "\", "\\") & "; Extended Properties=""Excel 12.0;HDR=No;FirstRowHasNames=False"""
        End If
        MySQLStr = "SELECT * FROM [Data$B11:I1011] WHERE F1 IS NOT NULL OR F2 IS NOT NULL"

        Dim oledbConn As OleDbConnection = New OleDbConnection(connString)
        Try
            Dim cmd As OleDbCommand = New OleDbCommand(MySQLStr, oledbConn)
            Dim oleda As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            oleda.Fill(ds)

            MyRezStr = Trim(CheckExcelData(ds))
            If MyRezStr = "" Then
                MyRezStr = SaveDataFromExcel(ds)
            End If
        Catch ex As Exception
            MyRezStr = ex.Message
        Finally
            oledbConn.Close()
        End Try
        If Trim(MyRezStr) = "" Then
        Else
            MyRezStr = "При попытке импорта из Excel произошли ошибки:" + Chr(13) + Chr(10) + Chr(13) + Chr(10) + MyRezStr
        End If
        UploadDataFromExcel = MyRezStr
    End Function

    Private Function CheckExcelData(ByRef ds As DataSet) As String
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// проверка данных Excel
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim MyRezStr As String
        Dim MyWRKStr As String
        Dim MyWRKInt As Integer
        Dim MyWRKDbl As Double
        Dim obj As New ServiceReference1.SWIServiceClient

        Dim MyItemCode As String                    '---код товара в Scala
        Dim MySuppItemCode As String                '---код товара поставщика
        Dim MyItemName As String                    '---название товара
        Dim MyUOM As String                         '---название единицы измерения

        MyRezStr = ""
        obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
        obj.ClientCredentials.UserName.Password = "!bh$DR2T435"
        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            '-------------------------------код товара в Scala---------------------------
            MyItemCode = Trim(ds.Tables(0).Rows(i).ItemArray(0).ToString)
            If Trim(MyItemCode) = "" Then
            ElseIf Trim(MyItemCode) = "xxxxxx" Then
            Else
                '-------Проверяем - есть ли такой код товара в Scala
                Dim MyParam As New ServiceReference1.SWIServiceItemInScalaExistOrNoParameters

                MyParam.MyItemCode = MyItemCode
                MyWRKStr = obj.ItemInScalaExistOrNo(MyParam)
                Try
                    MyWRKInt = Integer.Parse(MyWRKStr)
                    If MyWRKInt = 0 Then
                        MyRezStr = MyRezStr + "Ячейка B" + CStr(i + 11) + ".  Данный код Скала отсутствует в БД. Введите корректный код. " + Chr(13) + Chr(10)
                    ElseIf MyWRKInt > 1 Then
                        MyRezStr = MyRezStr + "Ячейка B" + CStr(i + 11) + ".  Данный код Скала присутствует в БД более чем в одном экземпляре. Обратитесь к администратору. " + Chr(13) + Chr(10)
                    End If
                Catch ex As Exception
                    MyRezStr = MyRezStr + "Ячейка B" + CStr(i + 11) + ". " + ex.Message + Chr(13) + Chr(10)
                End Try
            End If

            '-------------------------------код товара поставщика------------------------
            MySuppItemCode = Trim(ds.Tables(0).Rows(i).ItemArray(1).ToString)
            If Trim(MyItemCode) = "" Then
                '-------Проверяем - есть ли такой код товара поставщика в Scala
                Dim MyParam1 As New ServiceReference1.SWIServiceItemSuppInScalaExistOrNoParameters
                MyParam1.MyItemSuppCode = MySuppItemCode
                MyWRKStr = obj.ItemSuppInScalaExistOrNo(MyParam1)
                Try
                    MyWRKInt = Integer.Parse(MyWRKStr)
                    If MyWRKInt = 0 Then
                        MyRezStr = MyRezStr + "Ячейка C" + CStr(i + 11) + ".  Данный код товара поставщика отсутствует в БД. Введите корректный код. " + Chr(13) + Chr(10)
                    ElseIf MyWRKInt > 1 Then
                        '-------Если кодов несколько - выводим информацию с требованием ввести код Scala
                        Dim MyParam2 As New ServiceReference1.SWIServiceGetScalaSICtItemListParameters
                        Dim MyParamRet() As ServiceReference1.SWIServiceGetScalaSICtItemListParametersRet

                        MyParam2.MyItemSuppCode = MySuppItemCode
                        MyParamRet = obj.GetScalaSICtItemList(MyParam2)
                        MyRezStr = MyRezStr + "Ячейка C" + CStr(i + 11) + ".  Данный код товара поставщика есть в БД у разных поставщиков. Выберите и занесите в Excel соответствующий код Scala: " + Chr(13) + Chr(10)
                        MyRezStr = MyRezStr + "Код Скала " + "     Название в Скала                             " + "Код пост. " + "     Поставщик" + Chr(13) + Chr(10)
                        MyRezStr = MyRezStr + "----------------------------------------------------------------------------------------------------------------" + Chr(13) + Chr(10)
                        For j As Integer = 0 To MyParamRet.Count - 1
                            MyRezStr = MyRezStr + Right("          " + MyParamRet(j).MyItemCode, 10) + Right("                                                  " + MyParamRet(j).MyItemName, 50) + Right("          " + MyParamRet(j).MySuppCode, 10) + Right("                                   " + MyParamRet(j).MySuppName, 35) + Chr(13) + Chr(10)
                        Next
                    End If
                Catch ex As Exception
                    MyRezStr = MyRezStr + "Ячейка C" + CStr(i + 11) + ". " + ex.Message + Chr(13) + Chr(10)
                End Try
            End If

            '-------------------------------Название товара------------------------------
            MyItemName = ds.Tables(0).Rows(i).ItemArray(2).ToString
            If Trim(MyItemName) = "" Then
                If Trim(MyItemCode) = "xxxxxx" Or Trim(MySuppItemCode) = "xxxxxx" Then
                    '-------Пишем о необходимости заполнить название товара
                    MyRezStr = MyRezStr + "Ячейка D" + CStr(i + 11) + ".  Необходимо заполнить название товара. " + Chr(13) + Chr(10)
                End If
            End If

            '-----------------------------Единица измерения------------------------------
            MyUOM = ds.Tables(0).Rows(i).ItemArray(3).ToString
            If Trim(MyUOM) = "" Then
                MyRezStr = MyRezStr + "Ячейка E" + CStr(i + 11) + ".  Необходимо заполнить единицу измерения товара. " + Chr(13) + Chr(10)
            Else
                '-------Проверяем правильность занесения единиц измерения
                Select Case MyUOM
                    Case "pcs(шт.)"
                    Case "m (м)"
                    Case "kg (кг)"
                    Case "km (км)"
                    Case "litre (литр)"
                    Case "pack (Упак.)"
                    Case "set (Компл.)"
                    Case "pair (пара)"
                    Case Else
                        MyRezStr = MyRezStr + "Ячейка E" + CStr(i + 11) + ".  Необходимо заполнить единицу измерения товара. Заполнять надо значениями из выпадающего меню в шаблоне." + Chr(13) + Chr(10)
                End Select

            End If

            '-----------------------------Количество-------------------------------------
            MyWRKStr = ds.Tables(0).Rows(i).ItemArray(4).ToString
            If Trim(MyWRKStr) = "" Then
                '-------Пишем о необходимости заполнить количество
                MyRezStr = MyRezStr + "Ячейка F" + CStr(i + 11) + ".  Необходимо заполнить количество товара в коммерческом предложении. " + Chr(13) + Chr(10)
            Else
                '-------Проверяем - число ли это и больше или нет 0
                Try
                    MyWRKDbl = MyWRKStr
                    If MyWRKDbl <= 0 Then
                        MyRezStr = MyRezStr + "Ячейка F" + CStr(i + 11) + ".  Количество товара в коммерческом предложении должно быть числом, большим нуля. " + Chr(13) + Chr(10)
                    End If
                Catch ex As Exception
                    MyRezStr = MyRezStr + "Ячейка F" + CStr(i + 11) + ".  Количество товара в коммерческом предложении должно быть числом. " + Chr(13) + Chr(10)
                End Try
            End If

            '-----------------------------Цена-------------------------------------------
            MyWRKStr = ds.Tables(0).Rows(i).ItemArray(5).ToString
            If Trim(MyWRKStr) = "" Then
                '-------Пишем о необходимости заполнить цену
                MyRezStr = MyRezStr + "Ячейка G" + CStr(i + 11) + ".  Необходимо заполнить цену товара в коммерческом предложении. " + Chr(13) + Chr(10)
            Else
                '-------Проверяем - число ли это и больше или нет 0
                Try
                    MyWRKDbl = MyWRKStr
                    If MyWRKDbl <= 0 Then
                        MyRezStr = MyRezStr + "Ячейка G" + CStr(i + 11) + ".  Цена товара в коммерческом предложении должна быть числом, большим нуля. " + Chr(13) + Chr(10)
                    End If
                Catch ex As Exception
                    MyRezStr = MyRezStr + "Ячейка G" + CStr(i + 11) + ".  Цена товара в коммерческом предложении должна быть числом. " + Chr(13) + Chr(10)
                End Try
            End If

            '---------------------Срок готовности на складе в неделях--------------------
            MyWRKStr = ds.Tables(0).Rows(i).ItemArray(7).ToString
            If Trim(MyWRKStr) = "" Then
                '-------Пишем о необходимости заполнить Срок готовности на складе в неделях
                MyRezStr = MyRezStr + "Ячейка I" + CStr(i + 11) + ".  Необходимо заполнить Срок поставки товара в коммерческом предложении. " + Chr(13) + Chr(10)
            Else
                '-------Проверяем - число ли это и больше или нет 0
                Try
                    MyWRKDbl = MyWRKStr
                    If MyWRKDbl <= 0 Then
                        MyRezStr = MyRezStr + "Ячейка I" + CStr(i + 11) + ".  Срок поставки товара в коммерческом предложении должен быть числом, большим нуля. " + Chr(13) + Chr(10)
                    End If
                Catch ex As Exception
                    MyRezStr = MyRezStr + "Ячейка I" + CStr(i + 11) + ".  Срок поставки товара в коммерческом предложении должен быть числом. " + Chr(13) + Chr(10)
                End Try
            End If

            CheckExcelData = MyRezStr
        Next
    End Function

    Private Function SaveDataFromExcel(ByRef ds As DataSet) As String
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// запись данных Excel в КП
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim MyRezStr As String
        Dim obj As New ServiceReference1.SWIServiceClient
        Dim MyParam As New ServiceReference1.SWIServiceImportRowParameters
        Dim MyParam1 As New ServiceReference1.SWIServiceGetNewStrNumParameters
        Dim MyParam2 As New ServiceReference1.SWIServiceGetScalaCodeBySuppCodeParameters

        MyRezStr = ""
        obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
        obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            MyParam.MyOrderNum = Session("CPNumber")
            MyParam.MyItemCode = ""
            MyParam2.MyItemSuppCode = ""
            If Trim(ds.Tables(0).Rows(i).ItemArray(0).ToString) <> "" Then
                MyParam.MyItemCode = Trim(ds.Tables(0).Rows(i).ItemArray(0).ToString)
            Else
                '---находим скальский код по коду товара поставщика
                MyParam2.MyItemSuppCode = Trim(ds.Tables(0).Rows(i).ItemArray(1).ToString)
                MyParam.MyItemCode = Trim(obj.GetScalaCodeBySuppCode(MyParam2))
            End If
            MyParam.MyItemName = ds.Tables(0).Rows(i).ItemArray(2).ToString
            Select Case ds.Tables(0).Rows(i).ItemArray(3).ToString
                Case "pcs(шт.)"
                    MyParam.MyUOM = 0
                Case "m (м)"
                    MyParam.MyUOM = 1
                Case "kg (кг)"
                    MyParam.MyUOM = 2
                Case "km (км)"
                    MyParam.MyUOM = 3
                Case "litre (литр)"
                    MyParam.MyUOM = 4
                Case "pack (Упак.)"
                    MyParam.MyUOM = 5
                Case "set (Компл.)"
                    MyParam.MyUOM = 6
                Case "pair (пара)"
                    MyParam.MyUOM = 7
                Case Else
                    MyParam.MyUOM = 0
            End Select
            MyParam.MyQty = ds.Tables(0).Rows(i).ItemArray(4)
            MyParam.MyPrice = ds.Tables(0).Rows(i).ItemArray(5)
            MyParam.MyWeekQTY = ds.Tables(0).Rows(i).ItemArray(7)
            '---Номер новой строки
            MyParam1.MyCPID = Session("CPNumber")
            MyParam.MyStrNum = obj.GetNewStrNum(MyParam1)

            MyRezStr = obj.ImportRow(MyParam)
        Next
        SaveDataFromExcel = MyRezStr
    End Function
End Class