using AutoMapper;
using Football.Data;
using Football.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Football.DTO;
using Football.Service;

namespace Football.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController:ControllerBase
    {
        private readonly IClubService _clubService;
        public ClubController(IClubService clubService)
        {
            _clubService = clubService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClubDTO>>> GetClubs()
        {
            var clubDTO = await _clubService.GetAllClubs();
            return Ok(clubDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClubDTO>> GetClubs(int id)
        {
            var club = await _clubService.GetClubById(id);
            if (club == null)
            {
                return NotFound();
            }
            return club;
        }
        [HttpPost]
        public async Task <ActionResult<ClubDTO>> AddClub([FromBody]ClubDTO clubDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Returns detailed validation errors
            }
            await _clubService.AddClub(clubDTO);
            return CreatedAtAction(nameof(GetClubs), new { id = clubDTO.ClubId }, clubDTO);
        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult<ClubDTO>> DeleteClub(int id)
        {
            var club = await _clubService.DeleteClub(id);
            if(club == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<ClubDTO>> UpdateClub([FromBody]ClubDTO clubDTO)
        {
            try
            {
                var updateClub = await _clubService.UpdateClub(clubDTO);
                return Ok(clubDTO);
            }catch(ArgumentException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}
