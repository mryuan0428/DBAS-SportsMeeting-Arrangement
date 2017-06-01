<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search3.aspx.cs" Inherits="work_search_search3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:aConnectionString %>"
            SelectCommand="SELECT * FROM [运动员等级标准表]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            DataKeyNames="项目编号" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="项目编号" HeaderText="项目编号" ReadOnly="True" SortExpression="项目编号" />
                <asp:BoundField DataField="记录方式" HeaderText="记录方式" SortExpression="记录方式" />
                <asp:BoundField DataField="运动健将文本" HeaderText="运动健将文本" SortExpression="运动健将文本" />
                <asp:BoundField DataField="运动健将成绩" HeaderText="运动健将成绩" SortExpression="运动健将成绩" />
                <asp:BoundField DataField="一级文本" HeaderText="一级文本" SortExpression="一级文本" />
                <asp:BoundField DataField="一级成绩" HeaderText="一级成绩" SortExpression="一级成绩" />
                <asp:BoundField DataField="二级文本" HeaderText="二级文本" SortExpression="二级文本" />
                <asp:BoundField DataField="二级成绩" HeaderText="二级成绩" SortExpression="二级成绩" />
                <asp:BoundField DataField="三级文本" HeaderText="三级文本" SortExpression="三级文本" />
                <asp:BoundField DataField="三级成绩" HeaderText="三级成绩" SortExpression="三级成绩" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
