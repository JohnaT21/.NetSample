using TestProject.Repositories.Generics;

namespace TestProject.Repositories.Account.User;

public interface IUserRepository: IGRepository<TestProject.Data.DbModel.AccountSchema.ApplicationUser>
{

}
