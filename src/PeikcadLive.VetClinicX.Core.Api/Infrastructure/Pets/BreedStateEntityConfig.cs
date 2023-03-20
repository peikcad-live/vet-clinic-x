using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeikcadLive.VetClinicX.Core.Domain.Model.Pets.Breeds;

namespace PeikcadLive.VetClinicX.Core.Api.Infrastructure.Pets;

public sealed class BreedStateEntityConfig : IEntityTypeConfiguration<BreedState>
{
    public void Configure(EntityTypeBuilder<BreedState> builder)
    {
        builder.ToTable(nameof(Breed))
            .HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .ValueGeneratedNever();

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(DbConstants.SmallTextMaxLength);

        builder.HasOne(b => b.InnerSpecies)
            .WithMany()
            .HasForeignKey(b => b.SpeciesId);

        builder.Ignore(b => b.Species);
    }
}