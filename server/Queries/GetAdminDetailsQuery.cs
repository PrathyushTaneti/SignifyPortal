using MediatR;
using server.Utility.ApiResponse;
using Signify.Models;

namespace server.Queries
{
    public record GetAdminDetailsQuery : IRequest<List<Admin>>;
   
}
