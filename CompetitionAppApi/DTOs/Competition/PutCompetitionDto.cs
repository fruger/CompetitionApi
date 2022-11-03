namespace CompetitionAppApi.DTOs.Competition;

public class PutCompetitionDto
{
    public Guid Id { get; set; }
    public CompetitionStatus Status { get; set; }
}