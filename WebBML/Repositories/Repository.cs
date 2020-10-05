using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebDAL;

namespace WebBML.Repositories
{
   public class Repository<T> : IRepository<T> where T : class
    {
        private OLAuctionContext db;
        private DbSet<T> tbl;

        public Repository()
        {
            db = new OLAuctionContext();
            tbl = db.Set<T>();
        }

        //Add an entity to database function
        public bool Create(T entity)
        {
            try
            {
                tbl.Add(entity);
                Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public T Get(object id)
        {
            return tbl.Find(id);
        }

        public IEnumerable<T> Gets()
        {
            return tbl.AsEnumerable();
        }

        public IEnumerable<T> Gets(Expression<Func<T, bool>> predicate)
        {
            return tbl.Where(predicate).AsEnumerable();
        }


        public bool Update(T entity)
        {
            try
            {
                db.Entry(entity).State = EntityState.Modified;
                Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Remove(object id)
        {
            try
            {
                tbl.Remove(Get(id));
                Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
