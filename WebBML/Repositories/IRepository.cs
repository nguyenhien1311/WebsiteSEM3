using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebBML.Repositories
{
   public interface IRepository<T> where T : class
    {
        // get all entity
        IEnumerable<T> Gets();
        // get list entity with predicate
        IEnumerable<T> Gets(Expression<Func<T, bool>> predicate);
        // get entity with id 
        T Get(object id);
        // create an entity
        bool Create(T entity);
        // update an entity
        bool Update(T entity);
        // remove an entity
        bool Remove(object id);

        // save change
        void Save();
    }
}
