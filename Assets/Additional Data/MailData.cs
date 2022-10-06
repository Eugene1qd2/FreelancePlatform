using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.Assets.Additional_Data
{
    class MailData
    {
        private static string mail = "freelanceplatformassistant@mail.ru";
        public static void SendMail(string recipient, string messaage,string subject)
        {
            MailAddress From = new MailAddress(mail, "FreelancePlatformAssistant");
            MailAddress To = new MailAddress(recipient);
            MailMessage Message = new MailMessage(From, To);

            Message.Subject = subject;
            Message.Body = "<h2>"+ subject + "</h2><br><h3>"+messaage+"</h3>";
            Message.IsBodyHtml = true;

            var smtp = new SmtpClient
            {
                Host = "smtp.mail.ru",
                Port = 587, //993
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(From.Address, "05iMGhazWDKLWUAwBhLi")
            };
            smtp.Send(Message);
        }

    }
}
