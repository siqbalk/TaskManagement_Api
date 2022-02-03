using Data.DBContext;
using Data.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public class BaseRespository<TEntity> : IBaseRespository<TEntity>
        where TEntity : class
    {
        private TaskManagementDbContext _context;
        #region Constructor
        public BaseRespository(TaskManagementDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Generics
        public void Add(object entity)
        {
            _context.Add(entity);
            SaveChange();
        }

        public void Update(object entity)
        {
            _context.Update(entity);
            SaveChange();
        }

        public async Task Delete<T>(T id, bool isSaveChanges = true)
        {
            var entity = await Get(id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                if (isSaveChanges)
                {
                     SaveChange();
                }
            }
        }

        public bool SaveChange()
        {
            return _context.SaveChanges() > 0;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }
        public async Task<TEntity> Get<T>(T id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }


        #endregion

    }
}
