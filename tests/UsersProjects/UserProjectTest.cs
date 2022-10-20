using FluentAssertions;
using static tests.UserProjectFixture;

namespace tests;

[Collection(nameof(UserProjectCollection))]
public class UserProjectTest
{
    private readonly UserProjectFixture _userProjectFixture;

    public UserProjectTest(UserProjectFixture UserProjectFixture)
    {
        _userProjectFixture = UserProjectFixture;
    }

    [Fact(DisplayName = "Check constructor with empty user id")]
    [Trait("Model","UserProject")]
    public void UserProject_Constructor_empty_UserId()
    {
        var config = () => _userProjectFixture.CreateUserProjectWithEmptyUserId();
        config.Should().Throw<ArgumentException>().Where(x => x.Message.Contains("userId can't be empty"));
    }

    [Fact(DisplayName = "Check constructor with empty project id")]
    [Trait("Model","UserProject")]
    public void UserProject_Constructor_empty_ProjectId()
    {
        var config = () => _userProjectFixture.CreateUserProjectWithEmptyProjectId();
        config.Should().Throw<ArgumentException>().Where(x => x.Message.Contains("projectId can't be empty"));
    }
}