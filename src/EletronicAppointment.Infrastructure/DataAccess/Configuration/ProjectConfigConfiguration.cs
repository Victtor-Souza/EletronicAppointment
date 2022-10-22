using EletronicAppointment.Domain.ProjectConfigs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EletronicAppointment.Infrastructure.DataAccess.Configuration;

public class ProjectConfigConfiguration : IEntityTypeConfiguration<ProjectConfig>
{
    public void Configure(EntityTypeBuilder<ProjectConfig> builder)
    {
        if(builder is null)
            throw new ArgumentNullException(nameof(builder));

        builder.ToTable("TB_PROJECTCONFIG");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Project)
               .WithMany(x => x.Configs)
               .HasForeignKey(x => x.ProjectId);

        builder.Property(x => x.Description)
               .HasMaxLength(200)
               .IsRequired();

        builder.HasIndex(x => x.Key).IsUnique();
        builder.Property(x => x.Key)
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(x => x.Value)
               .HasMaxLength(100)
               .IsRequired();

        
       
    }
}