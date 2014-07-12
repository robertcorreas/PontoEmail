using System.Net.Mail;

namespace Model
{
    public class EmailProperties
    {
        public EmailProperties(string senderEmail, string senderName, string receiverEmail, string receiverName,
            string subject)
        {
            SenderEmail = senderEmail;
            SenderName = senderName;
            ReceiverEmail = receiverEmail;
            ReceiverName = receiverName;
            Subject = subject;
        }

        public string SenderEmail { get; private set; }

        public string SenderName { get; private set; }

        public string ReceiverEmail { get; private set; }

        public string ReceiverName { get; private set; }

        public string Subject { get; private set; }

        public MailMessage GetMailMessage()
        {
            var sender = new MailAddress(SenderEmail, SenderName);
            var receiver = new MailAddress(ReceiverEmail, ReceiverName);

            return new MailMessage(sender, receiver) { Subject = Subject };
        }
    }
}