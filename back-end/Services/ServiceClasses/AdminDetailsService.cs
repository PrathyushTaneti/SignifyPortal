using PetaPoco;
using SignifyAPI.Models;
using SignifyAPI.Services.ServiceInterfaces;

namespace SignifyAPI.Services.ServiceClasses
{
    public class AdminDetailsService : IAdminDetailsService
    {
        public readonly IDatabase DbContext;

        public AdminDetailsService()
        {
            this.DbContext = new Database("Server = .\\SQLEXPRESS; " + "Database = SignifyDb; Trusted_Connection = True; " + "TrustServerCertificate = True; ", "System.Data.SqlClient");
        }

        public int CreateAdmin(AdminDetails admin)
        {
            this.DbContext.Insert(admin);
            return admin.Id;
        }

        public bool DeleteAdmin(int id)
        {
            if(this.GetAdminDetailById(id) != null)
            {
                this.DbContext.Delete<AdminDetails>(id);
                return true;
            }
            return false;
        }

        public AdminDetails GetAdminDetailById(int id)
        {
            return this.DbContext.SingleOrDefault<AdminDetails>("Select * from AdminDetails where Id = @0", id);
        }

        public List<AdminDetails> GetAllAdminDetails()
        {
            return this.DbContext.Query<AdminDetails>("Select * from AdminDetails").ToList() ?? new List<AdminDetails>();
        }

        public bool UpdateAdmin(int id, AdminDetails admin)
        {
            if(this.GetAdminDetailById(id) != null)
            {
                this.DbContext.Update(admin);
                return true;
            }
            return false;
        }
    }
}
