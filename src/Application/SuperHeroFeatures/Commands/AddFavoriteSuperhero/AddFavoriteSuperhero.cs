using SuperHeroApp.Application.Common.Interfaces;
using SuperHeroApp.Domain.Entities;

namespace SuperHeroApp.Application.SuperHeroFeatures.Commands.AddFavoriteSuperhero;

public record AddFavoriteSuperheroCommand : IRequest<int>
{
    public int SuperheroId { get; set; }
}

public class AddFavoriteSuperheroCommandHandler : IRequestHandler<AddFavoriteSuperheroCommand, int>
{
    private readonly IApplicationDbContext _context;

    public AddFavoriteSuperheroCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(AddFavoriteSuperheroCommand request, CancellationToken cancellationToken)
    {
        var entity = new FavoriteSuperhero
        {
            SuperheroId = request.SuperheroId,
        };

        _context.Favorites.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.SuperheroId;
    }
}
