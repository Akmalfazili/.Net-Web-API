using Football.DTO;
using Football.Model;
using Football.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Football.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayersService _service;

        public PlayersController(IPlayersService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayersDTO>>> GetPlayers()
        {
            var playersDTO = await _service.GetAllPlayers();
            return Ok(playersDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayersDTO>> GetPlayers(int id)
        {
            var player = await _service.GetPlayersById(id);
            if (player == null)
            {
                return NotFound();
            }
            return player;
        }
        [HttpPost]
        public async Task<ActionResult<PlayersDTO>> AddPlayer([FromBody] PlayersDTO playerDTO)
        {

            try
            {
                var addedPlayer = await _service.AddPlayer(playerDTO);
                return CreatedAtAction(nameof(GetPlayers), new { id = addedPlayer.PlayerId }, addedPlayer);
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PlayersDTO>> DeletePlayer(int id)
        {
            var player = await _service.DeletePlayer(id);
            if (player == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<PlayersDTO>> UpdatePlayer([FromBody] PlayersDTO playerDTO)
        {
            try
            {
                var updatePlayer = await _service.UpdatePlayer(playerDTO);
                return Ok(playerDTO);
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}
