using SuperHeroApp.Application.Common.Interfaces;
using SuperHeroApp.Application.SuperHeroFeatures.Queries.SearchSuperHeroByName;

namespace SuperHeroApp.Application.SuperHeroFeatures.Queries.GetFavoriteSuperheroes;

public record GetFavoriteSuperheroesQuery : IRequest<List<SuperHeroDto>>
{

}

public class GetFavoriteSuperheroesQueryHandler : IRequestHandler<GetFavoriteSuperheroesQuery, List<SuperHeroDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IUser _user;
    private readonly ISuperHeroService _superHeroService;

    public GetFavoriteSuperheroesQueryHandler(IApplicationDbContext context, IUser user, ISuperHeroService superHeroService)
    {
        _context = context;
        _user = user;
        _superHeroService = superHeroService;
    }

    public async Task<List<SuperHeroDto>> Handle(GetFavoriteSuperheroesQuery request, CancellationToken cancellationToken)
    {
        var favorites = await _context.Favorites
           .Where(f => f.CreatedBy == _user.Id)
           .Select(f => f.SuperheroId)
           .ToListAsync(cancellationToken);

        var superHeros = await _superHeroService.GetSuperHeroesByIdsAsync(favorites);
       
        return superHeros;
    }
}
