<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script language=javascript>
function em()
{
    form1.username.value="";
    form1.userpwd.value="";
}
</script>
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <HTML>
<HEAD>
<TITLE>login</TITLE>
<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=gb2312">
</HEAD>
<BODY BGCOLOR=#FFFFFF LEFTMARGIN=0 TOPMARGIN=0 MARGINWIDTH=0 MARGINHEIGHT=0>
    <br />
    <br />
    <br />
<TABLE WIDTH=430 BORDER=0 CELLPADDING=0 CELLSPACING=0 align="center">
	<TR>
		<TD COLSPAN=8>
			<IMG SRC="images/login_1.gif" WIDTH=430 HEIGHT=130 ALT="" style="font-size: 12px"></TD>
		<TD>
			<IMG SRC="images/spacer.gif" WIDTH=1 HEIGHT=130 ALT=""></TD>
	</TR>
	<TR>
		<TD COLSPAN=2 ROWSPAN=4>
			<IMG SRC="images/login_2.gif" WIDTH=139 HEIGHT=133 ALT=""></TD>
		<TD>
			<IMG SRC="images/login_3.gif" WIDTH=1 HEIGHT=1 ALT=""></TD>
		<TD ROWSPAN=3>
			<IMG SRC="images/login_4.gif" WIDTH=8 HEIGHT=124 ALT=""></TD>
		<TD COLSPAN=3 ROWSPAN=2 style="background-image: url(images/login_5.gif)">
            <table style="font-size: 12px; width: 235px; height: 78px">
                <tr>
                    <td style="width: 386px">
                    </td>
                    <td style="width: 109px">
                    </td>
                    <td style="width: 100px">
                    </td>
                </tr>
                <tr>
                    <td style=" height: 22px; width: 386px;" align="left">
                        用户名：</td>
                    <td style="width: 109px; height: 22px">
                        <asp:TextBox ID="username" runat="server" Height="15px" Width="130px"></asp:TextBox>
                        </td>
                    <td style="width: 10px; height: 22px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="username"
                            ErrorMessage="用户名不能为空">*</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style=" height: 23px; width: 386px;" align="left">
                        密码：</td>
                    <td style="width: 109px; height: 23px">
                        <asp:TextBox ID="userpwd" runat="server" Height="15px" TextMode="Password" Width="130px"></asp:TextBox>
                        </td>
                    <td style="width: 10px; height: 23px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="userpwd"
                            ErrorMessage="密码不能为空">*</asp:RequiredFieldValidator></td>
                </tr>
            </table>
			</TD>
		<TD ROWSPAN=3>
			<IMG SRC="images/login_6.gif" WIDTH=42 HEIGHT=124 ALT=""></TD>
		<TD>
			<IMG SRC="images/spacer.gif" WIDTH=1 HEIGHT=1 ALT=""></TD>
	</TR>
	<TR>
		<TD ROWSPAN=2>
			<IMG SRC="images/login_7.gif" WIDTH=1 HEIGHT=123 ALT=""></TD>
		<TD>
			<IMG SRC="images/spacer.gif" WIDTH=1 HEIGHT=97 ALT=""></TD>
	</TR>
	<TR>
		<TD style="width:115px;height:26px; background-image: url(images/login_8.gif);">
            <table cellspacing="0" style="font-size: 12px">
                <tr>
                    <td style="width: 83px">
                        验证码</td>
                    <td style="width: 30px">
                        <asp:TextBox ID="ValidateNumber" runat="server" Height="15px" Width="30px"></asp:TextBox></td>
                    <td style="width: 30px">
                        <asp:Label ID="Label1" runat="server" Text="1"></asp:Label></td>
                </tr>
            </table>
            </TD>
		<TD style="width:61px;height:26px;">
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/login_9.gif" OnClick="ImageButton1_Click" /></TD>
		<TD style="width: 65px">
			<IMG SRC="images/login_10.gif" WIDTH=64 HEIGHT=26 ALT="" onclick="em()" style="cursor:hand"></TD>
		<TD>
			<IMG SRC="images/spacer.gif" WIDTH=1 HEIGHT=26 ALT=""></TD>
	</TR>
	<TR>
		<TD COLSPAN=6 ROWSPAN=2>
			<IMG SRC="images/login_11.gif" WIDTH=291 HEIGHT=57 ALT=""></TD>
		<TD>
			<IMG SRC="images/spacer.gif" WIDTH=1 HEIGHT=9 ALT=""></TD>
	</TR>
	<TR>
		<TD>
			<IMG SRC="images/login_12.gif" WIDTH=57 HEIGHT=48 ALT=""></TD>
		<TD>
			<IMG SRC="images/login_13.gif" WIDTH=82 HEIGHT=48 ALT=""></TD>
		<TD>
			<IMG SRC="images/spacer.gif" WIDTH=1 HEIGHT=48 ALT=""></TD>
	</TR>
</TABLE>
</BODY>
</HTML>
    </div>
    </form>
</body>
</html>
