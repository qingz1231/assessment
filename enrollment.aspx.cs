using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
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
            string name = txtName.Text;
            string ic = txtIc.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;
            byte[] fileBytes = resultImage.FileBytes;

            
            if(ApplicationController.addRecord(name, ic , phone, email, fileBytes))
            {
                Response.Redirect("success.html");
            }
            Response.Redirect("error.html");


        }

        [WebMethod]
        public static void processJson(string jsonData)
        {
            Boolean subject = false ;
            int indexSubject = 0;
            int targetx1 = 0;
            int targetx2 = 0;
            int targety1 = 0;
            int targety2 = 0;
            string[] mandatorySubs = { "1103", "1119", "1223" ,"1249"};
            Debug.WriteLine("This is a debug message:");
            List<ImageData> imageDatas = new JavaScriptSerializer().Deserialize<List<ImageData>>(jsonData);
            List<Subject> totalTaken = new List<Subject>();

            string pattern = @"[^a-zA-Z0-9\s]";
            foreach (ImageData imageData in imageDatas)
            {
                string data = Regex.Replace(imageData.text, pattern, "");
                //if (subject)
                //{
                //    if (imageData.boundingBox.x1 == 0)
                //    {
                //        totalTaken[indexSubject - 1].grade = imageData.text;

                //        subject = false; // stop looking for grade until next subject
                //    }
                //}

                if (data.All(char.IsDigit))
                {
                    string courseName = SubjectData.getCoursename(data);
                    Debug.WriteLine("This is a debug message:" + imageData.text);
                    if (courseName != null)
                    {
                        //subject = true;//subject present, looking for grade
                        //targetx1 = imageData.boundingBox.x1;
                        //targetx2 = imageData.boundingBox.x2;
                        //targety1 = imageData.boundingBox.y1;
                        //targety2 = imageData.boundingBox.y2;

                        //totalTaken.Add(new Subject { code = imageData.text, name = courseName });
                        
                        
                        indexSubject++;//point to next

                        Debug.WriteLine("Subject taken:" + imageData.boundingBox.x1.ToString());
                    }

                }
                


            }
        }
    }
}