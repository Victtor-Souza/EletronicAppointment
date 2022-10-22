using EletronicAppointment.Domain.Projects;

namespace EletronicAppointment.Domain.ProjectConfigs;

public class ProjectConfig
{
    public static ProjectConfig Create(Guid projectId, string description, string key, string value)
    {
        if (Guid.Equals(projectId, Guid.Empty))
            throw new ArgumentException("projectId can't be empty", nameof(projectId));

        if (String.IsNullOrEmpty(description))
            throw new ArgumentException("description can't be empty", nameof(description));
        
        if (String.IsNullOrEmpty(key))
            throw new ArgumentException("key can't be empty", nameof(key));
            
        if (String.IsNullOrEmpty(value))
            throw new ArgumentException("value can't be empty", nameof(value));

        return new ProjectConfig(projectId, description, key, value);
    }
    private ProjectConfig(Guid projectId, string description, string key, string value)
    {
        Id = Guid.NewGuid();
        ProjectId = projectId;
        Description = description;
        Key = key;
        Value = value;
    }

    public void Update(string description, string key, string value)
    {
        this.Description = description ?? this.Description;
        this.Key = key ?? this.Key;
        this.Value = value ?? this.Value;
    }

    public Guid Id { get; private set; }
    public Guid ProjectId { get; private set; }
    public string Description { get; private set; }
    public string Key { get; private set; }
    public string Value { get; private set; }
    public virtual Project Project {get; private set;}
    
}
