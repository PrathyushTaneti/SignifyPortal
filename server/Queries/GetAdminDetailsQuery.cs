using MediatR;
using Signify.Models;

namespace server.Queries
{
    public record GetAdminDetailsQuery : IRequest<List<Admin>>;
   
}
