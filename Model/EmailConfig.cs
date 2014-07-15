using System.Net;
using System.Net.Mail;

namespace Model
{
    public class EmailConfig
    {
        public EmailConfig(string login, string password, string smtp, int port, bool isSSL)
        {
            Login = login;
            Password = password;
            Smtp = smtp;
            Port = port;
            IsSSL = isSSL;
        }

        public string Login { get; private set; }

        public string Password { get; private set; }

        public string Smtp { get; private set; }

        public int Port { get; private set; }

        public bool IsSSL { get; private set; }

        public SmtpClient GetSmtpClient()
        {
            var smtpClient = new SmtpClient(Smtp, Port);
            smtpClient.EnableSsl = IsSSL;
            smtpClient.Credentials = new NetworkCredential(Login, Password);
            return smtpClient;
        }
    }
}