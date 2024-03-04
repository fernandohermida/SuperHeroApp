using SuperHeroApp.Application.Common.Interfaces;

namespace SuperHeroApp.Application.SuperHeroFeatures.Queries.SearchSuperHeroByName;

public record SearchSuperHeroByNameQuery : IRequest<SuperHeroResponse?>
{
    public required string Name { get; init; }
}

public class SearchSuperHeroByNameQueryValidator : AbstractValidator<SearchSuperHeroByNameQuery>
{
    public SearchSuperHeroByNameQueryValidator()
    {
    }
}

public class SearchSuperHeroByNameQueryHandler : IRequestHandler<SearchSuperHeroByNameQuery, SuperHeroResponse?>
{
    private readonly ISuperHeroService _superHeroService;

    public SearchSuperHeroByNameQueryHandler(ISuperHeroService superHeroService)
    {
        _superHeroService = superHeroService;
    }

    public async Task<SuperHeroResponse?> Handle(SearchSuperHeroByNameQuery request, CancellationToken cancellationToken)
    {
        var superHeros = await _superHeroService.SearchByNameAsync(request.Name);

        return superHeros;
    }
}
