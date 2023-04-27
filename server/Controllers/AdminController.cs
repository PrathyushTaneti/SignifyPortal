using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using server.Data;
using System.Data;
using System.Linq.Expressions;
using System.Net;

namespace server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Admin>> GetAllAdmins([FromServices] DataContext dataContext)
        {
            try
            {
                return dataContext.Admins.ToList();
            }
            catch (Exception e) when (dataContext is null)
            {
                throw ;
            }
        }


        [HttpPost]
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
    }
}
