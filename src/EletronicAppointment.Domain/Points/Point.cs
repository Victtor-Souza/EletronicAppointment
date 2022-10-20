namespace EletronicAppointment.Domain.Points;
public class Point
{
    public static Point Create(Guid userId, Guid projectId, int annotationType, string observation)
    {   
        if (Guid.Equals(userId, Guid.Empty))
            throw new ArgumentException("UserId can't be null", nameof(userId));
        
         if (Guid.Equals(projectId, Guid.Empty))
            throw new ArgumentException("ProjectId can't be null", nameof(projectId));
        
    
        return new Point(userId, projectId,annotationType, observation);
    }
    private Point(Guid userId, Guid projectId, int annotationType, string observation)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        ProjectId = projectId;
        Opened = DateTime.Now;
        Closed = null;
        AnnotationType = annotationType;
        Observation = observation;
    }

    public void Update(int annotationType, string observation)
    {
        AnnotationType = annotationType;
        Observation = observation ?? this.Observation;
    }

    public void ClosePoint()
    {
        if (this.IsClosed)
            throw new Exception("This point is already closed");
            
        this.Closed = DateTime.Now;
    }

    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid ProjectId { get; private set; }
    public DateTime Opened { get; private set; }
    public DateTime? Closed {get; private set;}
    public int AnnotationType { get; private set; }
    public string Observation { get; private set; }
    public bool IsClosed => Closed is not null;
}
