using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using server.Data;
using server.Queries;
using server.Utility.ApiRoute;
using System.Data;
using System.Linq.Expressions;
using System.Net;

namespace server.Controllers
{
    [Route(IGetApiRoute.DefaultRoute)]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMediator mediator;

        public AdminController(IMediator mediator) => this.mediator = mediator;


        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<List<Admin>>> GetAllAdmins([FromServices] DataContext dataContext)
        {
            try
            {
                //throw new ArgumentOutOfRangeException();
                return await this.mediator.Send(new GetAdminDetailsQuery());
            }
            catch (Exception e) when (dataContext is null)
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
