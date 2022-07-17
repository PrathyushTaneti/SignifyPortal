using SignifyAPI.Models;

namespace SignifyAPI.Services.ServiceInterfaces
{
    public interface IActiveMeetingsService
    {
        public List<ActiveMeetings> GetAllActiveMeetings();

        public ActiveMeetings GetMeetingById(int id);

        public int CreateMeeting(ActiveMeetings meeting);

        public bool UpdateMeeting(int id, ActiveMeetings meeting);

        public bool DeleteMeeting(int id);
    }
}
