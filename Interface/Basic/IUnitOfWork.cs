using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    /// <summary>
    ///  工作单元模式
    /// </summary>
    public  interface IUnitOfWork:IDisposable
    {
        void Commit();
        void Rollback();
        void SaveChanges();
    }
}
