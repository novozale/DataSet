Public Class OrderDetails
    Inherits System.Web.UI.Page

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
            Dim MyParam As New ServiceReference1.SWIServiceGetOrderDetailsParameters

            obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
            obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

            LabelTitle.Text = Session("OrderList_SelOrderNum")

            MyParam.MyOrderNumber = Session("OrderList_SelOrderNum")
            GridView1.DataSource = obj.GetOrderDetails(MyParam).Tables(0)
            GridView1.DataBind()
        End If
    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// выход со страницы
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Response.Redirect("OrderList.aspx", True)
    End Sub
End Class