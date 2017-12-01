using Base.Domain.Interfaces.UnitOfWork;
using Base.Infrastructure.Enums;
using Base.Infrastructure.Utilities;
using Base.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Base.Persistence.UnitOfWork
{
    public class UnitOfWork<T, IdT> : IUnitOfWork<T, IdT> where T : class
    {
        protected BaseContext<T> context;

        public UnitOfWork()
        {

        }

        public UnitOfWork(BaseContext<T> context)
        {
            this.context = context;
        }

        public virtual ResultData<T> Insert(T model)
        {
            ResultData<T> resultData = new ResultData<T>();

            try {
                context.DbSet.Add(model);

                resultData.Identity = context.SaveChanges();
            }
            catch (Exception exception) {
                resultData.ExceptionCode = Convert.ToInt32(ExceptionType.Error);
                resultData.ExceptionMessage = exception.Message;
                resultData.ExceptionStackTrace = exception.StackTrace;
            }
            finally {
                Dispose();
            }

            return resultData;
        }

        public virtual ResultData<T> Update(T model)
        {
            ResultData<T> resultData = new ResultData<T>();

            try
            {
                var entry = context.Entry(model);

                if (entry.State == EntityState.Detached)
                {
                    context.DbSet.Attach(model);
                }

                context.ChangeObjectState(model, EntityState.Modified);

                resultData.Identity = context.SaveChanges();
            }
            catch (Exception exception) {
                resultData.ExceptionCode = Convert.ToInt32(ExceptionType.Error);
                resultData.ExceptionMessage = exception.Message;
                resultData.ExceptionStackTrace = exception.StackTrace;
            }
            finally {
                Dispose();
            }

            return resultData;
        }

        public virtual ResultData<T> Delete(IdT id)
        {
            ResultData<T> resultData = new ResultData<T>();

            try
            {
                T model = context.DbSet.Find(id);
                var entry = context.Entry(model);

                if (entry.State == EntityState.Detached)
                {
                    context.DbSet.Attach(model);
                }

                //Exclusao fisica
                //context.ChangeObjectState(model, EntityState.Deleted);

                //context.SaveChanges();

                //Exclusao logica
                context.ChangeObjectState(model, EntityState.Modified);

                resultData.Identity = context.SaveChanges();
            }
            catch (Exception exception) {
                resultData.ExceptionCode = Convert.ToInt32(ExceptionType.Error);
                resultData.ExceptionMessage = exception.Message;
                resultData.ExceptionStackTrace = exception.StackTrace;
            }
            finally {
                Dispose();
            }

            return resultData;
        }

        public virtual ResultData<T> GetAll()
        {
            ResultData<T> resultData = new ResultData<T>();

            try
            {
                resultData.Results = context.DbSet.ToList();
            }
            catch (Exception exception) {
                resultData.ExceptionCode = Convert.ToInt32(ExceptionType.Error);
                resultData.ExceptionMessage = exception.Message;
                resultData.ExceptionStackTrace = exception.StackTrace;
            }
            finally {
                Dispose();
            }

            return resultData;
        }

        public virtual ResultData<T> GetById(IdT id)
        {
            ResultData<T> resultData = new ResultData<T>();

            try
            {
                resultData.Result = context.DbSet.Find(id);
            }
            catch (Exception exception) {
                resultData.ExceptionCode = Convert.ToInt32(ExceptionType.Error);
                resultData.ExceptionMessage = exception.Message;
                resultData.ExceptionStackTrace = exception.StackTrace;
            }
            finally {
                Dispose();
            }

            return resultData;
        }

        public virtual ResultData<T> Where(Expression<Func<T, bool>> expression)
        {
            ResultData<T> resultData = new ResultData<T>();

            try
            {
                resultData.Results = context.DbSet.Where(expression).ToList();
            }
            catch (Exception exception) {
                resultData.ExceptionCode = Convert.ToInt32(ExceptionType.Error);
                resultData.ExceptionMessage = exception.Message;
                resultData.ExceptionStackTrace = exception.StackTrace;
            }
            finally {
                Dispose();
            }

            return resultData;
        }

        public virtual ResultData<T> OrderBy(Expression<Func<T, bool>> expression)
        {
            ResultData<T> resultData = new ResultData<T>();

            try
            {
                resultData.Results = context.DbSet.OrderBy(expression).ToList();
            }
            catch (Exception exception) {
                resultData.ExceptionCode = Convert.ToInt32(ExceptionType.Error);
                resultData.ExceptionMessage = exception.Message;
                resultData.ExceptionStackTrace = exception.StackTrace;
            }
            finally {
                Dispose();
            }

            return resultData;
        }

        public void Dispose()
        {
        }
    }
}
