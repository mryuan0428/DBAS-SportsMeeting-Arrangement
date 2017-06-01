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
using System.IO;
using System.Text;

public partial class work_search_search6 : System.Web.UI.Page
{
    static string sql = null;//定义静态全局
    protected void Page_Load(object sender, EventArgs e)
    {
        if (sql != null) reload(sql);
        
      
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        string qu = "";
        string keyvalue = TextBox1.Text.ToString().Trim();//选项
        string keyname = DropDownList1.SelectedValue.ToString().Trim();//值
        if (keyname == "运动员号码") qu = " 报名表.运动员号码 like '%" + keyvalue + "%'";
        else if (keyname == "姓名")
            if (keyvalue.Length == 2)
            {
                qu = " 报名表.姓名 like '%" + keyvalue.Substring(0, 1) + "%" + keyvalue.Substring(1, 1) + "%'";
            }
            else
            {
                qu = " 报名表.姓名 like '%" + keyvalue + "%'";
            }
        else if (keyname == "参赛队")
        {
            if (keyvalue.Length == 2)
            {
                qu = " 参赛队报名表.参赛队简称  like '%" + keyvalue.Substring(0, 1) + "%" + keyvalue.Substring(1, 1) + "%'";
            }
            else
            {
                qu = " 参赛队报名表.参赛队简称 like '%" + keyvalue + "%'";
            }
        }
        string query = "SELECT 报名表.* FROM 报名表 INNER JOIN 参赛队报名表 ON 报名表.参赛队编号 = 参赛队报名表.参赛队编号 where" + qu + "";
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        sql = query;
        SqlDataAdapter ad = new SqlDataAdapter(query, myConnection);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void reload(string query)//防止分页从新载入数据还原到最初状态
    {
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        sql = query;
        SqlDataAdapter ad = new SqlDataAdapter(query, myConnection);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string query = "if exists (select 1 from  sysobjects  where  id = object_id('报名表') and   type = 'U')  SELECT 报名表.* FROM 报名表 else SELECT 错误.* FROM 错误";
        sql = query;
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        SqlDataAdapter ad = new SqlDataAdapter(query, myConnection);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
}
