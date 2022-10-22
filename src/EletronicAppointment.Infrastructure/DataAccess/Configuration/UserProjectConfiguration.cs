using EletronicAppointment.Domain.UsersProjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EletronicAppointment.Infrastructure.DataAccess.Configuration;

public class UserProjectConfiguration : IEntityTypeConfiguration<UserProject>
{
    public void Configure(EntityTypeBuilder<UserProject> builder)
    {
        if(builder is null)
            throw new ArgumentNullException(nameof(builder));

        builder.ToTable("TB_USERPROJECTS");

        builder.HasKey(x => new {x.UserId, x.ProjectId});

        builder.HasOne(x => x.Project)
               .WithMany(x => x.Users)
               .HasForeignKey(x => x.ProjectId);

        builder.HasOne(x => x.User)
               .WithMany(x => x.Projects)
               .HasForeignKey(x => x.UserId);
    }
}