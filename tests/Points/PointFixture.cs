using Bogus;
using EletronicAppointment.Domain.Points;

namespace tests;

public class PointFixture : IDisposable
{
    public Point CreatePoint() => new Faker<Point>("pt_BR")
                                      .CustomInstantiator(f => Point.Create(Guid.NewGuid(), 
                                                                         Guid.NewGuid(),
                                                                         1, 
                                                                         f.Lorem.Word()
                                      )).Generate();

    
    public Point CreateClosedPoint()
    {
        var point = this.CreatePoint();
        point.ClosePoint();

        return point;        
    }

   public List<Point> CreatePointsList()
   {
        var points = new List<Point>();
        for (int i = 0; i < 5; i++)
        {
            points.Add(this.CreatePoint());
        }

        return points;
   }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    [CollectionDefinition(nameof(PointCollection))]
    public class PointCollection : ICollectionFixture<PointFixture> { }
}