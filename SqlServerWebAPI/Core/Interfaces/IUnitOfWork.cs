using System;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
        bool Commit();
        bool Rollback();
    }
}
