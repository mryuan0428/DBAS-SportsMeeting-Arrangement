<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search0.aspx.cs" Inherits="work_search_search0" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>运动员号码</asp:ListItem>
            <asp:ListItem>姓名</asp:ListItem>
            <asp:ListItem>参赛队</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        &nbsp;&nbsp;
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="显示" />
        <table style="width: 517px; height: 86px">
            <tr>
                <td colspan="2" rowspan="3" style="width: 52553032px">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="20" OnSelectedIndexChanging="GridView1_SelectedIndexChanging"  Height="698px" Width="447px" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <SelectedRowStyle BackColor="Red" />
        </asp:GridView>
                </td>
                <td style="width: 468px; height: 83px;">
                    <asp:Label ID="Label3" runat="server" Text="未选" Width="108px"></asp:Label><br />
                    <asp:Label ID="Label1" runat="server" Text="项目名称：" Width="111px"></asp:Label><br />
                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"
                        OnTextChanged="DropDownList2_TextChanged" Width="146px">
                    </asp:DropDownList><br />
                    <asp:Label ID="Label2" runat="server" Text="参赛成绩文本："></asp:Label><br />
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 468px; height: 180px;">
                </td>
            </tr>
            <tr>
                <td style="width: 468px; height: 103px">
                </td>
            </tr>
        </table>
        <br />
        &nbsp;
        &nbsp;&nbsp;
    
    </div>
    </form>
</body>
</html>
