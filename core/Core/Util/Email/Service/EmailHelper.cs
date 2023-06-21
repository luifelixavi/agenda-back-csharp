using Core.Util.Email.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.Util.Email.Service
{
    public class EmailHelper : IEmailHelper
    {
        public async Task<bool> SendEmail(string userEmail, string message)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("lfxuea@gmail.com");
            mailMessage.To.Add(new MailAddress(userEmail));

            mailMessage.Subject = "[CONFIRMAÇÂO DE CONTA LFXUEA Fisio]";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = message;

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("lfxuea@gmail.com", "seroaihcwmitevdq");

            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;


            try
            {

                await client.SendMailAsync(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
