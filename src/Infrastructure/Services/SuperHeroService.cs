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

        return new SuperHeroResponse
        {
            Response = responseBody!.Response,
            Results = responseBody!.Results,
            ResultsFor = responseBody!.ResultsFor
        };
    }

    public async Task<List<SuperHeroDto>> GetSuperHeroesByIdsAsync(List<int> ids)
    {
        List<SuperHeroDto> superHeroes = new List<SuperHeroDto>();

        foreach (var id in ids)
        {
            var response = await _httpClient.GetAsync($"{id}");

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadFromJsonAsync<SuperHeroDto>();

                if (responseBody != null)
                {
                    superHeroes.Add(new SuperHeroDto
                    {
                        Id = responseBody.Id,
                        Name = responseBody.Name,
                        Powerstats = responseBody.Powerstats,
                        Biography = responseBody.Biography,
                        Appearance = responseBody.Appearance,
                        Work = responseBody.Work,
                        Connections = responseBody.Connections,
                        Image = responseBody.Image
                    });
                }
            }
        }

        return superHeroes;
    }
}
