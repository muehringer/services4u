using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using Base.Domain;
using Base.Infrastructure;
using Microsoft.Extensions.Options;
using Dapper;

namespace Base.Persistence
{
    public class SampleRepository : ISampleRepository
    {
        private IConnection connection;
        private IDbConnection IDbConn;

        public SampleRepository(IConnection _connection)
        {
            connection = _connection;
        }

        public ResultData<Sample> GetById(int id)
        {            
            IDbConn = connection.OpenConnection();

            string query = @"SELECT * FROM Sample WHERE SampleId = @sampleId AND Ativo = 1";

            ResultData<Sample> resultData = new ResultData<Sample>();

            try
            {
                resultData.Result = IDbConn.Query<Sample>(query, new { sampleId = id }).FirstOrDefault();
            }
            catch (Exception exception)
            {
                resultData.ExceptionCode = Convert.ToInt32(ExceptionType.Error);
                resultData.ExceptionMessage = exception.Message;
                resultData.ExceptionStackTrace = exception.StackTrace;
            }
            finally
            {
                connection.CloseConnection();
            }

            return resultData;
        }

        public ResultData<Sample> GetAll()
        {
            IDbConn = connection.OpenConnection();

            string query = @"SELECT * FROM Sample WHERE Ativo = 1";

            ResultData<Sample> resultData = new ResultData<Sample>();

            try
            {
                resultData.Results = IDbConn.Query<Sample>(query).ToList();
            }
            catch (Exception exception)
            {
                resultData.ExceptionCode = Convert.ToInt32(ExceptionType.Error);
                resultData.ExceptionMessage = exception.Message;
                resultData.ExceptionStackTrace = exception.StackTrace;
            }
            finally
            {
                connection.CloseConnection();
            }

            return resultData;
        }

        public ResultData<Sample> Insert(Sample entity)
        {
            IDbConn = connection.OpenConnection();

            string query = @"INSERT INTO Sample (Name) VALUES (@name)";

            ResultData<Sample> resultData = new ResultData<Sample>();

            try
            {
                resultData.Identity = (int)IDbConn.ExecuteScalar(query, new { name = entity.Name });
            }
            catch (Exception exception)
            {
                resultData.ExceptionCode = Convert.ToInt32(ExceptionType.Error);
                resultData.ExceptionMessage = exception.Message;
                resultData.ExceptionStackTrace = exception.StackTrace;
            }
            finally
            {
                connection.CloseConnection();
            }

            return resultData;
        }

        public ResultData<Sample> Update(Sample entity)
        {
            IDbConn = connection.OpenConnection();

            string query = @"UPDATE Sample SET Name = @name WHERE SampleId = @sampleId";

            ResultData<Sample> resultData = new ResultData<Sample>();

            try
            {
                IDbConn.Execute(query, new { name = entity.Name, sampleId = entity.SampleId });
            }
            catch (Exception exception)
            {
                resultData.ExceptionCode = Convert.ToInt32(ExceptionType.Error);
                resultData.ExceptionMessage = exception.Message;
                resultData.ExceptionStackTrace = exception.StackTrace;
            }
            finally
            {
                connection.CloseConnection();
            }

            return resultData;
        }

        public ResultData<Sample> Delete(int id)
        {
            IDbConn = connection.OpenConnection();

            string query = @"UPDATE Sample SET Ativo = 2, DataAtualizacao = GetDate() WHERE SampleId = @sampleId";

            ResultData<Sample> resultData = new ResultData<Sample>();

            try
            {
                IDbConn.Execute(query, new { sampleId = id });
            }
            catch (Exception exception)
            {
                resultData.ExceptionCode = Convert.ToInt32(ExceptionType.Error);
                resultData.ExceptionMessage = exception.Message;
                resultData.ExceptionStackTrace = exception.StackTrace;
            }
            finally
            {
                connection.CloseConnection();
            }

            return resultData;
        }
    }
}
