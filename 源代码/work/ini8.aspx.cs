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

public partial class work_ini8 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void Button1_Click(object sender, EventArgs e)//构建新的报名表
    {
        //选出参赛项目
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        con.Open();
        string mysql = "SELECT DISTINCT 项目名称, 项目顺序 FROM 参赛项目表 ORDER BY 项目顺序";
        SqlCommand dbCommand = new SqlCommand(mysql, con);
        SqlDataReader reader = dbCommand.ExecuteReader();
        int num = 0;
        string xmsql="";
        ArrayList alist = new ArrayList();
        while (reader.Read())
        {
            num = num + 1;
            alist.Add(reader[0]);
            xmsql +=",["+ alist[num - 1] + "]  int";
        }
        Response.Write("<script language=javascript>alert('" + num + "成功')</script>");
        con.Close();
        //结束选出参赛项目
        //删除
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
            con1.Open();
            mysql = "if exists (select * from sysobjects where name='报名表') drop table 报名表";
            SqlCommand dbCommand1 = new SqlCommand(mysql, con1);
            dbCommand1.ExecuteNonQuery();
            con1.Close();
        }
        //结束删除
        //创建
        SqlConnection con2 = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        con2.Open();
        mysql = "create table 报名表(运动员号码 nvarchar(10) primary key,参赛队编号 nvarchar(3),姓名 nvarchar(10),性别 nvarchar(2),年龄 smallint ,备注 nvarchar(255)" + xmsql + ")";
        SqlCommand dbCommand2 = new SqlCommand(mysql, con2);
        dbCommand2.ExecuteNonQuery();
        con2.Close();
        //结束创建
        //创建一条数据
        SqlConnection con3 = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        con3.Open();
        mysql = "insert into 报名表(运动员号码) values('编号')";
        SqlCommand dbCommand3 = new SqlCommand(mysql, con3);
        dbCommand3.ExecuteNonQuery();
        con3.Close();
        GridView2.DataBind();
        Server.Transfer("ini8.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)//导出报名表
    {
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        this.GridView2.RenderControl(htw);
        string strHtml = sw.ToString().Trim();

        string ExcelFileName = "运动员报名表.xls";
        string FilePhysicialPathName = Request.PhysicalApplicationPath+"\\";

        //生成的Excel文件名
        string objectExcelFileName = Path.Combine(FilePhysicialPathName, ExcelFileName);

        if (File.Exists(objectExcelFileName))
        {
            File.Delete(objectExcelFileName);
        }
        FileStream fs = new FileStream(objectExcelFileName, FileMode.Create);
        BinaryWriter bw = new BinaryWriter(fs, Encoding.GetEncoding("GB18030"));
        bw.Write(strHtml);
        bw.Close();
        fs.Close();

    }
 

    public override void VerifyRenderingInServerForm(Control control) { }//重载


    protected void Button3_Click(object sender, EventArgs e)//生成参赛队报名表
    {
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        this.GridView1.RenderControl(htw);
        string strHtml = sw.ToString().Trim();

        string ExcelFileName = "参赛队报名表.xls";
        string FilePhysicialPathName = Request.PhysicalApplicationPath + "\\";

        //生成的Excel文件名
        string objectExcelFileName = Path.Combine(FilePhysicialPathName, ExcelFileName);

        if (File.Exists(objectExcelFileName))
        {
            File.Delete(objectExcelFileName);
        }
        FileStream fs = new FileStream(objectExcelFileName, FileMode.CreateNew);
        BinaryWriter bw = new BinaryWriter(fs, Encoding.GetEncoding("GB18030"));
        bw.Write(strHtml);
        bw.Close();
        fs.Close();
    }
    protected void Button4_Click(object sender, EventArgs e)//参赛队预览
    {
        int a = 0;
        if(GridView1.Visible==true)
             GridView1.Visible = false;
        else 
            GridView1.Visible = true;
        GridView1.DataBind(); 
      //  Server.Transfer("ini8.aspx");

    }
    protected void Button5_Click(object sender, EventArgs e)//报名表预览
    {
        string query = "SELECT * FROM 报名表";
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        SqlDataAdapter ad = new SqlDataAdapter(query, myConnection);
        DataSet ds = new DataSet();
        ad.Fill(ds, "报名表");
        GridView2.DataSource = ds;

        if (GridView2.Visible.Equals(true))
            GridView2.Visible = false;
        else
            GridView2.Visible = true;
        GridView2.DataBind();
        //Server.Transfer("ini8.aspx");
    }
    protected void Button6_Click(object sender, EventArgs e)//转换数据库
    {
        //选出参赛项目
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        con.Open();
        string mysql = "select distinct 项目名称 from 参赛项目表 ";
        SqlCommand dbCommand = new SqlCommand(mysql, con);
        SqlDataReader reader = dbCommand.ExecuteReader();
        int num = 0;
        string xmsql = "";
        ArrayList alist = new ArrayList();
        while (reader.Read())
        {
            num = num + 1;
            alist.Add(reader[0]);
            //Response.Write("<script language=javascript>alert('" + alist[num - 1] + "成功')</script>");
            //SqlDataSource1.SelectCommand = "select * from 报名表 ";
            //ControlParameter cp = new ControlParameter("运动员号码");
            //SqlDataSource1.SelectParameters.Clear();
            //SqlDataSource1.SelectParameters.Add(cp);
            //GridView1.DataBind();
            xmsql += ",[" + alist[num - 1] + "]  bit";
        }
        Response.Write("<script language=javascript>alert('" + num + "成功')</script>");
        con.Close();
        //结束选出参赛项目
        //删除
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
            con1.Open();
            mysql = "if exists (select * from sysobjects where name='报名表') drop table 报名表";
            SqlCommand dbCommand1 = new SqlCommand(mysql, con1);
            dbCommand1.ExecuteNonQuery();
            con1.Close();
        }
        //结束删除
        //创建
        SqlConnection con2 = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        con2.Open();
        mysql = "create table 报名表(运动员号码 nvarchar(10) primary key,参赛队编号 nvarchar(3),姓名 nvarchar(10),性别 nvarchar(2),年龄 smallint ,备注 nvarchar(255)" + xmsql + ")";
        SqlCommand dbCommand2 = new SqlCommand(mysql, con2);
        dbCommand2.ExecuteNonQuery();
        con2.Close();
        //结束创建
        //创建一条数据
        SqlConnection con3 = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        con3.Open();
        mysql = "insert into 报名表(运动员号码) values('编号')";
        SqlCommand dbCommand3 = new SqlCommand(mysql, con3);
        dbCommand3.ExecuteNonQuery();
        con3.Close();
        GridView2.DataBind();
        Server.Transfer("ini8.aspx");
    }
}
