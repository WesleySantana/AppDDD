using System.Threading.Tasks;

namespace AppDDD.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}