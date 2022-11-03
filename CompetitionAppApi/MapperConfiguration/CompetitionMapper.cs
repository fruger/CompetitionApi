using CompetitionAppApi.DTOs.Competition;
using CompetitionAppApi.Models;

namespace CompetitionAppApi.MapperConfiguration;

public static class CompetitionMapper
{
    public static GetCompetitionDto CompetitionToGetCompetitionDto(this Competition competition)
    {
        return new GetCompetitionDto()
        {
            Id = competition.Id,
            Name = competition.Name,
            Laps = competition.Laps,
            Status = competition.Status,
            CompetitorIds = competition.Competitors.Select(c => c.Id).ToList()
        };
    }

    public static Competition PostCompetitionDtoToCompetition(this PostCompetitionDto postCompetitionDto)
    {
        return new Competition
        {
            Name = postCompetitionDto.Name,
            Laps = postCompetitionDto.Laps,
            Status = postCompetitionDto.Status
        };
    }

    public static void PutCompetitionDtoToCompetition(this PutCompetitionDto putCompetitionDto, Competition competition)
    {
        competition.Status = putCompetitionDto.Status;
    }
}