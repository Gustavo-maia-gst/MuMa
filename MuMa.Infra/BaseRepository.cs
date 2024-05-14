using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuMa.EntityFramework
{
    public class BaseRepository<TDbContext, TEntity, TKey>
    {
        protected readonly TDbContext DbContext;

        public BaseRepository(TDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
