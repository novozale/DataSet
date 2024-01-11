<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OrderList.aspx.vb" Inherits="SalesmanWorkplaceWEBClient.OrderList" EnableEventValidation="False"%>

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
                    <asp:Label ID="LabelTitle" runat="server" Text="Список заказов агента" Font-Names="Arial" Font-Size="10" Font-Bold="True" ForeColor="#003399"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" runat="server">
                    <asp:Table Width="100%" ID="Table3" runat="server" >
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="80%" runat="server" BackColor="#E5E5E5">
                                <asp:Label ID="Label1" runat="server" Text="Дата С " Font-Names="Arial" Font-Size="8" Font-Bold="True" ForeColor="#003399"></asp:Label>
                                <asp:Label ID="LabelFrom" runat="server" Text="01/01/2015" Font-Names="Arial" Font-Size="8" Font-Bold="True" ForeColor="#003399" BorderStyle="Solid" BorderWidth="1"></asp:Label>
                                <asp:Button ID="ButtonFrom" runat="server" Text="V" Font-Names="Arial" Font-Size="8" />   &nbsp 
                                <asp:Label ID="Label2" runat="server" Text="Дата По " Font-Names="Arial" Font-Size="8" Font-Bold="True" ForeColor="#003399"></asp:Label>
                                <asp:Label ID="LabelTo" runat="server" Text="31/12/2015" Font-Names="Arial" Font-Size="8" Font-Bold="True" ForeColor="#003399" BorderStyle="Solid" BorderWidth="1"></asp:Label>
                                <asp:Button ID="ButtonTo" runat="server" Text="V" Font-Names="Arial" Font-Size="8" />   &nbsp 
                                <asp:Label ID="Label3" runat="server" Text="Номер заказа: " Font-Names="Arial" Font-Size="8" Font-Bold="True" ForeColor="#003399"></asp:Label> &nbsp
                                <asp:TextBox ID="TextBoxOrderNumber" runat="server"></asp:TextBox> &nbsp
                                <asp:Label ID="Label4" runat="server" Text="Активность заказа: " Font-Names="Arial" Font-Size="8" Font-Bold="True" ForeColor="#003399"></asp:Label> &nbsp
                                <asp:DropDownList ID="DropDownListActive" runat="server" AutoPostBack="True">
                                    <asp:ListItem Value="0"> Все заказы </asp:ListItem>
                                    <asp:ListItem Value="1"> Только активные заказы </asp:ListItem>
                                </asp:DropDownList> &nbsp &nbsp
                                <asp:Button ID="ButtonRefresh" runat="server" Text="Обновить" Font-Names="Arial" Font-Size="8" /> &nbsp
                                <asp:Button ID="ButtonDetails" runat="server" Text="Строки заказа" Font-Names="Arial" Font-Size="8" />
                            </asp:TableCell>
                            <asp:TableCell Width="20%" runat="server" BackColor="#E5E5E5" HorizontalAlign="Right">
                                <asp:Button ID="ButtonQuit" runat="server" Text="Выход" Font-Names="Arial" Font-Size="8" />
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" runat="server" >
                    <asp:GridView ID="GridView1" runat="server" Width="100%" BackColor="White" BorderColor="#E7E7FF" BorderStyle="Groove" 
                            BorderWidth="1px" CellPadding="3" DataKeyNames="OrderNum" Font-Names="Arial" Font-Size="X-Small" AllowSorting="False" 
                            EnableSortingAndPagingCallbacks="False" ShowHeaderWhenEmpty="True" EnableViewState="True" AutoGenerateColumns="False" selectedindex="0"
                            PageSize="100">
                                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                <HeaderStyle BackColor="#000066" Font-Bold="True" ForeColor="#F7F7F7" />
                                <RowStyle BackColor="#F7F7F7" ForeColor="#4A3C8C" />
                                <SelectedRowStyle BackColor="#4444FF" Font-Bold="True" ForeColor="White" />
                         <Columns>
                            <asp:BoundField DataField="ClientCode" headertext="Покупатель"/>
                            <asp:BoundField DataField="OrderDate" headertext="Дата заказа"/>
                            <asp:BoundField DataField="OrderNum" headertext="Номер заказа"/>
                            <asp:BoundField DataField="OrderSumm" headertext="Сумма заказа"/>
                            <asp:BoundField DataField="ShipmentState" headertext="Состояние отгрузки"/>
                            <asp:BoundField DataField="OrderState" headertext="Состояние заказа"/>
                            <asp:BoundField DataField="RecordsQTY" headertext="Количество строк"/>
                        </Columns>
                    </asp:GridView>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" >
                 <asp:TableCell Width="100%" runat="server" HorizontalAlign="Right" BackColor="#E5E5E5">
                     <asp:Label ID="Label5" runat="server" Text="Показать страницу номер" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" ForeColor="#000099"></asp:Label> &nbsp
                     <asp:DropDownList ID="PagesList" runat="server" ForeColor="#000099" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small"
                         AutoPostBack="true" ></asp:DropDownList> &nbsp
                     <asp:Label ID="LabelQTYPages" runat="server" Text="из" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" ForeColor="#000099"></asp:Label> &nbsp &nbsp &nbsp
                     <asp:Label ID="Label6" runat="server" Text="Показывать по " Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" ForeColor="#000099"></asp:Label> &nbsp
                     <asp:DropDownList ID="QTYOnPageList" runat="server" ForeColor="#000099" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" 
                         AutoPostBack="true">
                         <asp:ListItem>20</asp:ListItem>
                         <asp:ListItem>30</asp:ListItem>
                         <asp:ListItem>50</asp:ListItem>
                     </asp:DropDownList> &nbsp
                     <asp:Label ID="Label7" runat="server" Text=" записей на странице" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" ForeColor="#000099"></asp:Label> &nbsp &nbsp &nbsp
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    <div id="MyDate1" runat="server" disabled="true" visible="false" style="border: medium double #000080; height:200px; width:200px;left:50px; top:50px; background-color:white; position:absolute; z-index:2" title="Дата С">
        <asp:Table Width="100%" Height="100%" ID="TableD1" runat="server"  BorderStyle="Double" BackColor="white">
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" Height="100%" runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                    <asp:Calendar ID="CalendarFrom" runat="server" Font-Names="Arial" Font-Size="8" ForeColor="#003399" Caption="Выберите дату С "></asp:Calendar>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" BackColor="#CCCCCC">
                <asp:TableCell Width="100%" runat="server" HorizontalAlign="Right">
                    <asp:Button ID="ButtonSelectData1" runat="server" Text="выбрать" Font-Names="Arial" Font-Size="8" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    <div id="MyDate2" runat="server" disabled="true" visible="false" style="border: medium double #000080; height:200px; width:200px;left:200px; top:50px; background-color:white; position:absolute; z-index:2" title="Дата С">
        <asp:Table Width="100%" Height="100%" ID="Table1" runat="server"  BorderStyle="Double" BackColor="white">
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" Height="100%" runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                    <asp:Calendar ID="CalendarTo" runat="server" Font-Names="Arial" Font-Size="8" ForeColor="#003399" Caption="Выберите дату По "></asp:Calendar>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" BackColor="#CCCCCC">
                <asp:TableCell Width="100%" runat="server" HorizontalAlign="Right">
                    <asp:Button ID="ButtonSelectData2" runat="server" Text="выбрать" Font-Names="Arial" Font-Size="8" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    <div id="DivErr" runat="server" disabled="true" visible="false" style="border: medium double #000080; height:50%; width:50%; left:25%; top:25%; background-color:white; position:absolute; z-index:2">
        <asp:Table Width="100%" Height="100%" ID="Table2" runat="server"  BorderStyle="Double" BackColor="white">
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" Height="100%" runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                    <asp:Label ID="LabelErr" runat="server" Text="Label" Font-Names="Arial" Font-Size="Medium" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" BackColor="#CCCCCC">
                <asp:TableCell Width="100%" runat="server" HorizontalAlign="Right">
                    <asp:Button ID="ButtonErr" runat="server" Text="OK" Font-Names="Arial" Font-Size="8" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    <div id="DivBG" runat="server" disabled="true" visible="false" style="height:200%; width:200%; left:0; top:0; background-color:black; position:absolute; z-index:1; opacity:0.6; filter:alpha(opacity=60);" >
    </div>
    </form>
</body>
</html>
