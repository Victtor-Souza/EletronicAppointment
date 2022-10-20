using Bogus;
using EletronicAppointment.Domain.Projects;

namespace tests;


public class ProjectFixture : IDisposable
{

    public Project CreateProject() => new Faker<Project>("pt_BR")
                                      .CustomInstantiator(f => Project.Create(f.Lorem.Word(), f.Date.Past(), f.Date.Future(), 1))
                                      .Generate();

    public Project CreateProjectWithoutDescription() => new Faker<Project>("pt_BR")
                                      .CustomInstantiator(f => Project.Create(String.Empty, f.Date.Past(), f.Date.Future(), 1))
                                      .Generate();

    public Project CreateProjectWithEndDateLessThanStartDate() => new Faker<Project>("pt_BR")
                                      .CustomInstantiator(f => Project.Create(f.Lorem.Word(), f.Date.Future(), f.Date.Past(), 1))
                                      .Generate();

    
    public Project CreateProjectWithUser() 
    {
        var project = this.CreateProject();
        project.AddUser(Guid.NewGuid());

        return project;
    }

    public Project CreateClosedProject()
    {
        var project = this.CreateProject();
        project.Update(project.Description, project.StartDate,DateTime.Now.AddDays(-1), project.ProjectCategory);
        return project;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    [CollectionDefinition(nameof(ProjectCollection))]
    public class ProjectCollection : ICollectionFixture<ProjectFixture> { }
}