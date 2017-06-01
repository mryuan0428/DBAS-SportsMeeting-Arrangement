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
/// stockClass 的摘要说明
/// </summary>
public class stockClass
{
	public stockClass()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public bool validate(string str)
    {
        string strobj;
        bool ss = false;
        for (int i = 0; i < str.Length; i++)
        {
            strobj = str.Substring(i, 1);
            if (strobj == "%" || strobj == "&" || strobj == "'" || strobj == "|" || strobj == "<" || strobj == ">")
            {
                ss = true;
                break;
            }
        }
        return ss;
    }
}
