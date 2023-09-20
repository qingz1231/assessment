using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Xml.Linq;

namespace assessment
{
    public class GmailSMTP
    {
        private static string from = "tarcitpstatusupdate@gmail.com";
        private static string fromPassword = "xguhrgjyggabkwpl";
        // Create an SMTP client
        private static SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(from, fromPassword),
            EnableSsl = true,
        };

        

        public static Boolean sendEmail(String subject, String body, String receipent)
        {
            // Create an email message
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(from),
                Subject =  subject,
                Body = body,
            };


            try
            {
                // Set the recipient's email address
                mailMessage.To.Add(receipent);

                // Send the email
                smtpClient.Send(mailMessage);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        public static int sendVerification(string receipent)
        {
            // Create a Random object
            Random random = new Random();

            // Generate a random 4-digit number
            int randomNumber = random.Next(1000, 10000); // Generates a number between 1000 and 9999 (inclusive)

            // Create an email message
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(from),
                Subject = "TARC ITP verification",
                Body = "Please enter the following verfication code : " + randomNumber.ToString(),
            };

            try
            {
                // Set the recipient's email address
                mailMessage.To.Add(receipent);
                // Send the email
                smtpClient.Send(mailMessage);
                return randomNumber;
            }
            catch (Exception ex)
            {
                return 0;
            }


            

        }

        

       
    }
}