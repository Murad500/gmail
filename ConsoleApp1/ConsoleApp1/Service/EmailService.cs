using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Service
{
    public class EmailService
    {
        public static bool SendConfirmationEmail(string recipientEmail)
        {

            string senderEmail = "eleazar.gorczany@ethereal.email";
            string senderPassword = "4QMjN73ces6Z5Azwxw";


            SmtpClient smtpClient = new SmtpClient("smtp.ethereal.email", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(senderEmail);
                mailMessage.To.Add(recipientEmail);
                mailMessage.Subject = "Hello from C# SMTP email system";
                mailMessage.Body = @"<h1>Salam</h1>";

                mailMessage.IsBodyHtml = true;

                smtpClient.Send(mailMessage);

                Console.WriteLine("Email sent successfully");

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);

                return false;
            }

            
        }
    }
}
