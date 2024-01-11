<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ItemsBatches.aspx.vb" Inherits="SalesmanWorkplaceWEBClient.ItemsBatches" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table Width="100%" ID="Table4" runat="server" >
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" runat="server" >
                    <asp:Label ID="Label1" runat="server" Text="Информация о партиях продукта" Font-Names="Arial" Font-Size="10" Font-Bold="True" ForeColor="#003399"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" runat="server" >
                    <asp:Table Width="100%" ID="Table1" runat="server" >
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="60%" runat="server" >
                                <asp:Label ID="LabelItemName" runat="server" Text="Label" Font-Names="Arial" Font-Bold="True" Font-Size="10" ForeColor="Blue" Width="100%"></asp:Label>
                            </asp:TableCell>
                         </asp:TableRow>
                    </asp:Table>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" runat="server" >
                    <asp:GridView ID="GridView1" runat="server" Width="100%" BackColor="White" BorderColor="#E7E7FF" BorderStyle="Groove" 
                        BorderWidth="1px" CellPadding="3" DataKeyNames="WH" Font-Names="Arial" Font-Size="8" AllowSorting="False" 
                        EnableSortingAndPagingCallbacks="False" ShowHeaderWhenEmpty="True" EnableViewState="True" AutoGenerateColumns="False" selectedindex="0"
                        PageSize="200">
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <HeaderStyle BackColor="#000066" Font-Bold="True" ForeColor="#F7F7F7" />
                        <RowStyle BackColor="#F7F7F7" ForeColor="#4A3C8C" />
                         <Columns>
                            <asp:BoundField DataField="WH" headertext="Склад"/>
                            <asp:BoundField DataField="BatchNum" headertext="№ партии"/>
                            <asp:BoundField DataField="BinNum" headertext="Ячейка"/>
                            <asp:BoundField DataField="Balance" headertext="Баланс"/>
                            <asp:BoundField DataField="Available" headertext="Доступно"/>
                            <asp:BoundField DataField="Allocated" headertext="Распределено"/>
                            <asp:BoundField DataField="Ordered" headertext="Задолжен."/>
                         </Columns>
                    </asp:GridView>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" Height="100%">
                <asp:TableCell Width="100%" runat="server" HorizontalAlign="Right" BorderStyle="Groove" BorderWidth="1" BackColor="#E5E5E5" VerticalAlign="Bottom">
                    <asp:Button ID="ButtonCancel" runat="server" Text="Закрыть" Font-Names="Arial" Font-Size="8" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    </form>
</body>
</html>
