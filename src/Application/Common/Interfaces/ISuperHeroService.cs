using SuperHeroApp.Application.SuperHeroFeatures.Queries.SearchSuperHeroByName;

namespace SuperHeroApp.Application.Common.Interfaces;
public interface ISuperHeroService
{
    Task<SuperHeroResponse?> SearchByNameAsync(string name);

    Task<List<SuperHeroDto>> GetSuperHeroesByIdsAsync(List<int> ids);

}
