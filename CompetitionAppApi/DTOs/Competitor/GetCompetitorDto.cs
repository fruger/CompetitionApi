namespace CompetitionAppApi.DTOs.Competitor;

public class GetCompetitorDto : BaseCompetitorDto
{
    public Guid Id { get; set; }
    public Guid CompetitionId { get; set; }
    public int StartingNumber { get; set; }
    public int PenaltyPointsSum { get; set; }
    public IList<Guid> LapIds { get; set; }
}