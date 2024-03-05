namespace SuperHeroApp.Domain.Entities;

public class SuperHero
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public Powerstats Powerstats { get; set; } = new Powerstats();
    public Biography Biography { get; set; } = new Biography();
    public Appearance1 Appearance { get; set; } = new Appearance1();
    public Work Work { get; set; } = new Work();
    public Connections Connections { get; set; } = new Connections();
    public Image Image { get; set; } = new Image();
}

public class Powerstats
{
    public string? Intelligence { get; set; }
    public string? Strength { get; set; }
    public string? Speed { get; set; }
    public string? Durability { get; set; }
    public string? Power { get; set; }
    public string? Combat { get; set; }
}

public class Biography
{
    public string? FullName { get; set; }
    public string? AlterEgos { get; set; }
    public List<string>? Aliases { get; set; }
    public string? PlaceOfBirth { get; set; }
    public string? FirstAppearance { get; set; }
    public string? Publisher { get; set; }
    public string? Alignment { get; set; }
}

public class Appearance1
{
    public string? Gender { get; set; }
    public string? Race { get; set; }
    public List<string>? Height { get; set; }
    public List<string>? Weight { get; set; }
    public string? EyeColor { get; set; }
    public string? HairColor { get; set; }
}

public class Work
{
    public string? Occupation { get; set; }
    public string? Base { get; set; }
}

public class Connections
{
    public string? GroupAffiliation { get; set; }
    public string? Relatives { get; set; }
}

public class Image
{
    public string? Url { get; set; }
}

