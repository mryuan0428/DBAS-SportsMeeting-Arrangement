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

public partial class work_guichengwenben : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        {
            SqlConnection con0 = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        con0.Open();
        string mysql0 = "delete  from 规程文本";
        SqlCommand dbCommand0 = new SqlCommand(mysql0, con0);
        int x = dbCommand0.ExecuteNonQuery();
        con0.Close();
        }
        SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        con1.Open();
        string mysql1 = "insert into 规程文本(id,规程) values(1,'"+TextBox1.Text.ToString()+"') ";
        SqlCommand dbCommand1 = new SqlCommand(mysql1, con1);
        dbCommand1.ExecuteNonQuery();
        con1.Close();

    }
}
