﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Schema;
using System.Web.Services;
using System.Data.SqlClient;

namespace assessment
{
    public partial class assessment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static int MyCSharpFunction(string inputParameter)
        {
            return ApplicationController.getRecordTotal(inputParameter);
        }


    }
}