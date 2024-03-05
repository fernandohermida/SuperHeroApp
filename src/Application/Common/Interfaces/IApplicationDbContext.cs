using SuperHeroApp.Domain.Entities;

namespace SuperHeroApp.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<FavoriteSuperhero> Favorites { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
