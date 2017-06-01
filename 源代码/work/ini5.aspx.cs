using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class ini5 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        con.Open();
        string mysql = "select max(项目编号) from 项目编码表 ";
        SqlCommand dbCommand = new SqlCommand(mysql, con);
        SqlDataReader reader = dbCommand.ExecuteReader();
        reader.Read();
        int a= Convert.ToInt32(reader[0])+1;
        TextBox1.Text = a.ToString().PadLeft(5,'0');
        con.Close();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Response.Write("<script language=javascript>alert('cuowu')</script>");
         int ischeck = 0;
         if (CheckBox1.Checked) ischeck = 1;
         //Response.Write("<script language=javascript>alert('" + TextBox1.Text + TextBox2.Text + TextBox3.Text + DropDownList1.Text + DropDownList2.Text + DropDownList3.Text + ischeck + "')</script>");
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        con.Open();
        string mysql = "insert into 项目编码表  values('"+TextBox1.Text+"','"+TextBox2.Text+"','"+DropDownList1.Text+"','"+DropDownList2.Text+"',"+ischeck+",'',0,0,'"+DropDownList3.Text+"','"+TextBox3.Text+"')";
        SqlCommand dbCommand = new SqlCommand(mysql, con);
        try
        {
            int a = dbCommand.ExecuteNonQuery();
            con.Close();
            Response.Write("<script language=javascript>alert('" + a + "成功')</script>");
            this.GridView1.DataBind();
            
        }
        catch (System.Exception ex)
        {
            con.Close();
            Response.Write("<script language=javascript>alert('错误')</script>");
        }
        Server.Transfer("ini5.aspx");//刷新页面

    }
}
