using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Diagnostics;

namespace Service
{
    /// <summary>
    /// 
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        IDbContextTransaction _transaction;
        DataContext _context;

        bool _disposed;

        /// <summary>
        /// 
        /// </summary>
        public UnitOfWork()
        {
            try
            {
                _context = new DataContext();
                _transaction = _context.Database.BeginTransaction();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();            
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Commit()
        {
            bool rtn = false;
            try
            {
                _transaction.Commit();
                rtn = true;
            }
            catch (Exception)
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _context.Database.BeginTransaction();
            }
            return rtn;
        }        

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Rollback()
        {
            bool rtn = false;
            try
            {
                _transaction?.Rollback();
                rtn = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _transaction?.Dispose();
                _transaction = _context.Database.BeginTransaction();
                resetRepositories();
            }
            return rtn;
        }

        /// <summary>
        /// 
        /// </summary>
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
                    if(_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    
                    if(_context != null)
                    {
                        _context.Dispose();
                        _context = null;
                    }

                    _disposed = true;
                }
            }
        }

        private void resetRepositories()
        {

        }

       
        ~UnitOfWork()
        {
            dispose(false);        }
    }
}
