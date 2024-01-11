Public Class AltItems
    Inherits System.Web.UI.Page
    Public Shared GridView1_SelRow As Integer = 0
    Public Shared GridView1_SelRowOld As Integer = 0

    '////////////////////////////////////////////////////////////////////////////////
    '//
    '// переменные сессии для данного окна
    '//
    '////////////////////////////////////////////////////////////////////////////////
    '//
    '//     ItemCode                                '--код товара, которому ищется альтернатива
    '//     ItemName                                '--название товара, которому ищется альтернатива
    '//     OrderLinesReturn                        '--признак возврата на страницу OrderLines
    '//     OrderLinesItemSelect                    '--выбранный код альтернативного продукта


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
            Dim MyParam As New ServiceReference1.SWIServiceGetAltProductListParameters

            obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
            obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

            LabelTitle.Text = Session("ItemCode") + " " + Session("ItemName")

            MyParam.MyCPID = Session("CPNumber")
            MyParam.MyItemCode = Session("ItemCode")
            GridView1.DataSource = obj.GetAltProductList(MyParam).Tables(0)
            GridView1.DataBind()

            CheckButtonsState()
        End If
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Возврат без выбора альтернативного продукта
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("OrderLinesReturn") = "Yes"
        Session("OrderLinesItemSelect") = ""
        Response.Redirect("OrderLines.aspx", True)
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

    Private Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// изменение выделенной строки после того, как событие свершилось
        '//
        '////////////////////////////////////////////////////////////////////////////////

        GridView1.SelectedIndex = GridView1_SelRow
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
                GridView1.Rows(GridView1_SelRowOld).BackColor = Drawing.Color.White
            Else
                GridView1.Rows(GridView1_SelRow).BackColor = Drawing.Color.FromArgb(68, 68, 255)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub CheckButtonsState()
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// проверка и выставление состояния кнопок
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Try
            If GridView1.Rows.Count = 0 Then
                ButtonSelect.Enabled = False
            Else
                ButtonSelect.Enabled = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ButtonSelect_Click(sender As Object, e As EventArgs) Handles ButtonSelect.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Выход с выбором альтернативного продукта
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("OrderLinesReturn") = "Yes"
        Session("OrderLinesItemSelect") = Server.HtmlDecode(GridView1.Rows(GridView1_SelRow).Cells(0).Text)
        Response.Redirect("OrderLines.aspx", True)
    End Sub
End Class