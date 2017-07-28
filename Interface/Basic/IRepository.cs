using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    /// <summary>
    ///   数据仓储
    /// </summary>
    /// <typeparam name="T"></typeparam>
   public  interface IRepository<T>
    {

        int id { get; set; }
        T GetById(object id);

        void Insert(T entity);

        void Insert(IList<T> entities);

        void Update(T entity);

        void Update(IList<T> entities);

        void Delete(T entity);

        IQueryable<T> Table { get; }

        IQueryable<T> TableNoTracking { get; }
    }
}
