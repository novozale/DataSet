Imports System.Security.Cryptography
Public Class Login
    Inherits System.Web.UI.Page
    Public Shared IsError As Integer = 0
    Public Shared ErrDescr As String = ""


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// загрузка страницы, параметры
        '//
        '////////////////////////////////////////////////////////////////////////////////

    End Sub

    Private Sub ButtonLogin_Click(sender As Object, e As EventArgs) Handles ButtonLogin.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// проверка пароля и переход на страницу со списком КП
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Dim obj As New ServiceReference1.SWIServiceClient
        Dim MyParam As New ServiceReference1.SWIServiceCheckPassParameters
        Dim MyParam1 As New ServiceReference1.SWIServiceGetFullNameParameters
        Dim MyParam2 As New ServiceReference1.SWIServiceGetSalesmanCodeParameters
        Dim MyRetValue As String

        obj.ClientCredentials.UserName.UserName = "eskru\IISConn"
        obj.ClientCredentials.UserName.Password = "!bh$DR2T435"

        If Trim(Login1.Text) = "" Then
            '--------ошибка - не введен логин
            LabelErr.Text = "ошибка - необходимо ввести логин."
            DivErr.Disabled = False
            DivErr.Visible = True
            DivBG.Disabled = False
            DivBG.Visible = True
        ElseIf Trim(Password1.Value) = "" Then
            '--------ошибка - не введен пароль
            LabelErr.Text = "ошибка - необходимо ввести пароль."
            DivErr.Disabled = False
            DivErr.Visible = True
            DivBG.Disabled = False
            DivBG.Visible = True
        Else
            MyParam.MyLogin = Login1.Text
            MyParam.MyPass = GetHashStr(Password1.Value)
            MyRetValue = obj.CheckPass(MyParam)

            If Trim(MyRetValue) = "" Then
                MyParam1.MyLogin = Login1.Text
                MyRetValue = obj.GetFullName(MyParam1)
                If Trim(MyRetValue) <> "" Then
                    Session("AgentFullName") = Trim(MyRetValue)
                    MyParam2.MyFullName = Session("AgentFullName")
                    MyRetValue = obj.GetSalesmanCode(MyParam2)
                    If Trim(MyRetValue) <> "" Then
                        Session("SalesmanCode") = Trim(MyRetValue)
                        Response.Redirect("ProposalList.aspx", True)
                    Else
                        '--------ошибка - не получить код продавца для агента
                        LabelErr.Text = "ошибка - не получить код продавца агента. Обратитесь к администратору."
                        DivErr.Disabled = False
                        DivErr.Visible = True
                        DivBG.Disabled = False
                        DivBG.Visible = True
                    End If
                Else
                    '--------ошибка - не получить полное имя агента
                    LabelErr.Text = "ошибка - не получить полное имя агента. Обратитесь к администратору."
                    DivErr.Disabled = False
                    DivErr.Visible = True
                    DivBG.Disabled = False
                    DivBG.Visible = True
                End If
            Else
                '--------ошибка - неверные логин или пароль
                LabelErr.Text = MyRetValue
                DivErr.Disabled = False
                DivErr.Visible = True
                DivBG.Disabled = False
                DivBG.Visible = True
            End If
        End If
    End Sub

    Private Function GetHashStr(MyStr As String) As String
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Получение строки MD5 для строки - параметра
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Using md5Hash As MD5 = MD5.Create()


            Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(MyStr))
            Dim sBuilder As New StringBuilder()
            Dim i As Integer
            For i = 0 To data.Length - 1
                sBuilder.Append(data(i).ToString("x2"))
            Next i
            GetHashStr = sBuilder.ToString
        End Using
    End Function

    Private Sub ButtonErr_Click(sender As Object, e As EventArgs) Handles ButtonErr.Click
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// закрытие Div с сообщением об ошибке
        '//
        '////////////////////////////////////////////////////////////////////////////////

        LabelErr.Text = ""
        DivErr.Disabled = True
        DivErr.Visible = False
        DivBG.Disabled = True
        DivBG.Visible = False
    End Sub
End Class