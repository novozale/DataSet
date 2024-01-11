Public Class ProposalList
    Inherits System.Web.UI.Page
    Public Shared GridView1_SelRow As Integer = 0
    Public Shared GridView1_SelRowOld As Integer = 0
    Public Shared StrQTY As Integer = 0
    Public Shared PageNum As Integer = 0

    '////////////////////////////////////////////////////////////////////////////////
    '//
    '// переменные сессии для данного окна
    '//
    '////////////////////////////////////////////////////////////////////////////////
    '//
    '//     CPList_QTYOn                                    '--количество строк на странице
    '//     CPList_StrQTY                                   '--количество строк в запросе
    '//     CPList_LastStr                                  '--номер последней строки на странице
    '//     CPList_Return                                   '--изначальная загрузка страницы или возврат на нее после операций
    '//     CPList_DateFrom                                 '--дата с
    '//     CPList_DateTo                                   '--дата По
    '//     CPList_PageNum                                  '--номер выводимой страницы
    '//     CPList_Salesman                                 '--продавец, обрабатывающий заказы агента
    '//     CPList_Sel_Index                                '--номер выбранной строки
    '//     CPList_ActiveCP                                 '--флаг - выводить только активные CP (1) или все (0)
    '//     CPNumber                                        '--ID коммерческого предложения
    '//
    '//


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// загрузка страницы, параметры
        '//
        '////////////////////////////////////////////////////////////////////////////////

        If Session("AgentFullName") = "" Then
            Response.Redirect("Login.aspx", True)
        End If
        If Session("CPList_QTYOn") = "" Then
            Session("CPList_QTYOn") = "20"
        End If
        If Session("CPList_ActiveCP") = "" Then
            Session("CPList_ActiveCP") = "1"
        End If
        If Session("CPList_PageNum") = "" Then
            Session("CPList_PageNum") = "0"
        End If

        Page.ClientScript.GetPostBackEventReference(GridView1, "")

        If Not IsPostBack Then
            Dim obj As New ServiceReference1.SWIServiceClient
            Dim MyParam As New ServiceReference1.SWIServiceGetCPListParameters
            Dim MyParam1 As New ServiceReference1.SWIServiceGetSalesmanListParameters

            obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
            obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

            '------------Даты с и по, номер страницы, количество на странице-------------
            LabelTitle.Text = "Список коммерческих предложений агента " & Session("AgentFullName")
            If Session("CPList_Return") = "" Then
                LabelFrom.Text = "01/" + Right("00" + CStr(Month(DateAdd(DateInterval.Month, -3, System.DateTime.Now))), 2) + "/" + CStr(Year(DateAdd(DateInterval.Month, -3, System.DateTime.Now)))
                Session("CPList_DateFrom") = LabelFrom.Text
                LabelTo.Text = Right("00" + CStr(Day(DateAdd(DateInterval.Month, 1, System.DateTime.Now))), 2) + "/" + Right("00" + CStr(Month(DateAdd(DateInterval.Month, 1, System.DateTime.Now))), 2) + "/" + CStr(Year(DateAdd(DateInterval.Month, 1, System.DateTime.Now)))
                Session("CPList_DateTo") = LabelTo.Text
                Session("CPList_ActiveCP") = "1"
            Else
                LabelFrom.Text = Session("CPList_DateFrom")
                LabelTo.Text = Session("CPList_DateTo")
            End If
            QTYOnPageList.SelectedValue = Session("CPList_QTYOn")

            '-------------Список продавцов-----------------------------------------------
            MyParam1.MyAllSalesmanFlag = 1
            DropDownListSalesman.DataSource = obj.GetSalesmanList(MyParam1).Tables(0)
            DropDownListSalesman.DataTextField = "SalesmanName"
            DropDownListSalesman.DataValueField = "SalesmanCode"
            DropDownListSalesman.DataBind()
            If Session("CPList_Return") = "" Then
                DropDownListSalesman.SelectedValue = "---"
            Else
                DropDownListSalesman.SelectedIndex = Session("CPList_Salesman")
            End If
            Session("CPList_Salesman") = CStr(DropDownListSalesman.SelectedIndex)

            DropDownListActive.SelectedValue = Session("CPList_ActiveCP")

            '-------------Список КП------------------------------------------------------
            If Session("CPList_Return") = "Yes-2" Then
                PageNum = PageNum - 1
            End If
            If Session("CPList_Return") = "Yes+2" Or Session("CPList_Return") = "Yes+1" Then
                PageNum = System.Math.Ceiling((Session("CPList_StrQTY") + 1) / Session("CPList_QTYOn")) - 1
            End If
            Session("CPList_PageNum") = CStr(PageNum)

            MyParam.MyAgentName = Session("AgentFullName")
            MyParam.MyStartDate = LabelFrom.Text
            MyParam.MyFinishDate = LabelTo.Text
            MyParam.MyOrderFlag = DropDownListActive.SelectedValue
            MyParam.MySalesmanCode = DropDownListSalesman.SelectedValue
            MyParam.MyPageNum = PageNum
            MyParam.MyQTYOnPage = Session("CPList_QTYOn")
            GridView1.Columns(7).Visible = True
            GridView1.DataSource = obj.GetCPList(MyParam).Tables(0)
            GridView1.DataBind()

            Session("CPList_LastStr") = GridView1.Rows.Count

            'GridView1.SelectedIndex = GridView1_SelRow

            '-------------общее количество записей и список страниц----------------------
            If GridView1.Rows.Count > 0 Then
                StrQTY = GridView1.Rows(0).Cells(7).Text
                GridView1.Columns(7).Visible = False
            Else
                StrQTY = 0
            End If
            Session("CPList_StrQTY") = StrQTY

            PagesList.Items.Clear()
            For i As Integer = 1 To System.Math.Ceiling(StrQTY / Session("CPList_QTYOn"))
                PagesList.Items.Insert(i - 1, i.ToString())
            Next
            '----------------------------------------------------------------------------
            If Session("CPList_Return") = "" Then
                PageNum = Session("CPList_PageNum")
                Try
                    PagesList.SelectedIndex = PageNum
                Catch ex As Exception
                End Try
            Else
                If CInt(Session("CPList_PageNum")) > System.Math.Ceiling(StrQTY / Session("CPList_QTYOn")) - 1 Then
                    '---кол - во страниц уменьшилось на 1
                    PageNum = CInt(Session("CPList_PageNum")) - 1
                    Try
                        PagesList.SelectedIndex = PageNum
                    Catch ex As Exception
                    End Try
                Else
                    '---кол - во страниц не изменилось
                    PageNum = Session("CPList_PageNum")
                    Try
                        PagesList.SelectedIndex = PageNum
                    Catch ex As Exception
                    End Try

                End If
            End If

            LabelQTYPages.Text = " из " + CStr(System.Math.Ceiling(StrQTY / Session("CPList_QTYOn")))

            If Session("CPList_Return") = "" Then
                '---новая загрузка
                GridView1_SelRowOld = 0
                GridView1_SelRow = Session("CPList_Sel_Index")
                Try
                    GridView1.SelectedIndex = GridView1_SelRow
                Catch ex As Exception
                End Try
                ChangeSelRow()
            ElseIf Session("CPList_Return") = "Yes" Then
                '---возврат с другой страницы, кол - во строк не менялось
                GridView1_SelRowOld = 0
                GridView1_SelRow = Session("CPList_Sel_Index")
                Try
                    GridView1.SelectedIndex = GridView1_SelRow
                Catch ex As Exception
                End Try
                ChangeSelRow()
            ElseIf Session("CPList_Return") = "Yes-1" Then
                '---возврат с другой страницы, кол - во строк уменьшалось
                If CInt(Session("CPList_PageNum")) > System.Math.Ceiling(StrQTY / Session("CPList_QTYOn")) - 1 Then
                    '---при этом еще и кол - во страниц уменьшилось
                    GridView1_SelRowOld = 0
                    GridView1_SelRow = GridView1.Rows.Count - 1
                    Try
                        GridView1.SelectedIndex = GridView1_SelRow
                    Catch ex As Exception
                    End Try
                    ChangeSelRow()
                Else
                    '--тут кол - во страниц не менялось
                    GridView1_SelRowOld = 0
                    GridView1_SelRow = Session("CPList_Sel_Index") - 1
                    Try
                        GridView1.SelectedIndex = GridView1_SelRow
                    Catch ex As Exception
                    End Try
                    ChangeSelRow()
                End If
            Else
                '--увеличение кол - ва строк - соответственно идем на последнюю
                GridView1_SelRowOld = 0
                GridView1_SelRow = GridView1.Rows.Count - 1
                Try
                    GridView1.SelectedIndex = GridView1_SelRow
                Catch ex As Exception
                End Try
                ChangeSelRow()
            End If
            Session("CPList_Sel_Index") = GridView1_SelRow

            CheckButtonsState()

            MyDate1.Disabled = True
            MyDate1.Visible = False
            MyDate2.Disabled = True
            MyDate2.Visible = False
            DivBG.Disabled = True
            DivBG.Visible = False

        End If
    End Sub

    Protected Sub CheckButtonsState()
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// проверка и выставление состояния кнопок
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Try
            If GridView1.Rows.Count = 0 Then
                ButtonDelete.Enabled = False
                ButtonEdit.Enabled = False
                ButtonCopy.Enabled = False
            ElseIf Trim(GridView1.Rows(GridView1_SelRow).Cells(6).Text) <> "" Then
                ButtonDelete.Enabled = False
                ButtonEdit.Enabled = False
                ButtonCopy.Enabled = True
            Else
                ButtonDelete.Enabled = True
                ButtonEdit.Enabled = True
                ButtonCopy.Enabled = True
            End If
        Catch ex As Exception
        End Try
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
                If Trim(GridView1.Rows(GridView1_SelRowOld).Cells(6).Text) <> "" Then
                    GridView1.Rows(GridView1_SelRowOld).BackColor = Drawing.Color.FromArgb(209, 255, 209)
                Else
                    If Trim(GridView1.Rows(GridView1_SelRowOld).Cells(2).Text) < Now Then
                        GridView1.Rows(GridView1_SelRowOld).BackColor = Drawing.Color.WhiteSmoke
                    Else
                        GridView1.Rows(GridView1_SelRowOld).BackColor = Drawing.Color.White
                    End If
                End If
            Else
                GridView1.Rows(GridView1_SelRow).BackColor = Drawing.Color.FromArgb(68, 68, 255)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub MyEvent(MyType As Integer)
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// повторная загрузка страницы
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim obj As New ServiceReference1.SWIServiceClient
        Dim MyParam As New ServiceReference1.SWIServiceGetCPListParameters

        obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
        obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

        If MyType = 0 Then
            '---обновление информации с новыми параметрами
            PageNum = 0
            Session("CPList_PageNum") = CStr(PageNum)
        ElseIf MyType = 1 Then
            '---1 - изменение номера выводимой страницы
            PageNum = Session("CPList_PageNum")
        ElseIf MyType = 2 Then
            '---2 - копирование КП (последняя запись)
            PageNum = System.Math.Ceiling((StrQTY + 1) / Session("CPList_QTYOn")) - 1
            Session("CPList_PageNum") = CStr(PageNum)
        ElseIf MyType = 3 Then
            '---3 - Удаление выбранного КП
            If CInt(Session("CPList_PageNum")) > System.Math.Ceiling((StrQTY - 1) / Session("CPList_QTYOn")) - 1 Then
                '---кол - во страниц уменьшилось на 1
                PageNum = CInt(Session("CPList_PageNum")) - 1
            Else
                '---кол - во страниц не изменилось
                PageNum = Session("CPList_PageNum")
            End If
        End If


        MyParam.MyAgentName = Session("AgentFullName")
        MyParam.MyStartDate = LabelFrom.Text
        MyParam.MyFinishDate = LabelTo.Text
        MyParam.MyOrderFlag = DropDownListActive.SelectedValue
        MyParam.MySalesmanCode = DropDownListSalesman.SelectedValue
        MyParam.MyPageNum = PageNum
        MyParam.MyQTYOnPage = Session("CPList_QTYOn")
        GridView1.DataSource = obj.GetCPList(MyParam).Tables(0)
        GridView1.Columns(7).Visible = True
        GridView1.DataBind()

        Session("CPList_LastStr") = GridView1.Rows.Count

        'PagesList.SelectedIndex = PageNum

        GridView1_SelRowOld = GridView1_SelRow
        If MyType = 0 Or MyType = 1 Then
            GridView1_SelRow = 0
        ElseIf MyType = 2 Then
            GridView1_SelRow = GridView1.Rows.Count - 1
        ElseIf MyType = 3 Then
            If CInt(Session("CPList_PageNum")) > System.Math.Ceiling((StrQTY - 1) / Session("CPList_QTYOn")) - 1 Then
                If GridView1_SelRow > 0 Then
                    GridView1_SelRow = GridView1.Rows.Count - 1
                End If
            Else
                GridView1_SelRow = GridView1_SelRow - 1
            End If
        End If
        Session("CPList_PageNum") = CStr(PageNum)
        Session("CPList_Sel_Index") = CStr(GridView1_SelRow)
        Try
            GridView1.SelectedIndex = GridView1_SelRow
        Catch ex As Exception
        End Try

        If GridView1.Rows.Count > 0 Then
            StrQTY = GridView1.Rows(0).Cells(7).Text
            GridView1.Columns(7).Visible = False
        Else
            StrQTY = 0
        End If

        Session("CPList_StrQTY") = StrQTY

        PagesList.Items.Clear()
        For i As Integer = 1 To System.Math.Ceiling(StrQTY / Session("CPList_QTYOn"))
            PagesList.Items.Insert(i - 1, i.ToString())
        Next
        Try
            PagesList.SelectedIndex = PageNum
        Catch ex As Exception
        End Try

        LabelQTYPages.Text = " из " + CStr(System.Math.Ceiling(StrQTY / Session("CPList_QTYOn")))

        ChangeSelRow()
        CheckButtonsState()
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
                If Trim(e.Row.Cells(6).Text) <> "" Then
                    e.Row.BackColor = Drawing.Color.FromArgb(209, 255, 209)
                Else
                    If Trim(e.Row.Cells(2).Text) < Now Then
                        e.Row.BackColor = Drawing.Color.WhiteSmoke
                    Else
                        e.Row.BackColor = Drawing.Color.White
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение выделенной строки после того, как событие свершилось
        '//
        '////////////////////////////////////////////////////////////////////////////////

        GridView1.SelectedIndex = GridView1_SelRow
        Session("CPList_Sel_Index") = GridView1.SelectedIndex
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
        '// обновление информации в окне с новыми параметрами
        '//
        '////////////////////////////////////////////////////////////////////////////////

        MyEvent(0)
    End Sub

    Private Sub ButtonSelectData1_Click(sender As Object, e As EventArgs) Handles ButtonSelectData1.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// При закрытии календаря "дата С" пишем в строку выбранную дату из календаря
        '//
        '////////////////////////////////////////////////////////////////////////////////

        LabelFrom.Text = Right("00" + CStr(Day(CalendarFrom.SelectedDate)), 2) + "/" + Right("00" + CStr(Month(CalendarFrom.SelectedDate)), 2) + "/" + CStr(Year(CalendarFrom.SelectedDate))
        Session("CPList_DateFrom") = LabelFrom.Text

        MyDate1.Disabled = True
        MyDate1.Visible = False
        DivBG.Disabled = True
        DivBG.Visible = False
    End Sub

    Private Sub ButtonFrom_Click(sender As Object, e As EventArgs) Handles ButtonFrom.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// При открытии календаря "дата С" выставляем на нем дату из строки и место открытия
        '//
        '////////////////////////////////////////////////////////////////////////////////

        CalendarFrom.SelectedDate = LabelFrom.Text
        CalendarFrom.VisibleDate = LabelFrom.Text

        MyDate1.Disabled = False
        MyDate1.Visible = True
        DivBG.Disabled = False
        DivBG.Visible = True
    End Sub

    Private Sub ButtonSelectData2_Click(sender As Object, e As EventArgs) Handles ButtonSelectData2.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// При закрытии календаря "дата По" пишем в строку выбранную дату из календаря
        '//
        '////////////////////////////////////////////////////////////////////////////////

        LabelTo.Text = Right("00" + CStr(Day(CalendarTo.SelectedDate)), 2) + "/" + Right("00" + CStr(Month(CalendarTo.SelectedDate)), 2) + "/" + CStr(Year(CalendarTo.SelectedDate))
        Session("CPList_DateTo") = LabelTo.Text

        MyDate2.Disabled = True
        MyDate2.Visible = False
        DivBG.Disabled = True
        DivBG.Visible = False
    End Sub

    Private Sub ButtonTo_Click(sender As Object, e As EventArgs) Handles ButtonTo.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// При открытии календаря "дата По" выставляем на нем дату из строки и место открытия
        '//
        '////////////////////////////////////////////////////////////////////////////////

        CalendarTo.SelectedDate = LabelTo.Text
        CalendarTo.VisibleDate = LabelTo.Text

        MyDate2.Disabled = False
        MyDate2.Visible = True
        DivBG.Disabled = False
        DivBG.Visible = True
    End Sub

    Public Sub My_SelectedIndexChanged(sender As Object, e As EventArgs) Handles QTYOnPageList.SelectedIndexChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение выводимого на странице количества
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("CPList_QTYOn") = QTYOnPageList.SelectedValue
        PagesList.Items.Clear()
        For i As Integer = 1 To System.Math.Ceiling(StrQTY / Session("CPList_QTYOn"))
            PagesList.Items.Insert(i - 1, i.ToString())
        Next
        LabelQTYPages.Text = " из " + CStr(System.Math.Ceiling(StrQTY / Session("CPList_QTYOn")))
        PageNum = 0

        MyEvent(0)
    End Sub

    Public Sub My_SelectedIndexChanged1(sender As Object, e As EventArgs) Handles PagesList.SelectedIndexChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение номера выводимой страницы
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Try
            PageNum = PagesList.SelectedIndex
        Catch ex As Exception
        End Try
        Session("CPList_PageNum") = CStr(PageNum)
        MyEvent(1)
    End Sub

    Private Sub ButtonCopy_Click(sender As Object, e As EventArgs) Handles ButtonCopy.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// копирование выделенного коммерческого предложения
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim obj As New ServiceReference1.SWIServiceClient
        Dim MyParam As New ServiceReference1.SWIServiceCopyCPParameters
        Dim MyRetValue As String

        obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
        obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

        MyParam.MyCPID = GridView1.Rows(GridView1_SelRow).Cells(0).Text
        MyRetValue = obj.CopyCP(MyParam)

        If Trim(MyRetValue) <> "" Then
            LabelErr.Text = MyRetValue
            DivErr.Disabled = False
            DivErr.Visible = True
            DivBG.Disabled = False
            DivBG.Visible = True
        Else
            MyEvent(2)
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
        MyEvent(0)
    End Sub

    Private Sub ButtonDelete_Click(sender As Object, e As EventArgs) Handles ButtonDelete.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// удаление выделенного коммерческого предложения
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim obj As New ServiceReference1.SWIServiceClient
        Dim MyParam As New ServiceReference1.SWIServiceDeleteCPParameters
        Dim MyRetValue As String

        obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
        obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

        MyParam.MyCPNumber = GridView1.Rows(GridView1_SelRow).Cells(0).Text
        MyRetValue = obj.DeleteCP(MyParam)

        If Trim(MyRetValue) <> "" Then
            LabelErr.Text = MyRetValue
            DivErr.Disabled = False
            DivErr.Visible = True
            DivBG.Disabled = False
            DivBG.Visible = True
        Else
            MyEvent(3)
        End If
    End Sub

    Private Sub ButtonCreate_Click(sender As Object, e As EventArgs) Handles ButtonCreate.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// создание нового коммерческого предложения
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("CPMode") = "New" '---создание
        Session("CPNumber") = ""
        Response.Redirect("EditHeader.aspx", True)
    End Sub

    Private Sub ButtonEdit_Click(sender As Object, e As EventArgs) Handles ButtonEdit.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// редактирование существующего коммерческого предложения
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("CPMode") = "Edit" '---создание
        Session("CPNumber") = GridView1.Rows(GridView1_SelRow).Cells(0).Text
        Response.Redirect("EditHeader.aspx", True)
    End Sub

    Private Sub DropDownListSalesman_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListSalesman.SelectedIndexChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// произведен выбор продавца
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("CPList_Salesman") = CStr(DropDownListSalesman.SelectedIndex)
    End Sub

    Private Sub DropDownListActive_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListActive.SelectedIndexChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// произведен выбор - выводить только активные КП или все
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("CPList_ActiveCP") = CStr(DropDownListActive.SelectedIndex)
    End Sub

    Private Sub ButtonFullQuit_Click(sender As Object, e As EventArgs) Handles ButtonFullQuit.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Выход из приложения
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session.RemoveAll()
        Me.Dispose()
        Response.Redirect("Login.aspx", True)
    End Sub

    Private Sub ButtonOrderList_Click(sender As Object, e As EventArgs) Handles ButtonOrderList.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Переход к окну со списком заказов
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Response.Redirect("OrderList.aspx", True)
    End Sub

    Private Sub ButtonTemplate_Click(sender As Object, e As EventArgs) Handles ButtonTemplate.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Загрузка шаблона спецификации
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim file As IO.FileInfo = New IO.FileInfo("C:\SW_WEB\Template\Спецификация Электроскандия.xls")

        If (file.Exists) Then

            Response.Clear()
            Response.ClearHeaders()
            Response.ClearContent()
            If Left(Request.Browser.Type, 7).ToUpper = "FIREFOX" Then
                Response.AddHeader("content-disposition", "attachment; filename*=" + """Спецификация Электроскандия.xls""")
            Else
                Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlPathEncode("Спецификация Электроскандия.xls"))
            End If
            Response.AddHeader("Content-Type", "application/Excel")
            Response.ContentType = "application/vnd.xls"
            Response.AddHeader("Content-Length", file.Length.ToString())
            Response.WriteFile(file.FullName)
            Response.End()
        End If
    End Sub


    Private Sub ButtonOrderState_Click(sender As Object, e As EventArgs) Handles ButtonOrderState.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Открытие отчета о состоянии заказов
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Response.Redirect("OrderStatePrint.aspx", True)
    End Sub

    Private Sub ButtonItemsTemplate_Click(sender As Object, e As EventArgs) Handles ButtonItemsTemplate.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Загрузка шаблона Товаров для заведения в Scala
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim file As IO.FileInfo = New IO.FileInfo("C:\SW_WEB\Template\Создание запаса в Scala.xls")

        If (file.Exists) Then

            Response.Clear()
            Response.ClearHeaders()
            Response.ClearContent()
            If Left(Request.Browser.Type, 7).ToUpper = "FIREFOX" Then
                Response.AddHeader("content-disposition", "attachment; filename*=" + """Создание запаса в Scala.xls""")
            Else
                Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlPathEncode("Создание запаса в Scala.xls"))
            End If
            Response.AddHeader("Content-Type", "application/Excel")
            Response.ContentType = "application/vnd.xls"
            Response.AddHeader("Content-Length", file.Length.ToString())
            Response.WriteFile(file.FullName)
            Response.End()
        End If
    End Sub

    Private Sub ButtonInstruction_Click(sender As Object, e As EventArgs) Handles ButtonInstruction.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Загрузка инструкции по рабочему месту торгового агента
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim file As IO.FileInfo = New IO.FileInfo("C:\SW_WEB\Template\Инструкция по рабочему месту торгового агента.docx")

        If (file.Exists) Then

            Response.Clear()
            Response.ClearHeaders()
            Response.ClearContent()
            If Left(Request.Browser.Type, 7).ToUpper = "FIREFOX" Then
                Response.AddHeader("content-disposition", "attachment; filename*=" + """Инструкция по рабочему месту торгового агента.docx""")
            Else
                Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlPathEncode("Инструкция по рабочему месту торгового агента.docx"))
            End If
            Response.AddHeader("Content-Type", "application/Word")
            Response.ContentType = "application/vnd.docx"
            Response.AddHeader("Content-Length", file.Length.ToString())
            Response.WriteFile(file.FullName)
            Response.End()
        End If
    End Sub
End Class