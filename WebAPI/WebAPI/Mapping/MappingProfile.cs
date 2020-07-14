using AutoMapper;
using WebAPI.Models;

namespace WebAPI.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Domain to Model
            CreateMap<User, UserModel>();
            CreateMap<User, UpdateModel>();

            // Model to Domain
            CreateMap<UserModel, User>();
            CreateMap<UpdateModel, User>();
        }
    }
}
