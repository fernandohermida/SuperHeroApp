using System.Reflection;
using SuperHeroApp.Application.Common.Interfaces;
using SuperHeroApp.Domain.Entities;
using SuperHeroApp.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SuperHeroApp.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<FavoriteSuperhero> Favorites => Set<FavoriteSuperhero>();

    public DbSet<SuperHero> Superheros => Set<SuperHero>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
