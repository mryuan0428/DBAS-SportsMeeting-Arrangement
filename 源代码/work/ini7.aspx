<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ini7.aspx.cs" Inherits="work_ini6" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:aConnectionString %>"
            DeleteCommand="DELETE FROM [运动会竞赛规程] WHERE [类型] = @类型" InsertCommand="INSERT INTO [运动会竞赛规程] ([类型], [名称], [参数值], [备注]) VALUES (@类型, @名称, @参数值, @备注)"
            SelectCommand="SELECT * FROM [运动会竞赛规程]" UpdateCommand="UPDATE [运动会竞赛规程] SET [名称] = @名称, [参数值] = @参数值, [备注] = @备注 WHERE [类型] = @类型">
            <DeleteParameters>
                <asp:Parameter Name="类型" Type="Int16" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="名称" Type="String" />
                <asp:Parameter Name="参数值" Type="Int16" />
                <asp:Parameter Name="备注" Type="String" />
                <asp:Parameter Name="类型" Type="Int16" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="类型" Type="Int16" />
                <asp:Parameter Name="名称" Type="String" />
                <asp:Parameter Name="参数值" Type="Int16" />
                <asp:Parameter Name="备注" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="类型"
            DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="类型" HeaderText="类型" ReadOnly="True" SortExpression="类型" />
                <asp:BoundField DataField="名称" HeaderText="名称" SortExpression="名称" />
                <asp:BoundField DataField="参数值" HeaderText="参数值" SortExpression="参数值" />
                <asp:BoundField DataField="备注" HeaderText="备注" SortExpression="备注" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="刷新设置" />
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:aConnectionString %>"
            DeleteCommand="DELETE FROM [运动员录取办法] WHERE [名次] = @名次" InsertCommand="INSERT INTO [运动员录取办法] ([名次], [得分]) VALUES (@名次, @得分)"
            SelectCommand="SELECT * FROM [运动员录取办法]" UpdateCommand="UPDATE [运动员录取办法] SET [得分] = @得分 WHERE [名次] = @名次">
            <DeleteParameters>
                <asp:Parameter Name="名次" Type="Int16" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="得分" Type="Int16" />
                <asp:Parameter Name="名次" Type="Int16" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="名次" Type="Int16" />
                <asp:Parameter Name="得分" Type="Int16" />
            </InsertParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="名次"
            DataSourceID="SqlDataSource2">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="名次" HeaderText="名次" ReadOnly="True" SortExpression="名次" />
                <asp:BoundField DataField="得分" HeaderText="得分" SortExpression="得分" />
            </Columns>
        </asp:GridView>
        &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;<br />
        &nbsp; &nbsp; &nbsp;<br />
        <asp:TextBox ID="guicheng"  runat="server" Height="261px" TextMode="MultiLine" Width="675px"></asp:TextBox><br />
        <asp:Button ID="Button2" runat="server" Text="更新" OnClick="Button2_Click" />
    </form>
</body>
</html>
