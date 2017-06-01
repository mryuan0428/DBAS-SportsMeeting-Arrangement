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

public partial class work_ini6 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //GridView2.Enabled = false;
            //是否计算团体总分
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
            con.Open();
            string mysql = "SELECT 参数值 FROM 运动会竞赛规程 WHERE (类型 = 3)";
            SqlCommand dbCommand = new SqlCommand(mysql, con);
            SqlDataReader reader = dbCommand.ExecuteReader();
            reader.Read();
            string a = reader[0].ToString();
            con.Close();
            if (a.Equals("0")) { GridView2.Visible = false; }

            // GridView3.Attributes.Add("style", "word-break;keep-all;word-wrap;normal");
            //规程
            // SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
            con.Open();
            mysql = "SELECT 规程 FROM 规程文本";
            SqlCommand dbCommand1 = new SqlCommand(mysql, con);
            string gctext = dbCommand1.ExecuteScalar().ToString();
            guicheng.Text = gctext;
            con.Close();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
            SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
            con1.Open();
           string mysql = "SELECT 参数值 FROM 运动会竞赛规程 WHERE (类型 = 4)";
            SqlCommand dbCommand1 = new SqlCommand(mysql, con1);
            SqlDataReader reader1 = dbCommand1.ExecuteReader();
            reader1.Read();
            int n = Convert.ToInt16(reader1[0].ToString());//录取名次
            con1.Close();

        
            {
                SqlConnection con3 = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
                con3.Open();
                mysql = "delete from 运动员录取办法";
                SqlCommand dbCommand3 = new SqlCommand(mysql, con3);
                dbCommand3.ExecuteNonQuery();
                con3.Close();
            }
            for (int i = 1; i <= n; i++)
            {
                SqlConnection con2 = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
                con2.Open();
                mysql = "insert into 运动员录取办法 values(" + i + ",0)";
                SqlCommand dbCommand2 = new SqlCommand(mysql, con2);
                dbCommand2.ExecuteNonQuery();
                con2.Close();
            }
        //GridView2.Enabled = true;
        Server.Transfer("ini7.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)//update
    {
        string gctext=guicheng.Text.ToString();
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        con.Open();
        string mysql = "UPDATE [规程文本] SET [规程] = '" + gctext + "'";
        SqlCommand dbCommand = new SqlCommand(mysql, con);
        dbCommand.ExecuteNonQuery();
        con.Close();
    }
}
