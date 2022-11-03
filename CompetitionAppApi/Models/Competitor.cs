using System.ComponentModel.DataAnnotations;

namespace CompetitionAppApi.Models;

public class Competitor
{
    public Guid Id { get; set; }
    
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    public int StartingNumber { get; set; }
    
    [Required]
    public char Group { get; set; }
    
    public int PenaltyPointsSum { get; set; }
    public IList<Lap> Laps { get; set; }
    public Guid CompetitionId { get; set; }

    public bool IsDisqualified { get; set; }
}