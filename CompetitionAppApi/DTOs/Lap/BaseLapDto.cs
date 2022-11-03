namespace CompetitionAppApi.DTOs.Lap;

public class BaseLapDto
{
    public int Number { get; set; }
    public int PenaltyPoints { get; set; }
    public Guid CompetitorId { get; set; }
}