using Base.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Base.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork<T, IdT> where T : class
    {
        ResultData<T> Insert(T model);
        ResultData<T> Update(T model);
        ResultData<T> Delete(IdT id);
        ResultData<T> GetAll();
        ResultData<T> GetById(IdT id);
        ResultData<T> Where(Expression<Func<T, bool>> expression);
        ResultData<T> OrderBy(Expression<Func<T, bool>> expression);
    }
}
