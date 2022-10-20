using EletronicAppointment.Domain.Points;
using FluentAssertions;
using static tests.ProjectFixture;

namespace tests;

[Collection(nameof(ProjectCollection))]
public class ProjectTest
{
    private readonly ProjectFixture _projectFixture;
    private readonly PointFixture _pointFixture;
    public ProjectTest(ProjectFixture ProjectFixture)
    {
        this._projectFixture = ProjectFixture;
        this._pointFixture = new PointFixture();
    }

    [Fact(DisplayName = "Check Add User Valid")]
    [Trait("Model", "Project")]
    public void Project_AddUser()
    {
        var project = _projectFixture.CreateProject();
        var action = () => project.AddUser(Guid.NewGuid());
        action.Should().NotThrow<Exception>("Because this user is not working in this project");
    }

    [Fact(DisplayName = "Check Add User Invalid")]
    [Trait("Model", "Project")]
    public void Project_AddUser_Invalid()
    {
        var project = _projectFixture.CreateProjectWithUser();
        var user = project.Users.FirstOrDefault();
        var action = () => project.AddUser(user.UserId);
        action.Should().Throw<Exception>("Because this user is currently working in this project");
    }

    [Fact(DisplayName = "Check add point in a close project")]
    [Trait("Model", "Project")]
    public void Project_AddPoint_Close_Project()
    {
        var project = _projectFixture.CreateClosedProject();
        var action = () => project.AddPoint(Guid.NewGuid(), 1, "", new List<Point>());
        action.Should().Throw<Exception>("Because project is closed");
    }

    [Fact(DisplayName = "Check add point with any point is not closed")]
    [Trait("Model", "Project")]
    public void Project_AddPoint_Open_Point()
    {
        var project = _projectFixture.CreateProject();
        var points = _pointFixture.CreatePointsList();
        
        points.First().ClosePoint();

        var action = () => project.AddPoint(Guid.NewGuid(), 1, "", points);
        action.Should().Throw<Exception>("Because one or more points is not close");
    }

    [Fact(DisplayName = "Check add point")]
    [Trait("Model", "Project")]
    public void Project_AddPoint()
    {
        var project = _projectFixture.CreateProject();
        var points = _pointFixture.CreatePointsList();
        
        points.ForEach(p => p.ClosePoint());

        var action = () => project.AddPoint(Guid.NewGuid(), 1, "", points);
        action.Should().NotThrow<Exception>("Because all points are close");
    }
}