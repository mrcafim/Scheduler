using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Web.Domain.Core.Transactions
{
    public interface IUnitOfWork : IDisposable
    {
        bool InTransaction { get; }
        void Begin();
        bool Commit();
        void Rollback();
    }
}
