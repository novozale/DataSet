Imports Microsoft.Reporting.WebForms

Public Class OrderStatePrint
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

        If Not Page.IsPostBack Then

            ReportViewer1.ProcessingMode = ProcessingMode.Remote
            Dim serverReport As ServerReport
            serverReport = ReportViewer1.ServerReport

            'Create parameters
            Dim OrderNumber As New ReportParameter()
            OrderNumber.Name = "OrderNumber"
            OrderNumber.Values.Add("")

            Dim CustomerCode As New ReportParameter()
            CustomerCode.Name = "CustomerCode"
            CustomerCode.Values.Add("")

            Dim SalesmanCode As New ReportParameter()
            SalesmanCode.Name = "SalesmanCode"
            SalesmanCode.Values.Add(Session("SalesmanCode"))

            Dim Details As New ReportParameter()
            Details.Name = "Details"
            Details.Values.Add("0")

            Dim GroupName As New ReportParameter()
            GroupName.Name = "GroupName"
            GroupName.Values.Add("Все группы")

            'Set the report parameters for the report
            Dim parameters() As ReportParameter = {OrderNumber, CustomerCode, SalesmanCode, Details, GroupName}
            serverReport.SetParameters(parameters)

            ReportViewer1.PromptAreaCollapsed = True
            ReportViewer1.ShowPromptAreaButton = False


        End If
    End Sub

    Private Sub ButtonQuit_Click(sender As Object, e As EventArgs) Handles ButtonQuit.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Выход из окна
        '//
        '////////////////////////////////////////////////////////////////////////////////

        Session("CPList_Return") = "Yes"
        Response.Redirect("ProposalList.aspx", True)
    End Sub
End Class