namespace PeikcadLive.VetClinicX.Core.Api.Infrastructure.Pets.Seeds;

public static class BreedsSeed
{
    public static readonly BreedState[] All =
    {
        // Dogs
        new() { Id = 1, Name = "Alaskan Malamute", SpeciesId = 1, Species = SpeciesSeed.All[0] },
        new() { Id = 2, Name = "Border Collie", SpeciesId = 1, Species = SpeciesSeed.All[0] },
        new() { Id = 3, Name = "Boston Terrier", SpeciesId = 1, Species = SpeciesSeed.All[0] },

        // Cats
        new() { Id = 4, Name = "Bombay", SpeciesId = 2, Species = SpeciesSeed.All[1] },
        new() { Id = 5, Name = "British Shorthair", SpeciesId = 2, Species = SpeciesSeed.All[1] },
        new() { Id = 6, Name = "Burmese", SpeciesId = 2, Species = SpeciesSeed.All[1] },

        // Horses
        new() { Id = 7, Name = "Andalusian", SpeciesId = 3, Species = SpeciesSeed.All[2] },
        new() { Id = 8, Name = "Friesian", SpeciesId = 3, Species = SpeciesSeed.All[2] },
        new() { Id = 9, Name = "Thoroughbred", SpeciesId = 3, Species = SpeciesSeed.All[2] }
    };
}