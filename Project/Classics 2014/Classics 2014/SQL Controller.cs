using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace Classics_2014
{
    class SQL_Controller
    {
        private string server;
        private string database;
        private string user;
        private MySqlConnection connection;
        private string error;
        private Process localDatabaseMain = new Process();
        private string CurrentDirectory = Directory.GetCurrentDirectory();

        public void MySQL_Controller(string Server, string Database, string User)
        {
            this.server = Server;
            this.database = Database;
            this.user = User;
            //SetupConnection();
			//StartDatabase();
        }
    }
}
