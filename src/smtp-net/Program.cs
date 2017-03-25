using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
namespace smtp_net
{
    class Program
    {
        static void Main(string[] args)
        {
            var isSent = SendEmail("example@gmail.com", "subject", "body");
            if (isSent)
            {
                Console.WriteLine("SENT");
            }
            else
            {
                Console.WriteLine("ERROR");
            }
            Console.ReadKey();
        }
        public static Boolean SendEmail(string toEmailAddress, string subject, string body)
        {
            var fromAddress = new MailAddress("yourSmtpEmailAccount@gmail.com", "Display Name");
            var toAddress = new MailAddress(toEmailAddress, "");
            var fromPassword = "yourSmtpEmailAccountPassword";
            var smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            var networkCredential = new NetworkCredential();
            networkCredential.UserName = fromAddress.Address;
            networkCredential.Password = fromPassword;
            smtp.Credentials = networkCredential;
            smtp.Timeout = 20000;
            var message = new MailMessage(fromAddress, toAddress);
            message.Subject = subject;
            message.Body = body;
            try
            {
                smtp.Send(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
