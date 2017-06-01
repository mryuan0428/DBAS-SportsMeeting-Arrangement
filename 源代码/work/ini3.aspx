<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="ini3.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:aConnectionString %>"
            DeleteCommand="DELETE FROM [参赛队报名表] WHERE [参赛队编号] = @参赛队编号" InsertCommand="INSERT INTO [参赛队报名表] ([参赛队编号], [参赛队名称], [参赛队简称], [运动员起始编号], [运动员截止编号], [领队], [教练员], [组别], [男子数], [女子数], [运动员总数], [工作人员], [队医], [备注]) VALUES (@参赛队编号, @参赛队名称, @参赛队简称, @运动员起始编号, @运动员截止编号, @领队, @教练员, @组别, @男子数, @女子数, @运动员总数, @工作人员, @队医, @备注)"
            SelectCommand="SELECT * FROM [参赛队报名表]" UpdateCommand="UPDATE [参赛队报名表] SET [参赛队名称] = @参赛队名称, [参赛队简称] = @参赛队简称, [运动员起始编号] = @运动员起始编号, [运动员截止编号] = @运动员截止编号, [领队] = @领队, [教练员] = @教练员, [组别] = @组别, [男子数] = @男子数, [女子数] = @女子数, [运动员总数] = @运动员总数, [工作人员] = @工作人员, [队医] = @队医, [备注] = @备注 WHERE [参赛队编号] = @参赛队编号">
            <DeleteParameters>
                <asp:Parameter Name="参赛队编号" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="参赛队名称" Type="String" />
                <asp:Parameter Name="参赛队简称" Type="String" />
                <asp:Parameter Name="运动员起始编号" Type="String" />
                <asp:Parameter Name="运动员截止编号" Type="String" />
                <asp:Parameter Name="领队" Type="String" />
                <asp:Parameter Name="教练员" Type="String" />
                <asp:Parameter Name="组别" Type="String" />
                <asp:Parameter Name="男子数" Type="Int16" />
                <asp:Parameter Name="女子数" Type="Int16" />
                <asp:Parameter Name="运动员总数" Type="Int16" />
                <asp:Parameter Name="工作人员" Type="String" />
                <asp:Parameter Name="队医" Type="String" />
                <asp:Parameter Name="备注" Type="String" />
                <asp:Parameter Name="参赛队编号" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="参赛队编号" Type="String" />
                <asp:Parameter Name="参赛队名称" Type="String" />
                <asp:Parameter Name="参赛队简称" Type="String" />
                <asp:Parameter Name="运动员起始编号" Type="String" />
                <asp:Parameter Name="运动员截止编号" Type="String" />
                <asp:Parameter Name="领队" Type="String" />
                <asp:Parameter Name="教练员" Type="String" />
                <asp:Parameter Name="组别" Type="String" />
                <asp:Parameter Name="男子数" Type="Int16" />
                <asp:Parameter Name="女子数" Type="Int16" />
                <asp:Parameter Name="运动员总数" Type="Int16" />
                <asp:Parameter Name="工作人员" Type="String" />
                <asp:Parameter Name="队医" Type="String" />
                <asp:Parameter Name="备注" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
        &nbsp;
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False"
            DataSourceID="SqlDataSource1" Height="50px" Width="381px" Font-Size="Smaller">
            <Fields>
                <asp:BoundField DataField="参赛队编号" HeaderText="参赛队编号" SortExpression="参赛队编号" />
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
                <asp:CommandField ShowInsertButton="True" />
            </Fields>
            <EmptyDataTemplate>
                数据为空！！！
            </EmptyDataTemplate>
        </asp:DetailsView>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            DataKeyNames="参赛队编号" DataSourceID="SqlDataSource1" Font-Size="Smaller" PageSize="20">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
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
            <EmptyDataTemplate>
                数据为空！！！
            </EmptyDataTemplate>
        </asp:GridView>
        &nbsp;</div>
    </form>
</body>
</html>
