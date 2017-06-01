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
using System.Data.OleDb;
using System.Data.SqlClient;
using Microsoft.Office.Core; 

public partial class work_ini9 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /**********************************************************  
    fileUp 是html控件组中的"Input(File)"控件  
         btnUPFile 是"确定"按钮  
    **********************************************************/
    protected void Button1_Click(object sender, EventArgs e)
    {

        //将需要导入的文件上传到服务器   
        string filePath = "", fileExtName = "";
        //string myFileName;//用不到，但也写上吧   
        string myPath;
        string FullName = "";//保存文件的完整文件名   
        if (fileUp.PostedFile.FileName != "")
        {
            //取得文件路径    
            filePath = fileUp.PostedFile.FileName;
            //取得文件扩展名   
            fileExtName = filePath.Substring(filePath.LastIndexOf(".") + 1);
            //判断是否为Excel文件   
            if (fileExtName == "xls")
            {
                try
                {
                    //取得与web服务器上指定的虚拟路径相对应的物理路径   
                    myPath = Server.MapPath("Upfiles/");
                    //取得文件名   
                    //myFileName = filePath.Substring(filePath.LastIndexOf("")+1);   
                    //取得当前时间，以“时时分分秒秒”来命名，以免重复   
                    string strDateName = DateTime.Now.ToString("hhmmss");
                    //保存上传文件到指定目录   
                    FullName = myPath + strDateName + "." + fileExtName;
                    fileUp.PostedFile.SaveAs(FullName);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
            else
            {
                Response.Write("<SCRIPT>alert('文件格式不正确');</SCRIPT>");
                return;
            }
        }

        linkExcel(FullName);
 
    }
    //数据插入到数据库
    private void linkExcel(string xlsFile)
    {
        string strConnect = "provider=Microsoft.Jet.OLEDB.4.0;" + "data source=" + xlsFile + ";Extended Properties=\"Excel 8.0;IMEX=1\"";
        OleDbConnection conxls = new OleDbConnection(strConnect);
        try
        {
            OleDbCommand cmdOleDb = new OleDbCommand();
            //string strConnect = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + xlsFile + ";Extended Properties=Excel 8.0;IMEX=1;HDR=YES;Persist Security Info=True";
            cmdOleDb.Connection = conxls;
            if (conxls.State.ToString() == "Closed")
            {
                conxls.Open();
            }
            string str = "select * from [运动员报名表$]";
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(str, conxls);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                /***************将数据绑定到gridview*****************************************************/
                try
                {

                    GridView1.DataSource = ds.Tables[0].DefaultView;
                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("读取出错" + ex.Message);
                }
                /***************绑定完成******************************************************************/

                /********将数据导入到数据库，如果有对应的SQLserver2000数据库，要求字段要一一对应**********/
                string mySql = "";
                //链接SQLserver2000数据库   
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
                if (con.State.ToString() == "Closed")
                {
                    con.Open();
                }
                SqlCommand myCmd = new SqlCommand();
                //将数据逐行写入到数据库中   
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //mySql = "insert into 运动员报名表 values('";

                    //数据库中三个字段，所以插入三列   
                    int age = 0;
                    if (ds.Tables[0].Rows[i][4].ToString() != "") age =Convert.ToInt32( ds.Tables[0].Rows[i][4]);
                    mySql = "insert into 报名表 values('" + ds.Tables[0].Rows[i][0].ToString() + "','" + ds.Tables[0].Rows[i][1].ToString() + "','" + ds.Tables[0].Rows[i][2].ToString() + "','" + ds.Tables[0].Rows[i][3].ToString() + "'," + age + ",'" + ds.Tables[0].Rows[i][5].ToString() + "'";
                    int ls = ds.Tables[0].Columns.Count;
                    for (int j = 0; j < ls - 6; j++)
                    {
                        mySql += ",'" + ds.Tables[0].Rows[i][j + 6].ToString() + "'";
                    }
                    mySql += ")";
                    myCmd.Connection = con;
                    myCmd.CommandText = mySql;
                    try
                    {
                        myCmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Response.Write("将数据插入数据库时出错" + ex.Message);
                    }
                }
                Response.Write("<SCRIPT>alert('数据已成功导入到数据库！');</SCRIPT>");
                GridView1.DataBind();
                if (con.State.ToString() == "Open")
                {
                    con.Close();
                }
                /*********导入数据库完成******************************************************************/
            }
            else
            {
                Response.Write("<SCRIPT>alert('Excel中没有数据！');</SCRIPT>");
            }
            if (conxls.State.ToString() == "Open")
            {
                conxls.Close();
            }

        }
        catch (Exception ex)
        {
            if (conxls.State.ToString() == "Open")
            {
                conxls.Close();
            }
            Response.Write("<SCRIPT>alert('导入的文件数据表错误！" + ex + "');</SCRIPT>");
        }

    }


}
