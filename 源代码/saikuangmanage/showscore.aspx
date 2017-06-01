<%@ Page Language="C#" AutoEventWireup="true" CodeFile="showscore.aspx.cs" Inherits="saikuangmanage_scoremanage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <br />
            <table align="center" border="1" bordercolordark="#003399" bordercolorlight="#ffffff"
                cellspacing="0" class="css" style="width: 760px; height: 373px">
                <tr>
                    <td align="center" colspan="5" style="color: white; height: 49px; background-color: #003399">
                        比赛成绩查询</td>
                    <td align="center" colspan="1" style="color: white; height: 49px; background-color: #003399">
                    </td>
                </tr>
                <tr>
                    <td align="center" style="width: 105px; height: 34px">
                        赛程类型：</td>
                    <td colspan="2" style="height: 34px">
                        <asp:DropDownList ID="saichengleixing" runat="server" AutoPostBack="True" Width="118px">
                            <asp:ListItem>决赛</asp:ListItem>
                            <asp:ListItem>预赛</asp:ListItem>
                        </asp:DropDownList></td>
                    <td align="center" style="width: 110px; height: 34px">
                        性别：</td>
                    <td colspan="2" style="height: 34px">
                        &nbsp;<asp:DropDownList ID="sex" runat="server" Width="129px">
                            <asp:ListItem>男</asp:ListItem>
                            <asp:ListItem>女</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td align="center" style="width: 105px; height: 39px">
                        &nbsp;组别：</td>
                    <td colspan="2" style="height: 39px">
                        <asp:DropDownList ID="zubie" runat="server" Width="114px">
                        </asp:DropDownList></td>
                    <td align="center" style="width: 110px; height: 39px">
                        &nbsp;项目类别 ：</td>
                    <td colspan="2" style="height: 39px">
                        <asp:DropDownList ID="xiangmuleixing" runat="server" Width="129px">
                            <asp:ListItem>田赛</asp:ListItem>
                            <asp:ListItem>径赛</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td align="center" colspan="6" rowspan="1">
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="查询" /></td>
                </tr>
                <tr>
                    <td align="center" rowspan="1" style="width: 105px; height: 28px;">
                        项目：</td>
                    <td rowspan="1" style="width: 143px; height: 28px;">
                        <asp:DropDownList ID="xiangmu" runat="server" Width="112px">
                        </asp:DropDownList></td>
                    <td rowspan="1" style="width: 132px; height: 28px;">
                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="查询" /></td>
                    <td align="center" rowspan="1" style="width: 110px; height: 28px;">
                        组次：</td>
                    <td rowspan="1" style="width: 163px; height: 28px;">
                        <asp:DropDownList ID="zuci" runat="server" Width="127px">
                        </asp:DropDownList></td>
                    <td rowspan="1" style="width: 163px; height: 28px">
                        排名方式：<asp:Label ID="Label1" runat="server" Text="未知" Width="50px"></asp:Label></td>
                </tr>
                <tr>
                    <td align="center" colspan="6" rowspan="1">
                        <asp:Button ID="Button1" runat="server" Text="执行" OnClick="Button1_Click1" /></td>
                </tr>
                <tr>
                    <td align="center" colspan="6" rowspan="7">
                        <asp:GridView ID="GridView1" runat="server"  Width="533px">
                        </asp:GridView>
                        &nbsp;&nbsp;</td>
                </tr>
                <tr>
                </tr>
                <tr>
                </tr>
                <tr>
                </tr>
                <tr>
                </tr>
                <tr>
                </tr>
                <tr>
                </tr>
                <tr>
                </tr>
                <tr>
                    <td align="center" colspan="6" style="height: 22px">
                        </td>
                </tr>
            </table>
            <br />
        </div>
    
    </div>
    </form>
</body>
</html>
