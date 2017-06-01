<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search9.aspx.cs" Inherits="work_search_search9" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="print" Text="打印" />
                <asp:BoundField DataField="日程号" HeaderText="日程号" ReadOnly="True" SortExpression="日程号" />
                <asp:BoundField DataField="项目名称" HeaderText="项目名称" SortExpression="项目名称" />
                <asp:BoundField DataField="组别" HeaderText="组别" SortExpression="组别" />
                <asp:CheckBoxField DataField="男女子项目" HeaderText="男女子项目" SortExpression="男女子项目" />
                <asp:BoundField DataField="组数" HeaderText="组数" SortExpression="组数" />
                <asp:ButtonField ButtonType="Button" CommandName="toword" Text="输出" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:aConnectionString %>"
            SelectCommand="SELECT [竞赛日程表].[日程号],[参赛项目表].[项目名称], [竞赛日程表].[组别],[参赛项目表].[男女子项目] , [竞赛日程表].[组数] FROM [参赛项目表],[竞赛日程表] where [参赛项目表].[项目编号]=[竞赛日程表].[项目编号]"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
