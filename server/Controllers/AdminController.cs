using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;

namespace server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly DataContext context;
        private readonly IMapper map;
        public AdminController(DataContext context, IMapper mapper)
        {
                this.context = context;
            this.map = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<AdminDTO>>> GetAdminDetails()
        {
            if (this.IsContextNull())
            {
                return BadRequest();
            }
            return this.map.Map<List<AdminDTO>>(await this.context.Admins.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateNewAdmin([FromBody] Admin admin)
        {
            if (this.IsContextNull() || admin == null)
            {
                return BadRequest();
            }
            if (this.context.Admins.Contains(admin))
            {
                return BadRequest();
            }
            var newDetail = new Admin
            {
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                UserName = admin.UserName,
                Password = admin.Password,
                DateCreated = DateTime.Now
            };
            await this.context.Admins.AddAsync(newDetail);
            await this.context.SaveChangesAsync();
            return await this.context.Admins.ContainsAsync(admin) ? 1 : 0;
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteAdmin([FromBody] int id)
        {
            await this.context.Admins.Where(admin => admin.Id == id).ExecuteDeleteAsync();
            await this.context.SaveChangesAsync();
            return this.context.Admins.Contains(this.context.Admins.SingleOrDefault(admin => admin.Id == id)) ? 1 : 0;
        }

        private bool IsContextNull()
        {
            return this.context is null;
        }
    }
}
