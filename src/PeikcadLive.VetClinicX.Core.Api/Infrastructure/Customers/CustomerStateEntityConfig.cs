using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeikcadLive.VetClinicX.Core.Domain.Model.Customers;

namespace PeikcadLive.VetClinicX.Core.Api.Infrastructure.Customers;

public sealed class CustomerStateEntityConfig : IEntityTypeConfiguration<CustomerState>
{
    public void Configure(EntityTypeBuilder<CustomerState> builder)
    {
        builder.ToTable(nameof(Customer))
            .HasKey(c => c.Id)
            .IsClustered(false);

        builder.Property(c => c.Id)
            .HasMaxLength(DbConstants.SmallTextMaxLength);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(DbConstants.SmallTextMaxLength);

        builder.Property(c => c.ContactPhone)
            .IsRequired()
            .HasMaxLength(DbConstants.SmallTextMaxLength);

        builder.Property(c => c.ContactEmail)
            .IsRequired()
            .HasMaxLength(DbConstants.SmallTextMaxLength);
    }
}