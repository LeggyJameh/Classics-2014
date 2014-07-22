using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.ComponentModel;

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

        #region MainControls

        public void MySQL_Controller(string Server, string Database, string User)
        {
            this.server = Server;
            this.database = Database;
            this.user = User;
            //SetupConnection();
            //StartDatabase();
        }

        public bool StartDatabase()
        {
            try
            {
                localDatabaseMain.StartInfo.FileName = CurrentDirectory + "\\Database\\bin\\mysqld.exe";
                localDatabaseMain.StartInfo.CreateNoWindow = true;
                localDatabaseMain.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                localDatabaseMain.Start();
                return true;
            }
            catch (Win32Exception e)
            {
                error = e.NativeErrorCode.ToString();
            }
            return false;
        }

        public bool StopDatabase()
        {
            try
            {
                localDatabaseMain.StartInfo.FileName = CurrentDirectory + "\\Database\\bin\\mysqladmin.exe";
                localDatabaseMain.StartInfo.CreateNoWindow = true;
                localDatabaseMain.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                localDatabaseMain.StartInfo.Arguments = "-u root shutdown";
                localDatabaseMain.Start();
                return true;
            }
            catch (Win32Exception e)
            {
                error = e.NativeErrorCode.ToString();
            }
            return false;
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        error = "Failed to connect to the Database.";
                        break;

                    case 1045:
                        error = "Invalid username/password, please try again";
                        break;

                    case 1042:
                        error = "Unable to create the socket on port 3306. Please check your network configuration";
                        break;

                    default:
                        error = ("Error " + ex.Number + " has occurred. Please report this issue.");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                error = (ex.Message);
            }
            return false;
        }

        public bool SetupConnection()
        {
            string connectionString;
            connectionString = "SERVER=" + server + ";DATABASE=" + database + ";UID=" + user;

            try
            {
                connection = new MySqlConnection(connectionString);
                return true;
            }
            catch
            {
                error = "Could not connect to the database";
            }
            return false;
        }

        #endregion

        #region Queries
        #region Create

        public bool CreateCompetitor(string Name, string Team, string Nationality)
        {
            string query = "INSERT INTO competitors (Name, Team, Nationality) VALUES ('" + Name + "', '" + Team + "', '" + Nationality + "');";
            return ExecuteNonQuery(query);
        }

        #endregion
        #region Remove

        public bool RemoveEvent(int EventID)
        {
            string query = "DROP TABLE `event " + EventID + "`;";
            return ExecuteNonQuery(query);
        }

        public bool RemoveCompetitor(int UID)
        {
            string query = "DELETE FROM competitors WHERE UID=`" + UID + "`;";
            return ExecuteNonQuery(query);
        }

        #endregion
        #region Modify



        #endregion
        #region Get



        private int GetLastInsertKey()
        {
            string query = "SELECT last_insert_id()";
            int ID = 0;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                try
                {
                    MySqlDataReader DataReader = cmd.ExecuteReader();
                    while (DataReader.Read())
                    {
                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            ID = DataReader.GetInt16(i);
                        }
                    }
                    DataReader.Close();
                }
                catch (MySqlException ex)
                {
                    error = ex.Message;
                }
                this.CloseConnection();
            }
            return ID;
        }

        #endregion
        #endregion

        #region Other
        private bool ExecuteNonQuery(string query)
        {
            bool completed = false;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                try
                {
                    cmd.ExecuteNonQuery();
                    completed = true;
                }
                catch (MySqlException ex)
                {
                    error = ex.Message;
                    completed = false;
                }
                this.CloseConnection();
            }
            return completed;
        }
        #endregion
    }
}
