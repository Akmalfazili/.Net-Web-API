using AutoMapper;
using Football.Data;
using Football.DTO;
using Football.Model;
using Microsoft.EntityFrameworkCore;
namespace Football.Service
{
    public class PlayersService : IPlayersService
    {
        private readonly IMapper _mapper;
        private readonly FootballContext _context;

        public PlayersService(IMapper mapper, FootballContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<PlayersDTO>> GetAllPlayers()
        {
            var players = await _context.Players.ToListAsync();
            return _mapper.Map<List<PlayersDTO>>(players);
        }

        public async Task<PlayersDTO> GetPlayersById(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return null;
            }
            return _mapper.Map<PlayersDTO>(player);
        }

        public async Task<PlayersDTO> AddPlayer(PlayersDTO playerDTO)
        {   
            var player =_mapper.Map<Players>(playerDTO);
            var club = await _context.Clubs.FindAsync(player.ClubId);
            if (club == null)
            {
                throw new ArgumentException("Club not found");
            }
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return _mapper.Map<PlayersDTO>(player);

        }
        public async Task<PlayersDTO> DeletePlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return null;
            }
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return _mapper.Map<PlayersDTO>(player);
        }

        public async Task<PlayersDTO> UpdatePlayer(PlayersDTO playerDTO)
        {
            var player = _mapper.Map<Players>(playerDTO);
            var playerTrue = await _context.Players.FindAsync(player.PlayerId);
            var clubTrue = await _context.Clubs.FindAsync(player.ClubId);
            if(playerTrue ==null)
            {
                throw new ArgumentException("Player not found");
            }
            if (clubTrue == null)
            {
                throw new ArgumentException("club not found");
            }

            playerTrue.Name = playerDTO.Name;
            playerTrue.Appearances = playerDTO.Appearances;
            playerTrue.ClubId = playerDTO.ClubId;

            await _context.SaveChangesAsync();
            return _mapper.Map<PlayersDTO>(playerTrue);
        }
    }
}
