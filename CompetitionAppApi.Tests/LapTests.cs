using System.Net.Http.Json;
using CompetitionAppApi.DTOs.Competitor;
using CompetitionAppApi.DTOs.Lap;
using Xunit;

namespace CompetitionAppApi.Tests;

public class LapTests : IClassFixture<TestingAppFactory<Program>>
{
    private readonly HttpClient _client;

    public LapTests(TestingAppFactory<Program> factory)
        => _client = factory.CreateClient();

    [Fact]
    public async Task GetLaps_ShouldReturnOK()
    {
        var getRequest = new HttpRequestMessage(HttpMethod.Get, "/api/Lap");

        var response = await _client.GetAsync(getRequest.RequestUri);

        var responseStatusCodeString = response.StatusCode.ToString();
        Assert.Contains("OK", responseStatusCodeString);
    }

    [Fact]
    public async Task GetLaps_ShouldReturnCompetitorWithExactId()
    {
        var getRequest = new HttpRequestMessage(HttpMethod.Get, "/api/Lap");

        var response = await _client.GetAsync(getRequest.RequestUri);

        var responseContent = await response.Content.ReadAsStringAsync();
        Assert.Contains("2ab3cd5f-5b89-46be-9625-c9c50bbfeb28", responseContent);
    }

    [Fact]
    public async Task PostLap_ShouldReturnCreatedStatusCode()
    {
        var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/Lap");

        var response = await _client.PostAsJsonAsync
            (postRequest.RequestUri, CorrectPostLapDto());

        var responseStatusCodeString = response.StatusCode.ToString();
        Assert.Contains("Created", responseStatusCodeString);
    }

    [Fact]
    public async Task PostLap_ShouldReturnCreatedLapWithExactCompetitorId()
    {
        var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/Lap");

        var response = await _client.PostAsJsonAsync
            (postRequest.RequestUri, CorrectPostLapDto());

        var responseString = await response.Content.ReadAsStringAsync();
        Assert.Contains("c45f74ee-b374-483b-b335-0cb115c2981b", responseString);
    }

    private PostLapDto CorrectPostLapDto()
    {
        var correctPostLapDto = new PostLapDto
        {
            Number = 7,
            PenaltyPoints = 2,
            CompetitorId = new Guid("c45f74ee-b374-483b-b335-0cb115c2981b")
        };
        return correctPostLapDto;
    }
}