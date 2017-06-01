<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="ini2.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:aConnectionString %>"
            DeleteCommand="DELETE FROM [历史最高纪录表] WHERE [自动编号] = @自动编号" InsertCommand="INSERT INTO [历史最高纪录表] ([项目编号], [平破级别], [成绩文本], [成绩], [姓名], [单位], [地点], [时间], [备注], [最新纪录]) VALUES (@项目编号, @平破级别, @成绩文本, @成绩, @姓名, @单位, @地点, @时间, @备注, @最新纪录)"
            SelectCommand="SELECT * FROM [历史最高纪录表]" UpdateCommand="UPDATE [历史最高纪录表] SET [项目编号] = @项目编号, [平破级别] = @平破级别, [成绩文本] = @成绩文本, [成绩] = @成绩, [姓名] = @姓名, [单位] = @单位, [地点] = @地点, [时间] = @时间, [备注] = @备注, [最新纪录] = @最新纪录 WHERE [自动编号] = @自动编号">
            <DeleteParameters>
                <asp:Parameter Name="自动编号" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="项目编号" Type="String" />
                <asp:Parameter Name="平破级别" Type="String" />
                <asp:Parameter Name="成绩文本" Type="String" />
                <asp:Parameter Name="成绩" Type="Single" />
                <asp:Parameter Name="姓名" Type="String" />
                <asp:Parameter Name="单位" Type="String" />
                <asp:Parameter Name="地点" Type="String" />
                <asp:Parameter Name="时间" Type="String" />
                <asp:Parameter Name="备注" Type="String" />
                <asp:Parameter Name="最新纪录" Type="Boolean" />
                <asp:Parameter Name="自动编号" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="项目编号" Type="String" />
                <asp:Parameter Name="平破级别" Type="String" />
                <asp:Parameter Name="成绩文本" Type="String" />
                <asp:Parameter Name="成绩" Type="Single" />
                <asp:Parameter Name="姓名" Type="String" />
                <asp:Parameter Name="单位" Type="String" />
                <asp:Parameter Name="地点" Type="String" />
                <asp:Parameter Name="时间" Type="String" />
                <asp:Parameter Name="备注" Type="String" />
                <asp:Parameter Name="最新纪录" Type="Boolean" />
            </InsertParameters>
        </asp:SqlDataSource>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="自动编号" DataSourceID="SqlDataSource1"
            Width="679px" Font-Size="Smaller">
            <EditItemTemplate>
                自动编号:
                <asp:Label ID="自动编号Label1" runat="server" Text='<%# Eval("自动编号") %>'></asp:Label><br />
                项目编号:
                <asp:TextBox ID="项目编号TextBox" runat="server" Text='<%# Bind("项目编号") %>'>
                </asp:TextBox><br />
                平破级别:
                <asp:TextBox ID="平破级别TextBox" runat="server" Text='<%# Bind("平破级别") %>'>
                </asp:TextBox><br />
                成绩文本:
                <asp:TextBox ID="成绩文本TextBox" runat="server" Text='<%# Bind("成绩文本") %>'>
                </asp:TextBox><br />
                成绩:
                <asp:TextBox ID="成绩TextBox" runat="server" Text='<%# Bind("成绩") %>'>
                </asp:TextBox><br />
                姓名:
                <asp:TextBox ID="姓名TextBox" runat="server" Text='<%# Bind("姓名") %>'>
                </asp:TextBox><br />
                单位:
                <asp:TextBox ID="单位TextBox" runat="server" Text='<%# Bind("单位") %>'>
                </asp:TextBox><br />
                地点:
                <asp:TextBox ID="地点TextBox" runat="server" Text='<%# Bind("地点") %>'>
                </asp:TextBox><br />
                时间:
                <asp:TextBox ID="时间TextBox" runat="server" Text='<%# Bind("时间") %>'>
                </asp:TextBox><br />
                备注:
                <asp:TextBox ID="备注TextBox" runat="server" Text='<%# Bind("备注") %>'>
                </asp:TextBox><br />
                最新纪录:
                <asp:CheckBox ID="最新纪录CheckBox" runat="server" Checked='<%# Bind("最新纪录") %>' /><br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                    Text="更新">
                </asp:LinkButton>
                <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                    Text="取消">
                </asp:LinkButton>
            </EditItemTemplate>
            <InsertItemTemplate>
                项目编号:
                <asp:TextBox ID="项目编号TextBox" runat="server" Text='<%# Bind("项目编号") %>'>
                </asp:TextBox><br />
                平破级别:
                <asp:TextBox ID="平破级别TextBox" runat="server" Text='<%# Bind("平破级别") %>'>
                </asp:TextBox><br />
                成绩文本:
                <asp:TextBox ID="成绩文本TextBox" runat="server" Text='<%# Bind("成绩文本") %>'>
                </asp:TextBox><br />
                成绩:
                <asp:TextBox ID="成绩TextBox" runat="server" Text='<%# Bind("成绩") %>'>
                </asp:TextBox><br />
                姓名:
                <asp:TextBox ID="姓名TextBox" runat="server" Text='<%# Bind("姓名") %>'>
                </asp:TextBox><br />
                单位:
                <asp:TextBox ID="单位TextBox" runat="server" Text='<%# Bind("单位") %>'>
                </asp:TextBox><br />
                地点:
                <asp:TextBox ID="地点TextBox" runat="server" Text='<%# Bind("地点") %>'>
                </asp:TextBox><br />
                时间:
                <asp:TextBox ID="时间TextBox" runat="server" Text='<%# Bind("时间") %>'>
                </asp:TextBox><br />
                备注:
                <asp:TextBox ID="备注TextBox" runat="server" Text='<%# Bind("备注") %>'>
                </asp:TextBox><br />
                最新纪录:
                <asp:CheckBox ID="最新纪录CheckBox" runat="server" Checked='<%# Bind("最新纪录") %>' /><br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                    Text="插入">
                </asp:LinkButton>
                <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                    Text="取消">
                </asp:LinkButton>
            </InsertItemTemplate>
            <ItemTemplate>
                自动编号:
                <asp:Label ID="自动编号Label" runat="server" Text='<%# Eval("自动编号") %>'></asp:Label>
                项目编号:&nbsp;
                <asp:Label ID="项目编号Label" runat="server" Text='<%# Bind("项目编号") %>'></asp:Label>平破级别:
                <asp:Label ID="平破级别Label" runat="server" Text='<%# Bind("平破级别") %>'></asp:Label><br />
                成绩文本:
                <asp:Label ID="成绩文本Label" runat="server" Text='<%# Bind("成绩文本") %>'></asp:Label>成绩:
                <asp:Label ID="成绩Label" runat="server" Text='<%# Bind("成绩") %>'></asp:Label>姓名:
                <asp:Label ID="姓名Label" runat="server" Text='<%# Bind("姓名") %>'></asp:Label><br />
                单位:
                <asp:Label ID="单位Label" runat="server" Text='<%# Bind("单位") %>'></asp:Label>地点:
                <asp:Label ID="地点Label" runat="server" Text='<%# Bind("地点") %>'></asp:Label>时间:
                <asp:Label ID="时间Label" runat="server" Text='<%# Bind("时间") %>'></asp:Label><br />
                备注:
                <asp:Label ID="备注Label" runat="server" Text='<%# Bind("备注") %>'></asp:Label>最新纪录:
                <asp:CheckBox ID="最新纪录CheckBox" runat="server" Checked='<%# Bind("最新纪录") %>' Enabled="false" /><br />
                &nbsp;
                <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                    Text="新建"></asp:LinkButton>
            </ItemTemplate>
        </asp:FormView>
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            DataKeyNames="自动编号" DataSourceID="SqlDataSource1" Font-Size="Smaller" PageSize="20">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="自动编号" HeaderText="自动编号" InsertVisible="False" ReadOnly="True"
                    SortExpression="自动编号" />
                <asp:BoundField DataField="项目编号" HeaderText="项目编号" SortExpression="项目编号" />
                <asp:BoundField DataField="平破级别" HeaderText="平破级别" SortExpression="平破级别" />
                <asp:BoundField DataField="成绩文本" HeaderText="成绩文本" SortExpression="成绩文本" />
                <asp:BoundField DataField="成绩" HeaderText="成绩" SortExpression="成绩" />
                <asp:BoundField DataField="姓名" HeaderText="姓名" SortExpression="姓名" />
                <asp:BoundField DataField="单位" HeaderText="单位" SortExpression="单位" />
                <asp:BoundField DataField="地点" HeaderText="地点" SortExpression="地点" />
                <asp:BoundField DataField="时间" HeaderText="时间" SortExpression="时间" />
                <asp:BoundField DataField="备注" HeaderText="备注" SortExpression="备注" />
                <asp:CheckBoxField DataField="最新纪录" HeaderText="最新纪录" SortExpression="最新纪录" />
            </Columns>
        </asp:GridView>
        &nbsp;
    </form>
</body>
</html>
