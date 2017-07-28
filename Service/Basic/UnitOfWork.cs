using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace Service
{
    /// <summary>
    ///  工作单元模式
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {

        public DbContext _context;
        private readonly IDbTransaction _transaction;

        /// <summary>
        ///  dbcontext.database 自带的事务
        /// </summary>
        private readonly DbContextTransaction _DbContextTransaction;
        private readonly ObjectContext _objectContext;
        public UnitOfWork(DbContext context)
        {
            //objectcontext的事务
            _context = context;
            _objectContext = ((IObjectContextAdapter)_context).ObjectContext;

            if (_objectContext.Connection.State != ConnectionState.Open)
            {
                _objectContext.Connection.Open();
                _transaction = _objectContext.Connection.BeginTransaction();
            }

            // dbcontext.database 的数据库  上面 和下面任选一一个就行了。

            if (context.Database.Connection.State!=ConnectionState.Open)
            {
                context.Database.Connection.Open();
                _DbContextTransaction = context.Database.BeginTransaction();
            }
            
         
        }


        public void Commit()
        {
            _context.SaveChanges();
            _transaction.Commit();
            //
            _DbContextTransaction.Commit();
        }

        public void Dispose()
        {
            if (_objectContext.Connection.State == ConnectionState.Open)
            {
                _objectContext.Connection.Close();
            }
            //2选1
            if (_context.Database.Connection.State == ConnectionState.Open)
            {
                _context.Database.Connection.Close();
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
            //  2选 1 
            _DbContextTransaction.Rollback();
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case System.Data.Entity.EntityState.Modified:
                        entry.State = System.Data.Entity.EntityState.Unchanged;
                        break;
                    case System.Data.Entity.EntityState.Added:
                        entry.State = System.Data.Entity.EntityState.Detached;
                        break;
                    case System.Data.Entity.EntityState.Deleted:
                        entry.State = System.Data.Entity.EntityState.Unchanged;
                        break;
                }
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
