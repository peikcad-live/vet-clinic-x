using Dapper;
using Microsoft.Data.SqlClient;
using PeikcadLive.VetClinicX.Core.Api.Application.Features.Veterinarians;
using PeikcadLive.VetClinicX.Core.Domain.Model.Veterinarians;

namespace PeikcadLive.VetClinicX.Core.Api.Infrastructure.Veterinarians;

public sealed class ProjectVeterinarianService : IProjectVeterinarianService
{
    private readonly SqlConnection connection;
    
    public ProjectVeterinarianService(IConfiguration configuration)
    {
        connection = new(configuration.GetConnectionString("Default"));
    }
    
    public async Task<Veterinarian?> ProjectBy(LicenseNumber id)
    {
        var state = await connection.QuerySingleOrDefaultAsync<VeterinarianState>(
            "SELECT * FROM Veterinarian WHERE Id = @Id", new {Id = id.ToString()}).ConfigureAwait(false);

        return state is not null ? Veterinarian.RehydrateFrom(state) : null;
    }
}