<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manage2.aspx.cs" Inherits="work_bianpaimanage_manage2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:aConnectionString %>"
            DeleteCommand="DELETE FROM [参赛项目表] WHERE [项目编号] = @项目编号" InsertCommand="INSERT INTO [参赛项目表] ([项目编号], [项目名称], [男女子项目], [项目顺序]) VALUES (@项目编号, @项目名称, @男女子项目, @项目顺序)"
            SelectCommand="SELECT [项目编号], [项目名称], [男女子项目], [项目顺序] FROM [参赛项目表] ORDER BY [项目顺序], [项目编号]"
            UpdateCommand="UPDATE [参赛项目表] SET [项目顺序] = @项目顺序 WHERE [项目编号] = @项目编号">
            <DeleteParameters>
                <asp:Parameter Name="项目编号" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="项目名称" Type="String" />
                <asp:Parameter Name="男女子项目" Type="Boolean" />
                <asp:Parameter Name="项目顺序" Type="Int32" />
                <asp:Parameter Name="项目编号" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="项目编号" Type="String" />
                <asp:Parameter Name="项目名称" Type="String" />
                <asp:Parameter Name="男女子项目" Type="Boolean" />
                <asp:Parameter Name="项目顺序" Type="Int32" />
            </InsertParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="项目编号"
            DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="项目编号" HeaderText="项目编号" ReadOnly="True" SortExpression="项目编号" />
                <asp:BoundField DataField="项目名称" HeaderText="项目名称" SortExpression="项目名称" ReadOnly="True" />
                <asp:CheckBoxField DataField="男女子项目" HeaderText="男女子项目" ReadOnly="True" SortExpression="男女子项目" />
                <asp:BoundField DataField="项目顺序" HeaderText="项目顺序" SortExpression="项目顺序" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
