<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ini10.aspx.cs" Inherits="work_ini10" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:aConnectionString %>"
            DeleteCommand="DELETE FROM [运动员等级标准表] WHERE [项目编号] = @项目编号" InsertCommand="INSERT INTO [运动员等级标准表] ([项目编号], [记录方式], [运动健将文本], [运动健将成绩], [一级文本], [一级成绩], [二级文本], [二级成绩], [三级文本], [三级成绩]) VALUES (@项目编号, @记录方式, @运动健将文本, @运动健将成绩, @一级文本, @一级成绩, @二级文本, @二级成绩, @三级文本, @三级成绩)"
            SelectCommand="SELECT * FROM [运动员等级标准表]" UpdateCommand="UPDATE [运动员等级标准表] SET [记录方式] = @记录方式, [运动健将文本] = @运动健将文本, [运动健将成绩] = @运动健将成绩, [一级文本] = @一级文本, [一级成绩] = @一级成绩, [二级文本] = @二级文本, [二级成绩] = @二级成绩, [三级文本] = @三级文本, [三级成绩] = @三级成绩 WHERE [项目编号] = @项目编号">
            <DeleteParameters>
                <asp:Parameter Name="项目编号" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="记录方式" Type="String" />
                <asp:Parameter Name="运动健将文本" Type="String" />
                <asp:Parameter Name="运动健将成绩" Type="Single" />
                <asp:Parameter Name="一级文本" Type="String" />
                <asp:Parameter Name="一级成绩" Type="Single" />
                <asp:Parameter Name="二级文本" Type="String" />
                <asp:Parameter Name="二级成绩" Type="Single" />
                <asp:Parameter Name="三级文本" Type="String" />
                <asp:Parameter Name="三级成绩" Type="Single" />
                <asp:Parameter Name="项目编号" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="项目编号" Type="String" />
                <asp:Parameter Name="记录方式" Type="String" />
                <asp:Parameter Name="运动健将文本" Type="String" />
                <asp:Parameter Name="运动健将成绩" Type="Single" />
                <asp:Parameter Name="一级文本" Type="String" />
                <asp:Parameter Name="一级成绩" Type="Single" />
                <asp:Parameter Name="二级文本" Type="String" />
                <asp:Parameter Name="二级成绩" Type="Single" />
                <asp:Parameter Name="三级文本" Type="String" />
                <asp:Parameter Name="三级成绩" Type="Single" />
            </InsertParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            DataKeyNames="项目编号" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
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
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="项目编号"
            DataSourceID="SqlDataSource1" Height="50px" Width="203px">
            <Fields>
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
                <asp:CommandField ShowInsertButton="True" />
            </Fields>
        </asp:DetailsView>
    </form>
</body>
</html>
