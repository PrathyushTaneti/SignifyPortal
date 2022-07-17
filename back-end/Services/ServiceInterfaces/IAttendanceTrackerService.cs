using SignifyAPI.Models;

namespace SignifyAPI.Services.ServiceInterfaces
{
    public interface IAttendanceTrackerService
    {
        public List<AttendanceTracker> GetAllAttendance();

        public AttendanceTracker GetAttendanceById(int id);

        public int CreateAttendance(AttendanceTracker attendance);

        public bool UpdateAttendace(int id, AttendanceTracker attendance);

        public bool DeleteAttendance(int id);
    }
}
