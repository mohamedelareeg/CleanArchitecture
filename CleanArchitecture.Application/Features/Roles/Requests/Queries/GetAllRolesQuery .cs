using CleanArchitecture.Application.Bases;
using MediatR;

namespace CleanArchitecture.Application.Features.Roles.Requests.Queries
{
    public class GetAllRolesQuery : IRequest<BaseResponse<IEnumerable<string>>>
    {
    }
}
