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

public partial class firstlogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con0 = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        con0.Open();
        string mysql0 = "DELETE 用户; INSERT INTO 用户(username, password, role) VALUES ('admin', 'admin', 1);" +
                        "delete 运动会基本信息表;INSERT INTO 运动会基本信息表(运动会名称)VALUES ('请填写');delete 运动会竞赛规程;" +
                        "INSERT INTO 运动会竞赛规程(类型, 名称, 参数值) values(1,'每个运动员最多能报项目数',5);" +
                        "INSERT INTO 运动会竞赛规程(类型, 名称, 参数值) values(2,'每个参赛队每个项目最多能报人数',5);" +
                        "INSERT INTO 运动会竞赛规程(类型, 名称, 参数值) values(3,'本次运动会是否计算积分',1);" +
                        "INSERT INTO 运动会竞赛规程(类型, 名称, 参数值) values(4,'本次运动会录取名次',8);" +
                        "INSERT INTO 运动会竞赛规程(类型, 名称, 参数值) values(5,'本次运动会团体分录取名次',8);" +
                        "INSERT INTO 运动会竞赛规程(类型, 名称, 参数值) values(6,'运动会级别',0);" +
                        "INSERT INTO 运动会竞赛规程(类型, 名称, 参数值) values(7,'某项目最少有几名运动员参赛',0);" +
                        "delete 运动员录取办法;" +
                        "INSERT INTO 运动员录取办法(名次, 得分) VALUES (1, 0);" +
                        "INSERT INTO 运动员录取办法(名次, 得分) VALUES (2, 0);" +
                        "INSERT INTO 运动员录取办法(名次, 得分) VALUES (3, 0);" +
                        "INSERT INTO 运动员录取办法(名次, 得分) VALUES (4, 0);" +
                        "INSERT INTO 运动员录取办法(名次, 得分) VALUES (5, 0);" +
                        "INSERT INTO 运动员录取办法(名次, 得分) VALUES (6, 0);" +
                        "INSERT INTO 运动员录取办法(名次, 得分) VALUES (7, 0);" +
                        "INSERT INTO 运动员录取办法(名次, 得分) VALUES (8, 0);" +
                        "delete 参赛队报名表;" +
                        "INSERT INTO 参赛队报名表(参赛队编号)VALUES (0);"+
                        "use c;" +
                        "if exists(select name from sysobjects where type='u' and id=object_id('项目编码表')) drop table 项目编码表;" +
                        "use a;" +
                        "select * into c.dbo.项目编码表 from 项目编码表 where 1=1;";
        SqlCommand dbCommand0 = new SqlCommand(mysql0, con0);
        int x = dbCommand0.ExecuteNonQuery();
        con0.Close();
    }
}
