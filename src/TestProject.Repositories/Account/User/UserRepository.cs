using TestProject.Data.DataContext;
using TestProject.Repositories.Generics;

namespace TestProject.Repositories.Account.User;

public class UserRepository : GRepository<TestProject.Data.DbModel.AccountSchema.ApplicationUser>, IUserRepository
{
    private readonly AppDbContext _appDbContext;

    public UserRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}

