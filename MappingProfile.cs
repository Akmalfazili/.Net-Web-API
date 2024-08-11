using AutoMapper;
using Football.DTO;
using Football.Model;
namespace Football
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<Club, ClubDTO>();
            CreateMap<Players, PlayersDTO>();
            CreateMap<PlayersDTO, Players>()
            .ForMember(dest => dest.Club, opt => opt.Ignore());
            CreateMap<ClubDTO, Club>();
        }
    }
}
