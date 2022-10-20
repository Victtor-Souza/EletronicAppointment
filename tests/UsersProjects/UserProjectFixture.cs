using Bogus;
using EletronicAppointment.Domain.UsersProjects;

namespace tests;

public class UserProjectFixture : IDisposable
{

    
    public UserProject CreateUserProjectWithEmptyUserId() => new Faker<UserProject>()
                                                .CustomInstantiator(f => UserProject.Create(
                                                    Guid.Empty,
                                                    Guid.NewGuid()
                                                ))
                                                .Generate();
    
    public UserProject CreateUserProjectWithEmptyProjectId() => new Faker<UserProject>()
                                                .CustomInstantiator(f => UserProject.Create(
                                                    Guid.NewGuid(),
                                                    Guid.Empty
                                                ))
                                                .Generate();

    

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    [CollectionDefinition(nameof(UserProjectCollection))]
    public class UserProjectCollection : ICollectionFixture<UserProjectFixture> { }
}