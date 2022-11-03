using System.Net.Http.Json;
using CompetitionAppApi.DTOs.Competitor;
using Xunit;

namespace CompetitionAppApi.Tests;

public class CompetitorTests : IClassFixture<TestingAppFactory<Program>>
{
    private readonly HttpClient _client;

    public CompetitorTests(TestingAppFactory<Program> factory)
        => _client = factory.CreateClient();

    [Fact]
    public async Task GetCompetitors_ShouldReturnOK()
    {
        var getRequest = new HttpRequestMessage(HttpMethod.Get, "/api/Competitor");

        var response = await _client.GetAsync(getRequest.RequestUri);

        var responseStatusCodeString = response.StatusCode.ToString();
        Assert.Contains("OK", responseStatusCodeString);
    }

    [Fact]
    public async Task GetCompetitors_ShouldReturnCompetitorWithExactId()
    {
        var getRequest = new HttpRequestMessage(HttpMethod.Get, "/api/Competitor");

        var response = await _client.GetAsync(getRequest.RequestUri);

        var responseContent = await response.Content.ReadAsStringAsync();
        Assert.Contains("2088f190-94d9-4f02-beb8-43f1d384316e", responseContent);
    }

    [Fact]
    public async Task PostCompetitor_ShouldReturnCreatedStatusCode()
    {
        var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/Competitor");

        var response = await _client.PostAsJsonAsync
            (postRequest.RequestUri, CorrectPostCompetitorDto());

        var responseStatusCodeString = response.StatusCode.ToString();
        Assert.Contains("Created", responseStatusCodeString);
    }

    [Fact]
    public async Task PostCompetitor_ShouldReturnCreatedCompetitorWithExactLastName()
    {
        var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/Competitor");

        var response = await _client.PostAsJsonAsync
            (postRequest.RequestUri, CorrectPostCompetitorDto());

        var responseString = await response.Content.ReadAsStringAsync();
        Assert.Contains("Kowalski", responseString);
    }

    [Fact]
    public async Task PutDisqualifiedCompetitor_ShouldReturnNoContentStatusCode()
    {
        var putRequest = new HttpRequestMessage(HttpMethod.Put,
            "/api/Competitor/disqualified/2088f190-94d9-4f02-beb8-43f1d384316e");

        var response = await _client.PutAsJsonAsync(putRequest.RequestUri, CorrectPutDisqualifiedCompetitorDto());

        var responseStatusCodeString = response.StatusCode.ToString();
        Assert.Contains("NoContent", responseStatusCodeString);
    }

    [Fact]
    public async Task PutDisqualifiedCompetitor_ShouldReturnDisqualifiedCompetitor()
    {
        var putRequest = new HttpRequestMessage(HttpMethod.Put,
            "/api/Competitor/disqualified/2088f190-94d9-4f02-beb8-43f1d384316e");

        await _client.PutAsJsonAsync(putRequest.RequestUri, CorrectPutDisqualifiedCompetitorDto());

        var responseString = await _client.GetAsync("/api/Competitor");
        var returnString = await responseString.Content.ReadAsStringAsync();
        Assert.Contains("\"isDisqualified\":true", returnString);
    }

    [Fact]
    public async Task PutPenaltyPointsSumCompetitor_ShouldReturnNoContentStatusCode()
    {
        var putRequest = new HttpRequestMessage(HttpMethod.Put,
            "/api/Competitor/penaltysum/2088f190-94d9-4f02-beb8-43f1d384316e");

        var response = await _client.PutAsJsonAsync(putRequest.RequestUri, CorrectPutPenaltyPointsSumCompetitorDto());

        var responseStatusCodeString = response.StatusCode.ToString();
        Assert.Contains("NoContent", responseStatusCodeString);
    }

    [Fact]
    public async Task PutPenaltyPointsSumCompetitor_ShouldReturnCompetitorWithExactPenaltyPointsSum()
    {
        var putRequest = new HttpRequestMessage(HttpMethod.Put,
            "/api/Competitor/penaltysum/2088f190-94d9-4f02-beb8-43f1d384316e");

        await _client.PutAsJsonAsync(putRequest.RequestUri, CorrectPutPenaltyPointsSumCompetitorDto());

        var responseString = await _client.GetAsync("/api/Competitor");
        var returnString = await responseString.Content.ReadAsStringAsync();
        Assert.Contains("\"penaltyPointsSum\":27", returnString);
    }


    private PostCompetitorDto CorrectPostCompetitorDto()
    {
        var correctPostCompetitorDto = new PostCompetitorDto
        {
            FirstName = "Adam",
            LastName = "Kowalski",
            Group = 'A',
            CompetitionId = new Guid()
        };
        return correctPostCompetitorDto;
    }

    private PutDisqualifiedCompetitorDto CorrectPutDisqualifiedCompetitorDto()
    {
        var correctPutDisqualifiedCompetitorDto = new PutDisqualifiedCompetitorDto
        {
            Id = new Guid("2088f190-94d9-4f02-beb8-43f1d384316e"),
            IsDisqualified = true
        };
        return correctPutDisqualifiedCompetitorDto;
    }

    private PutPenaltyPointsSumCompetitorDto CorrectPutPenaltyPointsSumCompetitorDto()
    {
        var correctPutPenaltyPointsSumCompetitorDto = new PutPenaltyPointsSumCompetitorDto
        {
            Id = new Guid("2088f190-94d9-4f02-beb8-43f1d384316e"),
            PenaltyPointsSum = 27,
        };
        return correctPutPenaltyPointsSumCompetitorDto;
    }
}