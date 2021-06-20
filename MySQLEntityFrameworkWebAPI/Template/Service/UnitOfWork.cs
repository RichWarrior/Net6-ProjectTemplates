using Core.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Diagnostics;

namespace $safeprojectname$
{
    public class UnitOfWork : IUnitOfWork
    {
        DataContext _context;
        IDbContextTransaction _transaction;

        bool _disposed;

        public UnitOfWork()
        {
            try
            {
                _context = new DataContext();
                _transaction = _context.Database.BeginTransaction();
            }
            catch (System.Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public bool Commit()
        {
            bool rtn = false;
            try
            {
                _transaction.Commit();
                rtn = true;
            }
            catch (System.Exception)
            {
                _transaction.Rollback();
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _context.Database.BeginTransaction();
                resetRepositories();
            }
            return rtn;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        private void resetRepositories()
        {

        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }

                    if (_context != null)
                    {
                        _context.Dispose();
                        _context = null;
                    }
                }

                _disposed = true;

            }
        }

        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}
