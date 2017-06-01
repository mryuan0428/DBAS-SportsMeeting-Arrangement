<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search1.aspx.cs" Inherits="work_search_search1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:aConnectionString %>"
            SelectCommand="SELECT * FROM [运动会竞赛规程]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="类型"
            DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="类型" HeaderText="类型" ReadOnly="True" SortExpression="类型" />
                <asp:BoundField DataField="名称" HeaderText="名称" SortExpression="名称" />
                <asp:BoundField DataField="参数值" HeaderText="参数值" SortExpression="参数值" />
                <asp:BoundField DataField="备注" HeaderText="备注" SortExpression="备注" />
            </Columns>
        </asp:GridView>
        &nbsp;<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:aConnectionString %>"
            SelectCommand="SELECT * FROM [运动员录取办法]"></asp:SqlDataSource>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="名次"
            DataSourceID="SqlDataSource2">
            <Columns>
                <asp:BoundField DataField="名次" HeaderText="名次" ReadOnly="True" SortExpression="名次" />
                <asp:BoundField DataField="得分" HeaderText="得分" SortExpression="得分" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
