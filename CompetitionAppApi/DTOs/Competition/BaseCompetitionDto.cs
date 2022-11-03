namespace CompetitionAppApi.DTOs.Competition;

public class BaseCompetitionDto
{
    public string Name { get; set; }
    public int Laps { get; set; }

    public CompetitionStatus Status { get; set; }
}