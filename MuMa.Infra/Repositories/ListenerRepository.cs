using Microsoft.EntityFrameworkCore;
using MuMa.Domain.Repositories;
using MuMa.Domain.Listeners;

namespace MuMa.EntityFramework.Repositories
{
    public class ListenerRepository : BaseRepository<MuMaDbContext, Listener, Guid>, IListenerRepository
    {
        public ListenerRepository(MuMaDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Listener> GetAsync(Guid id)
        {
            Listener? listener = await DbContext.Listeners.FindAsync(id);
            if (listener == null)
                throw new KeyNotFoundException("Listener not found");
            return listener;
        }

        public async Task<IEnumerable<Listener>> GetAll()
        {
            return DbContext.Listeners.AsEnumerable();
        }

        public async Task InsertAsync(Listener listener)
        {
            await DbContext.Listeners.AddAsync(listener);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Listener listener)
        {
            DbContext.Listeners.Update(listener);
            await DbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            Listener listener = await GetAsync(id);
            DbContext.Listeners.Remove(listener);
        }
    }
}
