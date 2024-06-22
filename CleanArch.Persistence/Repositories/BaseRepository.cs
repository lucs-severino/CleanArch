using Microsoft.EntityFrameworkCore;
using CleanArch.Persistence.Context;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Entities;


namespace CleanArch.Persistence.Repositores
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext Context;
        public BaseRepository(AppDbContext context)
        {
            Context = context;
        }

        public void Create(T entity)
        {
            entity.DateCreated = DateTimeOffset.Now;
            Context.Add(entity);
        }
        public void Update(T entity)
        {
            entity.DateUpadate = DateTimeOffset.Now;
            Context.Update(entity);
        }

        public void Delete(T entity)
        {
            entity.DateDelete = DateTimeOffset.Now;
            Context.Remove(entity);
        }

        public async Task<T> Get(Guid id, CancellationToken cancellationToken)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return await Context.Set<T>().ToListAsync(cancellationToken);
        }
        
    }
}
