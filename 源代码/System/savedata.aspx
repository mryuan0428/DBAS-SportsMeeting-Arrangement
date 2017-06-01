<%@ Page Language="C#" AutoEventWireup="true" CodeFile="savedata.aspx.cs" Inherits="System_savedata" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="备份" />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="注释"></asp:Label><br />
        <br />
        <br />
        &nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="还原数据库" /></div>
    </form>
</body>
</html>
