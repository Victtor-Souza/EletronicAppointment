using EletronicAppointment.Domain.Points;
using EletronicAppointment.Domain.ProjectConfigs;
using EletronicAppointment.Domain.Projects;
using EletronicAppointment.Domain.Users;
using EletronicAppointment.Domain.UsersProjects;
using Microsoft.EntityFrameworkCore;

namespace EletronicAppointment.Infrastructure.DataAccess;

public class Context:DbContext
{
    public Context(DbContextOptions options):base(options)
    {
        
    }

    public DbSet<User> Users {get; set;}
    public DbSet<UserProject> UsersProjects {get; set;}
    public DbSet<Project> Projects {get; set;}
    public DbSet<Point> Points {get; set;}
    public DbSet<ProjectConfig> ProjectConfigs {get; set;} 

    protected override void OnModelCreating(ModelBuilder builder)
    {
        if (builder is null)
        {
            throw new ArgumentException(nameof(builder));
        }

        builder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
    }

}