using FluentAssertions;
using static tests.UserFixture;

namespace tests;

[Collection(nameof(UserCollection))]
public class UserTest
{
    private readonly UserFixture _userFixture;
    public UserTest(UserFixture UserFixture) => this._userFixture = UserFixture;

    [Fact(DisplayName = "Check duplicate project on Add project")]
    [Trait("Model", "User")]
    public void User_AddProject_Invalid()
    {
        var user = _userFixture.CreateUserWithProjectAdded();
        var project = user.Projects.FirstOrDefault();
        var action = () => user.AddProject(project.ProjectId);

        action.Should().Throw<Exception>("Because this user already work in this project");

    }

    [Fact(DisplayName = "Check valid Add project")]
    [Trait("Model", "User")]
    public void User_AddProject()
    {
        var user = _userFixture.CreateUserWithProjectAdded();

        var action = () => user.AddProject(Guid.NewGuid());

        action.Should().NotThrow<Exception>("Because this user is not working in this project");

    }
}