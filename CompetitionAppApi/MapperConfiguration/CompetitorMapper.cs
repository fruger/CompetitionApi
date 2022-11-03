using CompetitionAppApi.DTOs.Competitor;
using CompetitionAppApi.Models;

namespace CompetitionAppApi.MapperConfiguration;

public static class CompetitorMapper
{
    public static GetCompetitorDto CompetitorToGetCompetitorDto(this Competitor competitor)
    {
        return new GetCompetitorDto
        {
            Id = competitor.Id,
            FirstName = competitor.FirstName,
            LastName = competitor.LastName,
            Group = competitor.Group,
            CompetitionId = competitor.CompetitionId,
            StartingNumber = competitor.StartingNumber,
            PenaltyPointsSum = competitor.PenaltyPointsSum,
            IsDisqualified = competitor.IsDisqualified,
            LapIds = competitor.Laps.Select(l => l.Id).ToList()
        };
    }

    public static Competitor PostCompetitorDtoToCompetitor(this PostCompetitorDto postCompetitorDto)
    {
        return new Competitor
        {
            FirstName = postCompetitorDto.FirstName,
            LastName = postCompetitorDto.LastName,
            Group = postCompetitorDto.Group,
            CompetitionId = postCompetitorDto.CompetitionId,
            StartingNumber = postCompetitorDto.StartingNumber,
            PenaltyPointsSum = postCompetitorDto.PenaltyPointsSum,
            IsDisqualified = postCompetitorDto.IsDisqualified,
        };
    }

    public static void PutDisqualifiedCompetitorDtoToCompetitor(
        this PutDisqualifiedCompetitorDto putDisqualifiedCompetitorDto, Competitor competitor)
    {
        competitor.IsDisqualified = putDisqualifiedCompetitorDto.IsDisqualified;
    }
    
    public static void PutPenaltyPointsSumCompetitorDtoToCompetitor(
        this PutPenaltyPointsSumCompetitorDto putPenaltyPointsSumCompetitorDto, Competitor competitor)
    {
        competitor.PenaltyPointsSum = putPenaltyPointsSumCompetitorDto.PenaltyPointsSum;
    }
}