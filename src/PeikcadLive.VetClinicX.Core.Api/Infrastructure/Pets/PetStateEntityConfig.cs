using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeikcadLive.VetClinicX.Core.Api.Infrastructure.Customers;
using PeikcadLive.VetClinicX.Core.Api.Infrastructure.Veterinarians;
using PeikcadLive.VetClinicX.Core.Domain.Model.Pets;

namespace PeikcadLive.VetClinicX.Core.Api.Infrastructure.Pets;

public sealed class PetStateEntityConfig : IEntityTypeConfiguration<PetState>
{
    public void Configure(EntityTypeBuilder<PetState> builder)
    {
        builder.ToTable(nameof(Pet))
            .HasKey(p => p.Id)
            .IsClustered(false);

        builder.Property(p => p.Id)
            .HasMaxLength(DbConstants.SmallTextMaxLength);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(DbConstants.SmallTextMaxLength);

        builder.HasOne(p => p.InnerBreed)
            .WithMany()
            .HasForeignKey(p => p.BreedId);

        builder.HasOne<CustomerState>()
            .WithMany()
            .HasForeignKey(p => p.HumanCompanionId);
        
        builder.HasOne<VeterinarianState>()
            .WithMany()
            .HasForeignKey(p => p.VeterinarianId)
            .IsRequired(false);

        builder.Ignore(p => p.Breed);
    }
}