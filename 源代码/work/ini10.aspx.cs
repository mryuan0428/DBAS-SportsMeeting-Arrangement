﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class work_ini10 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DetailsView1.Font.Size = FontUnit.Smaller;
        GridView1.Font.Size = FontUnit.Smaller;
    }
}
