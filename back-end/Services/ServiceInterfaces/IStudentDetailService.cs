using SignifyAPI.Models;

namespace SignifyAPI.Services.ServiceInterfaces
{
    public interface IStudentDetailService
    {
        public List<StudentDetails> GetAllStudentDetails();
        public StudentDetails GetStudentDetailById(int id);
        public int CreateStudentDetail(StudentDetails studentDetail);
        public bool UpdateStudentDetail(int id, StudentDetails studentDetail);
        public bool DeleteStudentDetail(int id);
    }
}
