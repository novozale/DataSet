<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AltItems.aspx.vb" Inherits="SalesmanWorkplaceWEBClient.AltItems" EnableEventValidation="False" %>

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
                <asp:Label ID="Label1" runat="server" Text="Продукты, альтернативные" Font-Names="Arial" Font-Size="10" Font-Bold="True" ForeColor="#003399"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" >
            <asp:TableCell Width="100%" runat="server" >
                 <asp:Label ID="LabelTitle" runat="server" Text="0000001 Стол" Font-Names="Arial" Font-Size="8" Font-Bold="True" ForeColor="#3366FF"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" >
            <asp:TableCell Width="100%" runat="server" >
                <asp:GridView ID="GridView1" runat="server" Width="100%" BackColor="White" BorderColor="#E7E7FF" BorderStyle="Groove" 
                    BorderWidth="1px" CellPadding="3" DataKeyNames="ProductCode" Font-Names="Arial" Font-Size="8" AllowSorting="False" 
                    EnableSortingAndPagingCallbacks="False" ShowHeaderWhenEmpty="True" EnableViewState="True" AutoGenerateColumns="False" selectedindex="0"
                    PageSize="200">
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <HeaderStyle BackColor="#000066" Font-Bold="True" ForeColor="#F7F7F7" />
                    <RowStyle BackColor="#F7F7F7" ForeColor="#4A3C8C" />
                    <SelectedRowStyle BackColor="#4444FF" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="ProductCode" headertext="Код запаса"/>
                        <asp:BoundField DataField="ProductName" headertext="Название запаса"/>
                        <asp:BoundField DataField="SuppProductCode" headertext="Код товара поставщика"/>
                        <asp:BoundField DataField="TotalQTY" headertext="Баланс на всех складах"/>
                        <asp:BoundField DataField="WhQty" headertext="Баланс на складе отгрузки"/>
                        <asp:BoundField DataField="WhAvl" headertext="Доступно на складе отгрузки"/>
                        <asp:BoundField DataField="SuppCode" headertext="Код поставщика"/>
                        <asp:BoundField DataField="SuppName" headertext="Название поставщика"/>
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" Height="100%">
            <asp:TableCell Width="100%" runat="server" HorizontalAlign="Right" BorderStyle="Groove" BorderWidth="1" BackColor="#E5E5E5" VerticalAlign="Bottom">
                <asp:Button ID="ButtonCancel" runat="server" Text="Отмена" Font-Names="Arial" Font-Size="8" />
                <asp:Button ID="ButtonSelect" runat="server" Text="Выбрать" Font-Names="Arial" Font-Size="8" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    </div>
    </form>
</body>
</html>
