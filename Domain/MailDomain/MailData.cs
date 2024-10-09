namespace Domain.MailDomain
{
    public class MailData
    {
        public string EmailToId { get; set; }
        public string EmailToName { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }

        public MailData(string emailToId, string emailToName, string emailSubject, string emailBody)
        {
            this.EmailToId = emailToId;
            this.EmailToName = emailToName;
            this.EmailSubject = emailSubject;
            this.EmailBody = emailBody;
        }
    }
}