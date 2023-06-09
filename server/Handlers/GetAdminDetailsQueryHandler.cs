using MediatR;
using server.Data;
using server.Queries;
using Signify.Models;

namespace server.Handlers
{
    public sealed class GetAdminDetailsQueryHandler : IRequestHandler<GetAdminDetailsQuery, List<Admin>>
    {
        private readonly DataContext context;

        public GetAdminDetailsQueryHandler(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<Admin>> Handle(GetAdminDetailsQuery request, CancellationToken cancellationToken)
        {
            return await this.context.Admins.ToListAsync();
        }
    }
}
