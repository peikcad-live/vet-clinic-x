namespace PeikcadLive.VetClinicX.Core.Api.Infrastructure.Pets.Seeds;

public static class SpeciesSeed
{
    public static readonly SpeciesState[] All =
    {
        new() { Id = 1, Name = "Dog" },
        new() { Id = 2, Name = "Cat" },
        new() { Id = 3, Name = "Horse" }
    };
}