namespace server.Mappings
{
    public class Map : Profile
    {
        public Map()
        {
            CreateMap<Admin, AdminDTO>();
        }
    }
}
