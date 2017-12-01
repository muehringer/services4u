using Base.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Persistence.ConnectionDapper
{
    public class ConnectionConfiguration
    {
        string typeDB = ConfigurationManager.AppSettings["TypeDB"].ToString();
        string strConn = ConfigurationManager.ConnectionStrings["BaseConnection"].ToString();

        private IDbConnection SelectConnection()
        {
            if (typeDB.Equals(DataBaseType.SQLServer.ToString()))
            {
                return new SqlConnection(strConn);
            }
            else
            {
                return new SqlConnection(strConn);
            }
        }

        public IDbConnection OpenConnection()
        {
            IDbConnection IConn = SelectConnection();

            IConn.Open();

            return IConn;
        }
    }
}
