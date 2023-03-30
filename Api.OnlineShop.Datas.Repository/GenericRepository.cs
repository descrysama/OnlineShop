using Api.OnlineShop.Datas.Entities;
using Api.OnlineShop.Datas.Repository.Contract;
using Microsoft.EntityFrameworkCore;


namespace Api.OnlineShop.Datas.Repository
{
	public abstract class GenericRepository<T> : IGenericRepository<T>  where T : class
	{

		protected readonly DbContext _dbContext;

        protected readonly DbSet<T> _table;


        protected GenericRepository(DbContext dbContext)
		{
			_dbContext = dbContext;
			_table = _dbContext.Set<T>();
		}

        public async Task<IEnumerable<T>> FindAll()
        {
            return await _table.ToListAsync().ConfigureAwait(false);
        }

        public async Task<T> FindByKey(object id)
        {
            object type = await _table.FindAsync(id).ConfigureAwait(false);
            if(type == null)
            {
                return null;
            } else
            {
                return await _table.FindAsync(id).ConfigureAwait(false);
            }
        }

        public async Task<T> Create(T element)
        {
            var newElement = await _table.AddAsync(element).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);

            return newElement.Entity;
        }

        public async Task<T> Update(T element)
        {
            var newElement = _table.Update(element);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);

            return newElement.Entity;
        }

        public async Task<T> Remove(T element)
        {
            var newElement = _table.Remove(element);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);

            return newElement.Entity;
        }

    }
}

