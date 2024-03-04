using SuperHeroApp.Application.Common.Interfaces;

namespace SuperHeroApp.Application.SuperHeroFeatures.Queries.GetFavoriteSuperheroes;

public record GetFavoriteSuperheroesQuery : IRequest<List<int>>
{

}

public class GetFavoriteSuperheroesQueryHandler : IRequestHandler<GetFavoriteSuperheroesQuery, List<int>>
{
    private readonly IApplicationDbContext _context;
    private readonly IUser _user;

    public GetFavoriteSuperheroesQueryHandler(IApplicationDbContext context, IUser user)
    {
        _context = context;
        _user = user;
    }

    public async Task<List<int>> Handle(GetFavoriteSuperheroesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Favorites
            .Where(f => f.CreatedBy == _user.Id)
            .Select(f => f.SuperheroId)
            .ToListAsync(cancellationToken);
    }
}
