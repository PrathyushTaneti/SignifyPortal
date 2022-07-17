using SignifyAPI.Models;

namespace SignifyAPI.Services.ServiceInterfaces
{
    public interface IActiveProgramsService
    {
        public List<ActivePrograms> GetAllActivePrograms();

        public ActivePrograms GetProgramById(int id);

        public int CreateProgram(ActivePrograms program);

        public bool UpdateProgram(int id, ActivePrograms program);

        public bool DeleteProgram(int id);
    }
}
