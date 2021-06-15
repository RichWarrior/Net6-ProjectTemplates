﻿using Core.Entities;
using Core.Utilities.Result;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IDataResult<T> Find(int id);
        IDataResult<List<T>> List();
        IResult Insert(T entity);
        IResult Delete(T entity);
        IResult Update(T entity);
    }
}
