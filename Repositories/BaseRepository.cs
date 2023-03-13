using design_pattern.Interfaces;
using design_pattern.Model;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using design_pattern.Consts;

namespace design_pattern.Repositories
{
    public class BaseRepository<t> : IBaseRepository<t> where t : class
    {
        protected ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<t> GetAll()
        {
            return _context.Set<t>().ToList();
        }


        public t GetById(int id)
        {
            return _context.Set<t>().Find(id);
        }

        public async Task<t> GetByIdAsync(int id)
        {
            return await _context.Set<t>().FindAsync(id);
        }
    
        public t Find(Expression<Func<t, bool>> match)
        {
            return _context.Set<t>().SingleOrDefault(match);
        }

        public t FindWithRelation(Expression<Func<t, bool>> match, string[] includes = null)
        {
            IQueryable<t> query = _context.Set<t>();

            if(includes != null)
                foreach(var include in includes)
                    query = query.Include(include);

                return query.SingleOrDefault(match);    
        } 

        public IEnumerable<t> FindAll(Expression<Func<t, bool>> match, string[] includes = null)
        {
            IQueryable<t> query = _context.Set<t>();

            if(includes != null)
                foreach(var include in includes)
                    query = query.Include(include);

                return query.Where(match).ToList();    
        }
    
       public IEnumerable<t> FindAll(Expression<Func<t, bool>> match, int take, int skip)
        {
            return _context.Set<t>().Where(match).Skip(skip).Take(take).ToList();
        }

       public IEnumerable<t> FindAll(Expression<Func<t, bool>> match, int? take, int? skip,
            Expression<Func<t, object>> orderBy = null, string orderByDirection = OrderBy.Ascending)
            {
                IQueryable<t> query = _context.Set<t>().Where(match);
                
                if(take.HasValue)
                    query = query.Take(take.Value);

                if(skip.HasValue)
                    query = query.Skip(skip.Value);

                if(orderBy != null)
                {
                    if(orderByDirection == OrderBy.Ascending)
                        query = query.OrderBy(orderBy);
                    else 
                        query = query.OrderByDescending(orderBy);    
                }

                return query.ToList();
            }
    
        public t Add(t entity)
        {
            _context.Set<t>().Add(entity);
            _context.SaveChanges();
            
            return entity;
        }

        public IEnumerable<t> AddRange(IEnumerable<t> entities)
        {
            _context.Set<t>().AddRange(entities);
            _context.SaveChanges();
            
            return entities;
        }
    
        public t update(t entity)
        {
            _context.Set<t>().Update(entity);
            _context.SaveChanges();
            return entity;
        }
    
       public void Delete(t entity)
       {
            _context.Set<t>().Remove(entity);
            _context.SaveChanges();
       }
    }
}