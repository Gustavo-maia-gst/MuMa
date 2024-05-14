using MuMa.Domain.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuMa.Domain.Repositories
{
    public interface IListenerRepository
    {
        Task<Listener> GetAsync(Guid id);
        Task<IEnumerable<Listener>> GetAll();
        Task UpdateAsync(Listener listener);
        Task InsertAsync(Listener listener);
        Task DeleteAsync(Guid id);
    }
}
