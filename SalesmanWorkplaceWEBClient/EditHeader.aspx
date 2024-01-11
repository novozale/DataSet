<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EditHeader.aspx.vb" Inherits="SalesmanWorkplaceWEBClient.EditHeader" EnableEventValidation="False"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Заголовок коммерческого предложения</title>
</head>
 <body >
    <form id="form1" runat="server">
         <asp:Table runat="server" Width="70%" >
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" runat="server" >
                    <asp:Table runat="server" Width="100%" >
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" >
                                <asp:Label ID="Label9" runat="server" Text="Работа с коммерческим предложением" Font-Names="Arial" Font-Bold="True" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label2" runat="server" Text="Коммерческое предложение Номер " Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:Label ID="CPNumber" runat="server" Text="1" BorderStyle="Groove" BorderWidth="1" Font-Names="Arial" Font-Size="Small" BackColor="#E1E1E1" Width="100%"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label3" runat="server" Text="Торговый агент " Font-Names="Arial"  Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:Label ID="AgentName" runat="server" Text="Иванов" BorderStyle="Groove" BorderWidth="1" Font-Names="Arial" Font-Size="Small" BackColor="#E1E1E1" Width="100%"></asp:Label>
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
                                <asp:Label ID="Label7" runat="server" Text="Информация о предложении" Font-Names="Arial" Font-Bold="True" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label1" runat="server" Text="Продавец" Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:DropDownList ID="DropDownListSalesman" runat="server" Width="100%" AppendDataBoundItems="True"></asp:DropDownList>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label5" runat="server" Text="Код покупателя " Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:Table runat="server" Width="100%" >
                                    <asp:TableRow runat="server" >
                                        <asp:TableCell Width="95%" runat="server" >
                                            <asp:Label ID="CustomerNumber" runat="server" Text="" BorderStyle="Groove" BorderWidth="1" Font-Names="Arial" Font-Size="Small" BackColor="#E1E1E1" Width="100%"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell Width="2%" runat="server" HorizontalAlign="Right">
                                            <asp:Button ID="ButtonCustomCustomer" runat="server" Text="X" Font-Names="Arial" Font-Size="8" />
                                        </asp:TableCell>
                                        <asp:TableCell Width="3%" runat="server" HorizontalAlign="Right">
                                            <asp:Button ID="SelectCustomer" runat="server" Text="Выбрать" Font-Names="Arial" Font-Size="8" />
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label4" runat="server" Text="Покупатель" Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:TextBox ID="CustomerName" runat="server" Width="99.5%"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label8" runat="server" Text="Адрес покупателя" Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:TextBox ID="CustomerAddress" runat="server" Width="99.5%"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label10" runat="server" Text="Склад" Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:DropDownList ID="DropDownListWH" runat="server" Width="100%" AppendDataBoundItems="True"></asp:DropDownList>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label11" runat="server" Text="Код документа" Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:DropDownList ID="DropDownListDocCodes" runat="server" Width="100%" AppendDataBoundItems="True"></asp:DropDownList>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label12" runat="server" Text="Валюта предложения" Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:DropDownList ID="DropDownListCurr" runat="server" Width="100%" AppendDataBoundItems="True"></asp:DropDownList>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label13" runat="server" Text="Примечание" Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:TextBox ID="Comments" runat="server" Width="99.5%"></asp:TextBox>
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
                                <asp:Label ID="Label14" runat="server" Text="Дополнительная информация" Font-Names="Arial" Font-Bold="True" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label15" runat="server" Text="Цены указаны на условиях" Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:DropDownList ID="DropDownListPriceCond" runat="server" Width="100%" AppendDataBoundItems="True"></asp:DropDownList>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label16" runat="server" Text="Условия оплаты" Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:TextBox ID="PaymentsCondition" runat="server" Width="99.5%"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label17" runat="server" Text="Срок действия предложения - до" Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:Table runat="server" Width="100%" >
                                    <asp:TableRow runat="server" >
                                        <asp:TableCell Width="98%" runat="server" >
                                            <asp:Label ID="CPValidTo" runat="server" Text="" Font-Names="Arial" Font-Size="Small" Width="100%" BorderStyle="Solid" BorderWidth="1" BorderColor="#999999"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell Width="2%" runat="server" >
                                            <asp:Button ID="ButtonDateExp" runat="server" Text="V" Font-Names="Arial" Font-Size="8" />
                                        </asp:TableCell>
                                     </asp:TableRow>
                                </asp:Table>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="30%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label19" runat="server" Text="Возможность частичной поставки " Font-Names="Arial" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:DropDownList ID="DropDownListPartialDel" runat="server" Width="100%" AppendDataBoundItems="True"></asp:DropDownList>
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
                                <asp:Label ID="Label20" runat="server" Text="Действия" Font-Names="Arial" Font-Bold="True" Font-Size="Small" Width="100%" ForeColor="#003399"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server">
                            </asp:TableCell>
                        </asp:TableRow>
                     </asp:Table>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" runat="server" >
                    <asp:Table runat="server" Width="100%" >
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="25%" runat="server" >
                                <asp:Button ID="CPPrint" runat="server" Text="Печать" Width="100%" Font-Names="Arial" Font-Size="8" />
                            </asp:TableCell>
                            <asp:TableCell Width="25%" runat="server" >
                                <asp:Button ID="CPStringEdit" runat="server" Text="Редактирование строк" Width="100%" Font-Names="Arial" Font-Size="8"/>
                            </asp:TableCell>
                            <asp:TableCell Width="25%" runat="server" >
                                <asp:Button ID="Quit" runat="server" Text="Выйти без сохранения" Width="100%" Font-Names="Arial" Font-Size="8"/>
                            </asp:TableCell>
                            <asp:TableCell Width="25%" runat="server" >
                                <asp:Button ID="SaveQuit" runat="server" Text="Сохранить и выйти" Width="100%" Font-Names="Arial" Font-Size="8"/>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" >
                <asp:TableCell Width="100%" runat="server" >
                    <asp:Table runat="server" Width="100%" BorderWidth="1" BorderColor="Silver" BorderStyle="Solid">
                        <asp:TableRow runat="server" >
                            <asp:TableCell Width="25%" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label21" runat="server" Text="файл с КП для загрузки" Font-Names="Arial" Font-Size="Small" ForeColor="#003399" Width="100%"></asp:Label>
                             </asp:TableCell>
                            <asp:TableCell Width="70%" runat="server" >
                                <asp:FileUpload ID="FileUpload1" runat="server" Width="100%" Font-Names="Arial" Font-Size="8" Height="20" />
                            </asp:TableCell>
                            <asp:TableCell Width="5%" runat="server" >
                                <asp:Button ID="ButtonUploadExcel" runat="server" Text="Загрузить в текущее КП" Width="100%" Font-Names="Arial" Font-Size="8" />
                            </asp:TableCell>
                         </asp:TableRow>
                    </asp:Table>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <div id="DivBG" runat="server" disabled="True" visible="False" style="height:200%; width:200%; left:0; top:0; background-color:black; position:absolute; z-index:1; opacity:0.6; filter:alpha(opacity=60);" >
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
        <div id="DivQuestion" runat="server" disabled="true" visible="false" style="border: medium double #000080; height:50%; width:50%; left:25%; top:25%; background-color:white; position:absolute; z-index:2">
            <asp:Table Width="100%" Height="100%" ID="Table1" runat="server"  BorderStyle="Double" BackColor="white">
                <asp:TableRow runat="server" >
                    <asp:TableCell Width="100%" Height="100%" runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                        <asp:Label ID="LabelQuestion" runat="server" Text="Label" Font-Names="Arial" Font-Size="Medium" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" BackColor="#CCCCCC">
                    <asp:TableCell Width="100%" runat="server" HorizontalAlign="Right">
                        <asp:Button ID="ButtonYes" runat="server" Text="Да" Font-Names="Arial" Font-Size="8" Width="50" /> &nbsp
                        <asp:Button ID="ButtonNo" runat="server" Text="Нет" Font-Names="Arial" Font-Size="8" Width="50"/>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
         </div>
        <div id="MyDate1" runat="server" disabled="true" visible="false" style="border: medium double #000080; height:200px; width:200px;left:60%; top:50%; background-color:white; position:absolute; z-index:2" title="Дата С">
            <asp:Table Width="100%" Height="100%" ID="TableD1" runat="server"  BorderStyle="Double" BackColor="white">
                <asp:TableRow runat="server" >
                    <asp:TableCell Width="100%" Height="100%" runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                        <asp:Calendar ID="CalendarExp" runat="server" Font-Names="Arial" Font-Size="8" ForeColor="#003399" Caption="Выберите дату С "></asp:Calendar>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" BackColor="#CCCCCC">
                    <asp:TableCell Width="100%" runat="server" HorizontalAlign="Right">
                        <asp:Button ID="ButtonSelectData1" runat="server" Text="выбрать" Font-Names="Arial" Font-Size="8" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
         </div>
        <div id="DivCustomers" runat="server" disabled="True" visible="False" style="border: medium double #000080; height:80%; width:80%; left:10%; top:10%; background-color:white; position:absolute; z-index:2;"  >
            <asp:Table Width="100%" ID="Table4" runat="server" BorderStyle="Double" BorderColor="#003399" BorderWidth="1">
                <asp:TableRow runat="server" >
                    <asp:TableCell Width="100%" runat="server" >
                        <asp:Label ID="LabelTitle" runat="server" Text="Список покупателей из Scala" Font-Names="Arial" Font-Size="10" Font-Bold="True" ForeColor="#003399"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" >
                    <asp:TableCell Width="100%" runat="server" >
                        <asp:Label ID="Label24" runat="server" Text="Параметры поиска" Font-Names="Arial" Font-Size="8" Font-Bold="True" ForeColor="#003399"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" >
                    <asp:TableCell Width="100%" runat="server" BorderStyle="Groove" BorderWidth="1" BackColor="#E5E5E5">
                        <asp:Label ID="Label6" runat="server" Text="Подстрока" Font-Names="Arial" Font-Size="8" Font-Bold="True" ForeColor="#003399"></asp:Label>
                        <asp:TextBox ID="Substring1" runat="server" Width="100Px"></asp:TextBox>
                        &nbsp <asp:Label ID="Label25" runat="server" Text="и" Font-Names="Arial" Font-Size="8" Font-Bold="True" ForeColor="#003399"></asp:Label> &nbsp
                        <asp:TextBox ID="Substring2" runat="server" Width="100Px"></asp:TextBox>
                        &nbsp &nbsp <asp:Label ID="Label26" runat="server" Text="Выбрать, где искать:" Font-Names="Arial" Font-Size="8" Font-Bold="True" ForeColor="#003399"></asp:Label> &nbsp
                        <asp:DropDownList ID="DropDownListFields" runat="server"></asp:DropDownList> &nbsp
                        <asp:Button ID="ButtonSearch" runat="server" Text="Поиск" Font-Names="Arial" Font-Size="8" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" >
                    <asp:TableCell Width="100%" runat="server" >
                        <asp:GridView ID="GridView1" runat="server" Width="100%" BackColor="White" BorderColor="#E7E7FF" BorderStyle="Groove" 
                            BorderWidth="1px" CellPadding="3" DataKeyNames="CustomerCode" Font-Names="Arial" Font-Size="X-Small" AllowSorting="False" 
                            EnableSortingAndPagingCallbacks="False" ShowHeaderWhenEmpty="True" EnableViewState="True" AutoGenerateColumns="False" selectedindex="0"
                            PageSize="100">
                                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                <HeaderStyle BackColor="#000066" Font-Bold="True" ForeColor="#F7F7F7" />
                                <RowStyle BackColor="#F7F7F7" ForeColor="#4A3C8C" />
                                <SelectedRowStyle BackColor="#4444FF" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="CustomerCode" headertext="Код клиента"/>
                                <asp:BoundField DataField="CustomerName" headertext="Имя клиента"/>
                                <asp:BoundField DataField="CustomerAddress" headertext="Адрес клиента"/>
                                <asp:BoundField DataField="INN" headertext="ИНН"/>
                                <asp:BoundField DataField="RecordsQTY" headertext="Количество строк"/>
                            </Columns>
                        </asp:GridView>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" >
                 <asp:TableCell Width="100%" runat="server" HorizontalAlign="Right" BorderStyle="Groove" BorderWidth="1" BackColor="#E5E5E5">
                     <asp:Label ID="Label18" runat="server" Text="Показать страницу номер" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" ForeColor="#000099"></asp:Label> &nbsp
                     <asp:DropDownList ID="PagesList" runat="server" ForeColor="#000099" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small"
                         AutoPostBack="true" ></asp:DropDownList> &nbsp
                     <asp:Label ID="LabelQTYPages" runat="server" Text="из" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" ForeColor="#000099"></asp:Label> &nbsp &nbsp &nbsp
                     <asp:Label ID="Label22" runat="server" Text="Показывать по " Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" ForeColor="#000099"></asp:Label> &nbsp
                     <asp:DropDownList ID="QTYOnPageList" runat="server" ForeColor="#000099" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" 
                         AutoPostBack="true">
                         <asp:ListItem>20</asp:ListItem>
                         <asp:ListItem>25</asp:ListItem>
                      </asp:DropDownList> &nbsp
                     <asp:Label ID="Label23" runat="server" Text=" записей на странице" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" ForeColor="#000099"></asp:Label> &nbsp &nbsp &nbsp
                </asp:TableCell>
            </asp:TableRow>
                <asp:TableRow runat="server" Height="100%">
                    <asp:TableCell Width="100%" runat="server" HorizontalAlign="Right" BorderStyle="Groove" BorderWidth="1" BackColor="#E5E5E5" VerticalAlign="Bottom">
                        <asp:Button ID="ButtonCustomCancel" runat="server" Text="Отмена" Font-Names="Arial" Font-Size="8" />
                        <asp:Button ID="ButtonCustomSelect" runat="server" Text="Выбрать" Font-Names="Arial" Font-Size="8" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <div id="DivErrTxt" runat="server" disabled="true" visible="false" style="border: medium double #000080; height:350pt; width:50%; left:25%; top:25%; background-color:white; position:absolute; z-index:2">
            <asp:Table Width="100%" Height="100%" ID="Table3" runat="server"  BorderStyle="Double" BackColor="white">
                <asp:TableRow runat="server" >
                    <asp:TableCell Width="100%" Height="100%" runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                        <asp:TextBox ID="TextBoxErrTxt" runat="server" Width="98%" Height="320pt" Wrap="False" Font-Names="Courier New" Font-Size="8" ReadOnly="True" TextMode="MultiLine" style="resize:none;"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" BackColor="#CCCCCC">
                    <asp:TableCell Width="100%" runat="server" HorizontalAlign="Right">
                        <asp:Button ID="ButtonErrTxt" runat="server" Text="OK" Font-Names="Arial" Font-Size="8" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
         </div>
    </form>
</body>
</html>
