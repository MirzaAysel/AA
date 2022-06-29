using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business29.Base
{
     public interface IBaseService<TEntity>
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> Get(int? id);
        Task Update(TEntity entity);
        Task Create(TEntity entity);
        Task Delete(int? id);
    }
}
