<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="ini1.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:aConnectionString %>"
            DeleteCommand="DELETE FROM [运动会基本信息表] WHERE [MeetingID] = @MeetingID" InsertCommand="INSERT INTO [运动会基本信息表] ([MeetingID], [运动会名称], [主办单位], [承办单位], [比赛地点], [参赛队数], [总裁判长], [副总裁判长], [运动会开始日期], [运动会结束日期]) VALUES (@MeetingID, @运动会名称, @主办单位, @承办单位, @比赛地点, @参赛队数, @总裁判长, @副总裁判长, @运动会开始日期, @运动会结束日期)"
            SelectCommand="SELECT * FROM [运动会基本信息表]" UpdateCommand="UPDATE [运动会基本信息表] SET [运动会名称] = @运动会名称, [主办单位] = @主办单位, [承办单位] = @承办单位, [比赛地点] = @比赛地点, [参赛队数] = @参赛队数, [总裁判长] = @总裁判长, [副总裁判长] = @副总裁判长, [运动会开始日期] = @运动会开始日期, [运动会结束日期] = @运动会结束日期 WHERE [MeetingID] = @MeetingID">
            <DeleteParameters>
                <asp:Parameter Name="MeetingID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="运动会名称" Type="String" />
                <asp:Parameter Name="主办单位" Type="String" />
                <asp:Parameter Name="承办单位" Type="String" />
                <asp:Parameter Name="比赛地点" Type="String" />
                <asp:Parameter Name="参赛队数" Type="Int16" />
                <asp:Parameter Name="总裁判长" Type="String" />
                <asp:Parameter Name="副总裁判长" Type="String" />
                <asp:Parameter Name="运动会开始日期" Type="DateTime" />
                <asp:Parameter Name="运动会结束日期" Type="DateTime" />
                <asp:Parameter Name="MeetingID" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="MeetingID" Type="Int32" />
                <asp:Parameter Name="运动会名称" Type="String" />
                <asp:Parameter Name="主办单位" Type="String" />
                <asp:Parameter Name="承办单位" Type="String" />
                <asp:Parameter Name="比赛地点" Type="String" />
                <asp:Parameter Name="参赛队数" Type="Int16" />
                <asp:Parameter Name="总裁判长" Type="String" />
                <asp:Parameter Name="副总裁判长" Type="String" />
                <asp:Parameter Name="运动会开始日期" Type="DateTime" />
                <asp:Parameter Name="运动会结束日期" Type="DateTime" />
            </InsertParameters>
        </asp:SqlDataSource>
    
    </div>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="MeetingID"
            DataSourceID="SqlDataSource1" Height="50px" Width="400px" Font-Size="Smaller">
            <Fields>
                <asp:BoundField DataField="MeetingID" HeaderText="MeetingID" ReadOnly="True" SortExpression="MeetingID" />
                <asp:BoundField DataField="运动会名称" HeaderText="运动会名称" SortExpression="运动会名称" />
                <asp:BoundField DataField="主办单位" HeaderText="主办单位" SortExpression="主办单位" />
                <asp:BoundField DataField="承办单位" HeaderText="承办单位" SortExpression="承办单位" />
                <asp:BoundField DataField="比赛地点" HeaderText="比赛地点" SortExpression="比赛地点" />
                <asp:BoundField DataField="参赛队数" HeaderText="参赛队数" SortExpression="参赛队数" />
                <asp:BoundField DataField="总裁判长" HeaderText="总裁判长" SortExpression="总裁判长" />
                <asp:BoundField DataField="副总裁判长" HeaderText="副总裁判长" SortExpression="副总裁判长" />
                <asp:BoundField DataField="运动会开始日期" HeaderText="运动会开始日期" SortExpression="运动会开始日期" />
                <asp:BoundField DataField="运动会结束日期" HeaderText="运动会结束日期" SortExpression="运动会结束日期" />
                <asp:CommandField ShowEditButton="True" />
            </Fields>
        </asp:DetailsView>
        &nbsp;
    </form>
</body>
</html>
