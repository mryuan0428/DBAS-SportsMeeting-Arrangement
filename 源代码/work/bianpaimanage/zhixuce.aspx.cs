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
using Microsoft.Office.Interop.Word;
using System.Data.SqlClient;

public partial class work_bianpaimanage_zhixuce : System.Web.UI.Page
{
    private  int tablenum = 0;//记录word中table数量
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string state = CreateWordFile("a");
        Response.Write("<script>alert('" + state + "')</script>");
    }
    public string CreateWordFile(string CheckedInfo)
    {
        string message = "";
        try
        {
            object missing = Type.Missing;
            object iStart = 0;
            object iEnd = 0;
            object wLine = Microsoft.Office.Interop.Word.WdBreakType.wdLineBreak;
            object wPage = Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak;
            Microsoft.Office.Interop.Word.Application app1 = new Application();
            app1.Visible = true;
            Microsoft.Office.Interop.Word.Document doc1 = app1.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            Microsoft.Office.Interop.Word.Range rng1 = doc1.Range(ref iStart, ref iEnd);
            rng1.Text = getguichegntext();//规程
            rng1.Start = rng1.End;
            rng1.InsertBreak(ref wLine);//换行
            rng1.Text = "参赛队统计表";
            rng1.Font.Size = 18;
            rng1.Font.Bold = 3;
            rng1.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
            rng1.Start = rng1.End;
            rng1.InsertBreak(ref wLine);//换行
            rng1.Start = printbaomingbiao(doc1, app1, rng1);
            rng1.Start = rng1.End;
            rng1.InsertBreak(ref wLine);//换行
            rng1.Text = "比赛日程统计表";
            rng1.Font.Size = 18;
            rng1.Font.Bold = 3;
            rng1.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
            rng1.Start = rng1.End;
            rng1.InsertBreak(ref wLine);//换行
            rng1.Text = "径赛";
            rng1.Font.Size = 18;
            rng1.Font.Bold = 3;
            rng1.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
            rng1.Start = rng1.End;
            rng1.Start = printrichengbiao(doc1, app1, rng1, 1);//径赛
            rng1.InsertBreak(ref wLine);//换行
            rng1.Text = "田赛";
            rng1.Font.Size = 18;
            rng1.Font.Bold = 3;
            rng1.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
            rng1.Start = rng1.End;
            rng1.Start = printrichengbiao(doc1, app1, rng1, 0);//田赛
            rng1.InsertBreak(ref wLine);//换行
            rng1.Text = "竞赛分组表";
            rng1.Font.Size = 18;
            rng1.Font.Bold = 3;
            rng1.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
            rng1.Start = rng1.End;
            printfenzubiao(doc1, app1, rng1);
             rng1.InsertBreak(ref wLine);//换行
            rng1.Text = "田赛分组表";
            rng1.Font.Size = 18;
            rng1.Font.Bold = 3;
            rng1.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
            rng1.Start = rng1.End;
            printfenzubiao1(doc1, app1, rng1);

            object filename = Server.MapPath("~/mb/zhixuce.DOC");
            doc1.SaveAs(ref filename, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
            //oWordDoc.Close(ref missing, ref missing, ref missing);
            //oWordApp.Application.Quit(ref missing, ref missing, ref missing);
            //string strFile = "~/mb/TEMP.DOC";//注意你的文件的路径   
            //Response.Clear();
            //Response.ClearHeaders();
            //Response.Charset = "GB2312";
            //Response.ContentEncoding = System.Text.Encoding.UTF8;
            //Response.ContentType = "application/msword";
            //Response.WriteFile(filename.ToString());   //提示下载
            doc1.Close(ref missing, ref missing, ref missing);
            app1.Quit(ref missing, ref missing, ref missing);
            message = "文件导出成功！请下载。";
        }
        catch
        {
            message = "文件导出异常！";
        }
        return message;
    }
  //  SELECT * FROM [规程文本]
          protected string getguichegntext()//获得规程文本
    {
        string query = "SELECT 规程 FROM [规程文本]";
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        myConnection.Open();
        SqlDataAdapter ad = new SqlDataAdapter(query, myConnection);
        SqlCommand cmd = new SqlCommand(query, myConnection);
        return Convert.ToString(cmd.ExecuteScalar());
    }
    //SELECT * FROM [参赛队报名表]
    private int printbaomingbiao(Microsoft.Office.Interop.Word.Document WordDoc, Microsoft.Office.Interop.Word.Application WordApp, Microsoft.Office.Interop.Word.Range rng)//报名表打印
    {
        tablenum++;//记录table数量
        Object Nothing = System.Reflection.Missing.Value;

        Microsoft.Office.Interop.Word.Table newTable = WordDoc.Tables.Add(rng, 1, 9, ref Nothing, ref Nothing);
        newTable.Range.Start = rng.End;
        //设置表格样式
        newTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleThickThinLargeGap;
        newTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        //newTable.Columns[1].Width = 100f;
        //newTable.Columns[2].Width = 220f;
        //newTable.Columns[3].Width = 105f;
        newTable.Cell(1, 1).Range.Text = "序号";
        newTable.Cell(1, 2).Range.Text = "参赛队(简称)";
        newTable.Cell(1, 3).Range.Text = "领队";
        newTable.Cell(1, 4).Range.Text = "教练员";
        newTable.Cell(1, 5).Range.Text = "男";
        newTable.Cell(1, 6).Range.Text = "女";
        newTable.Cell(1, 7).Range.Text = "总";
        newTable.Cell(1, 8).Range.Text = "起止编号";
        newTable.Cell(1, 9).Range.Text = "组别";
        int count=1;
        { 
                SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
                con1.Open();
                string mysql1 = "SELECT  参赛队简称 ,领队 , 教练员 , 男子数 , 女子数 , 运动员总数, 运动员起始编号 , 运动员截止编号, 组别  FROM 参赛队报名表";
                SqlCommand dbCommand1 = new SqlCommand(mysql1, con1);
                SqlDataReader reader1 = dbCommand1.ExecuteReader();
                while (reader1.Read())
                {
                    count++;
                    WordDoc.Content.Tables[tablenum].Rows.Add(ref Nothing);
                   newTable.Cell(count, 1).Range.Text = (count-1).ToString();
                    newTable.Cell(count, 2).Range.Text =reader1["参赛队简称"].ToString();
                    newTable.Cell(count, 3).Range.Text = reader1["领队"].ToString();
                    newTable.Cell(count, 4).Range.Text = reader1["教练员"].ToString();
                    newTable.Cell(count, 5).Range.Text = reader1["男子数"].ToString();
                    newTable.Cell(count, 6).Range.Text = reader1["女子数"].ToString();
                    newTable.Cell(count, 7).Range.Text = reader1["运动员总数"].ToString();
                    newTable.Cell(count, 8).Range.Text = reader1["运动员起始编号"].ToString() + "-" + reader1["运动员截止编号"].ToString();
                    newTable.Cell(count, 9).Range.Text = reader1["组别"].ToString();
                    
                }
                con1.Close();
            
        }

        return newTable.Range.End;
    }
    private int printrichengbiao(Microsoft.Office.Interop.Word.Document WordDoc, Microsoft.Office.Interop.Word.Application WordApp, Microsoft.Office.Interop.Word.Range rng,int istiansai )//日程表打印
    {
        tablenum++;//记录table数量
        Object Nothing = System.Reflection.Missing.Value;

        Microsoft.Office.Interop.Word.Table newTable = WordDoc.Tables.Add(rng, 1, 5, ref Nothing, ref Nothing);
        newTable.Range.Start = rng.End;
        //设置表格样式
        newTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleThickThinLargeGap;
        newTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        int count = 0;
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
            con1.Open();
            string mysql1 = "SELECT 参赛项目表.男女子项目, 竞赛日程表.组别, 参赛项目表.项目名称,"+
                "竞赛日程表.赛次, 竞赛日程表.参赛人数, 竞赛日程表.组数, 竞赛日程表.比赛时间,"+
                "参赛项目表.项目顺序 FROM 竞赛日程表 INNER JOIN  参赛项目表 ON 竞赛日程表.项目编号 = 参赛项目表.项目编号 "+
                "INNER JOIN   项目编码表 ON 参赛项目表.项目编号 = 项目编码表.项目编号 WHERE (项目编码表.项目类别 = "+istiansai+")"+
                "ORDER BY 参赛项目表.项目顺序";
            SqlCommand dbCommand1 = new SqlCommand(mysql1, con1);
            SqlDataReader reader1 = dbCommand1.ExecuteReader();
            while (reader1.Read())
            {
                string sex="男子";
                string saici="决赛";
                count++;
                WordDoc.Content.Tables[tablenum].Rows.Add(ref Nothing);
                newTable.Cell(count, 1).Range.Text = (count).ToString();
                if(reader1["男女子项目"].ToString()!="1")sex="女子";
                if(reader1["赛次"].ToString()=="0")saici="预初赛";
                newTable.Cell(count, 2).Range.Text = sex+reader1["组别"].ToString()+reader1["项目名称"].ToString()+saici;
                newTable.Cell(count, 3).Range.Text = reader1["参赛人数"].ToString();
                newTable.Cell(count, 4).Range.Text = reader1["组数"].ToString();
                newTable.Cell(count, 5).Range.Text = reader1["比赛时间"].ToString();
            }
            con1.Close();
        }
        return newTable.Range.End;       
    }
    //
    private int printfenzubiao(Microsoft.Office.Interop.Word.Document WordDoc, Microsoft.Office.Interop.Word.Application WordApp, Microsoft.Office.Interop.Word.Range rng)
    //分组表打印--径赛
    {
       
      //  int count = 0;
        int returnvalue = 0;
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
            con1.Open();
            string mysql1 = "SELECT 日程号, COUNT(日程号) AS 组数 FROM 详细分组表 GROUP BY 日程号 ORDER BY 日程号";
            SqlCommand dbCommand1 = new SqlCommand(mysql1, con1);
            SqlDataReader reader1 = dbCommand1.ExecuteReader();
            while (reader1.Read())
            {
                int index = Convert.ToInt32(reader1["日程号"]);
              //  GridViewRow selectedRow = GridView1.Rows[index];
              //  TableCell contactname = new TableCell();
                int zushu = Convert.ToInt32(reader1["组数"]);//获得组数
               // string xiangmuName = selectedRow.Cells[2].Text;//获得项目名
               // string contact0;
                //if (daoshu != 0)//竞赛
                //{
                 //   contactname = selectedRow.Cells[1];//获得编号
                //    contact0 = contactname.Text;//日程编号
                    //string mysql = "select count(*) from 详细分组表  where 日程号=" + index + " ";
                    //SqlConnection con = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
                    //SqlDataReader reader = SqlHelper.ExecuteReader(mysql, con);
                    //reader.Read();
                    for (int i = 0; i < zushu ; i++)
                    {
                        returnvalue = print(Convert.ToInt32(index), i + 1, rng, WordDoc, WordApp);
                        rng.Start = returnvalue;
                        rng.Text = "\n\n";
                        rng.Start = rng.End;
                    }
                //}
                //else//田赛
                //{
                    //contactname = selectedRow.Cells[1];//获得编号
                    //contact0 = contactname.Text;//日程编号
                    //print1(Convert.ToInt32(contact0));
                //}
            }
            con1.Close();

        }
        return rng.End;
    }
    protected int print(int richengID, int zuci,Microsoft.Office.Interop.Word.Range rng,Microsoft.Office.Interop.Word.Document WordDoc, Microsoft.Office.Interop.Word.Application WordApp)
    //径赛
    {
        tablenum++;//记录table数量
        Object Nothing = System.Reflection.Missing.Value;

        Microsoft.Office.Interop.Word.Table newTable = WordDoc.Tables.Add(rng, 2, 9, ref Nothing, ref Nothing);
        newTable.Range.Start = rng.End;
        //设置表格样式
        newTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleThickThinLargeGap;
        newTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        int i;
        newTable.Cell(1, 1).Merge(newTable.Cell(1, 9));
        newTable.Cell(1,1).Range.Text="项目名称:"+getSex(richengID) + getZUBIE(richengID) + getXMMC(richengID)+"  第"+zuci+" 组";
        int count=1;
       
        count++;
        WordDoc.Content.Tables[tablenum].Rows.Add(ref Nothing);
        //newTable.Cell(1,2)
        //Response.Write(" <script language='JavaScript'>window.open('about:blank','','fullscreen=1')</script>");
       // Response.Write("<p align=center>径赛分组表</p>");
        //Response.Write("<table border=1 cellspacing=0 bordercolor=#000000 align=center>");
        //Response.Write("<tr align=left><td colspan=9>");
        //Response.Write("项目名称:");
        //Response.Write(getSex(richengID) + getZUBIE(richengID) + getXMMC(richengID));
        //Response.Write("  赛程:");
        //Response.Write(getLEIXING(richengID));
        //Response.Write("  第"); Response.Write(zuci); Response.Write(" 组");
        //Response.Write("</td></tr>");
        //Response.Write("<tr><td width=80>道次</td>");

        newTable.Cell(count,1).Range.Text="组\\道";
        for (i = 2; i <= 9; i++)
        {
            newTable.Cell(count,i).Range.Text=(i-1).ToString();
            //Response.Write("<td width=80 align=center>" + i + "</td>");
        }
        ////Response.Write("</tr>");
        string query = "select * from 详细分组表 where 日程号=" + richengID + " and 组次=" + zuci + " ";
        SqlConnection myConnection = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
        SqlDataReader r = SqlHelper.ExecuteReader(query, myConnection);
        r.Read();
        ArrayList al = new ArrayList();
        for (i = 0; i < 8; i++)
        {

            al.Add(Convert.ToString(r["c" + Convert.ToString(i + 1)]));
        }
        for (int j = 1; j <= 3; j++)
        {
            switch (j)
            {
                case 1: 
                    //Response.Write("<tr><td width=80>号码</td>");
                    count++;
                    WordDoc.Content.Tables[tablenum].Rows.Add(ref Nothing);
                    for (i = 0; i < 8; i++)
                    {
                        if (al[i].ToString().Trim() != "") 
                            //Response.Write("<td align=center>&nbsp;</td>");

                        //else //Response.Write("<td align=center>" + al[i] + "</td>");
                            newTable.Cell(count, i+2).Range.Text = al[i].ToString();
                    }
                    break;
                case 2: 
                    //Response.Write("<tr><td width=80>姓名</td>");
                    count++;
                    WordDoc.Content.Tables[tablenum].Rows.Add(ref Nothing);
                    for (i = 0; i < 8; i++)
                    {
                        if (al[i].ToString().Trim() != "")// Response.Write("<td align=center>&nbsp;</td>");
                            newTable.Cell(count, i + 2).Range.Text = getNAME(al[i].ToString());
                        //else Response.Write("<td align=center>" + getNAME(al[i].ToString()) + "</td>");
                    }
                    break;
                case 3: 
                    //Response.Write("<tr><td width=80>单位</td>");
                    count++;
                    WordDoc.Content.Tables[tablenum].Rows.Add(ref Nothing);
                    for (i = 0; i < 8; i++)
                    {
                        if (al[i].ToString().Trim() != "") 
                            //Response.Write("<td align=center>&nbsp;</td>");
                            newTable.Cell(count, i + 2).Range.Text = getPART(al[i].ToString());
                            //else Response.Write("<td align=center>" + getPART(al[i].ToString()) + "</td>");
                    }
                    break;

            }

        }
        return newTable.Range.End;
    }
    private int printfenzubiao1(Microsoft.Office.Interop.Word.Document WordDoc, Microsoft.Office.Interop.Word.Application WordApp, Microsoft.Office.Interop.Word.Range rng)
    //分组表打印--田赛
    {

        //  int count = 0;
        int returnvalue = 0;
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
            con1.Open();
            string mysql1 = "SELECT 日程号 FROM 竞赛分组表 WHERE (组次 = 0) GROUP BY 日程号 ORDER BY 日程号";
            SqlCommand dbCommand1 = new SqlCommand(mysql1, con1);
            SqlDataReader reader1 = dbCommand1.ExecuteReader();
            while (reader1.Read())
            {
                int index = Convert.ToInt32(reader1["日程号"]);
        
                returnvalue = print1(Convert.ToInt32(index), rng, WordDoc, WordApp);
                rng.Start = returnvalue;
                rng.Text = "\n\n";
                rng.Start = rng.End;

            }
            con1.Close();

        }
        return rng.End;
    }
    protected int print1(int richengID, Microsoft.Office.Interop.Word.Range rng, Microsoft.Office.Interop.Word.Document WordDoc, Microsoft.Office.Interop.Word.Application WordApp)
    //田赛
    {
        tablenum++;//记录table数量
        Object Nothing = System.Reflection.Missing.Value;

        Microsoft.Office.Interop.Word.Table newTable = WordDoc.Tables.Add(rng, 2, 9, ref Nothing, ref Nothing);
        newTable.Range.Start = rng.End;
        //设置表格样式
        newTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleThickThinLargeGap;
        newTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        int i;
        newTable.Cell(1, 1).Merge(newTable.Cell(1, 9));
        newTable.Cell(1, 1).Range.Text = "项目名称:" + getSex(richengID) + getZUBIE(richengID) + getXMMC(richengID) + "  第1 组";
        int count = 1;

        count++;
       // WordDoc.Content.Tables[tablenum].Rows.Add(ref Nothing);

        string query = "select * from 竞赛分组表 where 日程号=" + richengID +" and (组次 = 0) ORDER BY 日程号, 道次";
     //   int numofpe = getNNUMOFPE(richengID);
        SqlConnection myConnection = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
        SqlDataReader r = SqlHelper.ExecuteReader(query, myConnection);
         ArrayList al = new ArrayList();
        while (r.Read())
        { 
          al.Add(Convert.ToString(r["运动员号码"]));
        };
        int numofpe = al.Count;
        for (int m = 0; m <= numofpe/8;m++ )
            for (int j = 1; j <= 3; j++)
            {
                switch (j)
                {
                    case 1:
                        //Response.Write("<tr><td width=80>号码</td>");
                        count++;
                        WordDoc.Content.Tables[tablenum].Rows.Add(ref Nothing);
                        for (i = 0; i < 8; i++)
                        {
                            if ((m*8+i)<numofpe)
                                newTable.Cell(count, i + 2).Range.Text = al[m*8+i].ToString();
                        }
                        break;
                    case 2:
                        //Response.Write("<tr><td width=80>姓名</td>");
                        count++;
                        WordDoc.Content.Tables[tablenum].Rows.Add(ref Nothing);
                        for (i = 0; i < 8; i++)
                        {
                            if ((m*8+i) <numofpe)// Response.Write("<td align=center>&nbsp;</td>");
                                newTable.Cell(count, i + 2).Range.Text = getNAME(al[m*8+i].ToString());
                            //else Response.Write("<td align=center>" + getNAME(al[i].ToString()) + "</td>");
                        }
                        break;
                    case 3:
                        //Response.Write("<tr><td width=80>单位</td>");
                        count++;
                        WordDoc.Content.Tables[tablenum].Rows.Add(ref Nothing);
                        for (i = 0; i < 8; i++)
                        {
                            if ((m * 8 + i) < numofpe)
                                //Response.Write("<td align=center>&nbsp;</td>");
                                newTable.Cell(count, i + 2).Range.Text = getPART(al[m*8+i].ToString());
                            //else Response.Write("<td align=center>" + getPART(al[i].ToString()) + "</td>");
                        }
                        break;

                }

            }
        return newTable.Range.End;
    }
    public String getXMMC(int richengID)//获得项目名称（日程号）
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
    public int getNNUMOFPE(int richengID)//获得某个项目人数
    {
        string mysql = "select count(*) from 竞赛分组表 where 日程号=" + richengID ;
        SqlConnection con = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
        int num = Convert.ToInt32(SqlHelper.ExecuteScalar(mysql, con));
        con.Close();
        return num;
    }
    public String getPART(string ID)//获得运动员单位
    {
        string mysql = "select 参赛队报名表.参赛队简称 from 报名表,参赛队报名表 where 报名表.运动员号码='" + ID + "' and 报名表.参赛队编号=参赛队报名表.参赛队编号";
        SqlConnection con = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
        string leixing = Convert.ToString(SqlHelper.ExecuteScalar(mysql, con));
        con.Close();
        return leixing;
    }
}
