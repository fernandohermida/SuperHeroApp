using System.Net.Http.Json;
using SuperHeroApp.Application.Common.Interfaces;
using SuperHeroApp.Application.SuperHeroFeatures.Queries.SearchSuperHeroByName;

namespace SuperHeroApp.Infrastructure.Services;
public class SuperHeroService : ISuperHeroService
{
    private readonly HttpClient _httpClient;

    public SuperHeroService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<SuperHeroResponse?> SearchByNameAsync(string name)
    {        
        var response = await _httpClient.GetAsync($"search/{name}");

        if (!response.IsSuccessStatusCode) return null;

        var responseBody = await response.Content.ReadFromJsonAsync<SuperHeroResponse>();

        return new SuperHeroResponse { 
            Response = responseBody!.Response,
            Results = responseBody!.Results        
        };
    }
}
