using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IBaseRespository<TEntity> where TEntity : class
    {
        void Add(object entity);
        bool SaveChange();
        void Update(object entity);
        IQueryable<TEntity> GetAll();
        Task<TEntity> Get<T>(T id);
        Task Delete<T>(T id, bool isSaveChanges = true);
    }
}