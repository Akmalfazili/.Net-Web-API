using Football.DTO;
using Football.Model;
namespace Football.Service
{
    public interface IClubService
    {
        Task<List<ClubDTO>> GetAllClubs();
        Task<ClubDTO> GetClubById(int id);
        Task<ClubDTO> AddClub(ClubDTO club);
        Task<ClubDTO> DeleteClub(int id);
        Task<ClubDTO> UpdateClub(ClubDTO club);
    }
}
