namespace CompetitionAppApi.DTOs.Competitor;

public class PutDisqualifiedCompetitorDto
{
    public Guid Id { get; set; }
    public bool IsDisqualified { get; set; }
}