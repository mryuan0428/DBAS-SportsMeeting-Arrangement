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

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {   
            Random validateN = new Random();
            this.Label1.Text = validateN.Next(9).ToString() + validateN.Next(9).ToString() + validateN.Next(9).ToString() + validateN.Next(9).ToString();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string username = Request["username"];
        string userpwd = Request["userpwd"];
        stockClass sc=new stockClass();
        if (sc.validate(username))
        {
            Response.Write("<script>alert('用户名中不能含有非法字符');history.back()</script>");
            return;
        }
        if(sc.validate(userpwd))
        {
            Response.Write("<script>alert('密码中不能含有非法字符');history.back()</script>");
            return;
        }
        if (this.ValidateNumber.Text != this.Label1.Text)
        {
            Response.Write("<script>alert('验证码错误');history.back()</script>");
            return;
        }
        SqlConnection strcon = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["conStr"]);
        strcon.Open();
        SqlCommand scd = new SqlCommand("select count(*) as ff from 用户 where username='"+username+"' and password='"+userpwd+"'",strcon);
        int count = Convert.ToInt32(scd.ExecuteScalar());
        strcon.Close();
        if (count > 0)
        {
            Session["username"] = username;
            Session["role"]=getrole(username);
            Response.Redirect("default.aspx");
        }
        else
        {
            Response.Write("<script>alert('用户名或者密码错误，请重新输入！');history.back()</script>");
            return;
        }
    }
    protected int  getrole(string username)//获得用户权限
    {
            SqlConnection strcon = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["conStr"]);
            strcon.Open();
            string sqlstr="select role from 用户 where username='" + username + "'";
            SqlCommand scd = new SqlCommand(sqlstr, strcon);
            int role = Convert.ToInt32(scd.ExecuteScalar());//1为管理员 0为操作者
            return role;
    }
}
