using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Base.Infrastructure.Utilities
{
    public class EmailHelper
    {
        public bool EnviarMensagem(string emailPara, string para, string assunto, string mensagem)
        {
            try
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(ConfigurationManager.AppSettings["EmailFrom"], ConfigurationManager.AppSettings["From"]);
                mail.To.Add(new MailAddress(emailPara, para));
                mail.Subject = assunto;
                mail.Priority = MailPriority.High;
                mail.IsBodyHtml = true;
                mail.Body = mensagem;

                SmtpClient smtp = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"], Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"]));

                EncryptionHelper encryptionHelper = new EncryptionHelper();

                smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["SmtpUser"], encryptionHelper.Descriptografar(ConfigurationManager.AppSettings["SmtpPassword"]));
                smtp.Send(mail);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EnviarMensagem(string emailPara, string para, string assunto, string mensagem, string nomeArquivo)
        {
            try
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(ConfigurationManager.AppSettings["EmailFrom"], ConfigurationManager.AppSettings["From"]);
                mail.To.Add(new MailAddress(emailPara, para));
                mail.Subject = assunto;
                mail.Priority = MailPriority.High;
                mail.IsBodyHtml = true;
                mail.Body = mensagem;
                mail.Attachments.Add(new Attachment(nomeArquivo));

                SmtpClient smtp = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"], Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"]));

                EncryptionHelper encryptionHelper = new EncryptionHelper();

                smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["SmtpUser"], encryptionHelper.Descriptografar(ConfigurationManager.AppSettings["SmtpPassword"]));
                smtp.Send(mail);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
