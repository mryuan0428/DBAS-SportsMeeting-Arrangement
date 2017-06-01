<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ini9.aspx.cs" Inherits="work_ini9" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;<asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        &nbsp;
        <asp:Label ID="Label1" runat="server" Text="说明：导入填写好的excel文档" Width="226px"></asp:Label><br />
        <asp:FileUpload ID="fileUp" runat="server" />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="确定" /></div>
    </form>
</body>
</html>
