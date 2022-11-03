using CompetitionAppApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CompetitionAppApi.Tests;

public class TestingAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<CompetitionAppDbContext>));

            if (descriptor != null)
                services.Remove(descriptor);

            services.AddDbContext<CompetitionAppDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryCompetitionAppTest");
            });

            var sp = services.BuildServiceProvider();
            using (var scope = sp.CreateScope())
            using (var appContext = scope.ServiceProvider.GetRequiredService<CompetitionAppDbContext>())
            {
                try
                {
                    appContext.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    //Log errors or do anything you think it's needed
                    throw;
                }

                appContext.Competitions.Add(new Competition
                {
                    Id = new Guid("e07b3e5c-b451-4197-bc1c-b7e423d4f060"),
                    Name = "Testing competition",
                    Laps = 7,
                    Competitors = null,
                    Status = (CompetitionStatus)1
                });
                appContext.Competitors.Add(new Competitor
                {
                    Id = new Guid("2088f190-94d9-4f02-beb8-43f1d384316e"),
                    FirstName = "Tomasz",
                    LastName = "Nowak",
                    StartingNumber = 321,
                    Group = 'C',
                    PenaltyPointsSum = 31,
                    Laps = null,
                    CompetitionId = new Guid("e07b3e5c-b451-4197-bc1c-b7e423d4f060"),
                    IsDisqualified = false
                });
                appContext.Laps.Add(new Lap
                {
                    Id = new Guid("2ab3cd5f-5b89-46be-9625-c9c50bbfeb28"),
                    Number = 3,
                    PenaltyPoints = 4,
                    CompetitorId = new Guid("2088f190-94d9-4f02-beb8-43f1d384316e")
                });

                appContext.SaveChanges();
            }
        });
    }
}