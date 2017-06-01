<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ini4.aspx.cs" Inherits="ini4" %>

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
    
    </div>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:aConnectionString %>"
            DeleteCommand="DELETE FROM [参赛项目表] WHERE [项目编号] = @项目编号" InsertCommand="INSERT INTO [参赛项目表] ([项目编号], [项目名称], [道数], [单一赛否], [记录方式], [备注], [男女子项目]) VALUES (@项目编号, @项目名称, @道数, @单一赛否, @记录方式, @备注, @男女子项目)"
            SelectCommand="SELECT * FROM [参赛项目表]" UpdateCommand="UPDATE [参赛项目表] SET [项目名称] = @项目名称, [道数] = @道数, [单一赛否] = @单一赛否, [记录方式] = @记录方式, [备注] = @备注, [男女子项目] = @男女子项目 WHERE [项目编号] = @项目编号">
            <DeleteParameters>
                <asp:Parameter Name="项目编号" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="项目名称" Type="String" />
                <asp:Parameter Name="道数" Type="Int16" />
                <asp:Parameter Name="单一赛否" Type="Boolean" />
                <asp:Parameter Name="记录方式" Type="Boolean" />
                <asp:Parameter Name="备注" Type="String" />
                <asp:Parameter Name="男女子项目" Type="Boolean" />
                <asp:Parameter Name="项目编号" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="项目编号" Type="String" />
                <asp:Parameter Name="项目名称" Type="String" />
                <asp:Parameter Name="道数" Type="Int16" />
                <asp:Parameter Name="单一赛否" Type="Boolean" />
                <asp:Parameter Name="记录方式" Type="Boolean" />
                <asp:Parameter Name="备注" Type="String" />
                <asp:Parameter Name="男女子项目" Type="Boolean" />
            </InsertParameters>
        </asp:SqlDataSource>

        &nbsp;
        &nbsp;&nbsp; &nbsp;<table style="background-color: gainsboro ; vertical-align: top; text-align: center;" align="center">
        <tr>
            <td style="width: 368px; height: 21px; font-size: small;" valign="top" align="center">可选项目</td>
            <td style="height: 21px; background-color: silver;"></td>
            <td style="width: 292px; height: 21px; font-size: small;" valign="top">已选项目</td>
        </tr>
            <tr>
                <td style="width: 368px; height: 365px" valign="top" >
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" OnRowCommand="GridView1_RowCommand"
            OnRowDataBound="GridView1_RowDataBound" Width="410px" AllowPaging="True" PageSize="20" Font-Size="Smaller" DataKeyNames="项目编号">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="add" Text="添" />
                <asp:BoundField DataField="项目编号" HeaderText="项目编号" ReadOnly="True" SortExpression="项目编号" />
                <asp:BoundField DataField="项目名称" HeaderText="项目名称" SortExpression="项目名称" />
                <asp:CheckBoxField DataField="项目类别" HeaderText="项目类别" SortExpression="项目类别" />
                <asp:CheckBoxField DataField="男女子项目" HeaderText="男女子项目" SortExpression="男女子项目" />
                <asp:CheckBoxField DataField="排名方式" HeaderText="排名方式" SortExpression="排名方式" />
                <asp:BoundField DataField="历史纪录" HeaderText="历史纪录" SortExpression="历史纪录" />
                <asp:BoundField DataField="道数" HeaderText="道数" SortExpression="道数" />
                <asp:CheckBoxField DataField="单一赛否" HeaderText="单一赛否" SortExpression="单一赛否" />
                <asp:CheckBoxField DataField="记录方式" HeaderText="记录方式" SortExpression="记录方式" />
                <asp:BoundField DataField="备注" HeaderText="备注" SortExpression="备注" />
            </Columns>
        </asp:GridView>
                </td>
                <td style="height: 365px; background-color: silver;"></td>
                <td style="width: 292px; height: 365px" valign="top">
                    &nbsp;<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
                        DataSourceID="SqlDataSource2" AllowPaging="True" PageSize="20" Width="352px" Font-Size="Smaller" DataKeyNames="项目编号">
                        <Columns>
                            <asp:CommandField ButtonType="Button" DeleteText="删" ShowDeleteButton="True" EditText="改" ShowEditButton="True" />
                            <asp:BoundField DataField="项目编号" HeaderText="项目编号" ReadOnly="True" SortExpression="项目编号" />
                            <asp:BoundField DataField="项目名称" HeaderText="项目名称" SortExpression="项目名称" />
                            <asp:BoundField DataField="道数" HeaderText="道数" SortExpression="道数" />
                            <asp:CheckBoxField DataField="单一赛否" HeaderText="单一赛否" SortExpression="单一赛否" />
                            <asp:CheckBoxField DataField="记录方式" HeaderText="记录方式" SortExpression="记录方式" />
                            <asp:BoundField DataField="备注" HeaderText="备注" SortExpression="备注" />
                            <asp:CheckBoxField DataField="男女子项目" HeaderText="男女子项目" SortExpression="男女子项目" />
                        </Columns>
                    </asp:GridView>
                </td>
                        </tr>
             </table>
        <br />
        &nbsp;
    </form>
</body>
</html>
