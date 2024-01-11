<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ItemsDetail.aspx.vb" Inherits="SalesmanWorkplaceWEBClient.ItemsDetail" EnableEventValidation="False" %>

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
                    <asp:Label ID="Label1" runat="server" Text="Детальная информация о продукте" Font-Names="Arial" Font-Size="10" Font-Bold="True" ForeColor="#003399"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" runat="server" >
                    <asp:Table Width="100%" ID="Table1" runat="server" >
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="60%" runat="server" VerticalAlign="Top" BackColor="#F4F4F4">
                                <asp:Table Width="100%" ID="Table2" runat="server" CellPadding="0" CellSpacing="0" >
                                    <asp:TableRow runat="server" >
                                        <asp:TableCell Width="60%" runat="server" >
                                            <asp:Label ID="LabelItemName" runat="server" Text="Label" Font-Names="Arial" Font-Bold="True" Font-Size="10" ForeColor="#003399" Width="100%"></asp:Label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow runat="server" >
                                        <asp:TableCell Width="60%" runat="server" >
                                            <asp:Label ID="LabelItemComment" runat="server" Text="Label" Font-Names="Arial" Font-Bold="True" Font-Size="10" ForeColor="#0066FF" Width="100%"></asp:Label>
                                        </asp:TableCell>
                                      </asp:TableRow>
                                </asp:Table>
                            </asp:TableCell>
                            <asp:TableCell Width="40%" runat="server"  BackColor="#E9E9E9">
                                 <asp:Table Width="100%" ID="Table3" runat="server" CellPadding="0" CellSpacing="0" >
                                    <asp:TableRow runat="server" >
                                        <asp:TableCell Width="60%" runat="server" >
                                            <asp:Table Width="100%" ID="Table5" runat="server" >
                                                <asp:TableRow runat="server" >
                                                    <asp:TableCell Width="25%" runat="server" HorizontalAlign="Right">
                                                        <asp:Label ID="Label2" runat="server" Text="Валюта:" Font-Names="Arial" Font-Bold="True" Font-Size="8" ForeColor="#003399" Width="100%"></asp:Label>
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="25%" runat="server" >
                                                        <asp:TextBox ID="TextBoxCurrName" runat="server" Width="100%" Font-Names="Arial" Font-Size="8" ReadOnly="True"></asp:TextBox>
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="25%" runat="server" HorizontalAlign="Right">
                                                        <asp:Label ID="Label5" runat="server" Text="Курс:" Font-Names="Arial" Font-Bold="True" Font-Size="8" ForeColor="#003399" Width="100%"></asp:Label>
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="25%" runat="server">
                                                        <asp:TextBox ID="TextBoxCurrValue" runat="server" Width="100%" Font-Names="Arial" Font-Size="8" ReadOnly="True"></asp:TextBox>
                                                    </asp:TableCell>
                                                </asp:TableRow>
                                            </asp:Table>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow runat="server" >
                                        <asp:TableCell Width="60%" runat="server" >
                                            <asp:Table Width="100%" ID="Table6" runat="server" >
                                                <asp:TableRow runat="server" >
                                                    <asp:TableCell Width="50%" runat="server" HorizontalAlign="Right">
                                                        <asp:Label ID="Label3" runat="server" Text="% таможенных пошлин:" Font-Names="Arial" Font-Bold="True" Font-Size="8" ForeColor="#003399" Width="100%"></asp:Label>
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="50%" runat="server" >
                                                        <asp:TextBox ID="TextBoxCustomsVal" runat="server" Width="100%" Font-Names="Arial" Font-Size="8" ReadOnly="True"></asp:TextBox>
                                                    </asp:TableCell>
                                                 </asp:TableRow>
                                            </asp:Table>
                                            <asp:Table Width="100%" ID="Table7" runat="server" >
                                                <asp:TableRow runat="server" >
                                                    <asp:TableCell Width="50%" runat="server" HorizontalAlign="Right">
                                                        <asp:Label ID="Label4" runat="server" Text="% транспортных расходов (за рубежом):" Font-Names="Arial" Font-Bold="True" Font-Size="8" ForeColor="#003399" Width="100%"></asp:Label>
                                                    </asp:TableCell>
                                                    <asp:TableCell Width="50%" runat="server" >
                                                        <asp:TextBox ID="TextBoxTransportVal" runat="server" Width="100%" Font-Names="Arial" Font-Size="8" ReadOnly="True"></asp:TextBox>
                                                    </asp:TableCell>
                                                 </asp:TableRow>
                                            </asp:Table>
                                        </asp:TableCell>
                                      </asp:TableRow>
                                </asp:Table>
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
                            <asp:BoundField DataField="BalanceQTY" headertext="Баланс"/>
                            <asp:BoundField DataField="AvailableQTY" headertext="Доступно"/>
                            <asp:BoundField DataField="ReservedQTY" headertext="Зарезервировано"/>
                            <asp:BoundField DataField="ZadlQTY" headertext="Задолжено"/>
                            <asp:BoundField DataField="AllocatedQTY" headertext="Распределено"/>
                            <asp:BoundField DataField="CalculatedPriCost" headertext="Себестоимость"/>
                            <asp:BoundField DataField="WarehouseAssortiment" headertext="Складской ассортимент"/>
                        </Columns>
                    </asp:GridView>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" Height="100%">
                <asp:TableCell Width="100%" runat="server" HorizontalAlign="Right" BorderStyle="Groove" BorderWidth="1" BackColor="#E5E5E5" VerticalAlign="Bottom">
                    <asp:Button ID="ButtonSelect" runat="server" Text="Показать информацию по партиям" Font-Names="Arial" Font-Size="8" />
                    <asp:Button ID="ButtonCancel" runat="server" Text="Закрыть" Font-Names="Arial" Font-Size="8" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    </form>
</body>
</html>
