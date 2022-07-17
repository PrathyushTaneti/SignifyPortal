using PetaPoco;
using SignifyAPI.Models;
using SignifyAPI.Services.ServiceInterfaces;

namespace SignifyAPI.Services.ServiceClasses
{
    public class ActiveMeetingsService : IActiveMeetingsService
    {
        public readonly IDatabase DbContext;

        public ActiveMeetingsService()
        {
            this.DbContext = new Database("Server = .\\SQLEXPRESS; " + "Database = SignifyDb; Trusted_Connection = True; " + "TrustServerCertificate = True; ", "System.Data.SqlClient");
        }
        public List<ActiveMeetings> GetAllActiveMeetings()
        {
            return this.DbContext.Query<ActiveMeetings>("Select * from ActiveMeetings").ToList() ?? new List<ActiveMeetings>();
        }

        public ActiveMeetings GetMeetingById(int id)
        {
            return this.DbContext.SingleOrDefault<ActiveMeetings>("Select * from ActiveMeetings where Id = @0", id);
        }

        public bool UpdateMeeting(int id, ActiveMeetings meeting)
        {
            if(this.GetMeetingById(id) != null)
            {
                this.DbContext.Update(meeting);
                return true;
            }
            return false;
        }

        public int CreateMeeting(ActiveMeetings activeMeeting)
        {
            this.DbContext.Insert(activeMeeting);
            return activeMeeting.Id;
        }

        public bool DeleteMeeting(int id)
        {
            if(this.GetMeetingById(id) != null)
            {
                this.DbContext.Delete<ActiveMeetings>(id);
                return true;
            }
            return false;
        }
    }
}
