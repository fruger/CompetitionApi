namespace CompetitionAppApi.DTOs.Competitor;

public class BaseCompetitorDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public char Group { get; set; }
    public bool IsDisqualified { get; set; }
}