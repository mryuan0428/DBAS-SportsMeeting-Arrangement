<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ini5.aspx.cs" Inherits="ini5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:aConnectionString %>"
            DeleteCommand="DELETE FROM [项目编码表] WHERE [项目编号] = @项目编号" InsertCommand="INSERT INTO [项目编码表] ([项目编号], [项目名称], [项目类别], [男女子项目], [排名方式], [历史纪录], [道数], [单一赛否], [记录方式], [备注]) VALUES (@项目编号, @项目名称, @项目类别, @男女子项目, @排名方式, @历史纪录, @道数, @单一赛否, @记录方式, @备注)"
            SelectCommand="SELECT * FROM [项目编码表]" UpdateCommand="UPDATE [项目编码表] SET [项目名称] = @项目名称, [项目类别] = @项目类别, [男女子项目] = @男女子项目, [排名方式] = @排名方式, [历史纪录] = @历史纪录, [道数] = @道数, [单一赛否] = @单一赛否, [记录方式] = @记录方式, [备注] = @备注 WHERE [项目编号] = @项目编号">
            <DeleteParameters>
                <asp:Parameter Name="项目编号" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="项目名称" Type="String" />
                <asp:Parameter Name="项目类别" Type="Boolean" />
                <asp:Parameter Name="男女子项目" Type="Boolean" />
                <asp:Parameter Name="排名方式" Type="Boolean" />
                <asp:Parameter Name="历史纪录" Type="String" />
                <asp:Parameter Name="道数" Type="Int16" />
                <asp:Parameter Name="单一赛否" Type="Boolean" />
                <asp:Parameter Name="记录方式" Type="Boolean" />
                <asp:Parameter Name="备注" Type="String" />
                <asp:Parameter Name="项目编号" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="项目编号" Type="String" />
                <asp:Parameter Name="项目名称" Type="String" />
                <asp:Parameter Name="项目类别" Type="Boolean" />
                <asp:Parameter Name="男女子项目" Type="Boolean" />
                <asp:Parameter Name="排名方式" Type="Boolean" />
                <asp:Parameter Name="历史纪录" Type="String" />
                <asp:Parameter Name="道数" Type="Int16" />
                <asp:Parameter Name="单一赛否" Type="Boolean" />
                <asp:Parameter Name="记录方式" Type="Boolean" />
                <asp:Parameter Name="备注" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
        &nbsp; &nbsp;&nbsp;<table style="width: 407px; font-size: small;">
            <tr>
                <td align="center" colspan="2">
                    添加新项目</td>
            </tr>
            <tr>
                <td style="width: 106px">
                    项目编号</td>
                <td style="width: 35px">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 106px; height: 26px">
                    项目名称</td>
                <td style="width: 35px; height: 26px">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
            </tr>
             <tr>
                <td style="width: 106px; height: 26px">
                    项目类别</td>
                <td style="width: 35px; height: 26px">
                    &nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>田赛</asp:ListItem>
                        <asp:ListItem>径赛</asp:ListItem>
                        <asp:ListItem>全能</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 106px; height: 26px">
                    男女子</td>
                <td style="width: 35px; height: 26px">
                    &nbsp;<asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem>男子</asp:ListItem>
                        <asp:ListItem>女子</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
             <tr>
                <td style="width: 106px; height: 26px">
                    记录方式</td>
                <td style="width: 35px; height: 26px">
                    &nbsp;<asp:DropDownList ID="DropDownList3" runat="server">
                        <asp:ListItem>手动</asp:ListItem>
                        <asp:ListItem>仪器</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
             <tr>
                <td style="width: 106px; height: 37px">
                    备注
                </td>
                <td style="width: 35px; height: 37px">
                    &nbsp;<asp:TextBox ID="TextBox3" runat="server" Height="69px" TextMode="MultiLine"
                        Width="257px"></asp:TextBox></td>
            </tr>
             <tr>
                <td style="width: 106px; height: 26px">
                    成绩最小为冠军</td>
                <td style="width: 35px; height: 26px">
                    &nbsp;<asp:CheckBox ID="CheckBox1" runat="server" /></td>
            </tr>
             <tr>
                 <td colspan="2" style="height: 26px">
                     &nbsp;
                     <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添加" /></td>
            </tr>
        </table>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            DataKeyNames="项目编号" DataSourceID="SqlDataSource1" Font-Size="Smaller" PageSize="20">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="项目编号" HeaderText="项目编号" ReadOnly="True" SortExpression="项目编号" />
                <asp:BoundField DataField="项目名称" HeaderText="项目名称" SortExpression="项目名称" />
                <asp:CheckBoxField DataField="项目类别" HeaderText="项目类别（径赛选定）" SortExpression="项目类别" />
                <asp:CheckBoxField DataField="男女子项目" HeaderText="男女（男选定）" SortExpression="男女子项目" />
                <asp:CheckBoxField DataField="排名方式" HeaderText="排名方式" SortExpression="排名方式" />
                <asp:BoundField DataField="历史纪录" HeaderText="历史纪录" SortExpression="历史纪录" />
                <asp:BoundField DataField="道数" HeaderText="道数" SortExpression="道数" />
                <asp:CheckBoxField DataField="单一赛否" HeaderText="单一赛否（单赛选定）" SortExpression="单一赛否" />
                <asp:CheckBoxField DataField="记录方式" HeaderText="记录方式（手动选定）" SortExpression="记录方式" />
                <asp:BoundField DataField="备注" HeaderText="备注" SortExpression="备注" />
            </Columns>
        </asp:GridView>
    </form>
        <br />
   
</body>
</html>
