using Bogus;
using EletronicAppointment.Domain.Users;

namespace tests;

public class UserFixture : IDisposable
{
    public User CreateUser() => new Faker<User>("pt_BR")
                                      .CustomInstantiator(f =>  User.Create(f.Lorem.Word(), 
                                                                        f.Lorem.Word(), 
                                                                        f.Phone.PhoneNumber()
                                                                               .Replace("(", "")
                                                                               .Replace(")", "")
                                                                               .Replace("-", "")
                                                                               .Replace(" ", ""), 
                                                                        f.Person.Email, 
                                                                        f.Lorem.Word(), 
                                                                        f.Lorem.Word())).Generate();

    public User CreateUserWithoutFirstName() => new Faker<User>("pt_BR")
                                      .CustomInstantiator(f =>  User.Create(String.Empty, 
                                                                        f.Lorem.Word(), 
                                                                        f.Phone.PhoneNumber()
                                                                               .Replace("(", "")
                                                                               .Replace(")", "")
                                                                               .Replace("-", "")
                                                                               .Replace(" ", ""), 
                                                                        f.Person.Email, 
                                                                        f.Lorem.Word(), 
                                                                        f.Lorem.Word())).Generate();
    
    public User CreateUserWithoutLastName() => new Faker<User>("pt_BR")
                                      .CustomInstantiator(f =>  User.Create(f.Lorem.Word(), 
                                                                        String.Empty, 
                                                                        f.Phone.PhoneNumber()
                                                                               .Replace("(", "")
                                                                               .Replace(")", "")
                                                                               .Replace("-", "")
                                                                               .Replace(" ", ""), 
                                                                        f.Person.Email, 
                                                                        f.Lorem.Word(), 
                                                                        f.Lorem.Word())).Generate();

    public User CreateUserWithoutUserName() => new Faker<User>("pt_BR")
                                      .CustomInstantiator(f =>  User.Create(f.Lorem.Word(), 
                                                                        f.Lorem.Word(), 
                                                                        f.Phone.PhoneNumber()
                                                                               .Replace("(", "")
                                                                               .Replace(")", "")
                                                                               .Replace("-", "")
                                                                               .Replace(" ", ""), 
                                                                        f.Person.Email, 
                                                                        String.Empty, 
                                                                        f.Lorem.Word())).Generate();

    public User CreateUserWithoutPassword() => new Faker<User>("pt_BR")
                                      .CustomInstantiator(f =>  User.Create(f.Lorem.Word(), 
                                                                        f.Lorem.Word(), 
                                                                        f.Phone.PhoneNumber()
                                                                               .Replace("(", "")
                                                                               .Replace(")", "")
                                                                               .Replace("-", "")
                                                                               .Replace(" ", ""), 
                                                                        f.Person.Email, 
                                                                        f.Lorem.Word(), 
                                                                        String.Empty)).Generate();


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