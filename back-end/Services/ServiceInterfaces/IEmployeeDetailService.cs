using SignifyAPI.Models;

namespace SignifyAPI.Services.ServiceInterfaces
{
    public interface IEmployeeDetailService
    {
        public List<EmployeeDetails> GetAllEmployeeDetails();

        public EmployeeDetails GetEmployeeDetailById(int id);

        public int CreateEmployeeDetail(EmployeeDetails employeeDetail);

        public bool UpdateEmployeeDetail(int id, EmployeeDetails employeeDetail);

        public bool DeleteEmployeeDetail(int id);
    }
}
