using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeikcadLive.VetClinicX.Core.Domain.Model.Veterinarians;

namespace PeikcadLive.VetClinicX.Core.Api.Infrastructure.Veterinarians;

public sealed class VeterinarianStateEntityConfig : IEntityTypeConfiguration<VeterinarianState>
{
    public void Configure(EntityTypeBuilder<VeterinarianState> builder)
    {
        builder.ToTable(nameof(Veterinarian))
            .HasKey(v => v.Id)
            .IsClustered(false);

        builder.Property(v => v.Id)
            .HasMaxLength(DbConstants.SmallTextMaxLength);
        
        builder.Property(v => v.Name)
            .IsRequired()
            .HasMaxLength(DbConstants.SmallTextMaxLength);

        builder.Property(v => v.ContactPhone)
            .IsRequired()
            .HasMaxLength(DbConstants.SmallTextMaxLength);
        
        builder.Property(v => v.ContactEmail)
            .IsRequired()
            .HasMaxLength(DbConstants.SmallTextMaxLength);
    }
}