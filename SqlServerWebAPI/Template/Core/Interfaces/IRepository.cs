using $safeprojectname$.Entities;
using $safeprojectname$.Utilities.Result;
using System.Collections.Generic;

namespace $safeprojectname$.Interfaces
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
