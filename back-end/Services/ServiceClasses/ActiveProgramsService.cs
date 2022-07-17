using PetaPoco;
using SignifyAPI.Models;
using SignifyAPI.Services.ServiceInterfaces;

namespace SignifyAPI.Services.ServiceClasses
{
    public class ActiveProgramsService : IActiveProgramsService
    {
        public readonly IDatabase DbContext;

        public ActiveProgramsService()
        {
            this.DbContext = new Database("Server = .\\SQLEXPRESS; " + "Database = SignifyDb; Trusted_Connection = True; " + "TrustServerCertificate = True; ", "System.Data.SqlClient");
        }
        public List<ActivePrograms> GetAllActivePrograms()
        {
            return this.DbContext.Query<ActivePrograms>("Select * from ActivePrograms").ToList() ?? new List<ActivePrograms>();
        }

        public ActivePrograms GetProgramById(int id)
        {
            //throw new NotImplementedException();
            return this.DbContext.SingleOrDefault<ActivePrograms>("Select * from ActivePrograms where Id = @0", id);

        }

        public bool UpdateProgram(int id, ActivePrograms program)
        {
            if (this.GetProgramById(id) != null)
            {
                this.DbContext.Update(program);
                return true;
            }
            return false;
        }

        public int CreateProgram(ActivePrograms program)
        {
            this.DbContext.Insert(program);
            return program.Id;
        }

        public bool DeleteProgram(int id)
        {
            if (this.GetProgramById(id) != null)
            {
                this.DbContext.Delete<ActivePrograms>(id);
                return true;
            }
            return false;
        }
    }
}
