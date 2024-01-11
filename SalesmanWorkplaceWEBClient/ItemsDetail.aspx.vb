Public Class ItemsDetail
    Inherits System.Web.UI.Page

    '////////////////////////////////////////////////////////////////////////////////
    '//
    '// переменные сессии для данного окна
    '//
    '////////////////////////////////////////////////////////////////////////////////
    '//
    '//     ItemCode                                '--код товара
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
            Dim MyParam As New ServiceReference1.SWIServiceGetItemDetailListParameters
            Dim MyParam1 As New ServiceReference1.SWIServiceGetItemDetailParameters
            Dim MyParamRet() As ServiceReference1.SWIServiceGetItemDetailParametersRet

            obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
            obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

            MyParam.MyCPID = Session("CPNumber")
            MyParam.MyItemCode = Session("ItemCode")
            GridView1.DataSource = obj.GetItemDetailList(MyParam).Tables(0)
            GridView1.DataBind()

            '----общая информация по запасу----------------------------------------------
            MyParam1.MyCPID = Session("CPNumber")
            MyParam1.MyItemCode = Session("ItemCode")
            MyParamRet = obj.GetItemDetail(MyParam1)

            LabelItemName.Text = MyParamRet(0).MyItemCodeName
            LabelItemComment.Text = MyParamRet(0).MyItemComment
            TextBoxCurrName.Text = MyParamRet(0).MyCurrencyName
            TextBoxCurrValue.Text = MyParamRet(0).MyCurrencyValueNow
            TextBoxCustomsVal.Text = MyParamRet(0).MyCustomTax
            TextBoxTransportVal.Text = MyParamRet(0).MyShippingCost
            If MyParamRet(0).MyItemComment = "Рекомендованная цена и себестоимость этого запаса на основе прайс - листа на закупку" Then
                LabelItemComment.ForeColor = System.Drawing.Color.DarkGreen
            Else
                LabelItemComment.ForeColor = System.Drawing.Color.DarkRed
            End If
        End If
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// выход из окна
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("OrderLinesReturn") = "Yes"
        Session("OrderLinesItemSelect") = ""
        Response.Redirect("OrderLines.aspx", True)
    End Sub

    Private Sub ButtonSelect_Click(sender As Object, e As EventArgs) Handles ButtonSelect.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// переход на окно с информацией по партиям
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("ItemCodeName") = Trim(LabelItemName.Text)
        Response.Redirect("ItemsBatches.aspx", True)
    End Sub
End Class