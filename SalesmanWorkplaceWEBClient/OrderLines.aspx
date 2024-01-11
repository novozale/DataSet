<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OrderLines.aspx.vb" Inherits="SalesmanWorkplaceWEBClient.OrderLines" EnableEventValidation="False" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Table Width="100%" ID="Table4" runat="server">
        <asp:TableRow runat="server" >
            <asp:TableCell Width="100%" runat="server" >
                <asp:Label ID="LabelTitle" runat="server" Text="Список запасов компании Электроскандия" Font-Names="Arial" Font-Size="10" Font-Bold="True" ForeColor="#003399"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" >
            <asp:TableCell Width="100%" runat="server" >
                <asp:Table Width="100%" ID="Table1" runat="server" >
                    <asp:TableRow runat="server" >
                        <asp:TableCell Width="90%" runat="server">
                            <asp:Table Width="100%" ID="Table2" runat="server" CellPadding="0" CellSpacing="-1">
                                <asp:TableRow runat="server">
                                    <asp:TableCell Width="100%" runat="server">
                                        <asp:Label ID="Label1" runat="server" Text="Параметры поиска" Font-Names="Arial" Font-Size="8" Font-Bold="True" ForeColor="#003399"></asp:Label>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow runat="server"  BackColor="Silver">
                                    <asp:TableCell Width="100%" runat="server" >
                                        <asp:Table Width="100%" ID="Table5" runat="server"  >
                                            <asp:TableRow runat="server" >
                                                <asp:TableCell Width="1%" runat="server" >
                                                    <asp:Label ID="Label6" runat="server" Text="Подстрока" Font-Names="Arial" Font-Size="8" ForeColor="#003399"></asp:Label>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server" >
                                                    <asp:TextBox ID="Substring1" runat="server" Width="100Px" Font-Size="8" Font-Names="Arial"></asp:TextBox>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server" >
                                                    <asp:Label ID="Label25" runat="server" Text="и" Font-Names="Arial" Font-Size="8" ForeColor="#003399"></asp:Label>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server" >
                                                    <asp:TextBox ID="Substring2" runat="server" Width="100Px" Font-Size="8" Font-Names="Arial"></asp:TextBox>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server" >
                                                    <asp:Label ID="Label26" runat="server" Text="Поиск:" Font-Names="Arial" Font-Size="8" ForeColor="#003399"></asp:Label>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server" >
                                                    <asp:DropDownList ID="DropDownListFields" runat="server" Width="100Px" Font-Names="Arial" Font-Size="8"></asp:DropDownList>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server" >
                                                    <asp:Label ID="Label3" runat="server" Text="Доступность:" Font-Names="Arial" Font-Size="8" ForeColor="#003399"></asp:Label> 
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server" >
                                                    <asp:DropDownList ID="DropDownListAvlItems" runat="server" Width="100Px" Font-Size="8" Font-Names="Arial">
                                                        <asp:ListItem Value="0"> Все товары </asp:ListItem>
                                                        <asp:ListItem Value="1"> Только в наличии</asp:ListItem>
                                                    </asp:DropDownList>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server" >
                                                    <asp:Label ID="Label4" runat="server" Text="Категория:" Font-Names="Arial" Font-Size="8" ForeColor="#003399"></asp:Label> 
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server" >
                                                    <asp:DropDownList ID="DropDownListCategories" runat="server" Width="100Px" Font-Size="8" Font-Names="Arial"></asp:DropDownList>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:Label ID="Label5" runat="server" Text="Поставщик:" Font-Names="Arial" Font-Size="8" ForeColor="#003399"></asp:Label>
                                                </asp:TableCell>
                                                 <asp:TableCell Width="1%" runat="server" >
                                                    <asp:TextBox ID="TextBoxSupplierCode" runat="server" Width="100Px" Enabled="False" Font-Size="8" Font-Names="Arial"></asp:TextBox>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:Button ID="ButtonSupplierClear" runat="server" Text="X" Font-Names="Arial" Font-Size="8" />
                                                </asp:TableCell>
                                                <asp:TableCell Width="88%" runat="server" >
                                                    <asp:Button ID="ButtonSupplierSearch" runat="server" Text="V" Font-Names="Arial" Font-Size="8" /> 
                                                </asp:TableCell>
                                             </asp:TableRow>
                                        </asp:Table>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </asp:TableCell>
                        <asp:TableCell Width="10%" runat="server" >
                            <asp:Table Width="100%" ID="Table3" runat="server" CellPadding="0" CellSpacing="-1">
                                <asp:TableRow runat="server">
                                    <asp:TableCell Width="100%" runat="server">
                                        <asp:Label ID="Label2" runat="server" Text="Действия" Font-Names="Arial" Font-Size="8" Font-Bold="True" ForeColor="#003399"></asp:Label>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow runat="server" BackColor="#E5E5E5">
                                    <asp:TableCell Width="100%" runat="server">
                                        <asp:Table Width="100%" ID="Table6" runat="server"  >
                                            <asp:TableRow runat="server" >
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:Button ID="ButtonRefresh" runat="server" Text="Обновить" Font-Size="8" Font-Names="Arial" />
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:Button ID="ButtonAlternateItems" runat="server" Text="Альтернативные товары" Font-Size="8" Font-Names="Arial" /> 
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:Button ID="ButtonDetails" runat="server" Text="Детали" Font-Size="8" Font-Names="Arial" />
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
                <!-- таблица с запасами   -->
                <asp:GridView ID="GridView1" runat="server" Width="100%" BackColor="White" BorderColor="#E7E7FF" BorderStyle="Groove" 
                    BorderWidth="1px" CellPadding="3" DataKeyNames="ItemCode, IsDead" Font-Names="Arial" Font-Size="8" AllowSorting="False" 
                    EnableSortingAndPagingCallbacks="False" ShowHeaderWhenEmpty="True" EnableViewState="True" AutoGenerateColumns="False" selectedindex="0"
                    PageSize="100">
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <HeaderStyle BackColor="#000066" Font-Bold="True" ForeColor="#F7F7F7" />
                    <RowStyle BackColor="#F7F7F7" ForeColor="#4A3C8C" />
                    <SelectedRowStyle BackColor="#4444FF" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="ItemCode" headertext="Код запаса"/>
                        <asp:BoundField DataField="ItemName" headertext="Название запаса"/>
                        <asp:BoundField DataField="Price" headertext="базовая цена"/>
                        <asp:BoundField DataField="SupplierItemCode" headertext="Код товара поставщика"/>
                        <asp:BoundField DataField="UOMName" headertext="Ед. измер."/>
                        <asp:BoundField DataField="TotalBalance" headertext="Баланс на всех складах"/>
                        <asp:BoundField DataField="WHBalance" headertext="Баланс на складе отгрузки"/>
                        <asp:BoundField DataField="WHAvailable" headertext="Доступно на складе отгрузки"/>
                        <asp:BoundField DataField="SupplierCode" headertext="Код поставщика"/>
                        <asp:BoundField DataField="SupplierName" headertext="Название поставщика"/>
                        <asp:BoundField DataField="IsDead" headertext="Неликвид" />
                        <asp:BoundField DataField="RecordsQTY" headertext="Количество строк"/>
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" >
             <asp:TableCell Width="100%" runat="server" HorizontalAlign="Right" BackColor="#E5E5E5">
                 <!-- pager для запасов   -->
                 <asp:Label ID="Label7" runat="server" Text="Показать страницу номер" Font-Bold="True" Font-Names="Arial" Font-Size="8" ForeColor="#000099"></asp:Label> &nbsp
                 <asp:DropDownList ID="PagesList1" runat="server" ForeColor="#000099" Font-Bold="True" Font-Names="Arial" Font-Size="8"
                     AutoPostBack="true" ></asp:DropDownList> &nbsp
                 <asp:Label ID="LabelQTYPages" runat="server" Text="из" Font-Bold="True" Font-Names="Arial" Font-Size="8" ForeColor="#000099"></asp:Label> &nbsp &nbsp &nbsp
                 <asp:Label ID="Label8" runat="server" Text="Показывать по " Font-Bold="True" Font-Names="Arial" Font-Size="8" ForeColor="#000099"></asp:Label> &nbsp
                 <asp:DropDownList ID="QTYOnPageList1" runat="server" ForeColor="#000099" Font-Bold="True" Font-Names="Arial" Font-Size="8" 
                     AutoPostBack="true" >
                     <asp:ListItem>10</asp:ListItem>
                     <asp:ListItem>12</asp:ListItem>
                     <asp:ListItem>15</asp:ListItem>
                 </asp:DropDownList> &nbsp
                 <asp:Label ID="Label9" runat="server" Text=" записей на странице" Font-Bold="True" Font-Names="Arial" Font-Size="8" ForeColor="#000099"></asp:Label> &nbsp &nbsp &nbsp
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" BackColor="White">
            <asp:TableCell Width="100%" runat="server" >
                <asp:Table runat="server" width="100%" CellPadding="-1" CellSpacing="-1">
                    <asp:TableRow runat="server" >
                        <asp:TableCell Width="70%" runat="server"  VerticalAlign="Top">
                            <asp:Table runat="server" Width="100%"  CellPadding="0" CellSpacing="0">
                                <asp:TableRow runat="server" >
                                    <asp:TableCell Width="100%" runat="server" >
                                        <asp:Table runat="server" CellPadding="0" CellSpacing="0">
                                            <asp:TableRow runat="server" HorizontalAlign="Right">
                                                <asp:TableCell Width="1%" runat="server"  >
                                                    <asp:Label ID="Label10" runat="server" Text="Запасы в КП №" Font-Names="Arial" Font-Size="8" Font-Bold="True" ForeColor="#003399" Width="65Pt"></asp:Label>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server"  >
                                                    <asp:TextBox ID="TextBoxCPNumber" runat="server" Font-Names="Arial" Font-Size="8" ReadOnly="True" BorderWidth="0" ></asp:TextBox>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server"  >
                                                    <asp:Label ID="Label11" runat="server" Text="Валюта:" Font-Names="Arial" Font-Size="8" Font-Bold="True" ForeColor="#003399"></asp:Label>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server"  >
                                                    <asp:TextBox ID="TextBoxCurrName" runat="server" Font-Names="Arial" Font-Size="8" ReadOnly="True" BorderWidth="0"></asp:TextBox>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server"  >
                                                    <asp:Label ID="Label12" runat="server" Text="Курс:" Font-Names="Arial" Font-Size="8" Font-Bold="True" ForeColor="#003399"></asp:Label>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server"  >
                                                    <asp:TextBox ID="TextBoxCurrValue" runat="server" Font-Names="Arial" Font-Size="8" ReadOnly="True" BorderWidth="0"></asp:TextBox>
                                                </asp:TableCell>
                                                <asp:TableCell Width="94%" runat="server" >
                                                </asp:TableCell>
                                            </asp:TableRow>
                                        </asp:Table>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow runat="server" BackColor="Silver">
                                    <asp:TableCell Width="100%" runat="server" >
                                        <asp:Table runat="server" Width="100%" CellPadding="0" CellSpacing="0">
                                            <asp:TableRow runat="server" HorizontalAlign="Right">
                                                <asp:TableCell Width="1%" runat="server"  >
                                                    <asp:Label ID="Label13" runat="server" Text="С/Стоим:" Width="60Pt" Font-Names="Arial" Font-Size="8" ForeColor="#003399" ></asp:Label>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:TextBox ID="TextBoxPriCost" runat="server" Font-Names="Arial" Font-Size="8" ReadOnly="False" Enabled="False"></asp:TextBox>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:Label ID="Label14" runat="server" Text="Сумма:" Width="65Pt" Font-Names="Arial" Font-Size="8" ForeColor="#003399"></asp:Label>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:TextBox ID="TextBoxSumm" runat="server" Font-Names="Arial" Font-Size="8" Enabled="False"></asp:TextBox>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:Label ID="Label15" runat="server" Text="Сумма с НДС:" Width="75Pt" Font-Names="Arial" Font-Size="8" ForeColor="#003399"></asp:Label>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:TextBox ID="TextBoxSummVithVAT" runat="server" Font-Names="Arial" Font-Size="8" Enabled="False"></asp:TextBox>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:Label ID="Label16" runat="server" Text="Маржа:" Font-Names="Arial" Font-Size="8" ForeColor="#003399"></asp:Label>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:TextBox ID="TextBoxMargin" runat="server" Font-Names="Arial" Font-Size="8" Enabled="False"></asp:TextBox>
                                                </asp:TableCell>
                                                <asp:TableCell Width="92%" runat="server">
                                                </asp:TableCell>
                                            </asp:TableRow>
                                        </asp:Table>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow runat="server" BackColor="Silver">
                                    <asp:TableCell Width="100%" runat="server" >
                                        <asp:Table runat="server" Width="100%" CellPadding="0" CellSpacing="0">
                                            <asp:TableRow runat="server" HorizontalAlign="Right">
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:Label ID="Label17" runat="server" Text="Доставка (РУБ):" Width="60Pt" Font-Names="Arial" Font-Size="8" ForeColor="#003399" ></asp:Label>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:TextBox ID="TextBoxDeliverySumm" runat="server" Font-Names="Arial" Font-Size="8" Enabled="False"></asp:TextBox>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:Label ID="Label18" runat="server" Text="Сумма без доставки в валюте:" Width="65Pt" Font-Names="Arial" Font-Size="6" ForeColor="#003399"></asp:Label>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:TextBox ID="TextBoxSummVithoutDelivery" runat="server" Font-Names="Arial" Font-Size="8" Enabled="False"></asp:TextBox>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:Label ID="Label19" runat="server" Text="Маржа с доставкой:" Width="75Pt" Font-Names="Arial" Font-Size="8" ForeColor="#003399"></asp:Label>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:TextBox ID="TextBoxMarginWithDelivery" runat="server" Font-Names="Arial" Font-Size="8" Enabled="False"></asp:TextBox>
                                                </asp:TableCell>
                                                 <asp:TableCell Width="94%" runat="server">
                                                </asp:TableCell>
                                            </asp:TableRow>
                                        </asp:Table>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow runat="server" BackColor="Silver">
                                    <asp:TableCell Width="100%" runat="server" >
                                        <asp:Table runat="server" Width="100%" CellPadding="0" CellSpacing="0">
                                            <asp:TableRow runat="server" HorizontalAlign="Right">
                                                <asp:TableCell Width="1%" runat="server" >
                                                    <asp:Label ID="Label20" runat="server" Text="Мин. маржа заказа (преодоление менеджером):" Width="219Pt" Font-Names="Arial" Font-Size="8" ForeColor="#003399" ></asp:Label>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:TextBox ID="TextBoxMarginLevelManager" runat="server" Font-Names="Arial" Font-Size="8" Enabled="False"></asp:TextBox>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:Label ID="Label21" runat="server" Text="Мин. маржа заказа (преодоление директором):" Width="197Pt" Font-Names="Arial" Font-Size="8" ForeColor="#003399"></asp:Label>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:TextBox ID="TextBoxMarginLevelDirector" runat="server" Font-Names="Arial" Font-Size="8" Enabled="False"></asp:TextBox>
                                                </asp:TableCell>
                                                  <asp:TableCell Width="96%" runat="server">
                                                </asp:TableCell>
                                            </asp:TableRow>
                                        </asp:Table>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </asp:TableCell>
                        <asp:TableCell Width="30%" runat="server" >
                            <asp:Table runat="server" Width="100%" CellPadding="0" CellSpacing="0">
                                <asp:TableRow runat="server" >
                                    <asp:TableCell Width="100%" runat="server" >
                                        <asp:Table runat="server" CellPadding="0" CellSpacing="0">
                                            <asp:TableRow runat="server" >
                                                <asp:TableCell Width="1%" runat="server"  >
                                                    <asp:Label ID="Label31" runat="server" Text="Действия" Font-Names="Arial" Font-Size="8" Font-Bold="True" ForeColor="#003399" Width="65Pt"></asp:Label>
                                                </asp:TableCell>
                                              </asp:TableRow>
                                        </asp:Table>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow runat="server" BackColor="#E5E5E5">
                                    <asp:TableCell Width="100%" runat="server" >
                                        <asp:Table runat="server" Width="100%" CellPadding="0" CellSpacing="0">
                                            <asp:TableRow runat="server" >
                                                <asp:TableCell Width="33%" runat="server">
                                                    <asp:Button ID="ButtonAddToCP" runat="server" Text="Добавить в КП" Font-Names="Arial" Font-Size="8" ForeColor="#006600" Width="100%" Font-Bold="True" />
                                                </asp:TableCell>
                                                <asp:TableCell Width="33%" runat="server">
                                                    <asp:Button ID="ButtonDelFromCP" runat="server" Text="Удалить из КП" Font-Names="Arial" Font-Size="8" ForeColor="#990033" Width="100%" Font-Bold="True"/>
                                                </asp:TableCell>
                                                <asp:TableCell Width="34%" runat="server">
                                                    <asp:Button ID="ButtonEditInCP" runat="server" Text="Редактировать" Font-Names="Arial" Font-Size="8" ForeColor="#996633" Width="100%" Font-Bold="True"/>
                                                </asp:TableCell>
                                             </asp:TableRow>
                                        </asp:Table>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow runat="server" BackColor="#E5E5E5">
                                    <asp:TableCell Width="100%" runat="server" >
                                        <asp:Table runat="server" CellPadding="0" CellSpacing="0">
                                            <asp:TableRow runat="server" HorizontalAlign="Right">
                                                <asp:TableCell Width="95%" runat="server">
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:Label ID="Label22" runat="server" Text="Скидка (%):" Width="50Pt" Font-Names="Arial" Font-Size="8" ForeColor="#003399" ></asp:Label>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:TextBox ID="TextBoxNewDiscount" runat="server" Font-Names="Arial" Font-Size="8" ></asp:TextBox>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:Label ID="Label23" runat="server" Text="Маржа (%):" Width="50Pt" Font-Names="Arial" Font-Size="8" ForeColor="#003399"></asp:Label>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:TextBox ID="TextBoxNewMargin" runat="server" Font-Names="Arial" Font-Size="8" ></asp:TextBox>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:Button ID="ButtonReCalcMarginDisc" runat="server" Text="Пересчитать" ForeColor="#003399" Font-Names="Arial" Font-Size="8" />
                                                </asp:TableCell>
                                             </asp:TableRow>
                                        </asp:Table>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow runat="server" BackColor="#E5E5E5">
                                    <asp:TableCell Width="100%" runat="server" >
                                        <asp:Table runat="server" CellPadding="0" CellSpacing="0">
                                            <asp:TableRow runat="server" HorizontalAlign="Right">
                                                <asp:TableCell Width="95%" runat="server">
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:Label ID="Label27" runat="server" Text="Увеличить цену строк на (%):" Width="120Pt" Font-Names="Arial" Font-Size="8" ForeColor="#003399"></asp:Label>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:TextBox ID="TextBoxPerCentIncreasing" runat="server" Font-Names="Arial" Font-Size="8" ></asp:TextBox>
                                                </asp:TableCell>
                                                <asp:TableCell Width="1%" runat="server">
                                                    <asp:Button ID="ButtonIncreasePerCent" runat="server" Text="Пересчитать" ForeColor="#003399" Font-Names="Arial" Font-Size="8" />
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
                <!-- таблица с запасами, включенными в заказ   -->
                <asp:GridView ID="GridView2" runat="server" Width="100%" BackColor="White" BorderColor="#E7E7FF" BorderStyle="Groove" 
                    BorderWidth="1px" CellPadding="3" DataKeyNames="StrNum" Font-Names="Arial" Font-Size="8" AllowSorting="False" 
                    EnableSortingAndPagingCallbacks="False" ShowHeaderWhenEmpty="True" EnableViewState="True" AutoGenerateColumns="False" selectedindex="0"
                    PageSize="100">
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <HeaderStyle BackColor="#000066" Font-Bold="True" ForeColor="#F7F7F7" />
                    <RowStyle BackColor="#F7F7F7" ForeColor="#4A3C8C" />
                    <SelectedRowStyle BackColor="#4444FF" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="StrNum" headertext="Номер строки"/>
                        <asp:BoundField DataField="ItemCode" headertext="Код запаса"/>
                        <asp:BoundField DataField="ItemName" headertext="Название запаса"/>
                        <asp:BoundField DataField="PriCost" headertext="С/стоим. за 1"/>
                        <asp:BoundField DataField="Price" headertext="Цена за 1"/>
                        <asp:BoundField DataField="Disc" headertext="Скидка (%)"/>
                        <asp:BoundField DataField="Qty" headertext="Кол-во"/>
                        <asp:BoundField DataField="StrSumDisc" headertext="Сумма строки со скидкой"/>
                        <asp:BoundField DataField="Margin" headertext="Маржа"/>
                        <asp:BoundField DataField="DelMargin" headertext="Маржа с доставкой"/>
                        <asp:BoundField DataField="VAT" headertext="НДС"/>
                        <asp:BoundField DataField="StrSumDiscVAT" headertext="Сумма строки со скидкой с НДС"/>
                        <asp:BoundField DataField="SupplierCode" headertext="Код поставщика"/>
                        <asp:BoundField DataField="SupplierName" headertext="Название поставщика"/>
                        <asp:BoundField DataField="IsBlocked" headertext="Заблокирован"/>
                        <asp:BoundField DataField="WeekQTY" headertext="Поставка (нед)"/>
                        <asp:BoundField DataField="RecordsQTY" headertext="Количество строк"/>
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" >
             <asp:TableCell Width="100%" runat="server" HorizontalAlign="Right" BackColor="#E5E5E5">
                 <!-- pager для запасов, включенных в заказ   -->
                 <asp:Label ID="Label24" runat="server" Text="Показать страницу номер" Font-Bold="True" Font-Names="Arial" Font-Size="8" ForeColor="#000099"></asp:Label> &nbsp
                 <asp:DropDownList ID="PagesList2" runat="server" ForeColor="#000099" Font-Bold="True" Font-Names="Arial" Font-Size="8"
                     AutoPostBack="true" ></asp:DropDownList> &nbsp
                 <asp:Label ID="LabelQTYPages1" runat="server" Text="из" Font-Bold="True" Font-Names="Arial" Font-Size="8" ForeColor="#000099"></asp:Label> &nbsp &nbsp &nbsp
                 <asp:Label ID="Label29" runat="server" Text="Показывать по " Font-Bold="True" Font-Names="Arial" Font-Size="8" ForeColor="#000099"></asp:Label> &nbsp
                 <asp:DropDownList ID="QTYOnPageList2" runat="server" ForeColor="#000099" Font-Bold="True" Font-Names="Arial" Font-Size="8" 
                     AutoPostBack="true" >
                     <asp:ListItem>8</asp:ListItem>
                     <asp:ListItem>10</asp:ListItem>
                     <asp:ListItem>12</asp:ListItem>
                     <asp:ListItem>15</asp:ListItem>
                 </asp:DropDownList> &nbsp
                 <asp:Label ID="Label30" runat="server" Text=" записей на странице" Font-Bold="True" Font-Names="Arial" Font-Size="8" ForeColor="#000099"></asp:Label> &nbsp &nbsp &nbsp
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" >
            <asp:TableCell Width="100%" runat="server" >
                <asp:Table runat="server" Width="100%">
                    <asp:TableRow runat="server" Width="100%">
                        <asp:TableCell Width="40%" runat="server" BackColor="Silver" HorizontalAlign="Left">
                            <asp:Button ID="ButtonSearch" runat="server" Text="Найти в запасах" Font-Names="Arial" Font-Size="8" />   &nbsp
                            <asp:Button ID="ButtonDelivery" runat="server" Text="Стоимость доставки" Font-Names="Arial" Font-Size="8" /> 
                        </asp:TableCell>
                        <asp:TableCell Width="60%" runat="server" BackColor="Silver" HorizontalAlign="Right">
                            <asp:Button ID="ButtonPrint" runat="server" Text="Печать" Font-Names="Arial" Font-Size="8" />   &nbsp
                            <asp:Button ID="ButtonUpload" runat="server" Text="Выгрузить в спецификацию" Font-Names="Arial" Font-Size="8" />   &nbsp
                            <asp:Button ID="ButtonQuit" runat="server" Text="Выйти" Font-Names="Arial" Font-Size="8" /> 
                         </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    </div>
    <div id="DivErr" runat="server" disabled="true" visible="false" style="border: medium double #000080; height:50%; width:50%; left:25%; top:25%; background-color:white; position:absolute; z-index:3">
        <asp:Table Width="100%" Height="100%" ID="Table7" runat="server"  BorderStyle="Double" BackColor="white">
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
    <div id="DivSuppliers" runat="server" disabled="True" visible="False" style="border: medium double #000080; height:80%; width:80%; left:10%; top:10%; background-color:white; position:absolute; z-index:2;"  >
        <asp:Table Width="100%" ID="Table8" runat="server" BorderStyle="Double" BorderColor="#003399" BorderWidth="1">
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" runat="server" >
                    <asp:Label ID="Label28" runat="server" Text="Список поставщиков" Font-Names="Arial" Font-Size="10" Font-Bold="True" ForeColor="#003399"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" runat="server" >
                    <asp:Label ID="Label32" runat="server" Text="Параметры поиска" Font-Names="Arial" Font-Size="8" Font-Bold="True" ForeColor="#003399"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" runat="server" BorderStyle="Groove" BorderWidth="1" BackColor="#E5E5E5">
                    <asp:Label ID="Label33" runat="server" Text="Подстрока" Font-Names="Arial" Font-Size="8" Font-Bold="True" ForeColor="#003399"></asp:Label>
                    <asp:TextBox ID="SuppSubstring1" runat="server" Width="100Px"></asp:TextBox>
                    &nbsp <asp:Label ID="Label34" runat="server" Text="и" Font-Names="Arial" Font-Size="8" Font-Bold="True" ForeColor="#003399"></asp:Label> &nbsp
                    <asp:TextBox ID="SuppSubstring2" runat="server" Width="100Px"></asp:TextBox>
                    &nbsp &nbsp <asp:Label ID="Label35" runat="server" Text="Выбрать, где искать:" Font-Names="Arial" Font-Size="8" Font-Bold="True" ForeColor="#003399"></asp:Label> &nbsp
                    <asp:DropDownList ID="DropDownListSuppFields" runat="server"></asp:DropDownList> &nbsp
                    <asp:Button ID="ButtonSuppSearch" runat="server" Text="Поиск" Font-Names="Arial" Font-Size="8" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" runat="server" >
                    <asp:GridView ID="GridView3" runat="server" Width="100%" BackColor="White" BorderColor="#E7E7FF" BorderStyle="Groove" 
                        BorderWidth="1px" CellPadding="3" DataKeyNames="SupplierCode" Font-Names="Arial" Font-Size="X-Small" AllowSorting="False" 
                        EnableSortingAndPagingCallbacks="False" ShowHeaderWhenEmpty="True" EnableViewState="True" AutoGenerateColumns="False" selectedindex="0"
                        PageSize="100">
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                            <HeaderStyle BackColor="#000066" Font-Bold="True" ForeColor="#F7F7F7" />
                            <RowStyle BackColor="#F7F7F7" ForeColor="#4A3C8C" />
                            <SelectedRowStyle BackColor="#4444FF" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="SupplierCode" headertext="Код поставщика"/>
                            <asp:BoundField DataField="SupplierName" headertext="Имя поставщика"/>
                            <asp:BoundField DataField="SupplierAddress" headertext="Адрес поставщика"/>
                            <asp:BoundField DataField="INN" headertext="ИНН"/>
                            <asp:BoundField DataField="RecordsQTY" headertext="Количество строк"/>
                        </Columns>
                    </asp:GridView>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" runat="server" HorizontalAlign="Right" BorderStyle="Groove" BorderWidth="1" BackColor="#E5E5E5">
                    <asp:Label ID="Label36" runat="server" Text="Показать страницу номер" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" ForeColor="#000099"></asp:Label> &nbsp
                    <asp:DropDownList ID="PagesListSupp" runat="server" ForeColor="#000099" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small"
                         AutoPostBack="true" ></asp:DropDownList> &nbsp
                    <asp:Label ID="LabelSuppQTYPages" runat="server" Text="из" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" ForeColor="#000099"></asp:Label> &nbsp &nbsp &nbsp
                    <asp:Label ID="Label38" runat="server" Text="Показывать по " Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" ForeColor="#000099"></asp:Label> &nbsp
                    <asp:DropDownList ID="QTYOnPageListSupp" runat="server" ForeColor="#000099" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" 
                         AutoPostBack="true">
                         <asp:ListItem>20</asp:ListItem>
                         <asp:ListItem>25</asp:ListItem>
                    </asp:DropDownList> &nbsp
                    <asp:Label ID="Label39" runat="server" Text=" записей на странице" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" ForeColor="#000099"></asp:Label> &nbsp &nbsp &nbsp
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" Height="100%">
                <asp:TableCell Width="100%" runat="server" HorizontalAlign="Right" BorderStyle="Groove" BorderWidth="1" BackColor="#E5E5E5" VerticalAlign="Bottom">
                    <asp:Button ID="ButtonSuppCancel" runat="server" Text="Отмена" Font-Names="Arial" Font-Size="8" />
                    <asp:Button ID="ButtonSuppSelect" runat="server" Text="Выбрать" Font-Names="Arial" Font-Size="8" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    <div id="DivDeliveryCost" runat="server" disabled="True" visible="False" style="border: medium double #000080; height:30%; width:30%; left:35%; top:35%; background-color:white; position:absolute; z-index:2;"  >
        <asp:Table runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="100%">
            <asp:TableRow runat="server" VerticalAlign="Bottom" Height="45%">
                <asp:TableCell runat="server" Width="100%" HorizontalAlign="Center">
                    <asp:Label ID="Label37" runat="server" Text="Стоимость доставки (РУБ)" Font-Names="Arial" Font-Size="10" Font-Bold="True" ForeColor="#003399"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" Width="100%" Height="5%">
                    <asp:TextBox ID="TextBoxDeliveryCost" runat="server" Font-Size="8" Font-Names="Arial" Width="100%"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" Width="100%" Height="5%">
                    <asp:CheckBox ID="CheckBoxAddDelivery" runat="server" Text="Добавить стоимость доставки к цене товаров" Font-Size="8" Font-Names="Arial" Checked="True" ForeColor="#003399" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" VerticalAlign="Top" Height="45%">
                <asp:TableCell runat="server" HorizontalAlign="Right">
                    <asp:Button ID="ButtonDeliveryCancel" runat="server" Text="Отмена" /><asp:Button ID="ButtonDeliverySave" runat="server" Text="Записать" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    </form>
</body>
</html>
