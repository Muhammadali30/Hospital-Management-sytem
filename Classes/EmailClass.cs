using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Final_Project.Classes
{
    static class EmailClass
    {
        public static void Send_Email(string receiver, string subject, string body)
        {
            try
            {
                // Set up the SMTP client
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("wonline474@gmail.com", "uvzbjdcjdqqusiwx"),
                    EnableSsl = true,
                };

                // Create the email message
                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("wonline474@gmail.com"),
                    Subject = "Subject of the email",
                    Body = "Body of the email",
                };

                // Add recipients
                mailMessage.To.Add("mirzaiffi1@gmail.com");
                //mailMessage.CC.Add("cc@example.com"); // Optional CC
                //mailMessage.Bcc.Add("bcc@example.com"); // Optional BCC

                // Send the email
                smtpClient.Send(mailMessage);

                MessageBox.Show("Email sent successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
