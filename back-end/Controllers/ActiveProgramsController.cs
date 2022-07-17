using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignifyAPI.Models;
using SignifyAPI.Services.ServiceInterfaces;

namespace SignifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActiveProgramsController : ControllerBase
    {
        public readonly IActiveProgramsService activeProgramsService;

        public ActiveProgramsController(IActiveProgramsService activeProgramsService)
        {
            this.activeProgramsService = activeProgramsService;
        }

        [HttpGet]
        public List<ActivePrograms> Get()
        {
            return this.activeProgramsService.GetAllActivePrograms();
        }

        [HttpGet("id")]
        public ActivePrograms Get(int id)
        {
            return this.activeProgramsService.GetProgramById(id);
        }

        [HttpPost]
        public int Post(ActivePrograms activePrograms)
        {
            return this.activeProgramsService.CreateProgram(activePrograms);
        }

        [HttpPut]
        public bool Put(int id,ActivePrograms activePrograms)
        {
            return this.activeProgramsService.UpdateProgram(id, activePrograms);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return this.activeProgramsService.DeleteProgram(id);
        }
    }
}
