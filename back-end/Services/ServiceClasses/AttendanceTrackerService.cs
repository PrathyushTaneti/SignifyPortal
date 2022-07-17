using PetaPoco;
using SignifyAPI.Models;
using SignifyAPI.Services.ServiceInterfaces;

namespace SignifyAPI.Services.ServiceClasses
{
    public class AttendanceTrackerService : IAttendanceTrackerService
    {
        public readonly IDatabase DbContext;

        public AttendanceTrackerService()
        {
            this.DbContext = new Database("Server = .\\SQLEXPRESS; " + "Database = SignifyDb; Trusted_Connection = True; " + "TrustServerCertificate = True; ", "System.Data.SqlClient");
        }

        public List<AttendanceTracker> GetAllAttendance()
        {
            return this.DbContext.Query<AttendanceTracker>("Select * from AttendanceTracker").ToList() ?? new List<AttendanceTracker>();
        }

        public AttendanceTracker GetAttendanceById(int id)
        {
            return this.DbContext.SingleOrDefault<AttendanceTracker>("Select * from AttendanceTracker where Id= @0", id);
        }

        public int CreateAttendance(AttendanceTracker attendance)
        {
            this.DbContext.Insert(attendance);
            return attendance.Id;
        }

        public bool UpdateAttendace(int id, AttendanceTracker attendance)
        {
            if(this.GetAttendanceById(id) != null){
                this.DbContext.Update(attendance);
                return true;
            }
            return false;
        }

        public bool DeleteAttendance(int id)
        {
            if(this.GetAttendanceById(id) != null)
            {
                this.DbContext.Delete<AttendanceTracker>(id);
                return true;
            }
            return false;
        }  
    }
}
