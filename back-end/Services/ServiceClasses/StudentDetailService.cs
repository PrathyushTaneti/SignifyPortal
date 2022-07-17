using PetaPoco;
using SignifyAPI.Models;
using SignifyAPI.Services.ServiceInterfaces;

namespace SignifyAPI.Services.ServiceClasses
{
    public class StudentDetailService : IStudentDetailService
    {
        public readonly IDatabase DbContext;

        public StudentDetailService()
        {
            this.DbContext = new Database("Server = .\\SQLEXPRESS; " + "Database = SignifyDb; Trusted_Connection = True; " + "TrustServerCertificate = True; ", "System.Data.SqlClient");
        }

        public List<StudentDetails> GetAllStudentDetails()
        {
            return this.DbContext.Query<StudentDetails>("Select * from StudentDetails").ToList() ?? new List<StudentDetails>(); 
        }

        public StudentDetails GetStudentDetailById(int id)
        {
            return this.DbContext.SingleOrDefault<StudentDetails>("Select * from StudentDetails where Id = @0", id);
        }

        public bool UpdateStudentDetail(int id, StudentDetails studentDetail)
        {
            if (this.GetStudentDetailById(id) != null)
            {
                this.DbContext.Update(studentDetail);
                return true;
            }
            return false;
        }

        public int CreateStudentDetail(StudentDetails studentDetail)
        {
            this.DbContext.Insert(studentDetail);
            return studentDetail.Id;
        }

        public bool DeleteStudentDetail(int id)
        {
            if(this.GetStudentDetailById(id) != null)
            {
                this.DbContext.Delete<StudentDetails>(id);
                return true;
            }
            return false;
        }     
    }
}


