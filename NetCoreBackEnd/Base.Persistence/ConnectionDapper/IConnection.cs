using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Base.Persistence
{
    public interface IConnection:IDisposable
    {
        IDbConnection OpenConnection();
        void CloseConnection();
    }
}