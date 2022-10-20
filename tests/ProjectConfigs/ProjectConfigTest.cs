using FluentAssertions;
using static tests.ProjectConfigFixture;

namespace tests;

[Collection(nameof(ProjectConfigCollection))]
public class ProjectConfigTest
{
    private readonly ProjectConfigFixture _projectConfigFixture;

    public ProjectConfigTest(ProjectConfigFixture projectConfigFixture)
    {
        _projectConfigFixture = projectConfigFixture;
    }

    [Fact(DisplayName = "Check constructor with empty project id")]
    [Trait("Model","ProjectConfig")]
    public void ProjectConfig_Constructor_empty_ProjectId()
    {
        var config = () => _projectConfigFixture.CreateProjectConfigWithEmptyProjectId();
        config.Should().Throw<ArgumentException>().Where(x => x.Message.Contains("projectId can't be empty"));
    }

    [Fact(DisplayName = "Check constructor with empty description")]
    [Trait("Model","ProjectConfig")]
    public void ProjectConfig_Constructor_Without_Description()
    {
        var config = () => _projectConfigFixture.CreateProjectConfigWithoutDescription();
        config.Should().Throw<ArgumentException>().Where(x => x.Message.Contains("description can't be empty"));
    }

    [Fact(DisplayName = "Check constructor with empty key")]
    [Trait("Model","ProjectConfig")]
    public void ProjectConfig_Constructor_Without_Key()
    {
        var config = () => _projectConfigFixture.CreateProjectConfigWithoutKey();
        config.Should().Throw<ArgumentException>().Where(x => x.Message.Contains("key can't be empty"));
    }

    [Fact(DisplayName = "Check constructor with empty value")]
    [Trait("Model","ProjectConfig")]
    public void ProjectConfig_Constructor_Without_Value()
    {
        var config = () => _projectConfigFixture.CreateProjectConfigWithoutValue();
        config.Should().Throw<ArgumentException>().Where(x => x.Message.Contains("value can't be empty"));
    }
}