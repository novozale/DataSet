Public Class ItemsBatches
    Inherits System.Web.UI.Page

    '////////////////////////////////////////////////////////////////////////////////
    '//
    '// переменные сессии для данного окна
    '//
    '////////////////////////////////////////////////////////////////////////////////
    '//
    '//     ItemCodeName                            '--код товара + название
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
            Dim MyParam As New ServiceReference1.SWIServiceGetItemBatchesParameters

            obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
            obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

            MyParam.MyItemCode = Session("ItemCode")
            GridView1.DataSource = obj.GetItemBatches(MyParam).Tables(0)
            GridView1.DataBind()

            LabelItemName.Text = Session("ItemCodeName")
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
End Class