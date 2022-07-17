using PetaPoco;
using SignifyAPI.Models;
using SignifyAPI.Services.ServiceInterfaces;

namespace SignifyAPI.Services.ServiceClasses
{
    public class PerformanceService : IPerformanceService
    {

        public readonly IDatabase DbContext;

        public PerformanceService()
        {
            this.DbContext = new Database("Server = .\\SQLEXPRESS; " + "Database = SignifyDb; Trusted_Connection = True; " + "TrustServerCertificate = True; ", "System.Data.SqlClient");
        }
        public List<Performance> GetAllPerformance()
        {
            return this.DbContext.Query<Performance>("Select * from Performance").ToList() ?? new List<Performance>();
        }

        public Performance GetPerformanceById(int id)
        {
            return this.DbContext.SingleOrDefault<Performance>("Select * from Performance where Id = @0", id);
        }

        public int CreatePerformance(Performance performance)
        {
            this.DbContext.Insert(performance);
            return performance.Id;
        }

        public bool UpdatePerformance(int id, Performance performance)
        {
            if (this.GetPerformanceById(id) != null)
            {
                this.DbContext.Update(performance);
                return true;
            }
            return false;
        }

        public bool DeletePerformance(int id)
        {
            if (this.GetPerformanceById(id) != null)
            {
                this.DbContext.Delete<Performance>(id);
                return true;
            }
            return false;
        }
    }
}
