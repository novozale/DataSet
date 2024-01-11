<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OrderDetails.aspx.vb" Inherits="SalesmanWorkplaceWEBClient.OrderDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table Width="100%" height="100%" ID="Table4" runat="server" >
        <asp:TableRow runat="server" >
            <asp:TableCell Width="100%" runat="server" >
                <asp:Label ID="Label1" runat="server" Text="Детальная информация по заказу" Font-Names="Arial" Font-Size="10" Font-Bold="True" ForeColor="#003399"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" >
            <asp:TableCell Width="100%" runat="server" >
                <asp:Table Width="100%" ID="Table1" runat="server" >
                    <asp:TableRow runat="server" BackColor="#E5E5E5" >
                        <asp:TableCell Width="60%" runat="server" >
                            <asp:Label ID="LabelTitle" runat="server" Text="0000001" Font-Names="Arial" Font-Size="8" Font-Bold="True" ForeColor="#3366FF"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell Width="40%" runat="server" HorizontalAlign="Right" >
                            <asp:Button ID="ButtonClose" runat="server" Text="Закрыть" Font-Names="Arial" Font-Size="8" />
                        </asp:TableCell>
                    </asp:TableRow>
                 </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" >
            <asp:TableCell Width="100%" runat="server" >
                <asp:GridView ID="GridView1" runat="server" Width="100%" BackColor="White" BorderColor="#E7E7FF" BorderStyle="Groove" 
                    BorderWidth="1px" CellPadding="3" DataKeyNames="StrNum" Font-Names="Arial" Font-Size="8" AllowSorting="False" 
                    EnableSortingAndPagingCallbacks="False" ShowHeaderWhenEmpty="True" EnableViewState="True" AutoGenerateColumns="False" selectedindex="0"
                    PageSize="100">
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <HeaderStyle BackColor="#000066" Font-Bold="True" ForeColor="#F7F7F7" />
                    <RowStyle BackColor="#F7F7F7" ForeColor="#4A3C8C" />
                    <Columns>
                        <asp:BoundField DataField="StrNum" headertext="Номер строки"/>
                        <asp:BoundField DataField="ItemCode" headertext="Код запаса"/>
                        <asp:BoundField DataField="ItemName" headertext="Название запаса"/>
                        <asp:BoundField DataField="OrderedQTY" headertext="Заказанное количество"/>
                        <asp:BoundField DataField="ReadyQTY" headertext="Готовое количество"/>
                        <asp:BoundField DataField="ShippedQTY" headertext="Отгруженное количество"/>
                        <asp:BoundField DataField="Price" headertext="Цена"/>
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>
     </asp:Table>
    </div>
    </form>
</body>
</html>
