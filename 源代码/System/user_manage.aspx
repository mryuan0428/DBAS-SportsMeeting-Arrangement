<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_manage.aspx.cs" Inherits="System_user_manage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:aConnectionString %>"
            DeleteCommand="DELETE FROM [用户] WHERE [id] = @id" InsertCommand="INSERT INTO [用户] ([username], [password], [role]) VALUES (@username, @password, @role)"
            SelectCommand="SELECT * FROM [用户]" UpdateCommand="UPDATE [用户] SET [username] = @username, [password] = @password, [role] = @role WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="username" Type="String" />
                <asp:Parameter Name="password" Type="String" />
                <asp:Parameter Name="role" Type="Boolean" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="username" Type="String" />
                <asp:Parameter Name="password" Type="String" />
                <asp:Parameter Name="role" Type="Boolean" />
            </InsertParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
            DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                    SortExpression="id" />
                <asp:BoundField DataField="username" HeaderText="用户名" SortExpression="username" />
                <asp:BoundField DataField="password" HeaderText="密码" SortExpression="password" />
                <asp:CheckBoxField DataField="role" HeaderText="角色" SortExpression="role" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
