using EletronicAppointment.Domain.Users;

namespace EletronicAppointment.Infrastructure.DataAccess.Repositories;

public class UserRepository:CommonRepository<User>, IUserRepository
{
    public UserRepository(Context context): base(context)
    {
        
    }
}