namespace CompetitionAppApi.DTOs.Competition;

public class GetCompetitionDto : BaseCompetitionDto
{
    public Guid Id { get; set; }
    public IList<Guid> CompetitorIds { get; set; }
}