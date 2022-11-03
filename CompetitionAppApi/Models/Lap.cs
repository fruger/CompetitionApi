using System.ComponentModel.DataAnnotations;

namespace CompetitionAppApi.Models;

public class Lap
{
    public Guid Id { get; set; }
    
    [Required]
    public int Number { get; set; }
    
    [Required]
    public int PenaltyPoints { get; set; }
    public Guid CompetitorId { get; set; }
}