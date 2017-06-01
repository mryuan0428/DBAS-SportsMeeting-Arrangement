using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
public partial class Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // Session["username"] = "gb";
        if (Convert.ToString(Session["username"]) == "")
        {
            Response.Write("<script language=javascript>alert('请登录');location='login.aspx'</script>");
        }
        if (Convert.ToInt32(Session["role"]) == 1)
        {
            this.Label1.Text = "管理员：";
            TreeView2.Visible=false;
            TreeView1.Visible = true;
        }
        else if (Convert.ToInt32(Session["role"]) == 0)
        {
            this.Label1.Text = "操作者：";
            TreeView1.Visible = false;
            TreeView2.Visible = true;
            
        }
            this.Label1.Text += Convert.ToString(Session["username"]);
        this.Label2.Text = Convert.ToString(DateTime.Today.ToShortDateString());
        TreeView1.Font.Size = FontUnit.Small;

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("login.aspx");
    }
}
