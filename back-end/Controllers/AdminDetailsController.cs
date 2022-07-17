using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignifyAPI.Models;
using SignifyAPI.Services.ServiceInterfaces;

namespace SignifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminDetailsController : ControllerBase
    {
        public readonly IAdminDetailsService adminDetailsService;
        public AdminDetailsController(IAdminDetailsService adminDetails)
        {
            this.adminDetailsService = adminDetails;
        }

        [HttpGet]
        public List<AdminDetails> Get()
        {
            return this.adminDetailsService.GetAllAdminDetails();
        }

        [HttpGet("id")]
        public AdminDetails GetById(int id)
        {
            return this.adminDetailsService.GetAdminDetailById(id);
        }

        [HttpPost]
        public int Post(AdminDetails admin)
        {
            return this.adminDetailsService.CreateAdmin(admin);
        }

        [HttpPut("id")]
        public bool Put(int id,AdminDetails admin)
        {
            return this.adminDetailsService.UpdateAdmin(id, admin);
        }

        [HttpDelete("id")]
        public bool Delete(int id)
        {
            return this.adminDetailsService.DeleteAdmin(id);
        }
    }
}
