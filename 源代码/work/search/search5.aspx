<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search5.aspx.cs" Inherits="work_search_search5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:aConnectionString %>"
            SelectCommand="SELECT * FROM [参赛队报名表]"></asp:SqlDataSource>
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="参赛队编号"
            DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="参赛队编号" HeaderText="参赛队编号" ReadOnly="True" SortExpression="参赛队编号" />
                <asp:BoundField DataField="参赛队名称" HeaderText="参赛队名称" SortExpression="参赛队名称" />
                <asp:BoundField DataField="参赛队简称" HeaderText="参赛队简称" SortExpression="参赛队简称" />
                <asp:BoundField DataField="运动员起始编号" HeaderText="运动员起始编号" SortExpression="运动员起始编号" />
                <asp:BoundField DataField="运动员截止编号" HeaderText="运动员截止编号" SortExpression="运动员截止编号" />
                <asp:BoundField DataField="领队" HeaderText="领队" SortExpression="领队" />
                <asp:BoundField DataField="教练员" HeaderText="教练员" SortExpression="教练员" />
                <asp:BoundField DataField="组别" HeaderText="组别" SortExpression="组别" />
                <asp:BoundField DataField="男子数" HeaderText="男子数" SortExpression="男子数" />
                <asp:BoundField DataField="女子数" HeaderText="女子数" SortExpression="女子数" />
                <asp:BoundField DataField="运动员总数" HeaderText="运动员总数" SortExpression="运动员总数" />
                <asp:BoundField DataField="工作人员" HeaderText="工作人员" SortExpression="工作人员" />
                <asp:BoundField DataField="队医" HeaderText="队医" SortExpression="队医" />
                <asp:BoundField DataField="备注" HeaderText="备注" SortExpression="备注" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
