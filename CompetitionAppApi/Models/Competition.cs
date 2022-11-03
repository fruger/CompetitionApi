using System.ComponentModel.DataAnnotations;

namespace CompetitionAppApi.Models;

public class Competition
{
    public Guid Id { get; set; }

    [Required] 
    public string Name { get; set; }

    [Required] 
    public int Laps { get; set; }
    public IList<Competitor> Competitors { get; set; }

    public CompetitionStatus Status { get; set; }
}