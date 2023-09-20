using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace assessment
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public static bool IsExist(string inputParameter)
        {
            // Your logic to check if inputParameter exists in records
            // Return true if it exists, false otherwise
                bool exists = ApplicationController.isRecordExist(inputParameter);
                return exists;
            
        }


        public static string performAuthenticate(string inputParameter)
        {
            string email = ApplicationController.getEmailByIc(inputParameter);
            Debug.WriteLine(email);
            int code = GmailSMTP.sendVerification(email);
            return code.ToString();

        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            string code = Session["code"] as string;
            if(txtCode.Text == code){
                Application application = ApplicationController.getApplicationByIc(txtIC.Text);
                lblApplicantName.Text = application.ApplicantName;
                lblApplicationId.Text = application.ApplicationID.ToString();
                lblStatus.Text = application.status;
                string base64Image = Convert.ToBase64String(application.result);
                string dataUri = "data:image/jpeg;base64," + base64Image;
                imgResult.ImageUrl = dataUri;

                lblApplicantName.Visible = true;
                lblApplicationId.Visible = true;
                lblStatus.Visible = true;
                imgResult.Visible = true;
            }
            else
            {
                lblErrorMessage.Text = "Wrong code, please re-enter";
                lblErrorMessage.Visible = true;
            }
        }

        protected void sendBtn_Click(object sender, EventArgs e)
        {
            string ic = txtIC.Text;
            if (IsExist(ic))
            {
                Debug.WriteLine("arrive");
                string code = performAuthenticate(ic);
                Debug.WriteLine(code.ToString());
                // Store a value in the session
                Session["Code"] = code;
            }
            else
            {
                lblErrorMessage.Text = "IC does not exist";
                lblErrorMessage.Visible = true;
            }
        }
    }
}