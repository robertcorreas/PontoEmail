using System.Net;
using System.Net.Mail;

namespace Model
{
    public class EmailConfig
    {
        public string Login { get; private set; }

        public string Password { get; private set; }

        public string SMTP { get; private set; }

        public int Port { get; private set; }

        public bool IsSSL { get; private set; }

        public EmailConfig(string login, string password, string smtp, int port, bool isSSL)
        {
            Login = login;
            Password = password;
            SMTP = smtp;
            Port = port;
            IsSSL = isSSL;
        }

        public SmtpClient GetSmtpClient()
        {
            var smtpClient = new SmtpClient(SMTP, Port);
            smtpClient.EnableSsl = IsSSL;
            smtpClient.Credentials = new NetworkCredential(Login, Password);
            return smtpClient;
        }
    }
}