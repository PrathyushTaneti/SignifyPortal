using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignifyAPI.Models;
using SignifyAPI.Services.ServiceInterfaces;

namespace SignifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceController : ControllerBase
    {
        public readonly IPerformanceService performanceService;

        public PerformanceController(IPerformanceService performanceService)
        {
            this.performanceService = performanceService;
        }

        [HttpGet]
        public List<Performance> Get()
        {
            return this.performanceService.GetAllPerformance();
        }

        [HttpGet("id")]
        public Performance GetById(int id)
        {
            return this.performanceService.GetPerformanceById(id);
        }

        [HttpPost]
        public int Post(Performance performance)
        {
            return this.performanceService.CreatePerformance(performance);
        }

        [HttpPut("id")]
        public bool Put(int id,Performance performance)
        {
            return this.performanceService.UpdatePerformance(id, performance);
        }

        [HttpDelete("id")]
        public bool Delete(int id)
        {
            return this.performanceService.DeletePerformance(id);
        }
    }
}
