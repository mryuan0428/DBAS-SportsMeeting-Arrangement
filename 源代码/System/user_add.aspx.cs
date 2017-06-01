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

public partial class System_user_add : System.Web.UI.Page
{
    SqlConnection strcon = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["conStr"]);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
         if (useryz(TextBox1.Text.ToString()))   //验证用户是否已存在
        {
            return;
        }
        strcon.Close();
        strcon.Open();
        string username = TextBox1.Text.ToString();
       
        string password = TextBox3.Text.ToString();
        
        int role =Convert.ToInt32( RBL1.SelectedValue);
        string sqlinsert = "insert into 用户 (username,password,role) values('" + username  + "','" + password + "',"+role+")";
        SqlCommand comm = strcon.CreateCommand();
        comm.CommandText = sqlinsert;
        SqlTransaction myTransaction = strcon.BeginTransaction(); //开始一个事务
        comm.Transaction = myTransaction;
        try
        {
            comm.ExecuteNonQuery();
            myTransaction.Commit();  //提交事务
            ClearTextBox();
            string mes = "恭喜 注册成功！";
            Response.Write("<script>alert('" + mes + "');location='../login.aspx'</script>");

        }
        catch
        {
            myTransaction.Rollback();  //回滚事务
        }
        finally
        {
            ClearTextBox();
            strcon.Close();
        }

    }
    protected Boolean useryz(string username)  //验证用户是否已存在
    {
        strcon.Open();
        SqlCommand comm = strcon.CreateCommand();
        comm.CommandText = "select username from 用户";
        SqlDataReader reader = comm.ExecuteReader();
        while (reader.Read())
        {
            if (reader[0].ToString() == username)
            {
                Response.Write(showmessage("该用户已存在！"));
                strcon.Close();
                return true;
            }
        }
        strcon.Close();
        return false;
    }
    protected void RBL1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        ClearTextBox();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Default.aspx");
    }
    protected void ClearTextBox()
    {
        TextBox1.Text = string.Empty;
        TextBox3.Text = string.Empty;
    }
    public string showmessage(string mes)  //提示信息
    {
        return "<script language='javascript'>alert('" + mes + "');location='javascript:history.go(-1)'</script>";
    }
}
