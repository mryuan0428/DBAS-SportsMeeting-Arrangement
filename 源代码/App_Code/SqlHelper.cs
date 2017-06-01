using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// 数据库的通用访问代码
/// </summary>
public class SqlHelper
{
	 //获取数据库连接字符串，其属于静态变量且只读，项目中所有文档可以直接使用，但不能修改
    public static readonly string ConnectionStringLocalTransaction = ConfigurationManager.AppSettings["conStr"];
    /// <returns>返回一个数值表示此SqlCommand命令执行后影响的行数</returns>

    public static int ExecuteNonQuery(string mysql, SqlConnection conn)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand(mysql,conn);
        int val = cmd.ExecuteNonQuery();
        return val;
    }
    public static object ExecuteScalar(string mysql, SqlConnection conn)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand(mysql, conn);
        return cmd.ExecuteScalar();
    }

    public static SqlDataReader ExecuteReader(string mysql,SqlConnection conn)
    {
     
        
        SqlCommand cmd = new SqlCommand(mysql,conn);
        // 在这里使用try/catch处理是因为如果方法出现异常，则SqlDataReader就不存在，
        //CommandBehavior.CloseConnection的语句就不会执行，触发的异常由catch捕获。
        //关闭数据库连接，并通过throw再次引发捕捉到的异常。
        try
        {
            conn.Open();
            SqlCommand dbCommand = new SqlCommand(mysql, conn);
            SqlDataReader reader = dbCommand.ExecuteReader();
            //reader.Read();
            return reader;
        }

        catch
        {
            conn.Close();
            throw;
        }
    }
   
  
}
