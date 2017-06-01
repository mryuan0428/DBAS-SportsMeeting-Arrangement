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
public partial class ini4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "add")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = GridView1.Rows[index];
            TableCell contactname=new TableCell();
            contactname= selectedRow.Cells[1];//获得编号
            string contact0 = contactname.Text;

            string mysql = "select * from 项目编码表  where 项目编号='" + contact0 + "'";
            SqlConnection con = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
            SqlDataReader reader=SqlHelper.ExecuteReader(mysql,con);
            reader.Read();
            int temp7 = 1,temp3=1,temp8=1;
            if (reader[7].Equals(false)) temp7 = 0;
            if (reader[3].Equals(false)) temp3 = 0;
            if (reader[8].Equals(false)) temp8 = 0;
            mysql = "insert into 参赛项目表(项目编号,项目名称, 道数, 单一赛否, 记录方式, 备注,男女子项目,项目顺序) values( '" + reader[0] +"','"+reader[1]+ "'," + reader[6] + "," + temp7 + "," + temp8 + ",'" + reader[9] + "',"+temp3+",0 )";
           con.Close();
            SqlConnection con1 = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
            try
            {
                int a = SqlHelper.ExecuteNonQuery(mysql,con1);
                con1.Close();
                Response.Write("<script language=javascript>alert('" + a + "成功')</script>");
                this.GridView1.DataBind();
                this.GridView2.DataBind();
            }
            catch (System.Exception ex)
            {
                con1.Close();
                Response.Write("<script language=javascript>alert('错误')</script>");
            }
            reader.Close();
        }
    }
}
