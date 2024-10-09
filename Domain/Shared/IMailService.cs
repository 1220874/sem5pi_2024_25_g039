using Domain.MailDomain;

namespace Shared
{
    public interface IMailService
    {
        bool SendMail(MailData Mail_Data);
    }
}