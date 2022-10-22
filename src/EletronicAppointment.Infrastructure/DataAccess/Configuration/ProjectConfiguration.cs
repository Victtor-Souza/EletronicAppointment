using EletronicAppointment.Domain.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EletronicAppointment.Infrastructure.DataAccess.Configuration;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        if (builder is null)
            throw new ArgumentNullException(nameof(builder));

        builder.ToTable("TB_PROJECTS");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Description)
               .HasMaxLength(500)
               .IsRequired();
        
        builder.Property(x => x.StartDate)
               .IsRequired();

        builder.Property(x => x.EndDate)
               .IsRequired();

        builder.Property(x => x.ProjectCategory)
               .IsRequired();
    }
}