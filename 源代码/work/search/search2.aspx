<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search2.aspx.cs" Inherits="work_search_search2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:aConnectionString %>"
            SelectCommand="SELECT * FROM [历史最高纪录表]"></asp:SqlDataSource>
        &nbsp;
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            DataKeyNames="自动编号" DataSourceID="SqlDataSource1" Font-Size="Smaller" PageSize="20">
            <Columns>
                <asp:BoundField DataField="自动编号" HeaderText="自动编号" InsertVisible="False" ReadOnly="True"
                    SortExpression="自动编号" />
                <asp:BoundField DataField="项目编号" HeaderText="项目编号" SortExpression="项目编号" />
                <asp:BoundField DataField="平破级别" HeaderText="平破级别" SortExpression="平破级别" />
                <asp:BoundField DataField="成绩文本" HeaderText="成绩文本" SortExpression="成绩文本" />
                <asp:BoundField DataField="成绩" HeaderText="成绩" SortExpression="成绩" />
                <asp:BoundField DataField="姓名" HeaderText="姓名" SortExpression="姓名" />
                <asp:BoundField DataField="单位" HeaderText="单位" SortExpression="单位" />
                <asp:BoundField DataField="地点" HeaderText="地点" SortExpression="地点" />
                <asp:BoundField DataField="时间" HeaderText="时间" SortExpression="时间" />
                <asp:BoundField DataField="备注" HeaderText="备注" SortExpression="备注" />
                <asp:CheckBoxField DataField="最新纪录" HeaderText="最新纪录" SortExpression="最新纪录" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
