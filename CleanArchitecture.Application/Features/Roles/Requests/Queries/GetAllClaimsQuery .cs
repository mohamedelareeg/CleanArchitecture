using CleanArchitecture.Application.Bases;
using MediatR;

namespace CleanArchitecture.Application.Features.Roles.Requests.Queries
{
    public class GetAllClaimsQuery : IRequest<BaseResponse<IEnumerable<string>>>
    {
    }
}
