using EletronicAppointment.Domain.Projects;
using EletronicAppointment.Domain.Users;

namespace EletronicAppointment.Domain.UsersProjects;

public class UserProject
{
    public static UserProject Create(Guid userId, Guid projectId) 
    {
        if (Guid.Equals(userId, Guid.Empty))
            throw new ArgumentException("userId can't be empty", nameof(userId));

        if (Guid.Equals(projectId, Guid.Empty))
            throw new ArgumentException("projectId can't be empty", nameof(projectId));

        return new UserProject(userId, projectId);
    }
    private UserProject(Guid userId, Guid projectId)
    {
        UserId = userId;
        ProjectId = projectId;
    }

    public Guid UserId { get; private set; }
    public Guid ProjectId { get; private set; }
    public virtual User User { get; private set; }
    public virtual Project Project { get; private set; }
}