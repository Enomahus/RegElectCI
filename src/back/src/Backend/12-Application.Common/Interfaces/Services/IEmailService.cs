using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendCreatePasswordEmailAsync(string activateLink, string toEmail);
        Task SendForgotPasswordEmailAsync(string resetLink, string toEmail);
    }
}
