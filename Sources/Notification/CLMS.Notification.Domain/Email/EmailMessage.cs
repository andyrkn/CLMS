namespace CLMS.Notification.Domain
{
    public sealed class EmailMessage
    {
        private EmailMessage()
        {
        }

        public string To { get; private set; }

        public string Subject { get; private set; }

        public string Body { get; private set; }

        public static EmailMessage Create(string to, string subject, string body)
        {
            return new EmailMessage
            {
                To = to,
                Subject = subject,
                Body = body
            };
        }
    }
}