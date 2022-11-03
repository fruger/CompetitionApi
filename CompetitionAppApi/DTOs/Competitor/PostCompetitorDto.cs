namespace CompetitionAppApi.DTOs.Competitor;

public class PostCompetitorDto : BaseCompetitorDto
{
    public int PenaltyPointsSum { get; set; }
    public int StartingNumber { get; set; }
    public Guid CompetitionId { get; set; }
}