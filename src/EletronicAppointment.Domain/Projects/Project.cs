using EletronicAppointment.Domain.Points;
using EletronicAppointment.Domain.UsersProjects;
using EletronicAppointment.Domain.ProjectConfigs;

namespace EletronicAppointment.Domain.Projects;
public class Project
{

    private Project()
    {
        this._configs = new List<ProjectConfig>();
        this._points = new List<Point>();
        this._users = new List<UserProject>();
    }
    private Project(string description, DateTime startDate, DateTime endDate, int projectCategory) : this()
    {
        this.Id = Guid.NewGuid();
        this.Description = description;
        this.StartDate = startDate;
        this.EndDate = endDate;
        this.ProjectCategory = projectCategory;
    }

    public void Update(string description, DateTime startDate, DateTime endDate, int projectCategory)
    {
        this.Description = description ?? this.Description;
        this.StartDate = startDate;
        this.EndDate = endDate;
        this.ProjectCategory = projectCategory;
    }

    public static Project Create(string description, DateTime startDate, DateTime endDate, int projectCategory)
    {
        if(string.IsNullOrWhiteSpace(description))
            throw new ArgumentNullException("Description can't be empty", nameof(description));

        if (endDate <= startDate)
            throw new ArgumentException("End date can't be less or equal then start date", nameof(endDate));


        return new Project(description, startDate, endDate, projectCategory);
    }
    public Guid Id { get; private set; }
    public string Description { get; private set; }
    private IList<Point> _points;
    public IReadOnlyCollection<Point> Points => _points.ToArray();
    private IList<UserProject> _users;
    public IReadOnlyCollection<UserProject> Users => _users.ToArray();
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public int ProjectCategory { get; private set; }
    private IList<ProjectConfig> _configs;
    public IReadOnlyCollection<ProjectConfig> Configs => _configs.ToArray();
    public bool IsOpen => this.StartDate <= DateTime.Now && this.EndDate > DateTime.Now;

    public void AddUser(Guid userId)
    {
        if(this.Users.Any(x => x.UserId == userId))
            throw new Exception("This user already work in this project!");

        this._users.Add(UserProject.Create(userId, this.Id));
    }

    public void AddPoint(Guid userId, int annotationType, string observation, List<Point> points)
    {
        if (!IsOpen)
            throw new Exception("This project is not open");
        
        if (points.Any(x => !x.IsClosed))
            throw new Exception("This user has points opened");

        var point = Point.Create(userId, this.Id, annotationType, observation);
        this._points.Add(point);
    }
}
