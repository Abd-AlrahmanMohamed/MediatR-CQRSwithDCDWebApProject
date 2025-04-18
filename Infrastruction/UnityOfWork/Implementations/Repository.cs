﻿
namespace Infrastructure.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entity;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }
        public async ValueTask<IEnumerable<T>> GetAllAsync() => await _entity.ToListAsync();

        public async ValueTask<T> GetByidAsync(int id) => await _entity.FindAsync(id);
        public async ValueTask<T> AddAsync(T entity)
        {
            await _entity.AddAsync(entity);
            return entity;
        }

        public async ValueTask<T> UpdateAsync(T entity)
        {
            _entity.Update(entity);

            return entity;
        }

        public async ValueTask<T> DeleteAsync(int id)
        {

            var delete = await _entity.FindAsync(id);
            if (delete != null)
                _entity.Remove(delete);

            return delete;
        }



        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
