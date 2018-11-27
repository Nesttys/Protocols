using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace SMTPProtocol
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static MailMessage CreateMessage(string from, string to, string subject, string body, string filePath = null)
        {
            MailMessage message = new MailMessage(from, to, subject, body);
            if (!string.IsNullOrEmpty(filePath))
                message.Attachments.Add(new Attachment(filePath));
            return message;
        }

        static void Send(string host, int port, string password, MailMessage message)
        {
            SmtpClient client = new SmtpClient(host, port);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(message.From.Address, password);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Send(message);
            message.Dispose();
            client.Dispose();

        }
    }
}
