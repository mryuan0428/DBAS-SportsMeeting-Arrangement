<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zhixuce.aspx.cs" Inherits="work_bianpaimanage_zhixuce" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Height="70px" OnClick="Button1_Click" Text="生成秩序册"
            Width="114px" /><br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" Height="45px" Width="136px" NavigateUrl="../../mb/zhixuce.DOC" Target="_blank">下载秩序册</asp:HyperLink>&nbsp;</div>
    </form>
</body>
</html>
