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
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //用NewEidIndex取得当前编辑的行号，然后获取gridviewrow对象
        GridView1.EditIndex = e.NewEditIndex;
       // GridView1.Rows[e.NewEditIndex].Cells[1].Attributes.Add("style", "ReadOnly:'True'");
        
            GridView1.DataBind();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        GridView1.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       //设置为只读
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //e.Row.Enabled = false;
            for (int i = 1; i < 13; i++)
            { 
                
               // ((e.Row.Cells[i])).Width = 10;
                e.Row.Cells[i].Enabled = false;
              
            }
            e.Row.Cells[5].Enabled = true;
            e.Row.Cells[6].Enabled = true;
            e.Row.Cells[7].Enabled = true;

        }
        //e.Row.Cells[1].Attributes.Add("style", "ReadOnly:'True'");
       // e.Row.Cells[1].Controls.IsReadOnly = true;
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)//更新并转化为数字成绩
    {
        
         SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
         string score1 = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[5].Controls[0])).Text.ToString().Trim();//成绩文本1
         string score2 = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[6].Controls[0])).Text.ToString().Trim();//成绩文本2
         string score3 = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[7].Controls[0])).Text.ToString().Trim();//成绩文本
         string richengID = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[16].Controls[0])).Text.ToString().Trim();//日程号
         int richeng = Convert.ToInt32(richengID);
         string yundongyuanID = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim();//运动员号码
        double scoren1= changetonum1(richeng,score1);//成绩1
        double scoren2 = changetonum1(richeng, score2);//成绩2
        double scoren3 = changetonum1(richeng, score3);//成绩
        sql = "update 竞赛分组表 set 成绩1="+scoren1+",成绩2="+scoren2+" ,成绩="+scoren3+", 成绩文本1 = '" + score1 + "',成绩文本2 = '" + score2 + "',成绩文本 = '" + score3 + "' where 日程号="+richeng+" and 运动员号码='"+yundongyuanID+"'";
         
        con.Open();
        SqlCommand dbCommand = new SqlCommand(sql, con);
        dbCommand.ExecuteNonQuery();
        con.Close();

        GridView1.DataBind();
    }
    protected void paixu_Click(object sender, EventArgs e)//计算排名
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
      int a=  GridView1.Rows.Count;//或的行数
      for (int i = 1; i <= a; i++)
      {

          string yundongyuanID = ((GridView1.Rows[i-1].Cells[1])).Text.ToString().Trim();//运动员号码
 string richengID = ((GridView1.Rows[i-1].Cells[16])).Text.ToString().Trim();//日程号
          int richeng = Convert.ToInt32(richengID);
          sql = "update 竞赛分组表 set 赛程名次="+i+ " where 日程号=" + richeng + " and 运动员号码='" + yundongyuanID + "'";

          con.Open();
          SqlCommand dbCommand = new SqlCommand(sql, con);
          dbCommand.ExecuteNonQuery();
          con.Close();
      }
      GridView1.DataBind();
    }
    protected double changetonum1(int richeng, string text)//成绩文本转换
    { 
         double num=0;
        if (getLEIXING(richeng) == 1)//电子计时 即时间转化
        {
            int loc = text.IndexOf(":");
            if (loc != -1)
            {
                string a = text.Substring(0, loc);
                num = 60 * Convert.ToDouble(a);
            }
            string b = text.Substring(loc + 1);
            if(b!="")
            num = num + Convert.ToDouble(b);
        }
        else //手动
        { 
            if(text!="")
            num = num + Convert.ToDouble(text); 
        }
        return num;
    }
    protected double changetonum(int richeng, string text)//成绩文本转换
    {
        double num=0;
        char[] t;
        if (getLEIXING(richeng) == 1)//电子计时 即时间转化
        {
            t = text.ToCharArray();
            int loc = text.IndexOf(":");
            int loc1 = text.IndexOf(".");
            int l=text.Length;
            if (loc != -1)
            {
                if (loc == 2)//XX:XX.XX
                {
                    num = 60 * ( (t[0]-48) * 10 + t[1]-48);
                    if(loc1!=-1)
                    {
                        if(loc1-loc==3)//XX:XX.XX
                        {
                          num=num+(t[3]-48)*10+t[4]-48+((t[6]-48)*10+t[7]-48)*0.01;
                        }
                        else if (loc1 - loc == 2)//XX:X.XX
                        {
                            num = num + t[3]-48  + ((t[5]-48) * 10 + t[6]-48) * 0.01;
                        }
                     }
                    else 
                    {
                        if (l == 5)
                            num = num + 10 * (t[3]-48) + t[4]-48;
                        else if (l == 4) num = num + t[3]-48;
                    }
                 }
                else if (loc == 1)//X:XX.XX
                {
                    num = 60 * (t[1]-48);
                    if (loc1 != -1)
                    {
                        if (loc1 - loc == 3)//XX:XX.XX
                        {
                            num = num + (t[2]-48) * 10 + t[3]-48 + ((t[5]-48) * 10 + t[6]-48) * 0.01;
                        }
                        else if (loc1 - loc == 2)//XX:X.XX
                        {
                            num = num + t[2]-48 + ((t[4]-48) * 10 + t[5]-48) * 0.01;
                        }
                    }
                    else
                    {
                        if (l == 4)
                            num = num + 10 * (t[2]-48) + t[3]-48;
                        else if (l == 3) num = num + t[2]-48;
                    }
                }
            }
            else
            {
                num = Convert.ToDouble(text);
            }
        }
        return num;
    }
    public int getLEIXING(int richengID)//获得项目记录方式（日程号）
    {
        string mysql = "SELECT 项目编码表.记录方式 FROM 项目编码表 INNER JOIN 竞赛日程表 ON 项目编码表.项目编号 = 竞赛日程表.项目编号 INNER JOIN 竞赛分组表 ON 竞赛日程表.日程号 = 竞赛分组表.日程号 where 竞赛日程表.日程号=" + richengID + "";
        SqlConnection con = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
        int leixing = Convert.ToInt32(SqlHelper.ExecuteScalar(mysql, con));
        return leixing;
    }
}
