using System.Net;
using System.Net.Mail;
using System.Text;

namespace SafiMed.Models
{
    internal class EmailSender
    {
        internal bool Send(FeedbackResponse response)
        {
            var fromAddress = new MailAddress("postmaster@safi-med.com", "Feedback Form");
            var toAddress = new MailAddress("email here", "Info SafiMed");
            var fromPassword = "password here";
            var subject = "Feedback From " + response.Name;
            var body = new StringBuilder();

            body.AppendLine(ViewRes.Resource.ContactFormName + ": " + response.Name);
            body.AppendLine(ViewRes.Resource.ContactFormComp + ": " + response.Company);
            body.AppendLine(ViewRes.Resource.ContactFormEMail + ": " + response.EMail);
            body.AppendLine(ViewRes.Resource.ContactFormPhone + ": " + response.Phone);
            body.AppendLine(ViewRes.Resource.ContactFormMail + ": " + response.Message);

            var smtp = new SmtpClient
            {
                Host = "mail.safi-med.com",
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body.ToString()
            })
            {
                smtp.Send(message);
                return true;
            }
        }

    }
}