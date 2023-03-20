using FluentValidation;
using PeikcadLive.VetClinicX.Core.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

builder.Services
    .AddValidatorsFromAssemblyContaining<Program>()
    .AddMediatR(c => c.RegisterServicesFromAssemblyContaining<Program>())
    .AddCoreModel(builder.Configuration)
    .AddEventBus();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection()
    .UseAuthorization();

app.MapControllers();

await app.UseSeed();
app.Run();