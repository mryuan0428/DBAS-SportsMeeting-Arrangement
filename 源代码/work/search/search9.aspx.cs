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

public partial class work_search_search9 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string query = "SELECT * FROM 详细分组表";
        //SqlConnection myConnection = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        //SqlDataAdapter ad = new SqlDataAdapter(query, myConnection);
        //DataSet ds = new DataSet();
        //ad.Fill(ds);
        //GridView1.DataSource = ds;
        //GridView1.DataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)//button event
    {
        if (e.CommandName == "print")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = GridView1.Rows[index];
            TableCell contactname = new TableCell();
            int daoshu =Convert.ToInt32( selectedRow.Cells[5].Text);//获得组数
            string xiangmuName = selectedRow.Cells[2].Text;//获得项目名
            string contact0;
            if (daoshu != 0)//竞赛
            {
                contactname = selectedRow.Cells[1];//获得编号
                contact0 = contactname.Text;//日程编号
                string mysql = "select count(*) from 详细分组表  where 日程号=" + Convert.ToInt32(contact0) + " ";
                SqlConnection con = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
                SqlDataReader reader = SqlHelper.ExecuteReader(mysql, con);
                reader.Read();
                int count = Convert.ToInt32(reader[0]);//获得组数
                for (int i = 0; i < count; i++)
                {
                    print(Convert.ToInt32(contact0), i + 1);
                }
            }
            else//田赛
            {
                contactname = selectedRow.Cells[1];//获得编号
                contact0 = contactname.Text;//日程编号
                print1(Convert.ToInt32(contact0));
            }
        
        }
        else if (e.CommandName == "toword")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = GridView1.Rows[index];
            TableCell contactname = new TableCell();
            int daoshu = Convert.ToInt32(selectedRow.Cells[5].Text);//获得项目名
            string xiangmuName = selectedRow.Cells[2].Text;//获得项目名
            string contact0;
            if (daoshu != 0)//径赛
            {
                contactname = selectedRow.Cells[1];//获得编号
                contact0 = contactname.Text;//日程编号
                string mysql = "select count(*) from 详细分组表  where 日程号=" + Convert.ToInt32(contact0) + " ";
                SqlConnection con = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
                SqlDataReader reader = SqlHelper.ExecuteReader(mysql, con);
                reader.Read();
                int count = Convert.ToInt32(reader[0]);//获得组数

                Microsoft.Office.Interop.Word.ApplicationClass oWordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                object oTemplate = Server.MapPath("~/mb/径赛检录表.DOT");
                object readOnly = false;
                // oWordApp.Visible = true;//是否在服务器上显示生成过程
                object missing = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Word.Document oWordDoc = oWordApp.Documents.Add(ref oTemplate, ref missing, ref missing, ref missing);//打开dot 模板文件 
                oWordDoc.Activate();

                for (int i = 0; i < count; i++)
                {
                    printword(Convert.ToInt32(contact0), i + 1, oWordApp, oWordDoc);
                }
                object filename = Server.MapPath("~/mb/TEMP.DOC");
                oWordDoc.SaveAs(ref filename, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                oWordDoc.Close(ref missing, ref missing, ref missing);
                oWordApp.Application.Quit(ref missing, ref missing, ref missing);
                string strFile = "~/mb/TEMP.DOC";//注意你的文件的路径   
                Response.Clear();
                Response.ClearHeaders();
                Response.Charset = "GB2312";
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                Response.ContentType = "application/msword";
                Response.WriteFile(filename.ToString());   //提示下载
            }
            else//田赛
            {

                contactname = selectedRow.Cells[1];//获得编号
                contact0 = contactname.Text;//日程编号
                print1word(Convert.ToInt32(contact0));
            }

            
        }
    }
    protected void print1(int richengID)//田赛
    {

        string query = "select  竞赛分组表.运动员号码 ,报名表.姓名,参赛队报名表.参赛队简称 from 竞赛分组表 ,报名表 ,参赛队报名表 where 竞赛分组表.运动员号码=报名表.运动员号码 and 报名表.参赛队编号=参赛队报名表.参赛队编号 and 日程号=" + richengID + "order by 竞赛分组表.运动员号码";
        SqlConnection myConnection = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
        SqlDataReader r = SqlHelper.ExecuteReader(query, myConnection);
        int i = 1;
        ArrayList al = new ArrayList();
        int a=  getNUMOFPART(richengID);//获得本项目参赛队总数
       int b= getNUMOFmaxnum();//单项目最多报名人数
       while (r.Read())
       {
           if (al.Count == 0) al.Add(r["运动员号码"].ToString());
           else
           {
               if (al.Count % b != 0 && getPART(al[al.Count - 1].ToString()) != getPART(r["运动员号码"].ToString()))
               {
                   while (al.Count % b != 0)
                       al.Add("no");//补齐
               }
               al.Add(r["运动员号码"].ToString());
           }
       }
            //构成类似二维数组并按运动会中斜线法进行运动员数序的排序
        while (al.Count % b != 0)
            al.Add("no");//补齐
        ArrayList alb=new ArrayList();

        int m = 0, n = 0, temp = 0;//斜线分组m代表列数，n代表行数
        for (m = 0; m < b; m++)
        {
            temp = m;
            for (n = 0; n < a; n++)
            {
                if (temp == b) { temp = 0; }//行数最大后归零
                //if (n == a) { n = 0;  }//列数最大后归零
                alb.Add(al[n * 5 + temp]);
                temp++;
            }
        }
        //int m = 0, n = 0;
        //for(i=0;i<a*b;i++)
        //    {
        //        if (m == a) m = 0;
        //        if (n == b) n = 0;
        //        alb.Add(al[b*m+ n]);
        //        m++; 
        //        n++;
        //    }

        //打印排好序的
            Response.Write("<p align=center>田赛远度成绩记录表</p>");
            Response.Write("<table border=1 cellspacing=0 bordercolor=#000000 align=center>");
            Response.Write("<tr align=left><td colspan=13>");
            Response.Write("项目名称:");
            Response.Write(getSex(richengID) + getZUBIE(richengID) + getXMMC(richengID));
            Response.Write("  赛程:");
            Response.Write(getLEIXING(richengID));
            Response.Write("  第1组");
            Response.Write("</td></tr>");
            //   Response.Write("<tr><td width=10>序号</td><td width=80>序号</td><td width=80>单位</td><td><tr><td colspan=3>预赛成绩</td></tr><tr><td width=20>1</td><td width=20>2</td><td width=20>3</td></tr></td><td width=80>备注</td>");
            Response.Write(" <tr>    <td width='20' rowspan='2'>序号</td>    <td width='20' rowspan='2'>号码</td>    <td width='20' rowspan='2'>姓名</td>    <td width='20' rowspan='2'>单位</td>    <td colspan='3'>预赛成绩</td>    <td colspan='3'>决赛成绩</td>    <td width='20' rowspan='2'>最优成绩</td>    <td width='20' rowspan='2'>名次</td>    <td width='20' rowspan='2'>备注</td>  </tr>  <tr>    <td width='20'>1</td>    <td width='20'>2</td>    <td width='20'>3</td>    <td width='20'>1</td>    <td width='20'>2</td>    <td width='20'>3</td>  </tr>");
            i = 1;   
        for (int j = 0; j < alb.Count; j++)
            {
                if (alb[j].ToString() != "no")
                {
                    Response.Write("<tr>");
                    Response.Write("<td >" + i + "</td>");
                    Response.Write("<td >" + alb[j] + "</td>");
                    Response.Write("<td >" + getNAME(alb[j].ToString()) + "</td>");
                    Response.Write("<td >" + getPART(alb[j].ToString()) + "</td>");
                    for (int j0 = 0; j0 < 9; j0++)
                        Response.Write("<td >&nbsp;</td>");
                    i++;
                    Response.Write("</tr>");
                }
            }

            Response.Write("<tr><td colspan=13> 风速： &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;  风速记录员： &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;  记录：&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;  径赛裁判长：&nbsp;&nbsp;  &nbsp;&nbsp; &nbsp;&nbsp;  </td></tr>");
            Response.Write("</table>");
    }
  
    protected void print(int richengID,int zuci)//径赛
    {
             int  i;
             //Response.Write(" <script language='JavaScript'>window.open('about:blank','','fullscreen=1')</script>");
            Response.Write("<p align=center>径赛分组表</p>");
            Response.Write("<table border=1 cellspacing=0 bordercolor=#000000 align=center>");
            Response.Write("<tr align=left><td colspan=9>");
            Response.Write("项目名称:");
            Response.Write(getSex(richengID) + getZUBIE(richengID) + getXMMC(richengID));
            Response.Write("  赛程:");
            Response.Write(getLEIXING(richengID));
            Response.Write("  第"); Response.Write(zuci); Response.Write(" 组");
            Response.Write("</td></tr>");
            Response.Write("<tr><td width=80>道次</td>");
            for ( i = 1; i <= 8; i++)
            {
                Response.Write("<td width=80 align=center>" + i + "</td>");
            }
            Response.Write("</tr>");
            string query = "select * from 详细分组表 where 日程号=" + richengID + " and 组次=" + zuci + " ";
            SqlConnection myConnection = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
            SqlDataReader r = SqlHelper.ExecuteReader(query, myConnection);
            r.Read();
            ArrayList al = new ArrayList();
            for (i = 0; i < 8; i++)
            {
               
               al.Add( Convert.ToString(r["c" + Convert.ToString(i+1)]) );
            }
            for (int j = 1; j <= 6; j++)
            {
                switch (j)
                {
                    case 1: Response.Write("<tr><td width=80>号码</td>");
                        for (i = 0; i <8; i++)
                        {
                            if (al[i].ToString()  == "") Response.Write("<td align=center>&nbsp;</td>");
                            else Response.Write("<td align=center>" + al[i] + "</td>");
                        }
                        break;
                    case 2: Response.Write("<tr><td width=80>姓名</td>");
                        for (i = 0; i < 8; i++)
                        {
                            if (al[i].ToString() == "") Response.Write("<td align=center>&nbsp;</td>");
                            else Response.Write("<td align=center>" +getNAME(al[i].ToString()) + "</td>");
                        }
                        break;
                    case 3: Response.Write("<tr><td width=80>单位</td>");
                        for (i = 0; i < 8; i++)
                        {
                            if (al[i].ToString() == "") Response.Write("<td align=center>&nbsp;</td>");
                            else Response.Write("<td align=center>" + getPART(al[i].ToString()) + "</td>");
                        }
                        break;
                    case 4: Response.Write("<tr><td width=80>成绩</td>");
                        for (i = 0; i < 8; i++)
                        {
                            Response.Write("<td align=center>&nbsp;</td>");
                        }
                        break;
                    case 5: Response.Write("<tr><td width=80>名次</td>");
                        for (i = 0; i < 8; i++)
                        {
                            Response.Write("<td align=center>&nbsp;</td>");
                        }
                        break;
                    case 6: Response.Write("<tr><td width=80>备注</td>");
                        for (i = 0; i < 8; i++)
                        {
                            Response.Write("<td align=center>&nbsp;</td>");
                        }
                        break;
                }
                
            }
            
            Response.Write("</tr>");
            Response.Write("<tr><td colspan=9> 风速： &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;  风速记录员： &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;  记录：&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;  径赛裁判长：&nbsp;&nbsp;  &nbsp;&nbsp; &nbsp;&nbsp;  </td></tr>");
            myConnection.Close();
            Response.Write("</table>");
            
        //}
        //con1.Close();
    }
    public string getXMMC(int richengID)//获得项目名称（日程号）
    {
        string mysql = "select 项目名称 from 项目编码表 where 项目编号=(select 项目编号 from 竞赛日程表 where 日程号='" + richengID + "')";
        SqlConnection con = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
        string name = Convert.ToString(SqlHelper.ExecuteScalar(mysql, con));
        con.Close();
        return name;
    }
    public String getSex(int richengID)//获得项目性别（日程号）
    {
        string mysql = "select 男女子项目 from 项目编码表 where 项目编号=(select 项目编号 from 竞赛日程表 where 日程号='" + richengID + "')";
        SqlConnection con = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
        int sex = Convert.ToInt32(SqlHelper.ExecuteScalar(mysql, con));
        con.Close();
        if (sex == 1) return "男子";
        else return "女子";
    }
    public String getZUBIE(int richengID)//获得项目组别（日程号）
    {
        string mysql = "select 组别 from 竞赛日程表 where 日程号='" + richengID + "'";
        SqlConnection con = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
        string zubie = Convert.ToString(SqlHelper.ExecuteScalar(mysql, con));
        con.Close();
        return zubie;
    }
    public String getLEIXING(int richengID)//获得项目赛程类型（日程号）
    {
        string mysql = "select 赛程类型 from 竞赛日程表 where 日程号='" + richengID + "'";
        SqlConnection con = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
        string leixing = Convert.ToString(SqlHelper.ExecuteScalar(mysql, con));
        con.Close();
        return leixing;
    }
    public String getNAME(string ID)//获得运动员姓名
    {
        string mysql = "select 姓名 from 报名表 where 运动员号码='" + ID + "'";
        SqlConnection con = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
        string leixing = Convert.ToString(SqlHelper.ExecuteScalar(mysql, con));
        con.Close();
        return leixing;
    }
    public String getPART(string  ID)//获得运动员单位
    {
        string mysql = "select 参赛队报名表.参赛队简称 from 报名表,参赛队报名表 where 报名表.运动员号码='" + ID + "' and 报名表.参赛队编号=参赛队报名表.参赛队编号";
        SqlConnection con = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
        string leixing = Convert.ToString(SqlHelper.ExecuteScalar(mysql, con));
        con.Close();
        return leixing;
    }
    public int getNUMOFPART( int richengID)//获得参赛单位数
    {
        string mysql = "SELECT COUNT(*) AS MAX FROM (SELECT DISTINCT 参赛队报名表.参赛队简称 FROM 竞赛分组表, 报名表, 参赛队报名表  WHERE 竞赛分组表.运动员号码 = 报名表.运动员号码 AND 报名表.参赛队编号 = 参赛队报名表.参赛队编号 AND 日程号 = "+richengID+")   DERIVEDTBL ";
        SqlConnection con = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
        int leixing = Convert.ToInt32(SqlHelper.ExecuteScalar(mysql, con));
        con.Close();
        return leixing;
    }
    public int getNUMOFmaxnum()//获得单个项目最多报名人数
    {
        string mysql = "select 参数值 from 运动会竞赛规程 where 类型=2";
        SqlConnection con = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
        int leixing = Convert.ToInt32(SqlHelper.ExecuteScalar(mysql, con));
        con.Close();
        return leixing;
    }

    protected void printword(int richengID, int zuci, Microsoft.Office.Interop.Word.ApplicationClass oWordApp, Microsoft.Office.Interop.Word.Document oWordDoc)//径赛
    {
      object missing = System.Reflection.Missing.Value;
        //  try
       // {
            
            string numzuci = zuci.ToString();
              object oBookMark = "项目名称"+numzuci;
            object what = Microsoft.Office.Interop.Word.WdGoToItem.wdGoToBookmark;
            object unit1 = missing;
            object count1 = 1;
            object extend1 = Microsoft.Office.Interop.Word.WdMovementType.wdMove;
            //   oWordApp.=oWordDoc.Bookmarks.get_Item(ref oBookMark).Range;

            oWordApp.Selection.GoTo(ref what, ref missing, ref missing, ref oBookMark);
            oWordApp.Selection.TypeText(getSex(richengID) + getZUBIE(richengID) + getXMMC(richengID));//项目名
            oBookMark = "sc" + numzuci;
            oWordApp.Selection.GoTo(ref what, ref missing, ref missing, ref oBookMark);
            oWordApp.Selection.TypeText(getLEIXING(richengID));//赛程
            oBookMark = "zc" + numzuci;
            oWordApp.Selection.GoTo(ref what, ref missing, ref missing, ref oBookMark);//组次
            oWordApp.Selection.TypeText(numzuci);
            //oBookMark = "t" + numzuci + "_n2";
            //oWordApp.Selection.GoTo(ref what, ref missing, ref missing, ref oBookMark);
            //oWordApp.Selection.TypeText("10003");

            string query = "select * from 详细分组表 where 日程号=" + richengID + " and 组次=" + zuci + " ";
            SqlConnection myConnection = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
            SqlDataReader r = SqlHelper.ExecuteReader(query, myConnection);
            r.Read();
            ArrayList al = new ArrayList();
            int i;
            for (i = 0; i < 8; i++)
            {

                al.Add(Convert.ToString(r["c" + Convert.ToString(i + 1)]));
            }
            for (int j = 1; j <= 6; j++)
            {
                switch (j)
                {
                    case 1:// Response.Write("<tr><td width=80>号码</td>");
                        for (i = 0; i < 8; i++)
                        {
                            if (al[i].ToString() == "")
                            {

                            }//Response.Write("<td align=center>&nbsp;</td>");
                            else 
                            {
                                oBookMark = "t"+ numzuci+"_n"+ Convert.ToString(i+1);
                                oWordApp.Selection.GoTo(ref what, ref missing, ref missing, ref oBookMark);
                                oWordApp.Selection.TypeText(al[i].ToString());//赛程
                            }//Response.Write("<td align=center>" + al[i] + "</td>");
                        }
                        break;
                    case 2: //Response.Write("<tr><td width=80>姓名</td>");
                        for (i = 0; i < 8; i++)
                        {
                            if (al[i].ToString() == "") { }// Response.Write("<td align=center>&nbsp;</td>");
                            else
                            {
                                oBookMark = "t" + numzuci + "_m" + Convert.ToString(i + 1);
                                oWordApp.Selection.GoTo(ref what, ref missing, ref missing, ref oBookMark);
                                oWordApp.Selection.TypeText(getNAME(al[i].ToString()));//赛程
                            }//Response.Write("<td align=center>" + getNAME(al[i].ToString()) + "</td>");
                        }
                        break;
                    case 3: //Response.Write("<tr><td width=80>单位</td>");
                        for (i = 0; i < 8; i++)
                        {
                            if (al[i].ToString() == "")
                            {

                            }//Response.Write("<td align=center>&nbsp;</td>");
                            else
                            {
                                oBookMark = "t" + numzuci + "_p" + Convert.ToString(i + 1);
                                oWordApp.Selection.GoTo(ref what, ref missing, ref missing, ref oBookMark);
                                oWordApp.Selection.TypeText(getPART(al[i].ToString()));//赛程
                            }// Response.Write("<td align=center>" + getPART(al[i].ToString()) + "</td>");
                        }
                        break;
                    //case 4: Response.Write("<tr><td width=80>成绩</td>");
                    //    for (i = 0; i < 8; i++)
                    //    {
                    //        Response.Write("<td align=center>&nbsp;</td>");
                    //    }
                    //    break;
                    //case 5: Response.Write("<tr><td width=80>名次</td>");
                    //    for (i = 0; i < 8; i++)
                    //    {
                    //        Response.Write("<td align=center>&nbsp;</td>");
                    //    }
                    //    break;
                    //case 6: Response.Write("<tr><td width=80>备注</td>");
                    //    for (i = 0; i < 8; i++)
                    //    {
                    //        Response.Write("<td align=center>&nbsp;</td>");
                    //    }
                        break;
                }

            }
        
    }
    protected void print1word(int richengID)//田赛
    {
        string query = "select  竞赛分组表.运动员号码 ,报名表.姓名,参赛队报名表.参赛队简称 from 竞赛分组表 ,报名表 ,参赛队报名表 where 竞赛分组表.运动员号码=报名表.运动员号码 and 报名表.参赛队编号=参赛队报名表.参赛队编号 and 日程号=" + richengID + "order by 竞赛分组表.运动员号码";
        SqlConnection myConnection = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
        SqlDataReader r = SqlHelper.ExecuteReader(query, myConnection);
        int i = 1;
        ArrayList al = new ArrayList();
        int a = getNUMOFPART(richengID);//获得本项目参赛队总数
        int b = getNUMOFmaxnum();//单项目最多报名人数
        while (r.Read())
        {
            if (al.Count == 0) al.Add(r["运动员号码"].ToString());
            else
            {
                if (al.Count % b != 0 && getPART(al[al.Count - 1].ToString()) != getPART(r["运动员号码"].ToString()))
                {
                    while (al.Count % b != 0)
                        al.Add("no");//补齐
                }
                al.Add(r["运动员号码"].ToString());
            }
        }
        //构成类似二维数组并按运动会中斜线法进行运动员数序的排序
        while (al.Count % b != 0)
            al.Add("no");//补齐
        ArrayList alb = new ArrayList();

        int m = 0, n = 0, temp = 0;//斜线分组m代表列数，n代表行数
        for (m = 0; m < b; m++)
        {
            temp = m;
            for (n = 0; n < a; n++)
            {
                if (temp == b) { temp = 0; }//行数最大后归零
                //if (n == a) { n = 0;  }//列数最大后归零
                alb.Add(al[n * 5 + temp]);
                temp++;
            }
        }
        //int m = 0, n = 0;
        //for (i = 0; i < a * b; i++)
        //{
        //    if (m == a) m = 0;
        //    if (n == b) n = 0;
        //    alb.Add(al[b * m + n]);
        //    m++;
        //    n++;
        //}

        Microsoft.Office.Interop.Word.ApplicationClass oWordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
        object oTemplate = Server.MapPath("~/mb/田赛检录表.DOT");
        object readOnly = false;
        //oWordApp.Visible = true;
        object missing = System.Reflection.Missing.Value;
        Microsoft.Office.Interop.Word.Document oWordDoc = oWordApp.Documents.Add(ref oTemplate, ref missing, ref missing, ref missing);//打开dot 模板文件 
        oWordDoc.Activate();

        //打印排好序的
        object oBookMark = "xm" ;
        object what = Microsoft.Office.Interop.Word.WdGoToItem.wdGoToBookmark;
        object unit1 = missing;
        object count1 = 1;
        object extend1 = Microsoft.Office.Interop.Word.WdMovementType.wdMove;
        //   oWordApp.=oWordDoc.Bookmarks.get_Item(ref oBookMark).Range;

        oWordApp.Selection.GoTo(ref what, ref missing, ref missing, ref oBookMark);
        oWordApp.Selection.TypeText(getSex(richengID) + getZUBIE(richengID) + getXMMC(richengID));//项目名
        oBookMark = "zb";
        oWordApp.Selection.GoTo(ref what, ref missing, ref missing, ref oBookMark);
        oWordApp.Selection.TypeText(getLEIXING(richengID));//赛程
        oBookMark = "sum";
        oWordApp.Selection.GoTo(ref what, ref missing, ref missing, ref oBookMark);//人数
        oWordApp.Selection.TypeText("??");


     // Response.Write(" <tr>    <td width='20' rowspan='2'>序号</td>    <td width='20' rowspan='2'>号码</td>    <td width='20' rowspan='2'>姓名</td>    <td width='20' rowspan='2'>单位</td>    <td colspan='3'>预赛成绩</td>    <td colspan='3'>决赛成绩</td>    <td width='20' rowspan='2'>最优成绩</td>    <td width='20' rowspan='2'>名次</td>    <td width='20' rowspan='2'>备注</td>  </tr>  <tr>    <td width='20'>1</td>    <td width='20'>2</td>    <td width='20'>3</td>    <td width='20'>1</td>    <td width='20'>2</td>    <td width='20'>3</td>  </tr>");
        i = 1;
        for (int j = 0; j < alb.Count; j++)
        {
            if (alb[j].ToString() != "no")
            {
                //Response.Write("<tr>");
               // Response.Write("<td >" + i + "</td>");
                oBookMark = "n"+(i).ToString();
                oWordApp.Selection.GoTo(ref what, ref missing, ref missing, ref oBookMark);//人数
                oWordApp.Selection.TypeText(alb[j].ToString());
                oBookMark = "m" + (i).ToString();
                oWordApp.Selection.GoTo(ref what, ref missing, ref missing, ref oBookMark);//人数
                oWordApp.Selection.TypeText(getNAME(alb[j].ToString()).Trim());
                oBookMark = "p" + (i).ToString();
                oWordApp.Selection.GoTo(ref what, ref missing, ref missing, ref oBookMark);//人数
                oWordApp.Selection.TypeText(getPART(alb[j].ToString()).Trim());

                //Response.Write("<td >" + alb[j] + "</td>");
                //Response.Write("<td >" + getNAME(alb[j].ToString()) + "</td>");
                //Response.Write("<td >" + getPART(alb[j].ToString()) + "</td>");
                //for (int j0 = 0; j0 < 9; j0++)
                //    Response.Write("<td >&nbsp;</td>");
                i++;
                //Response.Write("</tr>");
            }
        }

        object filename = Server.MapPath("~/mb/TEMP.DOC");
        oWordDoc.SaveAs(ref filename, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
        oWordDoc.Close(ref missing, ref missing, ref missing);
        oWordApp.Application.Quit(ref missing, ref missing, ref missing);
        string strFile = "~/mb/TEMP.DOC";//注意你的文件的路径   
        Response.Clear();
        Response.ClearHeaders();
        Response.Charset = "GB2312";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "application/msword";
        Response.WriteFile(filename.ToString());   //提示下载
       // Response.Write("<tr><td colspan=13> 风速： &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;  风速记录员： &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;  记录：&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;  径赛裁判长：&nbsp;&nbsp;  &nbsp;&nbsp; &nbsp;&nbsp;  </td></tr>");
       // Response.Write("</table>");
     
    }
}
