<%@ Page Language="C#" AutoEventWireup="true" CodeFile="guichengwenben.aspx.cs" Inherits="work_guichengwenben" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="请填写规程文本"></asp:Label><br />
            <asp:TextBox ID="TextBox1" runat="server" Height="402px" TextMode="MultiLine" Width="481px"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="提交" /></div>
    
    </div>
    </form>
</body>
</html>
