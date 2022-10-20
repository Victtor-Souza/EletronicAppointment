using FluentAssertions;
using static tests.PointFixture;

namespace tests;

[Collection(nameof(PointCollection))]
public class PointTest
{
    private readonly PointFixture _pointFixture;
    public PointTest(PointFixture pointFixture) => this._pointFixture = pointFixture;

    [Fact(DisplayName = "Check Close Point method")]
    [Trait("Model", "Point")]
    public void Point_ClosePoint()
    {
        var point = _pointFixture.CreateClosedPoint();

        var action = () => point.ClosePoint();

        action.Should().Throw<Exception>("Because this point is already close");
    }
}