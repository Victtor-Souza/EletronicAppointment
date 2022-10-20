using Bogus;
using EletronicAppointment.Domain.Users;

namespace tests;

public class UserFixture : IDisposable
{
    public User CreateUser() => new Faker<User>("pt_BR")
                                      .CustomInstantiator(f =>  User.Create(f.Lorem.Word(), 
                                                                        f.Lorem.Word(), 
                                                                        f.Lorem.Word(), 
                                                                        f.Lorem.Word(), 
                                                                        f.Lorem.Word(), 
                                                                        f.Lorem.Word())).Generate();

    public User CreateUserWithProjectAdded()
    {
        var user = this.CreateUser();

        user.AddProject(Guid.NewGuid());
        return user;
    }

    
    

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    [CollectionDefinition(nameof(UserCollection))]
    public class UserCollection : ICollectionFixture<UserFixture> { }
}