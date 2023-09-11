using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Schema;
using System.Web.Services;

namespace assessment
{
    public partial class assessment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string MyCSharpFunction(string inputParameter)
        {
            // Your C# code here
            return "Hello from C#! You sent: " + inputParameter;
        }


    }
}