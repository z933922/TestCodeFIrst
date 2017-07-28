using Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    /// <summary>
    ///   数据仓储
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T:class
    {

        public DbContext _context;

        public IDbSet<T> Entity;
      
        public Repository(DbContext context)
        {
            //objectcontext的事务
            _context = context;

        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Entity.Remove(entity);
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public T GetById(object id)
        {
            return Entity.Find(id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            Entity.Add(entity);
        }

        public void Insert(IList<T> entities)
        {
            try
            {
                if (entities == null)
                {
                    throw new ArgumentNullException("entities");
                }

                foreach (T entity in entities)
                {
                    if (entity == null)
                    {
                        throw new ArgumentNullException("entity");
                    }

                    Entity.Add(entity);
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public void Update(IList<T> entities)
        {
            try
            {
                if (entities == null)
                {
                    throw new ArgumentNullException("entities");
                }

                foreach (T entity in entities)
                {
                    if (entity == null)
                    {
                        throw new ArgumentNullException("entity");
                    }
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }
     
        public virtual IQueryable<T> TableNoTracking
        {
            get
            {
                return Entity.AsNoTracking();
            }
        }

        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (Entity == null)
                    Entity = _context.Set<T>();
                return Entity;
            }
        }

        public virtual int id { get; set; }
    }
}
