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
using System.Text;
using System.IO;

public partial class work_bianpaimanage_manage1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }
   
    protected int getNumxiangmu()//获得项目总数
    {
         string query = "select count(*) from 参赛项目表 ";
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        myConnection.Open();
        SqlDataAdapter ad = new SqlDataAdapter(query, myConnection);
        SqlCommand cmd = new SqlCommand(query, myConnection);
        int temp = Convert.ToInt32(cmd.ExecuteScalar());
        myConnection.Close();
        return temp;
    }
    protected int getNumofpeople(string XMID,string ZUBIE)//获得某个项目参赛人数 参数为项目编号
    {  
        int sex= getSexxiangmu(XMID); //获得男女子项目
        string name=getNamexiangmu(XMID);//获得某个项目名称
        string query = "select count(*) from 报名表 where ["+name+"] = 1 and 性别=" +sex + " and 参赛队编号 in (select 参赛队编号 from 参赛队报名表 where 组别='"+ZUBIE+"')";
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        myConnection.Open();
        SqlDataAdapter ad = new SqlDataAdapter(query, myConnection);
        SqlCommand cmd = new SqlCommand(query, myConnection);
        int temp=Convert.ToInt32(cmd.ExecuteScalar());
        myConnection.Close();
        return temp;
    }
    protected int getNumofpeople(string XMID)//获得某个项目参赛人数 参数为项目编号
    {
        int sex = getSexxiangmu(XMID); //获得男女子项目
        string name = getNamexiangmu(XMID);//获得某个项目名称
        string query = "select count(*) from 报名表 where [" + name + "] = 1 and 性别=" + sex + "";
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        myConnection.Open();
        SqlDataAdapter ad = new SqlDataAdapter(query, myConnection);
        SqlCommand cmd = new SqlCommand(query, myConnection);
        int temp=Convert.ToInt32(cmd.ExecuteScalar());
        myConnection.Close();
        return temp;
    }
    protected int getSexxiangmu(string XMID)//获得某个项目男女子项目
    {
        string query = "select 男女子项目 from 项目编码表 where 项目编号='" + XMID + "'";
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        myConnection.Open();
        SqlDataAdapter ad = new SqlDataAdapter(query, myConnection);
        SqlCommand cmd = new SqlCommand(query, myConnection);
        bool temp=Convert.ToBoolean(cmd.ExecuteScalar());
        myConnection.Close();
        if ( temp== true) return 1;
        else return 0;
    }
    protected string getNamexiangmu(string XMID)//获得某个项目名称
    {
        string query = "select 项目名称 from 项目编码表 where 项目编号='" + XMID + "'";
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        myConnection.Open();
        SqlDataAdapter ad = new SqlDataAdapter(query, myConnection);
        SqlCommand cmd = new SqlCommand(query, myConnection);
        string temp=Convert.ToString(cmd.ExecuteScalar());
        myConnection.Close();
        return temp;
    }

    protected int getNumxiangmudaoshu(string XMID)//获得项目道数
    {
        string query = "select 道数 from 参赛项目表 where 项目编号='"+XMID+"'";
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        myConnection.Open();
        SqlDataAdapter ad = new SqlDataAdapter(query, myConnection);
        SqlCommand cmd = new SqlCommand(query, myConnection);
        int temp=Convert.ToInt32(cmd.ExecuteScalar());
        myConnection.Close();
        return temp;
    }
    //protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)//进入编辑状态
    //{
    //    //用NewEidIndex取得当前编辑的行号，然后获取gridviewrow对象
    //    GridView2.EditIndex = e.NewEditIndex;
    //    GridView2.DataBind();

    //}
    //protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)//更新
    //{

    //    SqlConnection myConnection = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
    //    myConnection.Open();
    //    GridViewRow row = GridView2.Rows[e.RowIndex];
    //    string sql = "update 竞赛日程表 set";
    //}
    protected void Button2_Click(object sender, EventArgs e)//开始分组
    {
        //删除旧数据
        {
            SqlConnection co = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
            SqlHelper.ExecuteNonQuery("delete from 竞赛分组表",co);
            co.Close();
        }

        //ArrayList alist = new ArrayList();
        //ArrayList blist = new ArrayList();
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        con.Open();
        string mysql = "select * from 竞赛日程表  ";
        SqlCommand dbCommand = new SqlCommand(mysql, con);
        SqlDataReader reader = dbCommand.ExecuteReader();
        uint i = 0, numofpeople = 0, ZUSHU = 0;
        string ISonly = "", ZUBIE = "";
        while (reader.Read())//遍历所有项目
        {
            int richengID = Convert.ToInt32(reader["日程号"]);//日程号
            string XMID = Convert.ToString(reader["项目编号"]);//项目编号
            ZUBIE = Convert.ToString(reader["组别"]);//组别
            string xiangmuNAME = getNamexiangmu(XMID);//项目名
            ZUSHU = Convert.ToUInt32(reader[6]);//组数
            int sex = getSexxiangmu(XMID);//获得男女子
            SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
            con1.Open();
            mysql = "select 运动员号码,备注 from 报名表 where 参赛队编号 in (select 参赛队编号 from 参赛队报名表 where 组别='" + ZUBIE + "') and (性别=" + sex + ") and [" + xiangmuNAME + "]=1";
            SqlCommand dbCommand1 = new SqlCommand(mysql, con1);
            SqlDataReader reader1 = dbCommand1.ExecuteReader();
            //while (reader1.Read())
            //{
            //    //string yundongyuanID = Convert.ToString(reader1[0]);//运动员编号
            //    //string BEIZHU = Convert.ToString(reader1[1]);//备注
            //    //alist.Add(yundongyuanID);

            //}
            ArrayList al = new ArrayList();
            //int a = getNUMOFPART(richengID);//获得本项目参赛队总数
            int b = getNUMOFmaxnum();//单项目最多报名人数
            while (reader1.Read())
            {
                if (al.Count == 0) al.Add(reader1["运动员号码"].ToString());
                else
                {
                    string oldpart=getPART(al[al.Count - 1].ToString());
                    string newpart=getPART(reader1["运动员号码"].ToString());
                    if (al.Count % b != 0 &&  oldpart!=newpart )//不是一个单位
                    {
                        while (al.Count % b != 0)
                            al.Add("no");//补齐 为最高报名人数
                    }
                    al.Add(reader1["运动员号码"].ToString());
                }
            }
            
            //构成类似二维数组并按运动会中斜线法进行运动员数序的排序
            while (al.Count % b != 0)
                al.Add("no");//补齐
            //此时完成   单位个数*同一单位最大报名人数 的数组
            int a = al.Count / b;//单位数
            ArrayList alb = new ArrayList();//新建一个数组用来存放分好组的数据
            int m = 0, n = 0,temp=0;//斜线分组m代表列数，n代表行数
            for (m = 0; m < b; m++)
            {
                temp = m;
                for(  n=0;n<a;n++)
                {
                        if (temp == b) { temp = 0; }//行数最大后归零
                       //if (n == a) { n = 0;  }//列数最大后归零
                    alb.Add(al[n*5+temp]);
                    temp++;
                }
            }

                //for (i = 0; i < a * b; i++)
                //{
                //    if (m == a) { m = 0; }//行数最大后归零
                //    if (n == b) { n = 0;  }//列数最大后归零
                //    alb.Add(al[b * m + n]);//按斜线取值
                //    m++;//每次增一
                //    n++;
                //}
                con1.Close();
            //分组
            //{
            //    int numofdaoshu = getNumxiangmudaoshu(XMID);
            //    int max = alist.Count();
            //    int m, i=0,j=0;
            //    for (m = 0; m < ZUSHU; m++)
            //    {
            //        while (i <= max)
            //        {
            //            blist.Add(alist[j]);
            //            blist.i
            //          //  alist.RemoveAt(i);
            //            i += 1;
            //            if()
            //        }
            //    }
            //}
            //插入到分组信息表
            int i1 = 0, daoshu = 1, zushu = 1;
            int numofdaoshu = getNumxiangmudaoshu(XMID);
            SqlCommand dbCommand2;
            SqlConnection con2 = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
            con2.Open();
            for (i1 = 0; i1 < alb.Count; i1++)
            {
                if (alb[i1].ToString() != "no")//数据为有效数据时进行操作
                {
                    if (numofdaoshu == 0)//不分道泽把组数设为0
                    {
                        zushu = 0;
                    }
                    else
                    {
                        if (daoshu > numofdaoshu)//一组人满后转到下一组
                        {
                            zushu += 1;
                            daoshu = 1;
                        }
                    }
                    mysql = "insert into 竞赛分组表 values(" + richengID + ",'" + alb[i1] + "'," + zushu + "," + daoshu + ",'','','','','','','','','',0,'','') ";
                    daoshu++;
                    dbCommand2 = new SqlCommand(mysql, con2);
                    dbCommand2.ExecuteNonQuery();
               
                }
            }
            con2.Close();
            al.Clear();
            alb.Clear();
            //alist = null;
        }
        con.Close();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        //删除旧数据
        {
            SqlConnection co = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
            SqlHelper.ExecuteNonQuery("delete from 详细分组表", co);
            co.Close();
        }
        //写入详细分组表
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        con.Open();
        string mysql = "select 日程号,组数 from 竞赛日程表  ";
        SqlCommand dbCommand = new SqlCommand(mysql, con);
        SqlDataReader reader = dbCommand.ExecuteReader();
        while (reader.Read())//遍历所有项目
        {
            for (int i = 0; i <Convert.ToInt32(reader[1]); i++)
            {

                mysql = "insert into 详细分组表(日程号,组次) values(" + reader[0] + "," + (i + 1) + ")";
                SqlConnection con1 = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
                con1.Open();
                SqlCommand dbCommand1 = new SqlCommand(mysql, con1);
                dbCommand1.ExecuteNonQuery();
                con1.Close();
            }
        }
        con.Close();
   //
      //写入详细分组表
        SqlConnection con2 = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        con2.Open();
        mysql = "select 日程号,运动员号码,组次,道次 from 竞赛分组表  ";
        SqlCommand dbCommand2 = new SqlCommand(mysql, con2);
        SqlDataReader reader2 = dbCommand2.ExecuteReader();
        while (reader2.Read())//遍历所有项目
        {
            if (Convert.ToInt32( reader2[2] )!=0)//判断是否分组
            {
                int col = Convert.ToInt32(reader2[3]);
                string scol = Convert.ToString(col);
                
                //switch()
                //{
                //    case 1:col="c1"
                //}
                mysql = "update  详细分组表  set c" + scol + " ='" + reader2[1] + "' where 日程号=" + reader2[0] + " and 组次=" + reader2[2] + "";
                SqlConnection con3 = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
                con3.Open();
                SqlCommand dbCommand3 = new SqlCommand(mysql, con3);
                dbCommand3.ExecuteNonQuery();
                con3.Close();
            }
        }
        con2.Close();
    }
   //

    public int getNUMOFmaxnum()//获得单个项目最多报名人数
    {
        string mysql = "select 参数值 from 运动会竞赛规程 where 类型=2";
        SqlConnection con = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction);
        int leixing = Convert.ToInt32(SqlHelper.ExecuteScalar(mysql, con));
        con.Close();
        return leixing;
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
