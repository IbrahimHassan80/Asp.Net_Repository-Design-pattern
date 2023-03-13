using design_pattern.Consts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace  design_pattern.Interfaces
{
    public interface IBaseRepository<t> where t : class
    {

        IEnumerable<t> GetAll();
        
        t GetById(int id);

        Task<t> GetByIdAsync(int id);


        t Find(Expression<Func<t, bool>> match); 

        
        t FindWithRelation(Expression<Func<t, bool>> match, string[] includes = null); 

        IEnumerable<t> FindAll(Expression<Func<t, bool>> match, string[] includes = null);

        IEnumerable<t> FindAll(Expression<Func<t, bool>> match, int take, int skip);

        IEnumerable<t> FindAll(Expression<Func<t, bool>> match, int? take, int? skip,
            Expression<Func<t, object>> orderBy = null, string orderByDirection = OrderBy.Ascending);
    
        t Add(t entity);

        IEnumerable<t> AddRange(IEnumerable<t> entities);

        t update(t entity);

        void Delete(t entity);

    }
}
