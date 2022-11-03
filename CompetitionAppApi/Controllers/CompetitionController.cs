using CompetitionAppApi.DTOs.Competition;
using CompetitionAppApi.MapperConfiguration;
using CompetitionAppApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompetitionAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionController : ControllerBase
    {
        private readonly CompetitionAppDbContext _context;

        public CompetitionController(CompetitionAppDbContext context)
        {
            _context = context;
        }

        // GET: api/Competition
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCompetitionDto>>> GetCompetitions()
        {
            var competitions = await _context.Competitions
                .Include(c => c.Competitors)
                .ToListAsync();

            return competitions.Select(x => x.CompetitionToGetCompetitionDto()).ToArray();
        }
        
        // GET: api/Competition/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCompetitionDto>> GetCompetition(Guid id)
        {
          if (_context.Competitions == null)
          {
              return NotFound();
          }

          var competition = await _context.Competitions
              .Where(c => c.Id == id)
              .Include(c => c.Competitors)
              .FirstOrDefaultAsync();

          if (competition == null)
          {
              return NotFound();
          }

          return competition.CompetitionToGetCompetitionDto();
        }

        // POST: api/Competition
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Competition>> PostCompetition(PostCompetitionDto postCompetitionDto)
        { 
            var competition = postCompetitionDto.PostCompetitionDtoToCompetition();
            
          if (_context.Competitions == null)
          {
              return Problem("Entity set 'CompetitionAppDbContext.Competitions'  is null.");
          }

          _context.Competitions.Add(competition);
          await _context.SaveChangesAsync();

          return CreatedAtAction("GetCompetition", new { id = competition.Id }, competition);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompetition(Guid id, PutCompetitionDto putCompetitionDto)
        {
            if (id != putCompetitionDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }
            
            var competition = await _context.Competitions
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (competition == null)
            {
                return NotFound();
            }

            putCompetitionDto.PutCompetitionDtoToCompetition(competition);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
