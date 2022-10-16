using OES.API.Domain.Entities.Common;

namespace OES.API.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        void EnableLazyLoading();
    }
}
