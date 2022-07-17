using SignifyAPI.Models;

namespace SignifyAPI.Services.ServiceInterfaces
{
    public interface IAdminDetailsService
    {
        public List<AdminDetails> GetAllAdminDetails();

        public AdminDetails GetAdminDetailById(int id);

        public int CreateAdmin(AdminDetails admin);

        public bool UpdateAdmin(int id, AdminDetails admin);

        public bool DeleteAdmin(int id);
    }
}
