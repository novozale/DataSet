<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CPStrAdd.aspx.vb" Inherits="SalesmanWorkplaceWEBClient.CPStrAdd" EnableEventValidation="False"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table runat="server" Width="70%" >
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" runat="server" >
                    <asp:Table runat="server" Width="100%" >
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" >
                                <asp:Label ID="LabelStrNum" runat="server" Text="Добавление строки 000010" Font-Names="Arial" Font-Bold="True" Font-Size="10" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" >
                                <asp:Table runat="server" Width="100%" >
                                    <asp:TableRow runat="server" >
                                        <asp:TableCell Width="5%" runat="server" >
                                            <asp:Label ID="Label6" runat="server" Text="Валюта" Font-Names="Arial" Font-Size="10" Width="100%" ForeColor="#003399"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell Width="95%" runat="server" >
                                            <asp:TextBox ID="TextBoxCurrName" runat="server" Width="100%" Enabled="False" Font-Names="Arial" Font-Size="8"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:Table runat="server" Width="100%" >
                                    <asp:TableRow runat="server" >
                                        <asp:TableCell Width="5%" runat="server" >
                                            <asp:Label ID="Label18" runat="server" Text="Курс" Font-Names="Arial" Font-Size="10" Width="100%" ForeColor="#003399"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell Width="95%" runat="server" >
                                            <asp:TextBox ID="TextBoxCurrValue" runat="server" Width="100%" Enabled="False" Font-Names="Arial" Font-Size="8"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                             </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                              <asp:Label ID="LabelRecommendedPrice" runat="server" Text="Рекомендованная цена и себестоимость на основе прайс - листа на закупку" Font-Names="Arial" Font-Size="10" Width="100%" ForeColor="DarkGreen" Font-Bold="True"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                             </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                              <asp:Label ID="LabelWHAssortiment" runat="server" Text="Складской ассортимент" Font-Names="Arial" Font-Size="10" Width="100%" ForeColor="#003399" Font-Bold="True"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label2" runat="server" Text="Кратность в упаковке" Font-Names="Arial" Font-Size="10" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:TextBox ID="TextBoxQTYInPack" runat="server" Width="100%" Enabled="False" Font-Names="Arial" Font-Size="8"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label3" runat="server" Text="Мин. количество в заказе на закупку" Font-Names="Arial"  Font-Size="10" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:TextBox ID="TextBoxMinQTY" runat="server" Width="100%" Enabled="False" Font-Names="Arial" Font-Size="8"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label24" runat="server" Text="Срок поставки по прайсу поставщика (дней)" Font-Names="Arial"  Font-Size="10" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:TextBox ID="TextBoxLT" runat="server" Width="100%" Enabled="False" Font-Names="Arial" Font-Size="8"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" runat="server" >
                    <asp:Table runat="server" Width="100%" >
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" >
                                <asp:Label ID="Label7" runat="server" Text="Запас" Font-Names="Arial" Font-Bold="True" Font-Size="10" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label1" runat="server" Text="Код запаса в Scala" Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:Table runat="server" Width="100%" >
                                    <asp:TableRow runat="server" >
                                        <asp:TableCell Width="98%" runat="server">
                                            <asp:TextBox ID="TextBoxScalaItemCode" runat="server" Width="100%" Enabled="False" Font-Names="Arial" Font-Size="8"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Width="2%" runat="server">
                                            <asp:Button ID="ButtonScalaItemClear" runat="server" Text="X" Font-Size="8" Font-Names="Arial" />
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label5" runat="server" Text="Название запаса" Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:TextBox ID="TextBoxItemName" runat="server" Width="100%" Enabled="False" Font-Names="Arial" Font-Size="8"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label25" runat="server" Text="Код товара поставщика" Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:Table runat="server" Width="100%" >
                                    <asp:TableRow runat="server" >
                                        <asp:TableCell Width="98%" runat="server">
                                            <asp:TextBox ID="TextBoxSupplierItemCode" runat="server" Width="100%" Enabled="False" Font-Names="Arial" Font-Size="8"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Width="2%" runat="server">
                                            <asp:Button ID="ButtonSuppItemCodeClear" runat="server" Text="X" Font-Size="8" Font-Names="Arial" Enabled="False" />
                                        </asp:TableCell>
                                        <asp:TableCell Width="2%" runat="server">
                                            <asp:Button ID="ButtonSuppItemCodeSelect" runat="server" Text="Выбрать" Font-Size="8" Font-Names="Arial" Enabled="False" />
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                             </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label26" runat="server" Text="Код поставщика" Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:Table runat="server" Width="100%" >
                                    <asp:TableRow runat="server" >
                                        <asp:TableCell Width="98%" runat="server">
                                            <asp:TextBox ID="TextBoxSupplierCode" runat="server" Width="100%" Enabled="False" Font-Names="Arial" Font-Size="8"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Width="2%" runat="server">
                                            <asp:Button ID="ButtonSupplierClear" runat="server" Text="X" Font-Size="8" Font-Names="Arial" Enabled="False" />
                                        </asp:TableCell>
                                        <asp:TableCell Width="2%" runat="server">
                                            <asp:Button ID="ButtonSupplierSelect" runat="server" Text="Выбрать" Font-Size="8" Font-Names="Arial" Enabled="False" />
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label27" runat="server" Text="Название поставщика" Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:TextBox ID="TextBoxSupplierName" runat="server" Width="100%" Enabled="False" Font-Names="Arial" Font-Size="8"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                     </asp:Table>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" runat="server" >
                    <asp:Table runat="server" Width="100%" >
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" >
                                <asp:Label ID="Label4" runat="server" Text="Данные" Font-Names="Arial" Font-Bold="True" Font-Size="10" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label8" runat="server" Text="Количество" Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:TextBox ID="TextBoxQTY" runat="server" Width="100%" Font-Names="Arial" Font-Size="8" AutoPostBack="True"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label10" runat="server" Text="Единица измерения" Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:DropDownList ID="DropDownListUOM" runat="server" Width="100%" AppendDataBoundItems="True" Font-Size="8" Font-Names="Arial" Enabled="False"></asp:DropDownList>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label11" runat="server" Text="Цена за единицу" Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:TextBox ID="TextBoxPrice" runat="server" Width="100%" Font-Names="Arial" Font-Size="8" AutoPostBack="True"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label12" runat="server" Text="Себестоимость единицы" Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:TextBox ID="TextBoxPriCost" runat="server" Width="100%" Enabled="False" Font-Names="Arial" Font-Size="8" AutoPostBack="True"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label13" runat="server" Text="Скидка" Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:TextBox ID="TextBoxDiscount" runat="server" Width="100%" Font-Names="Arial" Font-Size="8" AutoPostBack="True"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label28" runat="server" Text="Маржа" Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:TextBox ID="TextBoxMargin" runat="server" Width="100%" Enabled="False" Font-Names="Arial" Font-Size="8"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label29" runat="server" Text="Срок поставки (нед)" Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:TextBox ID="TextBoxCPLT" runat="server" Width="100%" Font-Names="Arial" Font-Size="8"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label19" runat="server" Text="Срок доставки до клиента (нед)" Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:TextBox ID="TextBoxCPDelTime" runat="server" Width="100%" Font-Names="Arial" Font-Size="8"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                     </asp:Table>
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow runat="server" BackColor="#CCCCCC">
                <asp:TableCell Width="100%" runat="server" >
                    <asp:Table runat="server" Width="100%" >
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" >
                             </asp:TableCell>
                            <asp:TableCell Width="30%" runat="server" >
                            </asp:TableCell>
                            <asp:TableCell Width="20%" runat="server" >
                                <asp:Button ID="Quit" runat="server" Text="Отмена" Width="100%" Font-Names="Arial" Font-Size="8"/>
                            </asp:TableCell>
                            <asp:TableCell Width="20%" runat="server" >
                                <asp:Button ID="SaveQuit" runat="server" Text="Сохранить и выйти" Width="100%" Font-Names="Arial" Font-Size="8"/>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
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
                    <asp:Label ID="Label9" runat="server" Text="Список поставщиков" Font-Names="Arial" Font-Size="10" Font-Bold="True" ForeColor="#003399"></asp:Label>
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
    <div id="DivSuppItemCodes" runat="server" disabled="True" visible="False" style="border: medium double #000080; height:80%; width:80%; left:10%; top:10%; background-color:white; position:absolute; z-index:2;"  >
        <asp:Table Width="100%" ID="Table1" runat="server" BorderStyle="Double" BorderColor="#003399" BorderWidth="1">
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" runat="server" >
                    <asp:Label ID="Label14" runat="server" Text="Список кодов товара поставщика" Font-Names="Arial" Font-Size="10" Font-Bold="True" ForeColor="#003399"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" runat="server" >
                    <asp:Label ID="Label15" runat="server" Text="Параметры поиска" Font-Names="Arial" Font-Size="8" Font-Bold="True" ForeColor="#003399"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" runat="server" BorderStyle="Groove" BorderWidth="1" BackColor="#E5E5E5">
                    <asp:Label ID="Label16" runat="server" Text="Подстрока" Font-Names="Arial" Font-Size="8" Font-Bold="True" ForeColor="#003399"></asp:Label>
                    <asp:TextBox ID="SICSubstring1" runat="server" Width="100Px"></asp:TextBox>
                    &nbsp <asp:Label ID="Label17" runat="server" Text="и" Font-Names="Arial" Font-Size="8" Font-Bold="True" ForeColor="#003399"></asp:Label> &nbsp
                    <asp:TextBox ID="SICSubstring2" runat="server" Width="100Px"></asp:TextBox>
                    <asp:Button ID="ButtonSICSearch" runat="server" Text="Поиск" Font-Names="Arial" Font-Size="8" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" runat="server" >
                    <asp:GridView ID="GridView1" runat="server" Width="100%" BackColor="White" BorderColor="#E7E7FF" BorderStyle="Groove" 
                        BorderWidth="1px" CellPadding="3" DataKeyNames="SupplierItemCode" Font-Names="Arial" Font-Size="X-Small" AllowSorting="False" 
                        EnableSortingAndPagingCallbacks="False" ShowHeaderWhenEmpty="True" EnableViewState="True" AutoGenerateColumns="False" selectedindex="0"
                        PageSize="100">
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                            <HeaderStyle BackColor="#000066" Font-Bold="True" ForeColor="#F7F7F7" />
                            <RowStyle BackColor="#F7F7F7" ForeColor="#4A3C8C" />
                            <SelectedRowStyle BackColor="#4444FF" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="SupplierItemCode" headertext="Код товара поставщика"/>
                            <asp:BoundField DataField="Price" headertext="Цена"/>
                            <asp:BoundField DataField="PriCost" headertext="Себестоимость (без таможенных сборов)"/>
                            <asp:BoundField DataField="SupplierCode" headertext="Код поставщика"/>
                            <asp:BoundField DataField="SupplierName" headertext="Название поставщика"/>
                            <asp:BoundField DataField="MinOrderQTY" headertext="Мин кол-во в заказе на закупку"/>
                            <asp:BoundField DataField="LT" headertext="срок поставки (дни)"/>
                            <asp:BoundField DataField="WeekQTY" headertext="Срок готовности (недели)"/>
                            <asp:BoundField DataField="RecordsQTY" headertext="Количество строк"/>
                        </Columns>
                    </asp:GridView>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" runat="server" HorizontalAlign="Right" BorderStyle="Groove" BorderWidth="1" BackColor="#E5E5E5">
                    <asp:Label ID="Label20" runat="server" Text="Показать страницу номер" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" ForeColor="#000099"></asp:Label> &nbsp
                    <asp:DropDownList ID="PagesListSIC" runat="server" ForeColor="#000099" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small"
                         AutoPostBack="true" ></asp:DropDownList> &nbsp
                    <asp:Label ID="LabelSICQTYPages" runat="server" Text="из" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" ForeColor="#000099"></asp:Label> &nbsp &nbsp &nbsp
                    <asp:Label ID="Label22" runat="server" Text="Показывать по " Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" ForeColor="#000099"></asp:Label> &nbsp
                    <asp:DropDownList ID="QTYOnPageListSIC" runat="server" ForeColor="#000099" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" 
                         AutoPostBack="true">
                         <asp:ListItem>20</asp:ListItem>
                         <asp:ListItem>25</asp:ListItem>
                    </asp:DropDownList> &nbsp
                    <asp:Label ID="Label23" runat="server" Text=" записей на странице" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" ForeColor="#000099"></asp:Label> &nbsp &nbsp &nbsp
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" Height="100%">
                <asp:TableCell Width="100%" runat="server" HorizontalAlign="Right" BorderStyle="Groove" BorderWidth="1" BackColor="#E5E5E5" VerticalAlign="Bottom">
                    <asp:Button ID="ButtonSICCancel" runat="server" Text="Отмена" Font-Names="Arial" Font-Size="8" />
                    <asp:Button ID="ButtonSICSelect" runat="server" Text="Выбрать" Font-Names="Arial" Font-Size="8" />
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
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" runat="server" HorizontalAlign="Right" BackColor="#CCCCCC">
                    <asp:Button ID="ButtonErr" runat="server" Text="OK" Font-Names="Arial" Font-Size="8" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    </form>
</body>
</html>
