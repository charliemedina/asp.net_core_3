using AutoMapper;
using WebAPI.Models;

namespace WebAPI.Mapping
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            // Domain to Model
            CreateMap<User, UserModel>();

            // Model to Domain
            CreateMap<UserModel, User>();
        }
    }
}
