using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignifyAPI.Models;
using SignifyAPI.Services.ServiceInterfaces;

namespace SignifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDetailController : ControllerBase
    {
        public readonly IStudentDetailService studentDetailService;
        public StudentDetailController(IStudentDetailService studentDetailService)
        {
            this.studentDetailService = studentDetailService;
        }

        [HttpGet]
        public List<StudentDetails> Get()
        {
            return this.studentDetailService.GetAllStudentDetails();
        }

        [HttpGet("id")]
        public StudentDetails Get(int id)
        {
            return this.studentDetailService.GetStudentDetailById(id);
        }

        [HttpPut("id")]
        public bool Put(int id,StudentDetails studentDetail)
        {
            return this.studentDetailService.UpdateStudentDetail(id, studentDetail);
        }

        [HttpPost]
        public int Post(StudentDetails studentDetail)
        {
            return this.studentDetailService.CreateStudentDetail(studentDetail);
        }

        [HttpDelete("id")]
        public bool Delete(int id)
        {
            return this.studentDetailService.DeleteStudentDetail(id);
        }
    }
}
