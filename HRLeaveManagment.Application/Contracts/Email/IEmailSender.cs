using HRLeaveManagment.Application.Models;

namespace HRLeaveManagment.Application.Contracts.Email
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(EmailMessage email);
    }
}
