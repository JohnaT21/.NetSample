using System.Threading.Tasks;

namespace TestProject.Repositories.UOW;

public interface IUnitOfWork<T>
{
    int Commit();
    Task<int> CommitAsync();
}
