<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search4.aspx.cs" Inherits="ini4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;</div>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:aConnectionString %>"
            SelectCommand="SELECT [参赛项目表].*,[项目编码表].男女子项目 FROM [参赛项目表],[项目编码表] where [参赛项目表].项目编号=[项目编码表].项目编号">
        </asp:SqlDataSource>

        &nbsp;
        &nbsp;&nbsp; &nbsp;<table style="background-color: gainsboro ; vertical-align: top; text-align: center;" align="center">
        <tr>
            <td style="height: 21px; background-color: silver;"></td>
            <td style="width: 292px; height: 21px; font-size: small;" valign="top">
                参赛项目表</td>
        </tr>
            <tr>
                <td style="height: 365px; background-color: silver;"></td>
                <td style="width: 292px; height: 365px" valign="top">
                    &nbsp;<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="项目编号"
                        DataSourceID="SqlDataSource2" AllowPaging="True" PageSize="20" Width="352px" Font-Size="Smaller">
                        <Columns>
                            <asp:BoundField DataField="项目编号" HeaderText="项目编号" ReadOnly="True" SortExpression="项目编号" />
                            <asp:BoundField DataField="项目名称" HeaderText="项目名称" SortExpression="项目名称" />
                            <asp:BoundField DataField="道数" HeaderText="道数" SortExpression="道数" />
                            <asp:CheckBoxField DataField="单一赛否" HeaderText="单一赛否" SortExpression="单一赛否" />
                            <asp:BoundField DataField="记录方式" HeaderText="记录方式" SortExpression="记录方式" />
                            <asp:BoundField DataField="备注" HeaderText="备注" SortExpression="备注" />
                            <asp:BoundField DataField="男女子项目" HeaderText="男女子项目" SortExpression="男女子项目" />
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
