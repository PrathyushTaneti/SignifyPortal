using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using server.Data;
using server.Queries;
using server.Utility.ApiResponse;
using server.Utility.ApiRoute;
using Signify.Models;
using System.Data;
using System.Linq.Expressions;
using System.Net;

namespace server.Controllers
{
    [ApiController]
    [Route(GetApiRoute.DefaultRoute)]
    public class AdminController : ControllerBase
    {
        private readonly IMediator mediator;

        public AdminController(IMediator mediator) => this.mediator = mediator;



        [HttpGet("get.{format}"), FormatFilter]
        //[HttpGet]
        //[Authorize]
        public async Task<List<Admin>> GetAllAdmins()
        {
            try
            {
                return await this.mediator.Send(new GetAdminDetailsQuery());
            }
            catch (Exception e) 
            {
                throw e;
            }
        }


        [HttpPost]
        [Authorize]
        public Guid CreateNewAdmin([FromBody] Admin admin, [FromServices] DataContext dataContext)
        {
            try
            {
                admin.DateCreated = DateTime.UtcNow;
                dataContext.Admins.Add(admin);
                dataContext.SaveChanges();
                return admin.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public List<Student> GetStudents([FromServices] DataContext dataContext)
        {
            return dataContext.Students.ToList();
        }
    }
}
