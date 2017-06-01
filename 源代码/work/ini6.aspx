<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="ini6.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:aConnectionString %>"
            DeleteCommand="DELETE FROM [历史最高纪录表] WHERE [自动编号] = @自动编号" InsertCommand="INSERT INTO [历史最高纪录表] ([项目编号], [平破级别], [成绩文本], [成绩], [姓名], [单位], [地点], [时间], [备注], [最新纪录]) VALUES (@项目编号, @平破级别, @成绩文本, @成绩, @姓名, @单位, @地点, @时间, @备注, @最新纪录)"
            SelectCommand="SELECT * FROM [历史最高纪录表]" UpdateCommand="UPDATE [历史最高纪录表] SET [项目编号] = @项目编号, [平破级别] = @平破级别, [成绩文本] = @成绩文本, [成绩] = @成绩, [姓名] = @姓名, [单位] = @单位, [地点] = @地点, [时间] = @时间, [备注] = @备注, [最新纪录] = @最新纪录 WHERE [自动编号] = @自动编号">
            <DeleteParameters>
                <asp:Parameter Name="自动编号" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="项目编号" Type="String" />
                <asp:Parameter Name="平破级别" Type="String" />
                <asp:Parameter Name="成绩文本" Type="String" />
                <asp:Parameter Name="成绩" Type="Single" />
                <asp:Parameter Name="姓名" Type="String" />
                <asp:Parameter Name="单位" Type="String" />
                <asp:Parameter Name="地点" Type="String" />
                <asp:Parameter Name="时间" Type="String" />
                <asp:Parameter Name="备注" Type="String" />
                <asp:Parameter Name="最新纪录" Type="Boolean" />
                <asp:Parameter Name="自动编号" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="项目编号" Type="String" />
                <asp:Parameter Name="平破级别" Type="String" />
                <asp:Parameter Name="成绩文本" Type="String" />
                <asp:Parameter Name="成绩" Type="Single" />
                <asp:Parameter Name="姓名" Type="String" />
                <asp:Parameter Name="单位" Type="String" />
                <asp:Parameter Name="地点" Type="String" />
                <asp:Parameter Name="时间" Type="String" />
                <asp:Parameter Name="备注" Type="String" />
                <asp:Parameter Name="最新纪录" Type="Boolean" />
            </InsertParameters>
        </asp:SqlDataSource>
        &nbsp;
    
    </div>
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
        &nbsp;
    </form>
</body>
</html>
