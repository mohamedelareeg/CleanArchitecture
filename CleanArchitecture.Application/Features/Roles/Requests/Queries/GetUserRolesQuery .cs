using CleanArchitecture.Application.Bases;
using MediatR;

namespace CleanArchitecture.Application.Features.Roles.Requests.Queries
{
    public class GetUserRolesQuery : IRequest<BaseResponse<IEnumerable<string>>>
    {
        public string UserId { get; set; }
    }
}
