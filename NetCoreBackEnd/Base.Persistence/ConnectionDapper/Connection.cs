using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Base.Infrastructure;

namespace Base.Persistence
{
    public class Connection : IConnection
    {
        private readonly IOptions<KeysConfig> ChaveConfiguracao;

        public IDbConnection IConn { get; private set; }
        
        public Connection(IOptions<KeysConfig> chaveConfiguracao)
        {            
            ChaveConfiguracao = chaveConfiguracao;
        }

        private IDbConnection SelectConnection()
        {
            if (ChaveConfiguracao.Value.TypeDB.Equals(DataBaseType.MySql.ToString()))
            {
                return new MySqlConnection(ChaveConfiguracao.Value.ConnectionDB);
            }
           else
            {
                return new MySqlConnection(ChaveConfiguracao.Value.ConnectionDB);
            }
        }

        public IDbConnection OpenConnection()
        {
            IConn = SelectConnection();

            if (IConn != null && IConn.State != ConnectionState.Open)
            {
               IConn.Open();
            }

            return IConn;
        }

        public void CloseConnection()
        {
            if (IConn != null && IConn.State == ConnectionState.Open)
            {
                IConn.Close();
                IConn.Dispose();
            }
        }        

        public void Dispose()
        {
            CloseConnection();
        }
    }
}
