using CompetitionAppApi.DTOs.Lap;
using CompetitionAppApi.Models;

namespace CompetitionAppApi.MapperConfiguration;

public static class LapMapper
{
    public static GetLapDto LapToGetLapDto (this Lap lap)
    {
        return new GetLapDto
        {
            Id = lap.Id,
            Number = lap.Number,
            PenaltyPoints = lap.PenaltyPoints,
            CompetitorId = lap.CompetitorId,
        };
    }
    
    public static Lap PostLapDtoToLap (this PostLapDto postLapDto)
    {
        return new Lap
        {
            Number = postLapDto.Number,
            PenaltyPoints = postLapDto.PenaltyPoints,
            CompetitorId = postLapDto.CompetitorId
        };
    }
}