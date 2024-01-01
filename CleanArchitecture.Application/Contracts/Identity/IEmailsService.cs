using CleanArchitecture.Application.Bases;

namespace CleanArchitecture.Application.Contracts.Identity
{
    public interface IEmailsService
    {
        public Task<BaseResponse<string>> SendEmail(string email, string Message, string? reason);
    }
}
