using MediatR;
using server.Data;
using server.Queries;
using server.Utility.ApiResponse;
using Signify.Models;
using System.Net;

namespace server.Handlers
{
    public sealed class GetAdminDetailsQueryHandler : IRequestHandler<GetAdminDetailsQuery, ReturnResponse>
    {
        private readonly DataContext context;
        private readonly IResponse response;

        public GetAdminDetailsQueryHandler(DataContext context, IResponse response)
        {
            this.context = context;
            this.response = response;
        }

        public async Task<ReturnResponse> Handle(GetAdminDetailsQuery request, CancellationToken cancellationToken)
        {
             List<Admin> adminList =  this.context.Admins.ToList();
            int statusCode = (int)HttpStatusCode.OK;
            return this.response.returnResponse(statusCode, adminList);
        }
    }
}
