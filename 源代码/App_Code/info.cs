using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// info 的摘要说明
/// </summary>
public class info
{
    string num;
    string name;
    string partment;
    public info()
    {
        //
        // TODO: 在此处添加构造函数逻辑

        //
    }
	public void setinfo(string n,string na,string p)
	{
		//
		// TODO: 在此处添加构造函数逻辑
        num = n;
        name = na;
        partment = p;
		//
	}
    public string getnum()
    {
        return num;
    }
    public string getname()
    {
        return name;
    }
    public string getpartment()
    {
        return partment;
    }
}
