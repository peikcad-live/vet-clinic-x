using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeikcadLive.VetClinicX.Core.Domain.Model.Pets.SpeciesEntity;

namespace PeikcadLive.VetClinicX.Core.Api.Infrastructure.Pets;

public sealed class SpeciesStateEntityConfig : IEntityTypeConfiguration<SpeciesState>
{
    public void Configure(EntityTypeBuilder<SpeciesState> builder)
    {
        builder.ToTable(nameof(Species))
            .HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .ValueGeneratedNever();

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(DbConstants.SmallTextMaxLength);
    }
}