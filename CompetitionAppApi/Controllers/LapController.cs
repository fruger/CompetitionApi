using CompetitionAppApi.DTOs.Lap;
using CompetitionAppApi.MapperConfiguration;
using CompetitionAppApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompetitionAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LapController : ControllerBase
    {
        private readonly CompetitionAppDbContext _context;

        public LapController(CompetitionAppDbContext context)
        {
            _context = context;
        }

        // GET: api/Lap
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetLapDto>>> GetLaps()
        {
            var laps = await _context.Laps.ToListAsync();

            return laps.Select(x => x.LapToGetLapDto()).ToArray();
        }

        // POST: api/Lap
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lap>> PostLap(PostLapDto postLapDto)
        {
            var lap = postLapDto.PostLapDtoToLap();

            if (_context.Laps == null)
            {
                return Problem("Entity set 'CompetitionAppDbContext.Laps'  is null.");
            }

            _context.Laps.Add(lap);
            await _context.SaveChangesAsync();

            return Created("Created Lap", lap);
        }
    }
}