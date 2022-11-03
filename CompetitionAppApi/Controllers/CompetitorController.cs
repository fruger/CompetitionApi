using CompetitionAppApi.DTOs.Competitor;
using CompetitionAppApi.MapperConfiguration;
using CompetitionAppApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompetitionAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorController : ControllerBase
    {
        private readonly CompetitionAppDbContext _context;

        public CompetitorController(CompetitionAppDbContext context)
        {
            _context = context;
        }

        // GET: api/Competitor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCompetitorDto>>> GetCompetitors()
        {
            var competitors = await _context.Competitors
                .Include(l => l.Laps)
                .ToListAsync();

            return competitors.Select(x => x.CompetitorToGetCompetitorDto()).ToArray();
        }

        // POST: api/Competitor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Competitor>> PostCompetitor(PostCompetitorDto postCompetitorDto)
        {
            var competitor = postCompetitorDto.PostCompetitorDtoToCompetitor();

            if (_context.Competitors == null)
            {
                return Problem("Entity set 'CompetitionAppDbContext.Competitors'  is null.");
            }

            _context.Competitors.Add(competitor);
            await _context.SaveChangesAsync();

            return Created("Created Competitor", competitor);
        }

        // PUT: api/Competitor/disqualified/5
        [HttpPut("disqualified/{id}")]
        public async Task<IActionResult> PutDisqualifiedCompetitor(Guid id,
            PutDisqualifiedCompetitorDto putDisqualifiedCompetitorDto)
        {
            if (id != putDisqualifiedCompetitorDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            var competitor = await _context.Competitors
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (competitor == null)
            {
                return NotFound();
            }

            putDisqualifiedCompetitorDto.PutDisqualifiedCompetitorDtoToCompetitor(competitor);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/Competitor/penaltysum/5
        [HttpPut("penaltysum/{id}")]
        public async Task<IActionResult> PutPenaltyPointsSumCompetitor(Guid id,
            PutPenaltyPointsSumCompetitorDto putPenaltyPointsSumCompetitorDto)
        {
            if (id != putPenaltyPointsSumCompetitorDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            var competitor = await _context.Competitors
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (competitor == null)
            {
                return NotFound();
            }

            putPenaltyPointsSumCompetitorDto.PutPenaltyPointsSumCompetitorDtoToCompetitor(competitor);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}