﻿using Oracle.DataAccess.Client;

namespace Businesslayer.DAL
{
    public class Databaseconnection
    {
        public OracleConnection Connection { get; set; }
        public static string Connectionstring
        {
            get{return "User Id=system;Password=iPhone4SS;Data Source=" + "127.0.0.1/" + ";"; }
            private set {  }
        }

        public Databaseconnection()
        {
            Connection = new OracleConnection(Connectionstring);
        }
    }
}