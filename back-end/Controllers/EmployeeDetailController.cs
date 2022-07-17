using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignifyAPI.Models;
using SignifyAPI.Services.ServiceInterfaces;

namespace SignifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetailController : ControllerBase
    {
        public readonly IEmployeeDetailService employeeDetailService;
        public EmployeeDetailController(IEmployeeDetailService employeeDetailService)
        {
            this.employeeDetailService = employeeDetailService;
        }

        [HttpGet]
        public List<EmployeeDetails> Get()
        {
            return this.employeeDetailService.GetAllEmployeeDetails();
        }

        [HttpGet("id")]
        public EmployeeDetails Get(int id)
        {
            return this.employeeDetailService.GetEmployeeDetailById(id);
        }

        [HttpPut("id")]
        public bool Put(int id,EmployeeDetails employeeDetail)
        {
            return this.employeeDetailService.UpdateEmployeeDetail(id, employeeDetail);
        }

        [HttpPost]
        public int Post(EmployeeDetails employeeDetail)
        {
            return this.employeeDetailService.CreateEmployeeDetail(employeeDetail);
        }

        [HttpDelete("id")]
        public bool  Delete(int id)
        {
            return this.employeeDetailService.DeleteEmployeeDetail(id);
        }
    }
}
