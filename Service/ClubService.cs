using AutoMapper;
using Football.Data;
using Football.DTO;
using Football.Model;
using Microsoft.EntityFrameworkCore;

namespace Football.Service
{
    public class ClubService:IClubService
    {
        private readonly IMapper _mapper;
        private readonly FootballContext _context;
        public ClubService(IMapper mapper, FootballContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<ClubDTO>> GetAllClubs()
        {
            var clubs = await _context.Clubs.ToListAsync();
            return  _mapper.Map<List<ClubDTO>>(clubs);
        }

        public async Task<ClubDTO> GetClubById(int id)
        {
            var club = await _context.Clubs.FindAsync(id);
            if (club == null)
            {
                return null;
            }
            return _mapper.Map<ClubDTO>(club);
        }
        public async Task<ClubDTO> AddClub(ClubDTO clubDTO)
        {
            var club = _mapper.Map<Club>(clubDTO);
            _context.Add(club);
            await _context.SaveChangesAsync();
            return _mapper.Map<ClubDTO>(club);
        }

        public async Task<ClubDTO> DeleteClub(int id)
        {
            var club = await _context.Clubs.FindAsync(id);
            if(club == null)
            {
                return null;
            }
            _context.Remove(club);
            await  _context.SaveChangesAsync();
            return _mapper.Map<ClubDTO>(club) ;

        }

        public async Task<ClubDTO> UpdateClub(ClubDTO clubDTO)
        {
            var club = _mapper.Map<Club>(clubDTO);
            var clubTrue = await _context.Clubs.FindAsync(club.ClubId);
            if (clubTrue == null)
            {
                throw new ArgumentException("Club not found");
            }
            clubTrue.ClubName=clubDTO.ClubName;
            await _context.SaveChangesAsync();
            return _mapper.Map<ClubDTO>(clubTrue);
        } 
    }
}
