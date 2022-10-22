using EletronicAppointment.Domain.Users;
using EletronicAppointment.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EletronicAppointment.Infrastructure.DataAccess.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        if (builder is null)
            throw new ArgumentNullException(nameof(builder));

        builder.ToTable("TB_USERS");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(x => x.LastName)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(x => x.Password)
               .IsRequired();

        builder.Property(x => x.PhoneNumber)
               .HasConversion(p => p.ToString(), 
                              p => new PhoneNumber(p));

        builder.Property(x => x.EmailAddress)
               .HasConversion(e => e.ToString(), 
                              e => new EmailAddress(e));
    }
}