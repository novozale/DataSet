Public Class CPPrint
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// загрузка окна, выставление параметров
        '//
        '////////////////////////////////////////////////////////////////////////////////

        If Session("AgentFullName") = "" Then
            Response.Redirect("Login.aspx", True)
        End If

        CPLabel.Text = "Коммерческое предложение № " + Session("CPNumber")
    End Sub

    Private Sub ObjectDataSource1_ObjectCreated(sender As Object, e As ObjectDataSourceEventArgs) Handles ObjectDataSource1.ObjectCreated
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// переустановка источника данных 
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim obj As New ServiceReference1.SWIServiceClient

        obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
        obj.ClientCredentials.UserName.Password = "!bh$DR2T435"
        e.ObjectInstance = obj
    End Sub

    Private Sub ButtonQuit_Click(sender As Object, e As EventArgs) Handles ButtonQuit.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// выход из окна 
        '//
        '////////////////////////////////////////////////////////////////////////////////

        If Session("CPPrintFrom") = "Header" Then
            Response.Redirect("EditHeader.aspx", True)
        Else '--(Session("CPPrintFrom") = "Rows")
            Response.Redirect("OrderLines.aspx", True)
        End If
    End Sub

    Private Sub ObjectDataSource1_Selecting(sender As Object, e As ObjectDataSourceSelectingEventArgs) Handles ObjectDataSource1.Selecting
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Выставление параметра 
        '//
        '////////////////////////////////////////////////////////////////////////////////

        e.InputParameters("MyCPID") = Session("CPNumber")
    End Sub
End Class