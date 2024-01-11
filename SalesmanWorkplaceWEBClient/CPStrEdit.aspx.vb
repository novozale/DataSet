Public Class CPStrEdit
    Inherits System.Web.UI.Page
    '////////////////////////////////////////////////////////////////////////////////
    '//
    '// переменные сессии для данного окна
    '//
    '////////////////////////////////////////////////////////////////////////////////
    '//
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

        If Not IsPostBack Then
            Dim obj As New ServiceReference1.SWIServiceClient
            Dim MyParam As New ServiceReference1.SWIServiceGetItemEditParameters
            Dim MyParamRet() As ServiceReference1.SWIServiceGetItemEditParametersRet

            obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
            obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

            TextBoxCurrName.Text = Session("ItemList_CurrName")
            TextBoxCurrValue.Text = Session("ItemList_CurrExchRate")
            LabelStrNum.Text = "Редактирование строки " + Session("ItemList_CPItem_StrNum")

            '--Список единиц измерения---------------------------------------------------
            DropDownListUOM.DataSource = obj.GetUOMList().Tables(0)
            DropDownListUOM.DataTextField = "UOMName"
            DropDownListUOM.DataValueField = "UOMCode"
            DropDownListUOM.DataBind()

            '--------Данные на редактирование--------------------------------------------
            MyParam.MyCPID = Session("CPNumber")
            MyParam.MyStrNum = Session("ItemList_CPItem_StrNum")
            MyParamRet = obj.GetItemEdit(MyParam)

            '--------данные по элементам-------------------------------------------------
            '---комментарий по товару
            If Trim(MyParamRet(0).MyPriceFromScala) = "" Then
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
            TextBoxScalaItemCode.Text = MyParamRet(0).MyItemCode
            '---название запаса
            TextBoxItemName.Text = MyParamRet(0).MyItemName
            If Trim(MyParamRet(0).MyFromScala) = "" Then
                TextBoxItemName.Enabled = True
            Else
                TextBoxItemName.Enabled = False
            End If
            '---код товара поставщика
            TextBoxSupplierItemCode.Text = MyParamRet(0).MySupplierItemCode
            If Trim(MyParamRet(0).MyFromScala) = "" Then
                TextBoxSupplierItemCode.Enabled = True
            Else
                TextBoxSupplierItemCode.Enabled = False
            End If
            '---код поставщика
            TextBoxSupplierCode.Text = MyParamRet(0).MySupplierCode
            '---название поставщика
            TextBoxSupplierName.Text = MyParamRet(0).MySupplierName
            If Trim(MyParamRet(0).MySupplierCode) = "XXXXXX" Then
                TextBoxSupplierName.Enabled = True
            Else
                TextBoxSupplierName.Enabled = False
            End If
            '---количество
            TextBoxQTY.Text = MyParamRet(0).MyQTY
            '---единица измерения
            DropDownListUOM.SelectedValue = MyParamRet(0).MyUOMCode
            If Trim(MyParamRet(0).MyFromScala) = "" Then
                DropDownListUOM.Enabled = True
            Else
                DropDownListUOM.Enabled = False
            End If
            '---цена
            TextBoxPrice.Text = MyParamRet(0).MyPrice
            '---себестоимость
            TextBoxPriCost.Text = MyParamRet(0).MyPriCost
            If Trim(MyParamRet(0).MyPriceFromScala) = "" Then
                TextBoxPriCost.Enabled = True
            Else
                TextBoxPriCost.Enabled = False
            End If
            '---скидка
            TextBoxDiscount.Text = MyParamRet(0).MyDiscount
            '---маржа
            MarginCalculation()
            '---срок поставки
            TextBoxCPLT.Text = MyParamRet(0).WeekQTY
            '---срок доставки до клиента
            TextBoxClientDelTime.Text = MyParamRet(0).DelWeekQTY
        End If
    End Sub

    Private Sub Quit_Click(sender As Object, e As EventArgs) Handles Quit.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// выход без сохранения
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("OrderLinesReturn") = "Yes"
        Session("OrderLinesItemSelect") = ""
        Response.Redirect("OrderLines.aspx", True)
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

    Private Function CheckNewMargin() As String
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// проверка ввода данных в поле новая маржа 
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim ErrMessage As String
        Dim MyRez As Double

        '------------Новая маржа
        If Trim(TextBoxNewMargin.Text) = "" Then
            ErrMessage = "Необходимо заполнить поле ""Новая маржа (%)""."
            CheckNewMargin = ErrMessage
            Exit Function
        End If

        Try
            MyRez = CDbl(TextBoxNewMargin.Text)
            TextBoxNewMargin.Text = CStr(CDbl(TextBoxNewMargin.Text))
        Catch ex As Exception
            ErrMessage = "В поле ""Новая маржа (%)"" должно быть введено число."
            CheckNewMargin = ErrMessage
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
        If Trim(TextBoxClientDelTime.Text) = "" Then
            ErrMessage = "Необходимо заполнить поле ""Срок доставки до клиента (нед)""."
            CheckDataFilling = ErrMessage
            Exit Function
        End If

        Try
            MyRez = CDbl(TextBoxClientDelTime.Text)
            TextBoxClientDelTime.Text = CStr(CDbl(TextBoxClientDelTime.Text))
        Catch ex As Exception
            ErrMessage = "В поле ""Срок доставки до клиента (нед)"" должно быть введено число."
            CheckDataFilling = ErrMessage
            Exit Function
        End Try

        '------------срок доставки до клиента в неделях должен быть меньше или равен сроку поставки
        If CDbl(TextBoxClientDelTime.Text) > CDbl(TextBoxCPLT.Text) Then
            ErrMessage = "Срок доставки до клиента не может быть больше всего срока поставки. Откорректируйте срок поставки или срок доставки до клиента."
            CheckDataFilling = ErrMessage
            Exit Function
        End If

        CheckDataFilling = ""
    End Function

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

    Private Sub ButtonSetNewMargin_Click(sender As Object, e As EventArgs) Handles ButtonSetNewMargin.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Нажатие кнопки ввода новой маржи 
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim ErrMessage As String

        ErrMessage = Trim(CheckNewMargin())
        If ErrMessage = "" Then
            ErrMessage = Trim(CheckData())
            If ErrMessage = "" Then
                NewMarginCalculation()
                TextBoxNewMargin.Text = ""
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

    Private Sub NewMarginCalculation()
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// расчет новой цены, соответствующей запрошенной новой марже 
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim DiscCost As Double

        DiscCost = CDbl(TextBoxPriCost.Text) * 100 / (100 - CDbl(TextBoxNewMargin.Text))
        TextBoxPrice.Text = CStr(Math.Round(DiscCost * 100 / (100 - CDbl(TextBoxDiscount.Text)), 2))
        MarginCalculation()
    End Sub

    Private Function CheckWeekVal() As String
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// проверка ввода данных в поле срок поставки для всего заказа 
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim ErrMessage As String
        Dim MyRez As Double

        '------------срок поставки
        If Trim(TextBoxCPDelTime.Text) = "" Then
            ErrMessage = "Необходимо заполнить поле ""Срок поставки (нед.)""."
            CheckWeekVal = ErrMessage
            Exit Function
        End If

        Try
            MyRez = CDbl(TextBoxCPDelTime.Text)
            TextBoxCPDelTime.Text = CStr(CDbl(TextBoxCPDelTime.Text))
        Catch ex As Exception
            ErrMessage = "В поле ""Срок поставки (нед.)"" должно быть введено число."
            CheckWeekVal = ErrMessage
            Exit Function
        End Try

        '------------срок доставки до клиента в неделях
        If Trim(TextBoxCPClientDelTime.Text) = "" Then
            ErrMessage = "Необходимо заполнить поле ""Срок доставки до клиента (нед)""."
            CheckWeekVal = ErrMessage
            Exit Function
        End If

        Try
            MyRez = CDbl(TextBoxCPClientDelTime.Text)
            TextBoxCPClientDelTime.Text = CStr(CDbl(TextBoxCPClientDelTime.Text))
        Catch ex As Exception
            ErrMessage = "В поле ""Срок доставки до клиента (нед)"" должно быть введено число."
            CheckWeekVal = ErrMessage
            Exit Function
        End Try

        '------------срок доставки до клиента в неделях должен быть меньше или равен сроку поставки
        If CDbl(TextBoxCPClientDelTime.Text) > CDbl(TextBoxCPDelTime.Text) Then
            ErrMessage = "Срок доставки до клиента не может быть больше всего срока поставки. Откорректируйте срок поставки или срок доставки до клиента."
            CheckWeekVal = ErrMessage
            Exit Function
        End If

        CheckWeekVal = ""
    End Function

    Private Sub SaveCPDelTime_Click(sender As Object, e As EventArgs) Handles SaveCPDelTime.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// ввод нового срока поставки для всего заказа 
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim ErrMessage As String

        ErrMessage = Trim(CheckWeekVal())
        If ErrMessage = "" Then
            Dim obj As New ServiceReference1.SWIServiceClient
            Dim MyParam As New ServiceReference1.SWIServiceSetCPDelTimeParameters

            obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
            obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

            MyParam.MyCPID = Session("CPNumber")
            MyParam.MyWeekQTY = CDbl(TextBoxCPDelTime.Text)
            MyParam.MyDelWeekQTY = CDbl(TextBoxCPClientDelTime.Text)
            obj.SetCPDelTime(MyParam)

            TextBoxCPDelTime.Text = ""
            TextBoxCPClientDelTime.Text = ""
        Else
            LabelErr.Text = ErrMessage
            DivErr.Disabled = False
            DivErr.Visible = True
            DivBG.Disabled = False
            DivBG.Visible = True
        End If
    End Sub

    Private Sub TextBoxQTY_TextChanged(sender As Object, e As EventArgs) Handles TextBoxQTY.TextChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// ввод нового количества 
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Try
            TextBoxQTY.Text = CStr(CDbl(TextBoxQTY.Text))
        Catch ex As Exception
        End Try
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
                Dim MyParam As New ServiceReference1.SWIServiceEditOrderParameters

                obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
                obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

                MyParam.MyOrder = Session("CPNumber")
                MyParam.MyStr = Session("ItemList_CPItem_StrNum")
                MyParam.MyItemID = Trim(TextBoxScalaItemCode.Text)
                MyParam.MyName1 = Left(Trim(TextBoxItemName.Text), 25)
                MyParam.MyName2 = Mid(Trim(TextBoxItemName.Text), 26, 25)
                MyParam.MyCost = CDbl(TextBoxPrice.Text)
                MyParam.MyCostIntr = CDbl(TextBoxPriCost.Text)
                MyParam.MyQty = CDbl(TextBoxQTY.Text)
                MyParam.MyUnit = DropDownListUOM.SelectedValue
                MyParam.MyDiscount = CDbl(TextBoxDiscount.Text)
                MyParam.MyLT = CDbl(TextBoxCPLT.Text)
                MyParam.MyDelWeekQTY = CDbl(TextBoxClientDelTime.Text)
                MyParam.MyEditOrRecalc = 0
                obj.EditOrder(MyParam)

                Session("OrderLinesReturn") = "Yes"
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