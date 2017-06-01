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

public partial class System_savedata : System.Web.UI.Page
{
    SqlConnection strcon = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["conStr"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        strcon.Open();
        SqlCommand comm = strcon.CreateCommand();
        comm.CommandText = "select time from 数据库备份";
        SqlDataReader reader = comm.ExecuteReader();
        DropDownList1.Items.Clear();
        DropDownList1.Items.Add(new ListItem("--请选择--", "a"));
        while (reader.Read())
        {
            DropDownList1.Items.Add(new ListItem(reader[0].ToString(), "a"));
        }
        strcon.Close();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string dat = DateTime.Now.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
        string path = Server.MapPath("..\\App_Data\\");
        path = path + dat;
        string myExecuteQuery = "backup database a to disk='" +path+".dat'";
        SqlCommand myCommand = new SqlCommand(myExecuteQuery, strcon);
        myCommand.Connection.Open();
        myCommand.ExecuteNonQuery();
        strcon.Close();
      
         myExecuteQuery = "insert into 数据库备份(time,注释) values('"+dat+"','"+TextBox1.Text.ToString()+"') ";
        SqlCommand myCommand1 = new SqlCommand(myExecuteQuery, strcon);
        myCommand1.Connection.Open();
        myCommand1.ExecuteNonQuery();
        strcon.Close();
      Response.Write( "<script language='javascript'>alert('备份成功！')</script>");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
}
