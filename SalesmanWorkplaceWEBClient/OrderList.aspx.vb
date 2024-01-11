Public Class OrderList
    Inherits System.Web.UI.Page
    Public Shared GridView1_SelRow As Integer = 0
    Public Shared GridView1_SelRowOld As Integer = 0


    '////////////////////////////////////////////////////////////////////////////////
    '//
    '// переменные сессии для данного окна
    '//
    '////////////////////////////////////////////////////////////////////////////////
    '//
    '//     OrderList_QTYOn                                     '--количество строк на странице
    '//     OrderList_StrQTY                                    '--количество строк в запросе
    '//     OrderList_DateFrom                                  '--дата с
    '//     OrderList_DateTo                                    '--дата По
    '//     OrderList_PageNum                                   '--номер выводимой страницы
    '//     OrderList_Sel_Index                                 '--номер выбранной строки
    '//     OrderList_ActiveOrder                               '--флаг - выводить только активные заказы (1) или все (0)
    '//     OrderList_OrderNum                                  '--номер заказа
    '//     OrderList_SelOrderNum                               '--выбранный номер заказа для получения детальной информации
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// загрузка страницы, параметры
        '//
        '////////////////////////////////////////////////////////////////////////////////

        If Session("AgentFullName") = "" Then
            Response.Redirect("Login.aspx", True)
        End If

        If Session("OrderList_QTYOn") = "" Then
            Session("OrderList_QTYOn") = "20"
        End If
        If Session("OrderList_DateFrom") = "" Then
            Session("OrderList_DateFrom") = "01/" + Right("00" + CStr(Month(DateAdd(DateInterval.Month, -6, System.DateTime.Now))), 2) + "/" + CStr(Year(DateAdd(DateInterval.Month, -3, System.DateTime.Now)))
        End If
        If Session("OrderList_DateTo") = "" Then
            Session("OrderList_DateTo") = Right("00" + CStr(Day(DateAdd(DateInterval.Month, 1, System.DateTime.Now))), 2) + "/" + Right("00" + CStr(Month(DateAdd(DateInterval.Month, 1, System.DateTime.Now))), 2) + "/" + CStr(Year(DateAdd(DateInterval.Month, 1, System.DateTime.Now)))
        End If
        If Session("OrderList_PageNum") = "" Then
            Session("OrderList_PageNum") = "0"
        End If
        If Session("OrderList_Sel_Index") = "" Then
            Session("OrderList_Sel_Index") = "0"
        End If
        If Session("OrderList_ActiveOrder") = "" Then
            Session("OrderList_ActiveOrder") = "1"
        End If
        If Session("OrderList_OrderNum") = "" Then
            Session("OrderList_OrderNum") = ""
        End If

        Page.ClientScript.GetPostBackEventReference(GridView1, "")

        If Not IsPostBack Then
            Dim obj As New ServiceReference1.SWIServiceClient
            Dim MyParam As New ServiceReference1.SWIServiceGetOrderListParameters

            obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
            obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

            LabelTitle.Text = "Список заказов агента " + Session("AgentFullName")
            LabelFrom.Text = Session("OrderList_DateFrom")
            LabelTo.Text = Session("OrderList_DateTo")
            TextBoxOrderNumber.Text = Session("OrderList_OrderNum")
            DropDownListActive.SelectedValue = Session("OrderList_ActiveOrder")

            MyParam.MyAgentName = Session("AgentFullName")
            MyParam.MyStartDate = Session("OrderList_DateFrom")
            MyParam.MyFinishDate = Session("OrderList_DateTo")
            MyParam.MyOrderNumber = Session("OrderList_OrderNum")
            MyParam.MyOrderFlag = Session("OrderList_ActiveOrder")
            MyParam.MyPageNum = Session("OrderList_PageNum")
            MyParam.MyQTYOnPage = Session("OrderList_QTYOn")
            GridView1.Columns(6).Visible = True
            GridView1.DataSource = obj.GetOrderList(MyParam).Tables(0)
            GridView1.DataBind()

            '-------------общее количество записей и список страниц----------------------
            If GridView1.Rows.Count > 0 Then
                Session("OrderList_StrQTY") = GridView1.Rows(0).Cells(6).Text
                GridView1.Columns(6).Visible = False
            Else
                Session("OrderList_StrQTY") = "0"
            End If

            PagesList.Items.Clear()
            For i As Integer = 1 To System.Math.Ceiling(Session("OrderList_StrQTY") / Session("OrderList_QTYOn"))
                PagesList.Items.Insert(i - 1, i.ToString())
            Next
            Try
                PagesList.SelectedIndex = Session("OrderList_PageNum")
            Catch ex As Exception
            End Try

            LabelQTYPages.Text = " из " + CStr(System.Math.Ceiling(Session("OrderList_StrQTY") / Session("OrderList_QTYOn")))

            QTYOnPageList.SelectedValue = Session("OrderList_QTYOn")
            GridView1_SelRowOld = 0
            Try
                GridView1.SelectedIndex = Session("OrderList_Sel_Index")
                GridView1_SelRow = GridView1.SelectedIndex
                ChangeSelRow()
            Catch ex As Exception
            End Try

            CheckButtonsState()
        End If
    End Sub

    Private Sub ButtonQuit_Click(sender As Object, e As EventArgs) Handles ButtonQuit.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// выход со страницы
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("CPList_Return") = "Yes"
        Response.Redirect("ProposalList.aspx", True)
    End Sub

    Private Sub ButtonSelectData1_Click(sender As Object, e As EventArgs) Handles ButtonSelectData1.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// При закрытии календаря "дата С" пишем в строку выбранную дату из календаря
        '//
        '////////////////////////////////////////////////////////////////////////////////

        LabelFrom.Text = Right("00" + CStr(Day(CalendarFrom.SelectedDate)), 2) + "/" + Right("00" + CStr(Month(CalendarFrom.SelectedDate)), 2) + "/" + CStr(Year(CalendarFrom.SelectedDate))
        Session("OrderList_DateFrom") = LabelFrom.Text

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
        Session("OrderList_DateTo") = LabelTo.Text

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

    Protected Sub CheckButtonsState()
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// проверка и выставление состояния кнопок
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Try
            If GridView1.Rows.Count = 0 Then
                ButtonDetails.Enabled = False
            Else
                ButtonDetails.Enabled = True
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub RefreshInfo(MyType As Integer)
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// повторная загрузка страницы
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim obj As New ServiceReference1.SWIServiceClient
        Dim MyParam As New ServiceReference1.SWIServiceGetOrderListParameters

        obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
        obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

        If MyType = 0 Then
            '---обновление информации с новыми параметрами
            Session("OrderList_PageNum") = "0"
        ElseIf MyType = 1 Then
            '---1 - изменение номера выводимой страницы
        End If

        MyParam.MyAgentName = Session("AgentFullName")
        MyParam.MyStartDate = Session("OrderList_DateFrom")
        MyParam.MyFinishDate = Session("OrderList_DateTo")
        MyParam.MyOrderNumber = Session("OrderList_OrderNum")
        MyParam.MyOrderFlag = Session("OrderList_ActiveOrder")
        MyParam.MyPageNum = Session("OrderList_PageNum")
        MyParam.MyQTYOnPage = Session("OrderList_QTYOn")
        GridView1.Columns(6).Visible = True
        GridView1.DataSource = obj.GetOrderList(MyParam).Tables(0)
        GridView1.DataBind()

        '-------------общее количество записей и список страниц----------------------
        If GridView1.Rows.Count > 0 Then
            Session("OrderList_StrQTY") = GridView1.Rows(0).Cells(6).Text
            GridView1.Columns(6).Visible = False
        Else
            Session("OrderList_StrQTY") = "0"
        End If

        PagesList.Items.Clear()
        For i As Integer = 1 To System.Math.Ceiling(Session("OrderList_StrQTY") / Session("OrderList_QTYOn"))
            PagesList.Items.Insert(i - 1, i.ToString())
        Next
        Try
            PagesList.SelectedIndex = Session("OrderList_PageNum")
        Catch ex As Exception
        End Try

        LabelQTYPages.Text = " из " + CStr(System.Math.Ceiling(Session("OrderList_StrQTY") / Session("OrderList_QTYOn")))

        QTYOnPageList.SelectedValue = Session("OrderList_QTYOn")
        GridView1_SelRowOld = 0
        Try
            GridView1.SelectedIndex = Session("OrderList_Sel_Index")
        Catch ex As Exception
        End Try

        CheckButtonsState()
    End Sub

    Private Sub ButtonRefresh_Click(sender As Object, e As EventArgs) Handles ButtonRefresh.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Получение данных с новыми параметрами
        '//
        '////////////////////////////////////////////////////////////////////////////////

        RefreshInfo(0)
    End Sub

    Private Sub DropDownListActive_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListActive.SelectedIndexChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// произведен выбор - выводить только активные КП или все
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("OrderList_ActiveOrder") = CStr(DropDownListActive.SelectedIndex)
    End Sub

    Private Sub PagesList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PagesList.SelectedIndexChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение номера выводимой страницы
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Try
            Session("OrderList_PageNum") = CStr(PagesList.SelectedIndex)
        Catch ex As Exception
        End Try
        RefreshInfo(1)
    End Sub

    Private Sub QTYOnPageList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles QTYOnPageList.SelectedIndexChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение выводимого на странице количества
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("OrderList_QTYOn") = CStr(QTYOnPageList.SelectedValue)
        RefreshInfo(0)
    End Sub

    Private Sub TextBoxOrderNumber_TextChanged(sender As Object, e As EventArgs) Handles TextBoxOrderNumber.TextChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Введено значение номера заказа
        '//
        '////////////////////////////////////////////////////////////////////////////////

        If Trim(TextBoxOrderNumber.Text) = "" Then
            Session("OrderList_OrderNum") = ""
        Else
            Session("OrderList_OrderNum") = Right("0000000000" + Trim(TextBoxOrderNumber.Text), 10)
            TextBoxOrderNumber.Text = Right("0000000000" + Trim(TextBoxOrderNumber.Text), 10)
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
                If Trim(e.Row.Cells(4).Text) = "Полностью отгружен" Then
                    e.Row.BackColor = Drawing.Color.FromArgb(209, 255, 209)
                Else
                    If Trim(e.Row.Cells(5).Text) = "Начата работа" Then
                        e.Row.BackColor = Drawing.Color.WhiteSmoke
                    ElseIf Left(Trim(e.Row.Cells(5).Text), 19) = "Готов к отгрузке на" Then
                        e.Row.BackColor = Drawing.Color.LightYellow
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
        Session("OrderList_Sel_Index") = CStr(GridView1.SelectedIndex)
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

    Protected Sub ChangeSelRow()
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение подсветки выбранной строки
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Try
            If GridView1_SelRow <> GridView1_SelRowOld Then
                GridView1.Rows(GridView1_SelRow).BackColor = Drawing.Color.FromArgb(68, 68, 255)
                If Trim(GridView1.Rows(GridView1_SelRowOld).Cells(4).Text) = "Полностью отгружен" Then
                    GridView1.Rows(GridView1_SelRowOld).BackColor = Drawing.Color.FromArgb(209, 255, 209)
                Else
                    If Trim(GridView1.Rows(GridView1_SelRowOld).Cells(5).Text) = "Начата работа" Then
                        GridView1.Rows(GridView1_SelRowOld).BackColor = Drawing.Color.WhiteSmoke
                    ElseIf Left(Trim(GridView1.Rows(GridView1_SelRowOld).Cells(5).Text), 19) = "Готов к отгрузке на" Then
                        GridView1.Rows(GridView1_SelRowOld).BackColor = Drawing.Color.LightYellow
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

    Private Sub ButtonDetails_Click(sender As Object, e As EventArgs) Handles ButtonDetails.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// открытие окна с детальной информацией по заказу
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("OrderList_SelOrderNum") = GridView1.Rows(GridView1_SelRow).Cells(2).Text
        Response.Redirect("OrderDetails.aspx", True)
    End Sub
End Class