using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alluberes.NotificationEngine.Client
{
    static class SharedFunctions
    {

        public static bool SendEmail(EmailModel emailModel)
        {
            var result = false;

            var userName = string.Empty;
            var password = string.Empty;
            var host = string.Empty;
            var port = 587;
            var enableSSL = true;

            //userName = "alluberes@rightcodetechnologies.com";
            
            //host = "smtpout.secureserver.net";
            //port = 25;

            userName = "alluberes@itla.edu.do";
            
            host = "smtp.gmail.com";
            port = 587;


            //userName = "alluberes@gmail.com";
            
            //host = "smtp.gmail.com";
            //port = 587;
            

            var emailClient = new System.Net.Mail.SmtpClient();

            // emailClient.DeliveryFormat = System.Net.Mail.SmtpDeliveryFormat.International;
            emailClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            emailClient.EnableSsl = enableSSL;
            emailClient.Host = host;
            emailClient.Port = port;
            emailClient.UseDefaultCredentials = false;
            
            emailClient.Credentials = new System.Net.NetworkCredential(userName, password);

            var mailFrom = new System.Net.Mail.MailAddress("alluberes@itla.edu.do", "Abnel Lluberes (Itla)");
            var mailTo = new System.Net.Mail.MailAddress("alluberes@alluberes.com", "Abnel Lluberes (personal)");
            var mailCC = new System.Net.Mail.MailAddress("alluberes@rightcodetechnologies.com", "Right Code Technologies");


            var message = new System.Net.Mail.MailMessage();
            message.From = mailFrom;
            message.To.Add(mailTo);
            message.CC.Add(mailCC);
            message.Subject = emailModel.Subject;
            message.Body = emailModel.Message;

            emailClient.Send(message);

            result = true;

            return result;
        }

    }
}
