using EletronicAppointment.Domain.Projects;
using EletronicAppointment.Domain.Users.ValueObjects;
using EletronicAppointment.Domain.UsersProjects;


namespace EletronicAppointment.Domain.Users;

public class User
{
    public static User Create(string firstName, 
                string lastName, 
                string phoneNumber, 
                string emailAddress, 
                string username, 
                string password) 
    {
        if(String.IsNullOrWhiteSpace(firstName))
            throw new ArgumentNullException("FirstName can't be null", nameof(firstName));
        
        if(String.IsNullOrWhiteSpace(lastName))
            throw new ArgumentNullException("LastName can't be null", nameof(lastName));
        
        if(String.IsNullOrWhiteSpace(username))
            throw new ArgumentNullException("UserName can't be null", nameof(username));
        
        if(String.IsNullOrWhiteSpace(password))
            throw new ArgumentNullException("Password can't be null", nameof(password));

        return new User(firstName, 
                        lastName, 
                        phoneNumber, 
                        emailAddress, 
                        username, 
                        password);
    }
    private User()
    {
        this._projects = new List<UserProject>();
    }
    private User(string firstName, 
                string lastName, 
                string phoneNumber, 
                string emailAddress, 
                string username, 
                string password) :this()
    {
        this.Id = Guid.NewGuid();
        this.FirstName = firstName;
        this.LastName = lastName;
        this.PhoneNumber = phoneNumber;
        this.EmailAddress = emailAddress;
        this.Username = username;
        this.Password = HashUserPassword(password);
    }

    public void Update(string firstName, 
                       string lastName, 
                       string phoneNumber, 
                       string emailAddress, 
                       string username
                       ) 
    {
        this.FirstName = firstName ?? this.FirstName;
        this.LastName = lastName ?? this.LastName;
        this.PhoneNumber = phoneNumber ?? this.PhoneNumber;
        this.EmailAddress = emailAddress ?? this.EmailAddress;
        this.Username = username ?? this.Username;
    }

    public Guid Id { get; private set; }
    private IList<UserProject> _projects;
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public EmailAddress EmailAddress { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public IReadOnlyCollection<UserProject> Projects => _projects.ToArray();

    public void AddProject(Guid projectId)
    {
        if(this.Projects.Any(x => x.ProjectId == projectId))
            throw new Exception("This user already work in this project!");

        this._projects.Add(UserProject.Create(this.Id, projectId));
    }

    private string HashUserPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    private bool VerifyPassword(string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, this.Password);
    }
}