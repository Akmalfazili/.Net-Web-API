using Football.DTO;
using Football.Model;
namespace Football.Service
{
    public interface IPlayersService
    {
        Task<List<PlayersDTO>> GetAllPlayers();
        Task<PlayersDTO> GetPlayersById(int id);
        Task<PlayersDTO> AddPlayer(PlayersDTO player);
        Task<PlayersDTO> DeletePlayer(int id);
        Task<PlayersDTO>UpdatePlayer(PlayersDTO player);
    }
}
