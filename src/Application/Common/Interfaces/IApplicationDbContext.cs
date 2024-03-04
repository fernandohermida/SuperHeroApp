using SuperHeroApp.Domain.Entities;

namespace SuperHeroApp.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<FavoriteSuperhero> Favorites { get; }

    DbSet<SuperHero> Superheros { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
