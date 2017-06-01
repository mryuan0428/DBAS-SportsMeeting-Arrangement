<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manage1.aspx.cs" Inherits="work_bianpaimanage_manage1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:aConnectionString %>"
            DeleteCommand="DELETE FROM [竞赛日程表] WHERE [日程号] = @日程号" InsertCommand="INSERT INTO [竞赛日程表] ([日程号], [项目编号], [赛程类型], [组别], [参赛人数], [组数], [比赛日期], [检录时间], [比赛时间], [赛次]) VALUES (@日程号, @项目编号, @赛程类型, @组别, @参赛人数, @组数, @比赛日期, @检录时间, @比赛时间, @赛次)"
            SelectCommand="SELECT * FROM [竞赛日程表]" UpdateCommand="UPDATE [竞赛日程表] SET [项目编号] = @项目编号, [赛程类型] = @赛程类型, [组别] = @组别, [参赛人数] = @参赛人数, [组数] = @组数, [比赛日期] = @比赛日期, [检录时间] = @检录时间, [比赛时间] = @比赛时间, [赛次] = @赛次 WHERE [日程号] = @日程号">
            <DeleteParameters>
                <asp:Parameter Name="日程号" Type="Int16" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="项目编号" Type="String" />
                <asp:Parameter Name="赛程类型" Type="String" />
                <asp:Parameter Name="组别" Type="String" />
                <asp:Parameter Name="参赛人数" Type="Int16" />
                <asp:Parameter Name="组数" Type="Int16" />
                <asp:Parameter Name="比赛日期" Type="String" />
                <asp:Parameter Name="检录时间" Type="String" />
                <asp:Parameter Name="比赛时间" Type="String" />
                <asp:Parameter Name="赛次" Type="Int16" />
                <asp:Parameter Name="日程号" Type="Int16" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="日程号" Type="Int16" />
                <asp:Parameter Name="项目编号" Type="String" />
                <asp:Parameter Name="赛程类型" Type="String" />
                <asp:Parameter Name="组别" Type="String" />
                <asp:Parameter Name="参赛人数" Type="Int16" />
                <asp:Parameter Name="组数" Type="Int16" />
                <asp:Parameter Name="比赛日期" Type="String" />
                <asp:Parameter Name="检录时间" Type="String" />
                <asp:Parameter Name="比赛时间" Type="String" />
                <asp:Parameter Name="赛次" Type="Int16" />
            </InsertParameters>
        </asp:SqlDataSource>
        &nbsp;</div>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="日程号"
            DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="日程号" HeaderText="日程号" ReadOnly="True" SortExpression="日程号" >
                    <HeaderStyle Font-Size="Smaller" />
                </asp:BoundField>
                <asp:BoundField DataField="项目编号" HeaderText="项目编号" SortExpression="项目编号" />
                <asp:BoundField DataField="赛程类型" HeaderText="赛程类型" SortExpression="赛程类型" />
                <asp:BoundField DataField="组别" HeaderText="组别" SortExpression="组别" />
                <asp:BoundField DataField="参赛人数" HeaderText="参赛人数" SortExpression="参赛人数" />
                <asp:BoundField DataField="组数" HeaderText="组数" SortExpression="组数" />
                <asp:BoundField DataField="比赛日期" DataFormatString="{0:yy-MM-dd}" HeaderText="比赛日期"
                    SortExpression="比赛日期" HtmlEncode="False" />
                <asp:BoundField DataField="检录时间" HeaderText="检录时间" SortExpression="检录时间" DataFormatString="{0:HH:mm:ss}" HtmlEncode="False" />
                <asp:BoundField DataField="比赛时间" HeaderText="比赛时间" SortExpression="比赛时间" DataFormatString="{0:HH:mm:ss}" HtmlEncode="False" />
                <asp:BoundField DataField="赛次" HeaderText="赛次" SortExpression="赛次" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="再次初始生成" />
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="打印分组日程表" /><br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="日程号"
            DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="日程号" HeaderText="日程号" ReadOnly="True" SortExpression="日程号" />
                <asp:BoundField DataField="项目编号" HeaderText="项目编号" SortExpression="项目编号" />
                <asp:BoundField DataField="赛程类型" HeaderText="赛程类型" SortExpression="赛程类型" />
                <asp:BoundField DataField="组别" HeaderText="组别" SortExpression="组别" />
                <asp:BoundField DataField="参赛人数" HeaderText="参赛人数" SortExpression="参赛人数" />
                <asp:BoundField DataField="组数" HeaderText="组数" SortExpression="组数" />
                <asp:BoundField DataField="比赛日期" HeaderText="比赛日期" SortExpression="比赛日期" />
                <asp:BoundField DataField="检录时间" HeaderText="检录时间" SortExpression="检录时间" />
                <asp:BoundField DataField="比赛时间" HeaderText="比赛时间" SortExpression="比赛时间" />
                <asp:BoundField DataField="赛次" HeaderText="赛次" SortExpression="赛次" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="Button2" runat="server" Height="33px" OnClick="Button2_Click" Text="开始分组"
            Width="115px" /><br />
        <br />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="写进详细分组表" /><br />
    </form>
</body>
</html>
