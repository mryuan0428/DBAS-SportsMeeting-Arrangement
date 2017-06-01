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

public partial class work_search_search7 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
                int zuci=0,daoci=0;
                SqlConnection con1 = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction); ;
                string mysql1 = "select distinct 日程号 from 竞赛分组表 order by 日程号";
                SqlDataReader reader1 = SqlHelper.ExecuteReader(mysql1,con1);
                while (reader1.Read())
                {
                    int richengID = Convert.ToInt32(reader1["日程号"]);
                    Response.Write("<p align=center>竞赛分组表</p>");
                   
                    Response.Write("<table border=1 cellspacing=0 bordercolor=#000000 align=center>");
                    Response.Write("<tr align=left><td colspan=9>");
                     Response.Write("项目名称:");
                    Response.Write(getSex(richengID) +getZUBIE(richengID)+ getXMMC(richengID));
                    Response.Write("  赛程:");
                    Response.Write(getLEIXING(richengID));
                    Response.Write("</td></tr>");
                    Response.Write("<tr><td width=80>组次\\道次</td>");
                    for (int i = 1; i <= 8; i++)
                    {
                        Response.Write("<td width=80 align=center>" + i + "</td>");
                    }
                    Response.Write("</tr>");
                    string query = "select 运动员号码,组次,道次 from 竞赛分组表 where 日程号=" + richengID + " order by 组次,道次";
                    SqlConnection myConnection = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
                    SqlDataReader r = SqlHelper.ExecuteReader(query,myConnection);
                    int huanhang = 0;//补齐表格用
                    while(r.Read())
                    {   daoci= Convert.ToInt32(r["道次"]);
                        zuci=Convert.ToInt32(r["组次"]);
                        if(daoci==1&&zuci==1)Response.Write("<tr ><td align=center>"+zuci+"</td>");
                        if (daoci == 1 && zuci != 1) Response.Write("</tr><tr><td align=center>" + zuci + "</td>");
                        Response.Write("<td align=center>" + r["运动员号码"] + "</td>");
                        huanhang++;
                       
                    }
                    for (int j = 0; j < (8 - huanhang % 8);j++ )
                        Response.Write("<td>&nbsp;</td>");
                        Response.Write("</tr>");
                    myConnection.Close();
                    Response.Write("</table>");
                } 
                con1.Close();
        
    }
    public string getXMMC(int richengID)//获得项目名称（日程号）
    { 
        string mysql="select 项目名称 from 项目编码表 where 项目编号=(select 项目编号 from 竞赛日程表 where 日程号='"+richengID+"')";
        SqlConnection con = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
        string name =Convert.ToString( SqlHelper.ExecuteScalar(mysql, con) );
        return name;
    }
    public String getSex(int richengID)//获得项目性别（日程号）
    {
        string mysql = "select 男女子项目 from 项目编码表 where 项目编号=(select 项目编号 from 竞赛日程表 where 日程号='" + richengID + "')";
        SqlConnection con = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
        int sex = Convert.ToInt32 (SqlHelper.ExecuteScalar(mysql, con));
        if (sex == 1) return "男子";
        else return "女子";
    }
    public String getZUBIE(int richengID)//获得项目组别（日程号）
    {
        string mysql = "select 组别 from 竞赛日程表 where 日程号='" + richengID + "'";
        SqlConnection con = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
        string zubie = Convert.ToString(SqlHelper.ExecuteScalar(mysql, con));
        return zubie;
    }
    public String getLEIXING(int richengID)//获得项目赛程类型（日程号）
    {
        string mysql = "select 赛程类型 from 竞赛日程表 where 日程号='" + richengID + "'";
        SqlConnection con = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
        string leixing= Convert.ToString(SqlHelper.ExecuteScalar(mysql, con));
        return leixing;
    }
    
}
