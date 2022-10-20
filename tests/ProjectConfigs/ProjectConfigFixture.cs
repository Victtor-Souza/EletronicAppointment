using Bogus;
using EletronicAppointment.Domain.ProjectConfigs;

namespace tests;

public class ProjectConfigFixture : IDisposable
{

    public ProjectConfig CreateProjectConfig() => new Faker<ProjectConfig>()
                                                .CustomInstantiator(f => ProjectConfig.Create(
                                                    Guid.NewGuid(),
                                                    f.Lorem.Paragraph(),
                                                    f.Lorem.Word(),
                                                    f.Lorem.Word()
                                                ))
                                                .Generate();
    
    public ProjectConfig CreateProjectConfigWithEmptyProjectId() => new Faker<ProjectConfig>()
                                                .CustomInstantiator(f => ProjectConfig.Create(
                                                    Guid.Empty,
                                                    f.Lorem.Paragraph(),
                                                    f.Lorem.Word(),
                                                    f.Lorem.Word()
                                                ))
                                                .Generate();
    
    public ProjectConfig CreateProjectConfigWithoutDescription() => new Faker<ProjectConfig>()
                                                .CustomInstantiator(f => ProjectConfig.Create(
                                                    Guid.NewGuid(),
                                                    String.Empty,
                                                    f.Lorem.Word(),
                                                    f.Lorem.Word()
                                                ))
                                                .Generate();

    public ProjectConfig CreateProjectConfigWithoutKey() => new Faker<ProjectConfig>()
                                                .CustomInstantiator(f => ProjectConfig.Create(
                                                    Guid.NewGuid(),
                                                    f.Lorem.Paragraph(),
                                                    String.Empty,
                                                    f.Lorem.Word()
                                                ))
                                                .Generate();

    public ProjectConfig CreateProjectConfigWithoutValue() => new Faker<ProjectConfig>()
                                                .CustomInstantiator(f => ProjectConfig.Create(
                                                    Guid.NewGuid(),
                                                    f.Lorem.Paragraph(),
                                                    f.Lorem.Word(),
                                                    String.Empty
                                                ))
                                                .Generate();

    

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    [CollectionDefinition(nameof(ProjectConfigCollection))]
    public class ProjectConfigCollection : ICollectionFixture<ProjectConfigFixture> { }
}