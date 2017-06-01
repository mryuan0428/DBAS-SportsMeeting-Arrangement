<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_add.aspx.cs" Inherits="System_user_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="height: 244px" width="600" border=1>
            <tr>
                <td style="height: 27px">
                </td>
                <td style="font-size: 19px; height: 27px" align=center>
                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Larger" Height="23px"
                        Style="font-size: 19px; color: #ffcc66; font-family: 隶书; text-decoration: underline"
                        Text="添加用户" Width="204px"></asp:Label>&nbsp;</td>
                <td style="height: 27px; width: 5px;">
                </td>
            </tr>
            <tr>
                <td align="center">
                </td>
                <td align="center">
                    <asp:Panel ID="Panel1" runat="server" Height="50px" Style="text-align: left" Width="350px"
                        Wrap="False">
                        <asp:Label ID="Label1" runat="server" Text="用 户 名：" Width="82px"></asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server" CausesValidation="True"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                            ErrorMessage="用户名不能为空"></asp:RequiredFieldValidator><br />
                        &nbsp;&nbsp;
                        <br />
                        <asp:Label ID="Label6" runat="server" Text="密     码：" Width="82px"></asp:Label>
                        <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" Width="149px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3"
                            ErrorMessage="密码不能为空"></asp:RequiredFieldValidator><br />
                        &nbsp;<br />
                        <asp:RadioButtonList ID="RBL1" runat="server" EnableTheming="True" OnSelectedIndexChanged="RBL1_SelectedIndexChanged"
                            RepeatDirection="Horizontal" Width="222px">
                            <asp:ListItem Value="0" Selected="True">用户</asp:ListItem>
                            <asp:ListItem Value="1">管理员</asp:ListItem>
                        </asp:RadioButtonList>
                        &nbsp;&nbsp;
                    </asp:Panel>
                </td>
                <td style="width: 5px">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align=center>
                    &nbsp;<asp:Button ID="Button1" runat="server" CssClass="blueButtonCss" OnClick="Button1_Click"
                        Text="确认保存" />
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:Button ID="Button3" runat="server" CausesValidation="False"
                        CssClass="blueButtonCss" OnClick="Button3_Click" Text="重新填写" />
                    &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False"
                        CssClass="blueButtonCss" OnClick="Button2_Click" Text="返回" />
                </td>
                <td style="width: 5px">
                </td>
            </tr>
        </table>
        <br />
    
    </div>
    </form>
</body>
</html>
