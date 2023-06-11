using MediatR;
using server.Data;
using server.Queries;
using server.Utility.ApiResponse;
using Signify.Models;
using System.Net;

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
            // List<Admin> adminList =  this.context.Admins.ToList();
            //int statusCode = (int)HttpStatusCode.OK;
            return await this.context.Admins.ToListAsync();
        }
    }
}
