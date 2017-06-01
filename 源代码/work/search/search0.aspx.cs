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

public partial class work_search_search0 : System.Web.UI.Page
{
   // protected DataSet allds = new DataSet();
   static string sql = null;//定义静态全局
    static string numtemp = null;//定义当前所选择的运动员号码
    protected void Page_Load(object sender, EventArgs e)
    {
        if(sql!=null)  reload(sql);
    }
    protected void Button1_Click(object sender, EventArgs e)//search查询
    {
        string qu="";
        string keyvalue  = TextBox1.Text.ToString().Trim();//选项
        string  keyname= DropDownList1.SelectedValue.ToString().Trim();//值
        if (keyname == "运动员号码") qu = " 报名表.运动员号码 like '%" + keyvalue + "%'";
        else if (keyname == "姓名")
            if (keyvalue.Length == 2)
            {
                qu = " 报名表.姓名 like '%" + keyvalue.Substring(0, 1) + "%" + keyvalue.Substring(1, 1) + "%'";
            }
            else
            {
                qu = " 报名表.姓名 like '%" + keyvalue+"%'";
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
        string query = "SELECT 报名表.运动员号码, 参赛队报名表.参赛队简称,报名表.姓名, 报名表.性别, 报名表.年龄, 报名表.备注 FROM 报名表 INNER JOIN 参赛队报名表 ON 报名表.参赛队编号 = 参赛队报名表.参赛队编号 where"+qu+"";
        sql = query;
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        SqlDataAdapter ad = new SqlDataAdapter(query, myConnection);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)//翻页
    {
        GridView1.PageIndex = e.NewPageIndex;
        Label3.Text = "未指定";
        DropDownList2.Items.Clear();
        TextBox3.Text = "";
        GridView1.DataBind(); 
    }


    protected void Button2_Click(object sender, EventArgs e)//显示全部
    {
        string query = "SELECT 报名表.运动员号码, 参赛队报名表.参赛队简称,报名表.姓名, 报名表.性别, 报名表.年龄, 报名表.备注 FROM 报名表 INNER JOIN 参赛队报名表 ON 报名表.参赛队编号 = 参赛队报名表.参赛队编号 ";
        sql = query;
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        SqlDataAdapter ad = new SqlDataAdapter(query, myConnection);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void reload(string query)//防止分页从新载入数据还原到最初状态
    {
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        SqlDataAdapter ad = new SqlDataAdapter(query, myConnection);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)//选定后显示项目名称和成绩
    {


        numtemp = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();//获得运动员号码
        string name = GridView1.Rows[e.NewSelectedIndex].Cells[3].Text.ToString();//获得运动员名字
        Label3.Text = name;
        string query = "SELECT distinct 项目编码表.项目名称 FROM 竞赛分组表 INNER JOIN  竞赛日程表 ON 竞赛分组表.日程号 = 竞赛日程表.日程号 INNER JOIN   项目编码表 ON 竞赛日程表.项目编号 = 项目编码表.项目编号 WHERE (竞赛分组表.运动员号码 = '" + numtemp + "')";
        additems(DropDownList2, query);
        query = "SELECT 竞赛分组表.成绩文本 FROM 竞赛分组表 INNER JOIN  竞赛日程表 ON 竞赛分组表.日程号 = 竞赛日程表.日程号 INNER JOIN   项目编码表 ON 竞赛日程表.项目编号 = 项目编码表.项目编号 WHERE (竞赛分组表.运动员号码 = '" + numtemp + "') and (项目编码表.项目名称='" + DropDownList2.SelectedValue.ToString() + "')";
       TextBox3.Text=getscore(query) ;

   
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int i;
        //执行循环，保证每条数据都可以更新
        for (i = 0; i <= GridView1.Rows.Count; i++)
        {
            //首先判断是否是数据行
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //当鼠标停留时更改背景色
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#00A9FF'");
                //当鼠标移开时还原背景色
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            }
        }
    }
    protected void additems(DropDownList ddl, string query)//添加选项
    {

        SqlConnection myConnection = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
        SqlDataReader r = SqlHelper.ExecuteReader(query, myConnection);
        
        ddl.Items.Clear();//清空选项
        while (r.Read())
        {
            ddl.Items.Add(r[0].ToString());
        }
        myConnection.Close();
        r.Close();

    }
    protected string getscore(string query)//获得成绩
    {

        SqlConnection myConnection = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
        string score =Convert.ToString( SqlHelper.ExecuteScalar(query, myConnection));
        myConnection.Close();
        return score;

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

        string query = "SELECT 竞赛分组表.成绩文本 FROM 竞赛分组表 INNER JOIN  竞赛日程表 ON 竞赛分组表.日程号 = 竞赛日程表.日程号 INNER JOIN   项目编码表 ON 竞赛日程表.项目编号 = 项目编码表.项目编号 WHERE (竞赛分组表.运动员号码 = '" + numtemp + "') and (项目编码表.项目名称='" + DropDownList2.SelectedValue.ToString() + "')";
        TextBox3.Text = getscore(query);
    }
    protected void DropDownList2_TextChanged(object sender, EventArgs e)
    {
        string query = "SELECT 竞赛分组表.成绩文本 FROM 竞赛分组表 INNER JOIN  竞赛日程表 ON 竞赛分组表.日程号 = 竞赛日程表.日程号 INNER JOIN   项目编码表 ON 竞赛日程表.项目编号 = 项目编码表.项目编号 WHERE (竞赛分组表.运动员号码 = '" + numtemp + "') and (项目编码表.项目名称='" + DropDownList2.SelectedValue.ToString() + "')";
        TextBox3.Text = getscore(query);
    }
}
