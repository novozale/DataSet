<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CPPrint.aspx.vb" Inherits="SalesmanWorkplaceWEBClient.CPPrint" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="height: 100%;">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 98%;">
    <form id="form1" runat="server" style="height: 98%;">
    <div style="width: 100%; height: 100%; top: 0%; left: 0%">
        <asp:Table runat="server" Height="100%" Width="100%" >
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" Height="3%" runat="server" >
                    <asp:Table runat="server" Height="100%" Width="100%" BackColor="#CCCCCC"  BorderColor="#999999" BorderStyle="Groove" BorderWidth="1px" >
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="50%" Height="3%" runat="server" >
                                <asp:Label ID="CPLabel" runat="server" Text="Коммерческое предложение" Font-Bold="True" Font-Names="Arial" Font-Size="Smaller" ForeColor="#003399"></asp:Label> &nbsp &nbsp
                            </asp:TableCell>
                            <asp:TableCell Width="50%" Height="3%" runat="server" HorizontalAlign="Right">
                                <asp:Button ID="ButtonQuit" runat="server" Text="Выход" />
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" Height="94%" runat="server" BorderColor="#003399" VerticalAlign="Top">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" SizeToReportContent="True">
                        <LocalReport ReportPath="CommercialProposal.rdlc">
                            <DataSources>
                                <rsweb:ReportDataSource Name="DataSet1" DataSourceId="ObjectDataSource1"></rsweb:ReportDataSource>
                            </DataSources>
                        </LocalReport>
                    </rsweb:ReportViewer>
                    <asp:ObjectDataSource runat="server" SelectMethod="GetCPToPrint" TypeName="SalesmanWorkplaceWEBClient.ServiceReference1.SWIServiceClient, SalesmanWorkplaceWEBClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" ID="ObjectDataSource1">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="" Name="MyCPID" Type="String"></asp:Parameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </asp:TableCell>
            </asp:TableRow>
         </asp:Table>
    </div>
    </form>
</body>
</html>
