using Core.Interfaces;
using Core.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Service
{
    /// <summary>
    /// 
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        IDbTransaction transaction;
        IDbConnection connection;

        bool disposed;

        /// <summary>
        /// 
        /// </summary>
        public UnitOfWork()
        {
            try
            {
                ConnectionInfo connectionInfo = ConnectionInfo.Instance;
                connection = new MySqlConnection(connectionInfo.SqlServerConnectionString);
                connection.Open();
                transaction = connection.BeginTransaction();
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
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
                transaction.Commit();
                rtn = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                transaction.Dispose();
                transaction = connection.BeginTransaction();
                resetRepositories();
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
                transaction?.Rollback();
                rtn = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                transaction?.Dispose();
                transaction = connection.BeginTransaction();
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

        /// <summary>
        /// 
        /// </summary>
        private void resetRepositories()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        private void dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (transaction != null)
                    {
                        transaction.Dispose();
                        transaction = null;
                    }

                    if (connection != null)
                    {
                        connection.Dispose();
                        connection = null;
                    }
                }
                disposed = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}
