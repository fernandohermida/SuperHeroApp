namespace SuperHeroApp.Application.SuperHeroFeatures.Queries.SearchSuperHeroByName;

public class SuperHeroResponse
{
    public string? Response { get; set; }
    public string? ResultsFor { get; set; }
    public List<SuperHeroDto>? Results { get; set; }
}

public class SuperHeroDto
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public PowerstatsDTO Powerstats { get; set; } = new PowerstatsDTO();
    public BiographyDTO Biography { get; set; } = new BiographyDTO();
    public AppearanceDTO Appearance { get; set; } = new AppearanceDTO();
    public WorkDTO Work { get; set; } = new WorkDTO();
    public ConnectionsDTO Connections { get; set; } = new ConnectionsDTO();
    public ImageDTO Image { get; set; } = new ImageDTO();
}

public class PowerstatsDTO
{
    public string? Intelligence { get; set; }
    public string? Strength { get; set; }
    public string? Speed { get; set; }
    public string? Durability { get; set; }
    public string? Power { get; set; }
    public string? Combat { get; set; }
}

public class BiographyDTO
{
    public string? FullName { get; set; }
    public string? AlterEgos { get; set; }
    public List<string>? Aliases { get; set; }
    public string? PlaceOfBirth { get; set; }
    public string? FirstAppearance { get; set; }
    public string? Publisher { get; set; }
    public string? Alignment { get; set; }
}

public class AppearanceDTO
{
    public string? Gender { get; set; }
    public string? Race { get; set; }
    public List<string>? Height { get; set; }
    public List<string>? Weight { get; set; }
    public string? EyeColor { get; set; }
    public string? HairColor { get; set; }
}

public class WorkDTO
{
    public string? Occupation { get; set; }
    public string? Base { get; set; }
}

public class ConnectionsDTO
{
    public string? GroupAffiliation { get; set; }
    public string? Relatives { get; set; }
}

public class ImageDTO
{
    public string? Url { get; set; }
}
