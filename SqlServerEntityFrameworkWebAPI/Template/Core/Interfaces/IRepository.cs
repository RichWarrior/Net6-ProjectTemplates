using $safeprojectname$.Entities;
using $safeprojectname$.Utilities.Result;
using System.Collections.Generic;

namespace $safeprojectname$.Interfaces
{
    public interface IRepository<T> where T:BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IDataResult<T> Find(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IDataResult<List<T>> List();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        IResult Insert(T entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        IResult Delete(T entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        IResult Update(T entity);
    }
}
