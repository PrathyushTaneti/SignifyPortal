using SignifyAPI.Models;

namespace SignifyAPI.Services.ServiceInterfaces
{
    public interface IPerformanceService
    {
        public List<Performance> GetAllPerformance();

        public Performance GetPerformanceById(int id);

        public int CreatePerformance(Performance performance);

        public bool UpdatePerformance(int id, Performance performance);

        public bool DeletePerformance(int id);
    }
}
