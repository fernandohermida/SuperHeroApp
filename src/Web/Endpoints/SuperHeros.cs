﻿using SuperHeroApp.Application.SuperHeroFeatures.Commands.AddFavoriteSuperhero;
using SuperHeroApp.Application.SuperHeroFeatures.Queries.GetFavoriteSuperheroes;
using SuperHeroApp.Application.SuperHeroFeatures.Queries.SearchSuperHeroByName;

namespace SuperHeroApp.Web.Endpoints;

public class SuperHeros : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetFavorites, "favorites")
            .MapPost(AddFavorite, "favorites")
            .MapGet(SearchSuperHeroByName, "search");
    }

    public Task<List<SuperHeroDto>> GetFavorites(ISender sender)
    {
        return sender.Send(new GetFavoriteSuperheroesQuery());
    }

    public Task<int> AddFavorite(ISender sender, [AsParameters] AddFavoriteSuperheroCommand command)
    {
        return sender.Send(command);
    }

    public Task<SuperHeroResponse?> SearchSuperHeroByName(ISender sender, [AsParameters] SearchSuperHeroByNameQuery query)
    {
        return sender.Send(query);
    }
}
