using PetaPoco;
using SignifyAPI.Models;
using SignifyAPI.Services.ServiceInterfaces;

namespace SignifyAPI.Services.ServiceClasses
{
    public class EmployeeDetailService : IEmployeeDetailService
    {

        public readonly IDatabase DbContext;

        public EmployeeDetailService()
        {
            this.DbContext = new Database("Server = .\\SQLEXPRESS; " + "Database = SignifyDb; Trusted_Connection = True; " + "TrustServerCertificate = True; ", "System.Data.SqlClient");
        }

        public List<EmployeeDetails> GetAllEmployeeDetails()
        {
            return this.DbContext.Query<EmployeeDetails>("Select * from EmployeeDetails").ToList() ?? new List<EmployeeDetails>();
        }

        public EmployeeDetails GetEmployeeDetailById(int id)
        {
            return this.DbContext.SingleOrDefault<EmployeeDetails>("Select * from EmployeeDetails Where Id = @0", id);
        }

        public int CreateEmployeeDetail(EmployeeDetails employeeDetail)
        {
            this.DbContext.Insert(employeeDetail);
            return employeeDetail.Id;
        }

        public bool UpdateEmployeeDetail(int id, EmployeeDetails employeeDetail)
        {
            if (this.GetEmployeeDetailById(id) != null)
            {
                this.DbContext.Update(employeeDetail);
                return true;
            }
            return false;
        }

        public bool DeleteEmployeeDetail(int id)
        {
            if(this.GetEmployeeDetailById(id) != null)
            {
                this.DbContext.Delete<EmployeeDetails>(id);
                return true;
            }
            return false;
        }
    }
}
