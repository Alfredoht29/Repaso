﻿using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;

namespace Test.Model
{
    public class DataAccess
    {
        static DataAccess classInstance = null;
        static DataAccess Instance
        {
            get
              {
                if (classInstance == null)
                {
                    classInstance = new DataAccess();
                }
                return classInstance;
            }
        }
        public string DbString()
        {
            string connection = ConfigurationManager.ConnectionStrings["SqlServer"].ToString();
            return connection;
        }
        public SqlConnection DbConnection()
        {
            SqlConnection conn = new SqlConnection(DbString());
            return conn;
        }
    }
}
