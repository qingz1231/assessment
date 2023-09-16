using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace assessment
{
    public partial class enrollment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void enrollBtn_Click(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static void processJson(string jsonData)
        {
            Debug.WriteLine("This is a debug message:");
            List<ImageData> imageDatas = new JavaScriptSerializer().Deserialize<List<ImageData>>(jsonData);
 
            foreach (ImageData imageData in imageDatas)
            {

                string courseName = SubjectData.getCoursename(imageData.text);
                Debug.WriteLine("This is a debug message:" + imageData.text);
                if (courseName != null)
                {
                    Debug.WriteLine("Subject Taken:" + courseName);
                }


            }
        }
    }
}