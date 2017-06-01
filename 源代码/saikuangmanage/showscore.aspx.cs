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

public partial class saikuangmanage_scoremanage : System.Web.UI.Page
{
    string sql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            sql = "select distinct 组别 from 参赛队报名表 ";
            additems(zubie, sql);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)//选出合适项目
    {
        string sclx=saichengleixing.SelectedValue.ToString();//预赛或决赛
        string se = sex.SelectedValue.ToString();//性别
        string zb = zubie.SelectedValue.ToString();//组别
        string xmlx = xiangmuleixing.SelectedValue.ToString();//田赛或竞赛
        int xmlxint=0,sexint=0;
        if(xmlx=="径赛")xmlxint=1;
        if(se=="男")sexint=1;
        sql="select 项目名称 from 项目编码表 where 项目类别="+xmlxint+" and 男女子项目="+sexint+" and 项目编号 in ( select 项目编号 from 竞赛日程表 )";
        additems(xiangmu, sql);
        zuci.Items.Clear();
               
    }
    protected void additems(DropDownList ddl, string query)//添加选项
    { 
       
        SqlConnection myConnection = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
        SqlDataReader r = SqlHelper.ExecuteReader(query, myConnection);
        ddl.Items.Clear();//组别选项
        while (r.Read())
        {
            ddl.Items.Add(r[0].ToString());
        }
        
    }
    protected void showlabel(Label lab, string query)//显示升序还是降序
    {

        SqlConnection myConnection = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
       bool text = Convert.ToBoolean( SqlHelper.ExecuteScalar(query, myConnection));
        if (text == true)
            lab.Text = "升序";
        else lab.Text = "降序";
        myConnection.Close();
    }
    protected void Button3_Click(object sender, EventArgs e)//选出组次
    {
        string sclx = saichengleixing.SelectedValue.ToString();//预赛或决赛
        string se = sex.SelectedValue.ToString();//性别
        string zb = zubie.SelectedValue.ToString();//组别
        string xmlx = xiangmuleixing.SelectedValue.ToString();//田赛或竞赛
        int xmlxint = 0, sexint = 0;
        if (xmlx == "径赛") xmlxint = 1;
        if (se == "男") sexint = 1;
        string xmname = xiangmu.SelectedValue.ToString();
        sql = "select distinct 竞赛分组表.组次 from 竞赛分组表,竞赛日程表,项目编码表 where 竞赛分组表.日程号=竞赛日程表.日程号 and 竞赛日程表.项目编号=项目编码表.项目编号 and 竞赛日程表.组别='"+zb+"' and 项目编码表.项目类别="+xmlxint+" and 项目编码表.男女子项目="+sexint+" and 项目编码表.项目名称='"+xmname+"'";
        zuci.Items.Clear();
        additems(zuci, sql);
        zuci.Items.Add("所有组");
        sql = "select  项目编码表.排名方式 from 竞赛分组表,竞赛日程表,项目编码表 where 竞赛分组表.日程号=竞赛日程表.日程号 and 竞赛日程表.项目编号=项目编码表.项目编号 and 竞赛日程表.组别='"+zb+"' and 项目编码表.项目类别="+xmlxint+" and 项目编码表.男女子项目="+sexint+" and 项目编码表.项目名称='"+xmname+"'";
        showlabel(Label1,sql);
    }
    protected void Button1_Click1(object sender, EventArgs e)//显示成绩表
    {
        string paixu="desc";
        if (Label1.Text == "升序") paixu = "asc";
        //else if (Label1.Text == "降序") paixu = ;
        string sclx = saichengleixing.SelectedValue.ToString();//预赛或决赛
        string se = sex.SelectedValue.ToString();//性别
        string zb = zubie.SelectedValue.ToString();//组别
        string xmlx = xiangmuleixing.SelectedValue.ToString();//田赛或竞赛
        int xmlxint = 0, sexint = 0;
        if (xmlx == "径赛") xmlxint = 1;
        if (se == "男") sexint = 1;
        string xmname = xiangmu.SelectedValue.ToString();
        string zcstr = zuci.SelectedValue.ToString();
        if (zcstr == "所有组")
        {
            sql = "SELECT  竞赛分组表.运动员号码,报名表.姓名, 参赛队报名表.参赛队简称, 竞赛分组表.道次, " +
                   " 竞赛分组表.成绩文本1, 竞赛分组表.成绩文本2,竞赛分组表.成绩文本, 竞赛分组表.成绩1,竞赛分组表.成绩2,竞赛分组表.成绩,竞赛分组表.得分, " +
                   "竞赛分组表.组内名次, 竞赛分组表.赛程名次, 竞赛分组表.备注, 竞赛分组表.等级 ,竞赛日程表.日程号 " +
                   "FROM 竞赛分组表 INNER JOIN " +
                   "报名表 ON 竞赛分组表.运动员号码 = 报名表.运动员号码 INNER JOIN " +
                   "参赛队报名表 ON 报名表.参赛队编号 = 参赛队报名表.参赛队编号 INNER JOIN " +
                   "竞赛日程表 ON 竞赛分组表.日程号 = 竞赛日程表.日程号 INNER JOIN " +
                   "项目编码表 ON 竞赛日程表.项目编号 = 项目编码表.项目编号 " +
                   "WHERE (项目编码表.项目名称 ='" + xmname + "') AND (项目编码表.项目类别 = " + xmlxint + ") AND  (项目编码表.男女子项目 = " + sexint + ") AND (竞赛日程表.组别 = '" + zb + "') ORDER BY 竞赛分组表.成绩 " + paixu + ",竞赛分组表.成绩1 " + paixu + ",竞赛分组表.成绩2 " + paixu + ",竞赛分组表.道次";

        }
        else
        {
            int zc = Convert.ToInt16(zcstr);

            sql = "SELECT  竞赛分组表.运动员号码,报名表.姓名, 参赛队报名表.参赛队简称, 竞赛分组表.道次, " +
                    " 竞赛分组表.成绩文本1, 竞赛分组表.成绩文本2,竞赛分组表.成绩文本,竞赛分组表.成绩1,竞赛分组表.成绩2,竞赛分组表.成绩, 竞赛分组表.得分, " +
                    "竞赛分组表.组内名次, 竞赛分组表.赛程名次, 竞赛分组表.备注, 竞赛分组表.等级 ,竞赛日程表.日程号 " +
                    "FROM 竞赛分组表 INNER JOIN " +
                    "报名表 ON 竞赛分组表.运动员号码 = 报名表.运动员号码 INNER JOIN " +
                    "参赛队报名表 ON 报名表.参赛队编号 = 参赛队报名表.参赛队编号 INNER JOIN " +
                    "竞赛日程表 ON 竞赛分组表.日程号 = 竞赛日程表.日程号 INNER JOIN " +
                    "项目编码表 ON 竞赛日程表.项目编号 = 项目编码表.项目编号 " +
                    "WHERE (项目编码表.项目名称 ='" + xmname + "') AND (项目编码表.项目类别 = " + xmlxint + ") AND  (项目编码表.男女子项目 = " + sexint + ") AND  (竞赛分组表.组次 = " + zc + ") AND (竞赛日程表.组别 = '" + zb + "') ORDER BY 竞赛分组表.成绩 " + paixu + ",竞赛分组表.成绩1 " + paixu + ",竞赛分组表.成绩2 " + paixu + ",竞赛分组表.道次";
        }
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
            SqlDataAdapter ad = new SqlDataAdapter(sql, myConnection);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            
            //string query = "SELECT 报名表.* FROM 报名表";
            //SqlConnection myConnection = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
            //SqlDataAdapter ad = new SqlDataAdapter(query, myConnection);
            //DataSet ds = new DataSet();
            //ad.Fill(ds);
            //GridView1.DataSource = ds;
            //GridView1.DataBind();
    }
    protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
       
    }
    public int getLEIXING(int richengID)//获得项目记录方式（日程号）
    {
        string mysql = "SELECT 项目编码表.记录方式 FROM 项目编码表 INNER JOIN 竞赛日程表 ON 项目编码表.项目编号 = 竞赛日程表.项目编号 INNER JOIN 竞赛分组表 ON 竞赛日程表.日程号 = 竞赛分组表.日程号 where 竞赛日程表.日程号=" + richengID + "";
        SqlConnection con = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
        int leixing = Convert.ToInt32(SqlHelper.ExecuteScalar(mysql, con));
        return leixing;
    }
}
