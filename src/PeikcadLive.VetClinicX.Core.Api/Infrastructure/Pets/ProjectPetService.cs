using Dapper;
using Microsoft.Data.SqlClient;
using PeikcadLive.VetClinicX.Core.Api.Application.Features.Pets;
using PeikcadLive.VetClinicX.Core.Domain.Model.Pets;

namespace PeikcadLive.VetClinicX.Core.Api.Infrastructure.Pets;

public sealed class ProjectPetService : IProjectPetService
{
    private readonly SqlConnection connection;
    
    public ProjectPetService(IConfiguration configuration)
    {
        connection = new(configuration.GetConnectionString("Default"));
    }
    
    public async Task<Pet?> ProjectBy(AnimalId id)
    {
        var state = await connection.QueryAsync<PetState, BreedState, SpeciesState, PetState>(
@"SELECT
    P.Id, P.Name, P.HumanCompanionId, P.VeterinarianId, P.BreedId,
    B.Id, B.Name, B.SpeciesId,
    S.Id, S.Name
FROM Pet P
    INNER JOIN Breed B ON P.BreedId = B.Id
    INNER JOIN Species S ON B.SpeciesId = S.Id
WHERE P.Id = @Id",
        (pet, breed, species) =>
        {
            pet.InnerBreed = breed;
            breed.InnerSpecies = species;
            
            return pet;
        },
        new {Id = id.ToString()}).ConfigureAwait(false);

        return state is not null ? Pet.RehydrateFrom(state.First()) : null;
    }
}