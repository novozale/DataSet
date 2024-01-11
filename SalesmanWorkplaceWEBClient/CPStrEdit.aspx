<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CPStrEdit.aspx.vb" Inherits="SalesmanWorkplaceWEBClient.CPStrEdit" EnableEventValidation="False" %>

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
                                <asp:Label ID="LabelStrNum" runat="server" Text="Редактирование строки 000010" Font-Names="Arial" Font-Bold="True" Font-Size="10" Width="100%" ForeColor="#003399"></asp:Label>
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
                                <asp:TextBox ID="TextBoxScalaItemCode" runat="server" Width="100%" Enabled="False" Font-Names="Arial" Font-Size="8"></asp:TextBox>
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
                                <asp:TextBox ID="TextBoxSupplierItemCode" runat="server" Width="100%" Enabled="False" Font-Names="Arial" Font-Size="8"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label26" runat="server" Text="Код поставщика" Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:TextBox ID="TextBoxSupplierCode" runat="server" Width="100%" Enabled="False" Font-Names="Arial" Font-Size="8"></asp:TextBox>
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
                                <asp:DropDownList ID="DropDownListUOM" runat="server" Width="100%" AppendDataBoundItems="True" Font-Size="8" Font-Names="Arial"></asp:DropDownList>
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
                                <asp:Label ID="Label9" runat="server" Text="Срок доставки до клиента (нед)" Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:TextBox ID="TextBoxClientDelTime" runat="server" Width="100%" Font-Names="Arial" Font-Size="8"></asp:TextBox>
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
                                <asp:Label ID="Label14" runat="server" Text="Новое значение маржи" Font-Names="Arial" Font-Bold="True" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label15" runat="server" Text="Новая маржа (%)" Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:Table runat="server" Width="100%" >
                                    <asp:TableRow runat="server" >
                                        <asp:TableCell Width="98%" runat="server" HorizontalAlign="Right">
                                            <asp:TextBox ID="TextBoxNewMargin" runat="server" Width="100%" Font-Names="Arial" Font-Size="8"></asp:TextBox>
                                        </asp:TableCell>
                                        <asp:TableCell Width="2%" runat="server" HorizontalAlign="Right">
                                            <asp:Button ID="ButtonSetNewMargin" runat="server" Text=">" Font-Names="Arial" Font-Bold="True" Font-Size="8" />
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
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
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" runat="server" >
                    <asp:Table runat="server" Width="100%" >
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" >
                                <asp:Label ID="Label16" runat="server" Text="Срок поставки всего КП" Font-Names="Arial" Font-Bold="True" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label17" runat="server" Text="Срок поставки (нед.)" Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:TextBox ID="TextBoxCPDelTime" runat="server" Width="100%" Font-Names="Arial" Font-Size="8"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label19" runat="server" Text="Срок доставки до клиента (нед.)" Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:TextBox ID="TextBoxCPClientDelTime" runat="server" Width="100%" Font-Names="Arial" Font-Size="8"></asp:TextBox>
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
                             </asp:TableCell>
                            <asp:TableCell Width="20%" runat="server" >
                                <asp:Button ID="SaveCPDelTime" runat="server" Text="Сохранить" Width="100%" Font-Names="Arial" Font-Size="8"/>
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
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" runat="server" HorizontalAlign="Right" BackColor="#CCCCCC">
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
