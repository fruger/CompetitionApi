using System.Net.Http.Json;
using CompetitionAppApi.DTOs.Competition;
using Xunit;

namespace CompetitionAppApi.Tests;

public class CompetitionTests : IClassFixture<TestingAppFactory<Program>>
{
    private readonly HttpClient _client;
    public CompetitionTests(TestingAppFactory<Program> factory) 
        => _client = factory.CreateClient();

    [Fact]
    public async Task GetCompetitions_ShouldReturnOK()
    {
        var getRequest = new HttpRequestMessage(HttpMethod.Get, "/api/Competition");
        
        var response = await _client.GetAsync(getRequest.RequestUri);
        
        var responseStatusCodeString = response.StatusCode.ToString();
        Assert.Contains("OK", responseStatusCodeString);
    }
    
    [Fact]
    public async Task GetCompetitions_ShouldReturnCompetitionWithExactId()
    {
        var getRequest = new HttpRequestMessage(HttpMethod.Get, "/api/Competition");
        
        var response = await _client.GetAsync(getRequest.RequestUri);

        var responseContent = await response.Content.ReadAsStringAsync();
        Assert.Contains("e07b3e5c-b451-4197-bc1c-b7e423d4f060", responseContent);
    }
    
    [Fact]
    public async Task GetCompetition_ShouldReturnOK()
    {
        var getRequest = new HttpRequestMessage(HttpMethod.Get, "/api/Competition/e07b3e5c-b451-4197-bc1c-b7e423d4f060");
        
        var response = await _client.GetAsync(getRequest.RequestUri);
        
        var responseStatusCodeString = response.StatusCode.ToString();
        Assert.Contains("OK", responseStatusCodeString);
    }
    
    [Fact]
    public async Task GetCompetition_ShouldReturnRecordWithExactName()
    {
        var getRequest = new HttpRequestMessage(HttpMethod.Get, "/api/Competition/e07b3e5c-b451-4197-bc1c-b7e423d4f060");
        
        var response = await _client.GetAsync(getRequest.RequestUri);
        
        var responseString = await response.Content.ReadAsStringAsync();
        Assert.Contains("Testing competition", responseString);
    }
    
    [Fact]
    public async Task PostCompetition_ShouldReturnCreatedStatusCode()
    {
        var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/Competition");
        
        var response = await _client.PostAsJsonAsync
            (postRequest.RequestUri, CorrectPostCompetitionDto());
        
        var responseStatusCodeString = response.StatusCode.ToString();
        Assert.Contains("Created", responseStatusCodeString);
    }
    
    [Fact]
    public async Task PostCompetition_ShouldReturnCreatedCompetitionWithExactName()
    {
        var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/Competition");
        
        var response = await _client.PostAsJsonAsync
            (postRequest.RequestUri, CorrectPostCompetitionDto());
        
        var responseString = await response.Content.ReadAsStringAsync();
        Assert.Contains("Testing Name", responseString);
    }
    
    [Fact]
    public async Task PutCompetition_ShouldReturnNoContentStatusCode()
    {
        var putRequest = new HttpRequestMessage(HttpMethod.Put,
            "/api/Competition/e07b3e5c-b451-4197-bc1c-b7e423d4f060");

        var response = await _client.PutAsJsonAsync(putRequest.RequestUri, CorrectPutCompetitionDto());

        var responseStatusCodeString = response.StatusCode.ToString();
        Assert.Contains("NoContent", responseStatusCodeString);
    }
    
    [Fact]
    public async Task PutCompetition_ShouldReturnStartedCompetition()
    {
        var putRequest = new HttpRequestMessage(HttpMethod.Put,
            "/api/Competition/e07b3e5c-b451-4197-bc1c-b7e423d4f060");

        await _client.PutAsJsonAsync(putRequest.RequestUri, CorrectPutCompetitionDto());

        var responseString = await _client.GetAsync("/api/Competition/e07b3e5c-b451-4197-bc1c-b7e423d4f060");
        var returnString = await responseString.Content.ReadAsStringAsync();
        Assert.Contains("\"status\":2", returnString);
    }

    private PostCompetitionDto CorrectPostCompetitionDto()
    {
        var correctPostCompetitionDto = new PostCompetitionDto
        {
            Name = "Testing Name",
            Laps = 8
        };
        return correctPostCompetitionDto;
    }
    
    private PutCompetitionDto CorrectPutCompetitionDto()
    {
        var correctPutCompetitionDto = new PutCompetitionDto
        {
            Id = new Guid("e07b3e5c-b451-4197-bc1c-b7e423d4f060"),
            Status = (CompetitionStatus)2
        };
        return correctPutCompetitionDto;
    }
}