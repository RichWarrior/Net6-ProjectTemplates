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
        public bool Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
