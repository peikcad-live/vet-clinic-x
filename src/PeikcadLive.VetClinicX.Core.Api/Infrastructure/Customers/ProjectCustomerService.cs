using Dapper;
using Microsoft.Data.SqlClient;
using PeikcadLive.VetClinicX.Core.Api.Application.Features.Customers;
using PeikcadLive.VetClinicX.Core.Domain.Model.Customers;

namespace PeikcadLive.VetClinicX.Core.Api.Infrastructure.Customers;

public sealed class ProjectCustomerService : IProjectCustomerService
{
    private readonly SqlConnection connection;
    
    public ProjectCustomerService(IConfiguration configuration)
    {
        connection = new(configuration.GetConnectionString("Default"));
    }
    
    public async Task<Customer?> ProjectBy(CustomerCode id)
    {
        var state = await connection.QuerySingleOrDefaultAsync<CustomerState>(
            "SELECT * FROM Customer WHERE Id = @Id", new {Id = id.ToString()}).ConfigureAwait(false);

        return state is not null ? Customer.RehydrateFrom(state) : null;
    }
}