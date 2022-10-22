using EletronicAppointment.Domain.Points;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EletronicAppointment.Infrastructure.DataAccess.Configuration;

public class PointConfiguration : IEntityTypeConfiguration<Point>
{
    public void Configure(EntityTypeBuilder<Point> builder)
    {
        if(builder is null)
            throw new ArgumentNullException(nameof(builder));

        builder.ToTable("TB_POINTS");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.User)
               .WithMany(x => x.Points)
               .HasForeignKey(x => x.UserId);

        builder.HasOne(x => x.Project)
               .WithMany(x => x.Points)
               .HasForeignKey(x => x.ProjectId);

        builder.Property(x => x.Observation)
               .HasMaxLength(200)
               .IsRequired(false);

        builder.Property(x => x.Opened)
               .IsRequired();
        
        builder.Property(x => x.Closed)
               .IsRequired(false);

        builder.Property(x => x.AnnotationType)
               .IsRequired();
    }
}